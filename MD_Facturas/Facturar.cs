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
using CrystalDecisions.CrystalReports;

namespace MD_Facturas
{   
    public partial class Facturar : Form
    {
        public Cls_Con con1 = new Cls_Con();
        public string usuario = "admin";
        public Facturar()
        {
            InitializeComponent();
            
            Txt_Usuario.Text = usuario;           
        }

        private void Facturar_Load(object sender, EventArgs e)
        {   
            // TODO: This line of code loads data into the 'mODULO_FACT_VECADataSet.Tbl_Tipo_Doc' table. You can move, or remove it, as needed.
            this.tbl_Tipo_DocTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Tipo_Doc);
            // TODO: This line of code loads data into the 'mODULO_FACT_VECADataSet.Tbl_Servicios' table. You can move, or remove it, as needed.
            this.tbl_ServiciosTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Servicios);
            // TODO: esta línea de código carga datos en la tabla 'mODULO_FACT_VECADataSet.Tbl_Det_Fact' Puede moverla o quitarla según sea necesario.
          //  this.tbl_Det_FactTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Det_Fact);


        }

        private void Txt_NombreCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Txt_IdCliente.Text = (Txt_NombreCliente.Text).Substring(Txt_NombreCliente.Text.LastIndexOf('|') + 1).Trim();
                    Txt_NombreCliente.Text = Txt_NombreCliente.Text.Remove(Txt_NombreCliente.Text.LastIndexOf('|')).Trim();
                    tbl_ClientesTableAdapterFactura.FillBy_Id_Nombre(mODULO_FACT_VECADataSet.Tbl_Clientes, Convert.ToDecimal(Txt_IdCliente.Text),
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
                       // Txt_Dui.Text = Convert.ToString(row["No_Documento"]);
                        textBox3.Text = Convert.ToString(row["NIT"]); // NIT
                        textBox3.Enabled = false; // inhabilita control para solo lectura 
                        Txt_Nrc.Text = Convert.ToString(row["Nrc"]); // nRC
                        Txt_Nrc.Enabled = false;
                        Txt_Giro.Text = Convert.ToString(row["Giro"]);
                        Cbx_TipoDoc.SelectedValue = Convert.ToInt32(row["Id_Tipo_Cliente"]);
                        dateTimePicker1.Value = Convert.ToDateTime(row["Fecha"]).Date;
                    }
                }
            }
        } // Fin evento Key DOwn
        // evento text changed
        private void Txt_NombreCliente_TextChanged(object sender, EventArgs e)
        {

            if (Txt_NombreCliente.TextLength > 4)
            {

                SqlParameter[] p = 
            {
                new SqlParameter("@NOMBRE",SqlDbType.VarChar){Value =  Cls_Helper.BusquedaPro(Txt_NombreCliente) },
                new SqlParameter("@EMPRESA",SqlDbType.Decimal){ Value = Login.Empresa }
            };
                try
                {
                    Cls_Helper.AutoCompletar(Txt_NombreCliente,
                         con1.GetDataTable("SELECT * FROM TBL_CLIENTES WHERE NOMBRE LIKE @NOMBRE AND Cod_empresa = @EMPRESA", con1.conexion, p), "Nombre", "Id_cliente");
                }
                catch
                {
                    // maneja error
                }
            }
        }// Fin Evento. text change

       // BOTON CANCELAR
        private void Btt_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Boton fin celledit
        private void dgvDetFact_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        { 
            decimal cantidad,precio, Total;
            decimal Iva=0;
            decimal Subtotal = 0;
            decimal ventasujeta = 0;
            bool result;
             dgvDetFact.Rows[e.RowIndex].Cells["No_Linea"].Value = e.RowIndex+1;
            if (decimal.TryParse(Convert.ToString(dgvDetFact.Rows[e.RowIndex].Cells["cantidad"].Value), out cantidad) 
                && decimal.TryParse(Convert.ToString(dgvDetFact.Rows[e.RowIndex].Cells["Precio"].Value),out precio))
            {  
                Total = cantidad * precio;
                dgvDetFact.Rows[e.RowIndex].Cells["Precio_Total"].Value = Total;
                Txt_Subtotal.Text = Convert.ToString(Total);

                //sumatoria 
                foreach (DataGridViewRow row in dgvDetFact.Rows)
                {
                    if (Convert.ToDecimal(dgvDetFact.Rows[row.Index].Cells["Precio_Total"].Value) > 0)
                    {
                        if (bool.TryParse(Convert.ToString(dgvDetFact.Rows[row.Index].Cells["sujeto"].Value), out result) == false)
                        {
                            Subtotal += Convert.ToDecimal(dgvDetFact.Rows[row.Index].Cells["Precio_Total"].Value);
                            Iva += Convert.ToDecimal(dgvDetFact.Rows[row.Index].Cells["Precio_Total"].Value) * Login.iva_empresa;
                        }
                        else
                        {
                            ventasujeta += Convert.ToDecimal(dgvDetFact.Rows[row.Index].Cells["Precio_Total"].Value);
                        }
                    } // fin if

                }// fin foreach
            } // fin if externo 

                Txt_VentaSujeta.Text = Convert.ToString(ventasujeta);
                Txt_Subtotal.Text = Convert.ToString(Subtotal);
                Txt_Iva.Text = Convert.ToString(Iva);
                Txt_RetPer.Text = "0.00"; // TODO VALIDAR CAMPO
                Sumatoria();
         }// Fin CellEndEdit event.

        private void Sumatoria()
        {  
            decimal iva,subtotal,retper,sujeta;
            decimal.TryParse(Txt_Iva.Text,out iva);
            decimal.TryParse(Txt_Subtotal.Text,out subtotal);
            decimal.TryParse(Txt_RetPer.Text,out retper);
            decimal.TryParse(Txt_VentaSujeta.Text,out sujeta);

            Txt_Total.Text = Convert.ToString(subtotal + sujeta + retper + iva);
        }

        private void Btt_Guardar_Click(object sender, EventArgs e)
        {
            bool chk = false;
            int NoLinea;
            decimal VentaExenta = 0;
           // Cls_Helper.MostrarMensaje(" " + dgvDetFact.RowCount.ToString(),"");
            decimal correlativo = 0;
            try
            {
                if (Chk_Exenta.Checked == true)
                {
                    VentaExenta = Convert.ToDecimal(Txt_Subtotal.Text);
                }
                else
                {
                    VentaExenta = Convert.ToDecimal(0.00);
                }
               correlativo = tbl_FacturaTableAdapter.INSERTAR_ENFACT(Convert.ToDecimal(Txt_Factura.Text),
                    Convert.ToString(Cbx_TipoDoc.SelectedValue), Txt_Serie.Text, Convert.ToDecimal(Txt_IdCliente.Text), Login.Cod_PuntoVenta,
                    Convert.ToString(dateTimePicker1.Value), Txt_Boleto.Text, Convert.ToDecimal(Txt_Subtotal.Text),
                    Convert.ToDecimal(Txt_Iva.Text), Convert.ToDecimal(Login.Empresa),"P","P",DateTime.Now,Convert.ToDecimal(Txt_RetPer.Text),
                    Convert.ToDecimal(Txt_VentaSujeta.Text), Convert.ToDecimal(Txt_Subtotal.Text), Chk_Exenta.Checked, VentaExenta, Txt_NombreCliente.Text, Txt_Direccion.Text, Txt_Telefono.Text, Txt_Movil.Text, textBox3.Text, Txt_Nrc.Text, Txt_Giro.Text,0);

               foreach (DataGridViewRow row in dgvDetFact.Rows)
               {
                  
                   if (row.Cells["Precio_Total"].Value != null)
                   {
                       bool.TryParse(Convert.ToString(row.Cells["sujeto"].Value), out chk); // convierte el valor del checkbox column
                       NoLinea = row.Index + 1;
                       tbl_Det_FactTableAdapter.InsertDetFact(correlativo, NoLinea,
                           Convert.ToString(row.Cells["Id_Servicio"].Value),Convert.ToDecimal(row.Cells["Cantidad"].Value),
                           Convert.ToDecimal(row.Cells["Precio"].Value), Convert.ToDecimal(row.Cells["Precio_Total"].Value),
                           "N",Convert.ToString(row.Cells["Descripcion_User"].Value),chk);
                   }
               } // fin foreach
               Cls_Helper.MostrarMensaje("Factura creada con éxito", "Información");
               Cls_Helper.LimpiarCampos(groupBox1); Cls_Helper.LimpiarCampos(groupBox2);

            }
            catch (SystemException ex)
            {
                Cls_Helper.MostrarMensaje("Error al tratar de guardar la factura. " + ex.Message, "Error", 1);
            }
           
        }

        private void Btt_FactRecAct_Click(object sender, EventArgs e)
        {
            tbl_FacturaTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Factura);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            tbl_Det_FactTableAdapter.FillBy_correlativo(mODULO_FACT_VECADataSet.Tbl_Det_Fact,
                Convert.ToDecimal(dataGridView1.CurrentRow.Cells["CorrelativoBus"].Value));
        }

      
        // Exento de IVA TODO: VALIDAR FUNCIONAMIENTO
        private void Chk_Exenta_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Exenta.Checked)
            {
                Txt_RetPer.Text = "0.00"; Txt_Iva.Text = "0.00";
            }
            else
            {
                Txt_RetPer.Text = "0.00";
                try // MODIFICAR ESTA PARTE. SOLUCION TEMPORAL PARA CUANDO SUBTOTAL = ""
                {
                    Txt_Iva.Text = Convert.ToString(Login.iva_empresa * Convert.ToDecimal(Txt_Subtotal.Text));
                }
                catch { }
            }
        }

        private void Btt_Reporte_Click(object sender, EventArgs e)
        {
            FacturasTab.Select();
        }


        // BOTON IMPRIME FACTURAS 
        private void btnImpFac_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                Visor_Informe informe = new Visor_Informe();
                // llena el datatable
                rEP_DOCUMENTOS_FISCALESTableAdapter.Fill_BYNOFACT(reportes.REP_DOCUMENTOS_FISCALES,
                   Convert.ToDecimal(dataGridView1.CurrentRow.Cells["No_Factura"].Value), Convert.ToDecimal(Login.Empresa),
                    Convert.ToString(dataGridView1.CurrentRow.Cells["Serie"].Value));
              
                informe.GeneraDocumento(reportes.REP_DOCUMENTOS_FISCALES);

               informe.Show();
            }

        }

  

        // Fin EnD Edit

      


    }
}
