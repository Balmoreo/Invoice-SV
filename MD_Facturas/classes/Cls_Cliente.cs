using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MD_Facturas.classes
{
   public class Cls_Cliente : Cls_Con
    {
        //variables
        private decimal _IdCliente = 0;
        private decimal _TipoCliente =0;
        private string _Nombre = null;
        private string _Telefono = null;
        private string _Direccion = null;
        private string _Nit = null;
        private string _Pais = null;
        private string _Email = null;
        private DateTime _FechaCreado = DateTime.Now.Date;
        private string _CreadoPor = null; // usuario que creó el cliente.
        private string _Nrc = null;
        private decimal _TipoCont = 0;
        private decimal _CodEmpresa = 0; // codigo de la empresa referenciando a Creadopor
        private string _Giro = "";
               

        // propiedades
        public decimal IdCliente { get { return _IdCliente; } set { _IdCliente = value; } }
        public decimal TipoCliente { get { return _TipoCliente; } set { _TipoCliente = value; } }
        public string Nombre { get { return _Nombre; } set { _Nombre = value; } }
        public string Telefono { get { return _Telefono; } set { _Telefono = value; } }
        public string Direccion { get { return _Direccion; } set { _Direccion = value; } }
        public string Nit { get { return _Nit; } set { _Nit = value; } }
        public string Pais { get { return _Pais; } set { _Pais = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public DateTime FechaCreado { get { return _FechaCreado; } set { _FechaCreado = value; } }
        public string CreadoPor { get { return _CreadoPor; } set { _CreadoPor = value; } }
        public string Nrc { get { return _Nrc; } set { _Nrc = value; } }
        public decimal TipoCont { get { return _TipoCont; } set { _TipoCont = value; } }
        public decimal CodEmpresa { get { return _CodEmpresa; } set { _CodEmpresa = value; } }
        public string Giro { get { return _Giro; } set { _Giro = value; } }



        public virtual decimal CrearCliente()
        {
            return IdCliente;
        }

        public virtual void BuscarCliente()
        {
            
        }

        public virtual void ModificarCliente()
        {
            
        }


       
    } // FIN CLASE CLIENTE


    public class Empresa : Cls_Cliente
    {
        private string _Fax = "";
        //private string _TipoCont = ""; // tipo contribuyente
       
        private string _RazonSocial = "";

        public string Fax { get { return _Fax; } set { _Fax = value; } }
        public string RazonSocial { get { return _RazonSocial; } set { _RazonSocial = value; } }


        public override decimal CrearCliente() // crear cliente tipo persona
        {
            SqlCommand c = new SqlCommand();
            c.Connection = conexion;
            c.CommandType = CommandType.StoredProcedure;
            c.CommandText = "P_CrearModificarCliente";
            c.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
            c.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Direccion;
            c.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono;
            c.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Email;
            c.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
            c.Parameters.Add("@nrc", SqlDbType.VarChar).Value = Nrc;
            c.Parameters.Add("@Giro", SqlDbType.VarChar).Value = Giro;
            c.Parameters.Add("@TipoCliente", SqlDbType.Decimal).Value = TipoCliente; //  tipo de cliente.
            c.Parameters.Add("@CodPais", SqlDbType.VarChar).Value = Pais;
            c.Parameters.Add("@TipoCont", SqlDbType.Decimal).Value = TipoCont;
            c.Parameters.Add("@Fecha", SqlDbType.Date).Value = FechaCreado;
            c.Parameters.Add("@CreadoPor", SqlDbType.VarChar).Value = CreadoPor;
            c.Parameters.Add("@CodEmpresa", SqlDbType.Decimal).Value = CodEmpresa;
            c.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = RazonSocial;
            

            SqlParameter id = new SqlParameter("@idCliente", SqlDbType.Decimal);
            id.Direction = ParameterDirection.Output;
            c.Parameters.Add(id);
           
            try
            {
                Conectar();
                c.ExecuteNonQuery();
                IdCliente = Convert.ToDecimal(id.Value);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Desconectar();
            }

            return IdCliente;
        } // fIN CREAR CLIENTE

        public override void ModificarCliente() // modifica cliente
        {
            SqlCommand c = new SqlCommand();
            c.Connection = conexion;
            c.CommandType = CommandType.StoredProcedure;
            c.CommandText = "P_CrearModificarCliente";
            c.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
            c.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Direccion;
            c.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono;
            c.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Email;
            c.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
            c.Parameters.Add("@nrc", SqlDbType.VarChar).Value = Nrc;
            c.Parameters.Add("@Giro", SqlDbType.VarChar).Value = Giro;
            c.Parameters.Add("@TipoCliente", SqlDbType.Decimal).Value = TipoCliente; //  tipo de cliente.
            c.Parameters.Add("@CodPais", SqlDbType.VarChar).Value = Pais;
            c.Parameters.Add("@TipoCont", SqlDbType.Decimal).Value = TipoCont;
            c.Parameters.Add("@Fecha", SqlDbType.Date).Value = FechaCreado;
            c.Parameters.Add("@CreadoPor", SqlDbType.VarChar).Value = CreadoPor;
            c.Parameters.Add("@modifica", SqlDbType.Bit).Value = true;
            c.Parameters.Add("@CodEmpresa", SqlDbType.Decimal).Value = CodEmpresa;
            c.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = RazonSocial;


            SqlParameter id = new SqlParameter("@Idin", SqlDbType.Decimal);
            id.Direction = ParameterDirection.Input;
            c.Parameters.Add(id);
            id.Value = IdCliente;
            try
            {
                Conectar();
                c.ExecuteNonQuery();
               // IdCliente = Convert.ToDecimal(id.Value);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Desconectar();
            }

       }//  FIN modifica cliente

    } // fin clase empresa


    public class Persona : Cls_Cliente
    {
        private string _Celular = "";
        private string _Pasaporte = "";
        private string _Dui = "";
        private string _Referencia = ""; // en caso que persona pertenezca a empresa

        public string Celular { get { return _Celular; } set { _Celular = value; } }
        public string Pasaporte { get { return _Pasaporte; } set { _Pasaporte = value; } }
        public string Dui { get { return _Dui; } set { _Dui = value; } }
        public string Referencia { get { return _Referencia; } set { _Referencia = value; } }

        public override decimal CrearCliente() // crear cliente tipo persona
        {
            SqlCommand c = new SqlCommand();
            c.Connection = conexion;
            c.CommandType = CommandType.StoredProcedure;
            c.CommandText = "P_CrearModificarCliente";
            c.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
            c.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Direccion;
            c.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono;
            c.Parameters.Add("@Movil", SqlDbType.VarChar).Value = Celular;
            c.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Email;
            c.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
            c.Parameters.Add("@nrc", SqlDbType.VarChar).Value = Nrc;
            c.Parameters.Add("@Giro", SqlDbType.VarChar).Value = Giro;
            c.Parameters.Add("@TipoCliente", SqlDbType.Decimal).Value = TipoCliente; //  tipo de cliente.
            c.Parameters.Add("@CodPais", SqlDbType.VarChar).Value = Pais;
            c.Parameters.Add("@TipoCont", SqlDbType.Decimal).Value = TipoCont;
            c.Parameters.Add("@Fecha", SqlDbType.Date).Value = FechaCreado;
            c.Parameters.Add("@CreadoPor", SqlDbType.VarChar).Value = CreadoPor;
            c.Parameters.Add("@DUI", SqlDbType.VarChar).Value = Dui;
            c.Parameters.Add("@CodEmpresa", SqlDbType.Decimal).Value = CodEmpresa;
            c.Parameters.Add("@pasaporte", SqlDbType.VarChar).Value = Pasaporte;

            SqlParameter id = new SqlParameter("@idCliente",SqlDbType.Decimal);
            id.Direction = ParameterDirection.Output;
            c.Parameters.Add(id);
            try
            {
                Conectar();
                c.ExecuteNonQuery();
                IdCliente = Convert.ToDecimal(id.Value);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Desconectar();
            }

            return IdCliente;
        } // fin crear cliente

        public override void ModificarCliente()
        {
            SqlCommand c = new SqlCommand();
            c.Connection = conexion;
            c.CommandType = CommandType.StoredProcedure;
            c.CommandText = "P_CrearModificarCliente";
            c.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
            c.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Direccion;
            c.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono;
            c.Parameters.Add("@Movil", SqlDbType.VarChar).Value = Celular;
            c.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Email;
            c.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
            c.Parameters.Add("@nrc", SqlDbType.VarChar).Value = Nrc;
            c.Parameters.Add("@TipoCliente", SqlDbType.Decimal).Value = TipoCliente; //  tipo de cliente.
            c.Parameters.Add("@CodPais", SqlDbType.VarChar).Value = Pais;
            c.Parameters.Add("@TipoCont", SqlDbType.Decimal).Value = TipoCont;
            c.Parameters.Add("@Fecha", SqlDbType.Date).Value = FechaCreado;
            c.Parameters.Add("@CreadoPor", SqlDbType.VarChar).Value = CreadoPor;
            c.Parameters.Add("@DUI", SqlDbType.VarChar).Value = Dui;
            c.Parameters.Add("@modifica", SqlDbType.Bit).Value = true;
            c.Parameters.Add("@CodEmpresa", SqlDbType.Decimal).Value = CodEmpresa;
            c.Parameters.Add("@pasaporte", SqlDbType.VarChar).Value = Pasaporte;
            c.Parameters.Add("@Giro", SqlDbType.VarChar).Value = Giro;

            SqlParameter id = new SqlParameter("@Idin",SqlDbType.Decimal);
            id.Direction = ParameterDirection.Input;
            c.Parameters.Add(id);
            id.Value = IdCliente;
            try
            {
                Conectar();
                c.ExecuteNonQuery();
              //  IdCliente = Convert.ToDecimal(id.Value);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Desconectar();
            }

        }// Modifica cliente
        

    }
}
