using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MD_Facturas
{
    public partial class Login : Form
    {
        public static dynamic Su;
        public static string Iduser;
        public static string userLg;
        public static dynamic Pass;
        public static dynamic Ge;
        public static dynamic Enc;
        public static dynamic Ven;
        public static dynamic Nombre;
        public static dynamic Empresa;// = "200";
        public static dynamic Cod_PuntoVenta;// = 300;
        public static decimal iva_empresa =Convert.ToDecimal(Properties.Settings.Default.impuesto)/100;//13M/100; // parametrizar 
        public static dynamic NombrePais;
        public static dynamic NombrePV;
        public static dynamic CodPais;
       
       
        public Login()
        {
            InitializeComponent();
        }

        private void Btt_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btt_Aceptar_Click(object sender, EventArgs e)
        {   
            if(this.Txt_Usuario.Text == "" || this.Txt_Pass.Text == "")
            {
                MessageBox.Show("Complete todos los campos para poder iniciar sesión");
                this.Txt_Usuario.Text = "";
                this.Txt_Pass.Text = "";
            }

            else
            {
                try
                {
                    SqlConnection cnx;
                    cnx = new SqlConnection(Properties.Settings.Default.cnx);
                    cnx.Open();
                    String CadenaComando = "select *from Tbl_Usuarios u inner join Tbl_Empleados e on u.Id_Empleado=e.Id_Empleado inner join Tbl_Pais p on e.Cod_Pais=p.Cod_Pais inner join Tbl_Punto_Venta pv on pv.Cod_empresa=e.Cod_Empresa and pv.Cod_Punto_Venta=e.Cod_Punto_Venta where u.Usuario = '" + Txt_Usuario.Text + "'";
                    SqlCommand Comando = new SqlCommand(CadenaComando, cnx);
                    SqlDataReader Resultado = Comando.ExecuteReader();
                    if (Resultado.Read())
                    {
                         Su = Resultado["Supervisor"];
                         Pass = Resultado["PASSWORD"];
                         Ge = Resultado["Gerente"];
                         Enc = Resultado["Encargado"];
                         Ven = Resultado["Ventas"];
                         Nombre = Resultado["Nombre_Empleado"];
                         Empresa = Resultado["Cod_Empresa"];
                         Cod_PuntoVenta = Resultado["Cod_Punto_venta"];
                         userLg = Convert.ToString(Resultado["Usuario"]);
                        Iduser=Convert.ToString(Resultado["Cod_Usuario"]);
                        NombrePais = Resultado["Nombre_Pais"];
                        NombrePV = Resultado["Nombre_Punto"];
                        CodPais = Resultado["Cod_Pais"];
                        
                        if (Txt_Pass.Text == Pass && (Su == "S" || Ge == "S" || Enc == "S" || Ven == "S"))
                        { 
                            if (Su == "S" || Ge == "S") {
                                MDIParent1 p1 = (MDIParent1)Application.OpenForms["MDIParent1"];
                                MDIParent1 f1 = (MDIParent1)p1;
                                f1.Tipo_Usuario = "G";
                                f1.Nombre_Usuario = Convert.ToString(Nombre);
                                f1.Seccion = "Activa";
                                f1.Lb_Estado.Text = "Activa";
                                f1.Text = "VECA -- Facturación  " + NombrePais + "--" + NombrePV + " --Empleado " + Nombre;
                                f1.Lb_Estado.ForeColor = System.Drawing.Color.Blue;
                                f1.CodUsuarioLg = Iduser;
                                f1.Usuario = userLg;
                                this.Hide();
                            }
                            else if (Enc == "S" || Ven == "S"){
                                MDIParent1 p1 = (MDIParent1)Application.OpenForms["MDIParent1"];
                                MDIParent1 f1 = (MDIParent1)p1;
                                f1.Tipo_Usuario = "V";
                                f1.Nombre_Usuario = Convert.ToString(Nombre);
                                f1.Seccion = "Activa";
                                f1.Lb_Estado.Text = "Activa";
                                f1.Text = "VECA -- Facturación " + NombrePais + "--" + NombrePV + " --Empleado " + Nombre;
                                f1.Lb_Estado.ForeColor = System.Drawing.Color.Blue;
                                 f1.CodUsuarioLg = Iduser;
                                 f1.Usuario = userLg;
                                this.Hide();                      
                            }
                        }
                        else
                            if (Txt_Pass.Text != Pass)
                            {
                                MessageBox.Show("La contraseña no es valida");
                                this.Txt_Pass.Text = "";
                            }
                    }
                    else
                    {
                        MessageBox.Show("La Usuario  " + Txt_Usuario.Text.Trim() + " no fue encontrada");
                    }
                    cnx.Close();
                } catch (SqlException ex)
                {
                    MessageBox.Show("Ha ocurrido un error: " + ex.Message, "Error");
                }
            }         
        }

        private void Txt_Pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Btt_Aceptar.PerformClick();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
