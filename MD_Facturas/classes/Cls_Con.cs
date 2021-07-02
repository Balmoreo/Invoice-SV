using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MD_Facturas.classes
{ // clase conexion
   public  class Cls_Con 
    {
        private SqlConnection _conexion = new SqlConnection(MD_Facturas.Properties.Settings.Default.cnx);

        public SqlConnection conexion { get { return _conexion; } }


        public void Conectar()
        {
            try
            {
                conexion.Open();
            }
            catch (SqlException ex)
            {
                Cls_Helper.MostrarMensaje("No se ha podido establecer conexión.", "Error", 1);
            }
            
        }

        public void Desconectar()
        {
            conexion.Close();
        }

        /// <summary>
        ///  retorna un data table-- recibe string query, conexion
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cn"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string query)
        {
            
                DataTable dt;
                SqlDataAdapter da;
                dt = new DataTable();
                try
                {
                    da = new SqlDataAdapter(query, conexion);
                    da.Fill(dt);

                }
                catch (Exception error)
                {
                    throw error;
                }
                return dt;
           
        }

        /// <summary>
        /// Metodo para generar un DataTable a partir de un query con Sql Parameters. Los parametros se agregan al final.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cn"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string query, SqlConnection cn, params SqlParameter[] param)
        {
            SqlCommand cm = new SqlCommand();
           DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            cm.Connection = cn;
            cm.CommandText = query;

            foreach (SqlParameter p in param)
            {
                cm.Parameters.Add(p);
            }
            try
            {
                cn.Open();
                da = new SqlDataAdapter(cm);
                da.Fill(dt);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return dt;
        }

        /// <summary>
        /// Obtiene un DataTable a partir de un query a un DataSet existente utilizando el metodo "Select". Recibe:
        /// <para>Nombre dataset</para>
        /// <para>Nombre Tabla del dataset</para>
        /// <para>string de consulta despues de la clausula Where</para>
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable(DataSet dataset, string tabla, string consulta)
        {
         
                DataTable dt = new DataTable();
                try
                {
                DataRow[] DataTableQuery;
                DataTableQuery = dataset.Tables[tabla].Select(consulta);
                foreach (DataColumn dc in dataset.Tables[tabla].Columns) { dt.Columns.Add(dc.ColumnName); }
                foreach (DataRow s in DataTableQuery) { dt.Rows.Add(s.ItemArray); }
              }
            catch { }
                return dt; // retorna un data taeble
            
        }
    }
}
