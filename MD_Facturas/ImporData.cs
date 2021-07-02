using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using MD_Facturas.classes;
using CrystalDecisions.CrystalReports;



namespace MD_Facturas
{
    public partial class ImporData : Form
    {
        public string Fichero { get; set; }
        public string xSheet { get; set; }

        public ImporData()
        {
            InitializeComponent();
        }

        private void ImporData_Load(object sender, EventArgs e)
        {

        }
        public void ExportarDataGridViewExcel(DataGridView grd, string ExcelFile, string SelectedTable)
        {
            //string xSheet = "";
            DataSet ds = new DataSet();
            OleDbDataAdapter da;
            DataTable dt;
            OleDbConnection conn;

            xSheet = SelectedTable;
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "data source=" + ExcelFile + "; " + "Extended Properties='Excel 12.0 Xml;HDR=Yes'");

            try
            {
                da = new OleDbDataAdapter("SELECT * FROM  [" + xSheet + "$]", conn);

                conn.Open();
                da.Fill(ds, "MyData");
                dt = ds.Tables["MyData"];
                grd.DataSource = ds;
                grd.DataMember = "MyData";
           //     MessageBox.Show("Se ha cargado la importacion correctamente Importado con exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Inserte un nombre valido de la Hoja que desea importar");
            }
            finally
            {
                conn.Close();
            }
            //   }



        }

        private void BttCargar_Click(object sender, EventArgs e)
        {
            try
            {
                

                if (Cls_Helper.MostrarMensaje("¿Desea Cargar el archivo de Excel?", "Confirmar", 3) == DialogResult.Yes)
                {
                    string conexion = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + Fichero + ";Extended Properties=\"Excel 8.0; HDR=Yes\"";

                    OleDbConnection origen = default(OleDbConnection);
                    origen = new OleDbConnection(conexion);

                    OleDbCommand seleccion = default(OleDbCommand);
                    seleccion = new OleDbCommand("Select * From [" + xSheet + "$]", origen);

                    OleDbDataAdapter adaptador = new OleDbDataAdapter();
                    adaptador.SelectCommand = seleccion;

                    DataSet ds = new DataSet();

                    adaptador.Fill(ds);

                    //  dataGridView1.DataSource = ds.Tables[0];

                    origen.Close();


                    SqlConnection conexion_destino = new SqlConnection();
                    conexion_destino.ConnectionString = Properties.Settings.Default.cnx;

                    conexion_destino.Open();

                    SqlBulkCopy importar = default(SqlBulkCopy);
                    importar = new SqlBulkCopy(conexion_destino);
                    importar.DestinationTableName = "Tbl_FacturaTemp";
                    importar.WriteToServer(ds.Tables[0]);
                    conexion_destino.Close();
                    Cls_Helper.MostrarMensaje("Carga realizada con éxito", "Información");
                    BttFacturacion.Enabled = true;
                    int i = 0;
                   for (i = 0; i < this.DataGExcel.Rows.Count; i++)
                    {
                        this.DataGExcel.Rows.RemoveAt(i);
                    }
                   DataGExcel.DataSource = null;
                }
            }
            catch { }

        }

        private void BttFacturacion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de Generar Facturacion", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GrabarFACT();
            }
           // BttFacturacion.Enabled = false;
        }


        public void GrabarFACT()
        {
            SqlConnection cn;
            cn = new SqlConnection(Properties.Settings.Default.cnx);
            SqlCommand cmd = new SqlCommand("P_Cargar_Facturas", cn);//cb_addEncCoti
            cmd.CommandType = CommandType.StoredProcedure;
            //SqlParameter partout = new SqlParameter("@p",SqlDbType.Int);
            cn.Open();
            try
            {
               if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Facturacion Generada");
                    BttFacturacion.Enabled = false;

                }
            }
            catch
            {
            }
            cn.Close();
        }
    }
}
