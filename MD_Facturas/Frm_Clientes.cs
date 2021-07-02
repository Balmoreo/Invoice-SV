using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MD_Facturas.classes;

namespace MD_Facturas
{
    public partial class Frm_Clientes : Form
    {
        private Cls_Cliente cliente;
      //  public string usuario;
        public string usuario = "admin";
        public decimal empresa = 200;
        public Cls_Con con = new Cls_Con();
        int y = 0;
        public Frm_Clientes()
        {
            InitializeComponent();
            Cls_Helper.LlenaComboBox(Cbx_TipoCliente, con.GetDataTable("SELECT * FROM Tbl_Tipo_Cliente"), "Tipo_Cliente", "Id_Tipo_Cliente");
            Cls_Helper.LlenaComboBox(Cbx_Pais, con.GetDataTable("SELECT * FROM Tbl_Pais"), "Nombre_Pais", "Cod_Pais");
            Cls_Helper.LlenaComboBox(Cbx_TipoContr, con.GetDataTable("SELECT * FROM Tbl_Contribuyente where Pais ="+Login.CodPais), "Tipo_Contribuyente", "Id_Tipo_Contribuyecte");
            Txt_Usuario.Enabled = false; Txt_Usuario.Text = usuario;
       }


        private void Frm_Clientes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mODULO_FACT_VECADataSet.Tbl_Clientes' table. You can move, or remove it, as needed.
            this.tbl_ClientesTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Clientes);
           
        }

        private void Btt_Guardar_Click(object sender, EventArgs e)
        {
             ValidarDatos();
            if(y!=1) // valida datos vacíos
            {
                // instancia la clase cliente con su tipo.
                if (Convert.ToInt32(Cbx_TipoCliente.SelectedValue) == 2)
                {
                    cliente = new Persona
                     {
                         Nombre = Txt_NombreCliente.Text,
                         Direccion = Txt_Direccion.Text,
                         Telefono = Txt_Telefono.Text,
                         Celular = Txt_Movil.Text,
                         Email = Txt_Correo.Text,
                         Nit = textBox3.Text,
                         Nrc = Txt_Nrc.Text,
                         TipoCliente = Convert.ToDecimal(Cbx_TipoCliente.SelectedValue),
                         Pais = Convert.ToString(Cbx_Pais.SelectedValue),
                         TipoCont = Convert.ToDecimal(Cbx_TipoContr.SelectedValue),
                         FechaCreado = DateTime.Now.Date,
                         CreadoPor = usuario,
                         Dui = Txt_Dui.Text,
                         CodEmpresa = Login.Empresa,
                         Pasaporte = Txt_Pasaporte.Text,
                         Giro = Txt_Giro.Text
                     };
                }
                else
                {
                    cliente = new Empresa
                    {
                        Nombre = Txt_NombreCliente.Text,
                        Direccion = Txt_Direccion.Text,
                        Telefono = Txt_Telefono.Text,
                        Email = Txt_Correo.Text,
                        Nit = textBox3.Text,
                        Nrc = Txt_Nrc.Text,
                        TipoCliente = Convert.ToDecimal(Cbx_TipoCliente.SelectedValue),
                        Pais = Convert.ToString(Cbx_Pais.SelectedValue),
                        TipoCont = Convert.ToDecimal(Cbx_TipoContr.SelectedValue),
                        FechaCreado = DateTime.Now.Date,
                        CreadoPor = usuario,
                        CodEmpresa = Login.Empresa, // se debe traer de variable global
                        Giro = Txt_Giro.Text,
                        Fax = "", // pendiente agregar campo para Fax
                        RazonSocial = Txt_NombreCliente.Text // pendiente de agregar campo para Razon Social.
                    };
                }
                try
                {
                    Txt_IdCliente.Text = Convert.ToString(cliente.CrearCliente());
                    Cls_Helper.LimpiarCampos(groupBox1); Cls_Helper.LimpiarCampos(groupBox2); Cls_Helper.LimpiarCampos(groupBox3);
                    Cls_Helper.MostrarMensaje("Cliente agregado exitosamente", "Información", 0);
                }
                catch (Exception ex)
                {
                    Cls_Helper.MostrarMensaje("No se pudo agregar al cliente. "+ex.Message+".", "Error", 1);
                }
            
            }
            else { y = 0; }
        }  
        
        // BOTON ACTUALIZAR REGISTRO
        private void Btt_Actualizar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Cbx_TipoCliente.SelectedValue) == 2)
            {
                cliente = new Persona
                {
                    Nombre = Txt_NombreCliente.Text,
                    Direccion = Txt_Direccion.Text,
                    Telefono = Txt_Telefono.Text,
                    Celular = Txt_Movil.Text,
                    Email = Txt_Correo.Text,
                    Nit = textBox3.Text,
                    Nrc = Txt_Nrc.Text,
                    Giro = Txt_Giro.Text,
                    TipoCliente = Convert.ToDecimal(Cbx_TipoCliente.SelectedValue),
                    Pais = Convert.ToString(Cbx_Pais.SelectedValue),
                    TipoCont = Convert.ToDecimal(Cbx_TipoContr.SelectedValue),
                    FechaCreado = DateTime.Now.Date,
                    CreadoPor = usuario,
                    Dui = Txt_Dui.Text,
                    CodEmpresa = 200,
                    Pasaporte = Txt_Pasaporte.Text,
                      IdCliente =  Convert.ToDecimal(Txt_IdCliente.Text)
                };
            }
            else
            {
                cliente = new Empresa
                {
                    Nombre = Txt_NombreCliente.Text,
                    Direccion = Txt_Direccion.Text,
                    Telefono = Txt_Telefono.Text,
                    Email = Txt_Correo.Text,
                    Nit = textBox3.Text,
                    Nrc = Txt_Nrc.Text,
                    TipoCliente = Convert.ToDecimal(Cbx_TipoCliente.SelectedValue),
                    Pais = Convert.ToString(Cbx_Pais.SelectedValue),
                    TipoCont = Convert.ToDecimal(Cbx_TipoContr.SelectedValue),
                    FechaCreado = DateTime.Now.Date,
                    CreadoPor = usuario,
                    CodEmpresa = 200, // se debe traer de variable global
                    Giro = Txt_Giro.Text,
                    Fax = "", // pendiente agregar campo para Fax
                    RazonSocial = Txt_NombreCliente.Text, // pendiente de agregar campo para Razon Social.
                    IdCliente =  Convert.ToDecimal(Txt_IdCliente.Text)
                };
            }
            try
            {
               cliente.ModificarCliente();
                //Cls_Helper.LimpiarCampos(groupBox1); Cls_Helper.LimpiarCampos(groupBox2); Cls_Helper.LimpiarCampos(groupBox3);
                Cls_Helper.MostrarMensaje("Cliente modificado exitosamente", "Información", 0);
            }
            catch (Exception ex)
            {
                Cls_Helper.MostrarMensaje("No se pudo modificar al cliente. " + ex.Message + ".", "Error", 1);
            }

        } 

        // TEMPORAL PARA PRUEBA
        private void Btt_Buscar_Click(object sender, EventArgs e)
        {
            VerClientes v = new VerClientes();
            v.MostrarClientes();
            v.MdiParent = this.MdiParent;
            v.Show();
        }

        // METODO PARA VALIDAR DATOS DE ENTRADA
        public void ValidarDatos()
        {
            if (this.Txt_NombreCliente.Text == "")
            {
                y = 1;
                MessageBox.Show("Registro Vacio Nombre Cliente ");
            }
            else if (this.Txt_Direccion.Text == "")
            {
                y = 1;
                MessageBox.Show("Registro Vacio Direccion ");
            }
            else if (this.Txt_Telefono.Text == "")
            {
                y = 1;
                MessageBox.Show("Registro Vacio Telefono ");
            }

        }

        // valida seleccion y bloquea textboxes
        private void Cbx_TipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Cbx_TipoCliente.SelectedValue) == 1) // empresa
            {
               // Txt_Nrc.Enabled = true;
                Txt_Dui.Enabled = false;
                Txt_Pasaporte.Enabled = false;
                Txt_Movil.Enabled = false;
            }
            else // persona  // se dejó por si hay que poner restricción luego.
            {
              //  Txt_Nrc.Enabled = true;
                Txt_Dui.Enabled = true;
                Txt_Pasaporte.Enabled = true;
                Txt_Movil.Enabled = true;
                Txt_Giro.Enabled = true;
            }

        }// fin evento selected index changed.

        // evento text changed del textbox nombre cliente.
        private void Txt_NombreCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Txt_NombreCliente.TextLength > 6)
                {

                    SqlParameter[] p =
                {
                   new SqlParameter("@EMPRESA",SqlDbType.Decimal){ Value = Login.Empresa }
                };
                    try
                    {
                        Cls_Helper.AutoCompletar(Txt_NombreCliente,
                          con.GetDataTable("SELECT * FROM TBL_CLIENTES WHERE Cod_empresa = @EMPRESA", con.conexion, p), "Nombre", "Id_cliente");
                    }
                    catch { }
                }
                
            }
            catch { }

        }

        private void Txt_NombreCliente_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        Txt_IdCliente.Text = (Txt_NombreCliente.Text).Substring(Txt_NombreCliente.Text.LastIndexOf('|') + 1).Trim();
                        Txt_NombreCliente.Text = Txt_NombreCliente.Text.Remove(Txt_NombreCliente.Text.LastIndexOf('|')).Trim();
                        tbl_ClientesTableAdapter.FillBy_Id_Nombre(mODULO_FACT_VECADataSet.Tbl_Clientes, Convert.ToDecimal(Txt_IdCliente.Text),
                            Txt_NombreCliente.Text);
                    }
                    catch
                    {
                    }

                    if (mODULO_FACT_VECADataSet.Tbl_Clientes.Rows.Count == 1)
                    {
                        //llena el formulario con resultado 
                        foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_Clientes.Rows)
                        {
                            Txt_Direccion.Text = Convert.ToString(row["Direccion"]);
                            Txt_Telefono.Text = Convert.ToString(row["Telefono"]);
                            Txt_Movil.Text = Convert.ToString(row["Movil"]);
                            Txt_Correo.Text = Convert.ToString(row["Correo"]);
                            Txt_Dui.Text = Convert.ToString(row["No_Documento"]);
                            textBox3.Text = Convert.ToString(row["NIT"]); // NIT
                            textBox3.Enabled = false; // inhabilita control para solo lectura 
                            chk_ModNit.Visible = true; chk_ModNrc.Checked = false;
                            Txt_Nrc.Text = Convert.ToString(row["Nrc"]); // nRC
                            Txt_Nrc.Enabled = false;
                            chk_ModNrc.Visible = true; chk_ModNrc.Checked = false;
                            Txt_Giro.Text = Convert.ToString(row["Giro"]);
                            Cbx_Pais.SelectedValue = Convert.ToInt32(row["Cod_Pais"]);
                            Cbx_TipoCliente.SelectedValue = Convert.ToInt32(row["Id_Tipo_Cliente"]);
                            Cbx_TipoContr.SelectedValue = Convert.ToString(row["Id_Tipo_Contribuyecte"]);
                            Txt_Pasaporte.Text = Convert.ToString(row["Pasaporte"]);
                            dateTimePicker1.Value = Convert.ToDateTime(row["Fecha"]).Date;
                        }
                    }
                }
            }
            catch { }
         } // Key Down event

        // BOTON CANCELAR
        private void Btt_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chk_ModNit_CheckedChanged(object sender, EventArgs e)
        {
            if (Login.Su == "S")
            {
                textBox3.Enabled = (chk_ModNit.Checked) ? true : false;
            }
            else
            {

            }

        }

        private void chk_ModNrc_CheckedChanged(object sender, EventArgs e)
        {
            if (Login.Su == "S")
            {
                Txt_Nrc.Enabled = (chk_ModNrc.Checked) ? true : false;
            }
            else
            {

            }
        }





        public void llenarInforCliente()
        {
            try
            {
                Txt_IdCliente.Text = (Txt_NombreCliente.Text).Substring(Txt_NombreCliente.Text.LastIndexOf('|') + 1).Trim();
                Txt_NombreCliente.Text = Txt_NombreCliente.Text.Remove(Txt_NombreCliente.Text.LastIndexOf('|')).Trim();
                tbl_ClientesTableAdapter.FillBy_Id_Nombre(mODULO_FACT_VECADataSet.Tbl_Clientes, Convert.ToDecimal(Txt_IdCliente.Text),
                    Txt_NombreCliente.Text);
            }
            catch
            {
            }

            if (mODULO_FACT_VECADataSet.Tbl_Clientes.Rows.Count == 1)
            {
                //llena el formulario con resultado 
                foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_Clientes.Rows)
                {
                    Txt_Direccion.Text = Convert.ToString(row["Direccion"]);
                    Txt_Telefono.Text = Convert.ToString(row["Telefono"]);
                    Txt_Movil.Text = Convert.ToString(row["Movil"]);
                    Txt_Correo.Text = Convert.ToString(row["Correo"]);
                    Txt_Dui.Text = Convert.ToString(row["No_Documento"]);
                    textBox3.Text = Convert.ToString(row["NIT"]); // NIT
                    textBox3.Enabled = false; // inhabilita control para solo lectura 
                    chk_ModNit.Visible = true; chk_ModNrc.Checked = false;
                    Txt_Nrc.Text = Convert.ToString(row["Nrc"]); // nRC
                    Txt_Nrc.Enabled = false;
                    chk_ModNrc.Visible = true; chk_ModNrc.Checked = false;
                    Txt_Giro.Text = Convert.ToString(row["Giro"]);
                    Cbx_Pais.SelectedValue = Convert.ToInt32(row["Cod_Pais"]);
                    Cbx_TipoCliente.SelectedValue = Convert.ToInt32(row["Id_Tipo_Cliente"]);
                    Cbx_TipoContr.SelectedValue = Convert.ToString(row["Id_Tipo_Contribuyecte"]);
                    Txt_Pasaporte.Text = Convert.ToString(row["Pasaporte"]);
                    dateTimePicker1.Value = Convert.ToDateTime(row["Fecha"]).Date;
                }
            }

        }
                     

    }
}
