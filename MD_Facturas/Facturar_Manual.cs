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
    public partial class Facturar_Manual : Form
    {
        public Cls_Con con1 = new Cls_Con();
        public string usuario;
        int l = 0;
        public Facturar_Manual()
        {
            InitializeComponent();
            
            Txt_Usuario.Text = usuario;   
            
        }

        private void Facturar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mODULO_FACT_VECADataSet.Tbl_Doc_PuntoVenta' table. You can move, or remove it, as needed.
            this.tbl_Doc_PuntoVentaTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Doc_PuntoVenta);
            // TODO: This line of code loads data into the 'mODULO_FACT_VECADataSet.Tbl_Tipo_Doc' table. You can move, or remove it, as needed.
            this.tbl_Tipo_DocTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Tipo_Doc);
            // TODO: This line of code loads data into the 'mODULO_FACT_VECADataSet.Tbl_Servicios' table. You can move, or remove it, as needed.
            this.tbl_ServiciosTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Servicios);
            this.tbl_Tipo_DocFacTTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Tipo_DocFacT, Convert.ToInt32(Login.CodPais));
            this.tbl_Tipo_DocNCTableAdapter.Fill(this.mODULO_FACT_VECADataSet2.Tbl_Tipo_DocNC, Convert.ToInt32(Login.CodPais));
            this.tbl_Tipo_Doc_BusquedaTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Tipo_Doc_Busqueda, Convert.ToInt32(Login.CodPais));
            DataTable data = con1.GetDataTable("SELECT Id_Servicio,Cod_Servicio,Descripcion FROM tbl_servicios where Descripcion IN('Tarifa','Servicio')");
            Cls_Helper.ComboBoxColumn_Fill(dgvDetFact, "ComboTarifa", data, "Descripcion", "Id_Servicio");
            this.tbl_Tipo_DocNDTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Tipo_DocND, Convert.ToInt32(Login.CodPais));
            Txt_Usuario.Text = usuario;
            SeleccionaTipoDoc("SALNC");
            SeleccionaTipoDocNC("SALND");
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
                        textBox3.Text = Convert.ToString(row["NIT"]); // NIT
                        textBox3.Enabled = false; // inhabilita control para solo lectura 
                        Txt_Nrc.Text = Convert.ToString(row["Nrc"]); // nRC
                        Txt_Nrc.Enabled = false;
                        Txt_Giro.Text = Convert.ToString(row["Giro"]);
                    }
                }
                if (Txt_IdCliente.Text == "999")
                {
                    BloquearInf(true);
                }
                else
                {
                    BloquearInf(false);
                }
            }
        } // Fin evento Key DOwn
        // evento text changed
        private void Txt_NombreCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Txt_NombreCliente.TextLength > 4)
                {

                    SqlParameter[] p =
                {
                   new SqlParameter("@EMPRESA",SqlDbType.Decimal){ Value = Login.Empresa }
                };
                    try
                    {
                        Cls_Helper.AutoCompletar(Txt_NombreCliente,
                          con1.GetDataTable("SELECT * FROM TBL_CLIENTES WHERE Cod_empresa = @EMPRESA", con1.conexion, p), "Nombre", "Id_cliente");
                    }
                    catch { }
                }
            }
            catch { }
        }// Fin Evento. text change

       // BOTON CANCELAR
        private void Btt_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Boton fin celledit
        private void dgvDetFact_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal ReservaTotal, Precio, TotalGravado, Iva = 0;
                decimal monto_iva = 0;
                decimal Subtotal = 0;

                if (string.IsNullOrWhiteSpace(Convert.ToString(dgvDetFact.Rows[e.RowIndex].Cells["Precio"].Value)) != true)
                {
                    if (Convert.ToDecimal(dgvDetFact.Rows[e.RowIndex].Cells["Precio"].Value) >= 0 && dgvDetFact.Rows[e.RowIndex].Cells["Precio"].Selected)
                    {
                        if (Chk_Exenta.Checked == false)
                        {
                            monto_iva = Math.Round(Convert.ToDecimal(dgvDetFact.Rows[e.RowIndex].Cells["precio"].Value) * Login.iva_empresa, 4);
                        }
                        else
                        {
                            monto_iva = Convert.ToDecimal(0.00);
                        }
                        TotalGravado = Convert.ToDecimal(dgvDetFact.Rows[e.RowIndex].Cells["precio"].Value) + Math.Round(monto_iva, 4);
                        dgvDetFact.Rows[e.RowIndex].Cells["monto_iva"].Value = monto_iva;
                        dgvDetFact.Rows[e.RowIndex].Cells["Total_Tarifa"].Value = TotalGravado;
                        ReservaTotal = (Convert.ToDecimal(dgvDetFact.Rows[e.RowIndex].Cells["TotalReserva"].Value) - Math.Round(TotalGravado, 2, MidpointRounding.AwayFromZero)); // calcula el valor restante de reserva (valor no sujeto)
                        if (Convert.ToDecimal(dgvDetFacServicios.Rows[e.RowIndex].Cells["Precio_Total"].Value) == 0)
                        {
                            dgvDetFacServicios.Rows.Add(1, 1020, "OTROS IMPUESTOS", 1, ReservaTotal, ReservaTotal, true);
                        }
                        else
                        {
                            dgvDetFacServicios.Rows[e.RowIndex].Cells["Precio_Total"].Value = ReservaTotal;
                            dgvDetFacServicios.Rows[e.RowIndex].Cells["Precio1"].Value = ReservaTotal;
                        }
                        dgvDetFacServicios_CellEndEdit(dgvDetFacServicios.Rows[e.RowIndex].Cells["Precio_Total"], e); // llama evento de grid clon
                    } // fin if

                    else
                    {
                        if (Chk_Exenta.Checked == false)
                        {
                            monto_iva = Convert.ToDecimal(dgvDetFact.Rows[e.RowIndex].Cells["monto_iva"].Value);// Math.Round(Convert.ToDecimal(dgvDetFact.Rows[e.RowIndex].Cells["precio"].Value) * Login.iva_empresa, 3);
                        }
                        else
                        {
                            monto_iva = Convert.ToDecimal(0.00);
                        }
                        TotalGravado = Convert.ToDecimal(dgvDetFact.Rows[e.RowIndex].Cells["precio"].Value) + Math.Round(monto_iva, 3);
                        dgvDetFact.Rows[e.RowIndex].Cells["monto_iva"].Value = monto_iva;
                        dgvDetFact.Rows[e.RowIndex].Cells["Total_Tarifa"].Value = TotalGravado;
                        ReservaTotal = (Convert.ToDecimal(dgvDetFact.Rows[e.RowIndex].Cells["TotalReserva"].Value) - Math.Round(TotalGravado, 2, MidpointRounding.AwayFromZero)); // calcula el valor restante de reserva (valor no sujeto)
                        if (Convert.ToDecimal(dgvDetFacServicios.Rows[e.RowIndex].Cells["Precio_Total"].Value) != 0)
                        {
                            dgvDetFacServicios.Rows[e.RowIndex].Cells["Precio_Total"].Value = ReservaTotal;
                            dgvDetFacServicios.Rows[e.RowIndex].Cells["Precio1"].Value = ReservaTotal;
                        }
                        dgvDetFacServicios_CellEndEdit(dgvDetFacServicios.Rows[e.RowIndex].Cells["Precio_Total"], e); // llama evento de grid clon


                    }
                }
                foreach (DataGridViewRow row in dgvDetFact.Rows)
                {
                    if (Convert.ToDecimal(dgvDetFact.Rows[row.Index].Cells["Total_Tarifa"].Value) > 0)
                    {
                        Subtotal += Math.Round(Convert.ToDecimal(dgvDetFact.Rows[row.Index].Cells["Precio"].Value), 2, MidpointRounding.AwayFromZero);
                        Iva += Math.Round(Convert.ToDecimal(dgvDetFact.Rows[row.Index].Cells["monto_iva"].Value), 2, MidpointRounding.AwayFromZero);
                    } // fin if

                }// fin foreach

                Txt_Subtotal.Text = Convert.ToString(Math.Round(Subtotal, 2));
                Txt_Iva.Text = Convert.ToString(Math.Round(Iva, 2));
                Txt_RetPer.Text = "0.00"; // TODO VALIDAR CAMPO
                Sumatoria();

            }
            catch { }
         }// Fin CellEndEdit event dgvServicios.

        private void Sumatoria()
        {
            try
            {
                decimal iva, subtotal, retper, sujeta;
                decimal.TryParse(Txt_Iva.Text, out iva);
                decimal.TryParse(Txt_Subtotal.Text, out subtotal);
                decimal.TryParse(Txt_RetPer.Text, out retper);
                decimal.TryParse(Txt_VentaSujeta.Text, out sujeta);

                Txt_Total.Text = Convert.ToString(Math.Round(subtotal + sujeta + retper + iva + Convert.ToDecimal(ImpTurismo.Text), 2));
            }
            catch { }
        }

        private void Btt_Guardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de crear una nueva factura", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ValidarDatosFactura();
                if (l != 1)
                {
                    bool chk = false;
                    int NoLinea = 0;
                    decimal VentaExenta = 0;
                    decimal VentaGravada = 0;
                         decimal correlativo = 0;
                    try
                    {
                        if (Chk_Exenta.Checked == true)
                        {
                            VentaExenta = Convert.ToDecimal(Txt_Subtotal.Text);
                            VentaGravada = Convert.ToDecimal(0.00);
                        }
                        else
                        {
                            VentaExenta = Convert.ToDecimal(0.00);
                            VentaGravada = Convert.ToDecimal(Txt_Subtotal.Text);
                        }

                        correlativo = tbl_FacturaTableAdapter.INSERTAR_ENFACT(Convert.ToDecimal(Txt_Factura.Text),
                             Convert.ToString(Cbx_TipoDoc.SelectedValue), Txt_Serie.Text, Convert.ToDecimal(Txt_IdCliente.Text), Login.Cod_PuntoVenta,
                             Convert.ToString(dateTimePicker1.Value.ToShortDateString()), Txt_Boleto.Text, Convert.ToDecimal(Txt_Total.Text),
                             Convert.ToDecimal(Txt_Iva.Text), Convert.ToDecimal(Login.Empresa), "P", "P", DateTime.Now, Convert.ToDecimal(Txt_RetPer.Text),
                             Convert.ToDecimal(Txt_VentaSujeta.Text), Convert.ToDecimal(VentaGravada), Chk_Exenta.Checked, VentaExenta, Convert.ToString(Txt_NombreCliente.Text), Convert.ToString(Txt_Direccion.Text), Convert.ToString(Txt_Telefono.Text), Convert.ToString(Txt_Movil.Text), Convert.ToString(textBox3.Text), Convert.ToString(Txt_Nrc.Text), Convert.ToString(Txt_Giro.Text),Convert.ToDecimal(ImpTurismo.Text));

                        //validar luego con transaccion
                        this.tbl_Doc_PuntoVentaTableAdapter.ActualizarDocPuntoVenta(Convert.ToString(Cbx_TipoDoc.SelectedValue), Login.Cod_PuntoVenta);

                        foreach (DataGridViewRow row in dgvDetFacServicios.Rows)
                        {

                            if (Convert.ToDecimal(row.Cells["Precio_Total"].Value) > 0)
                            {
                                bool.TryParse(Convert.ToString(row.Cells["sujeto"].Value), out chk); // convierte el valor del checkbox column
                                NoLinea = row.Index + 1;
                                tbl_Det_FactTableAdapter.InsertDetFact(correlativo, NoLinea,
                                    Convert.ToString(row.Cells["Id_Servicio"].Value), Convert.ToDecimal(row.Cells["Cantidad"].Value),
                                    Convert.ToDecimal(row.Cells["Precio1"].Value), Convert.ToDecimal(row.Cells["Precio_Total"].Value),
                                    "N", Convert.ToString(row.Cells["Descripcion"].Value), chk);
                            }
                        } // fin foreach

                        //inserta detalle primer grid.
                        foreach (DataGridViewRow row in dgvDetFact.Rows)
                        {
                            if (Convert.ToDecimal(row.Cells["Total_Tarifa"].Value) > 0)
                            {

                                NoLinea += NoLinea;
                                tbl_Det_FactTableAdapter.InsertDetFact(correlativo, NoLinea,
                                    Convert.ToString(row.Cells["ComboTarifa"].Value), 1,
                                    Convert.ToDecimal(row.Cells["Precio"].Value), Convert.ToDecimal(row.Cells["Total_Tarifa"].Value),
                                    "N", Convert.ToString(row.Cells["Descripcion_User"].Value), false);
                            }
                        }


                        Cls_Helper.MostrarMensaje("Factura creada con éxito", "Información");

                        if (Cls_Helper.MostrarMensaje("¿Desea imprimir la factura?", "Confirmar", 3) == DialogResult.Yes)
                        {
                            Cls_ReportHelper Report1 = new Cls_ReportHelper
                           {
                               TipoInforme = Convert.ToString(Cbx_TipoDoc.SelectedValue),
                               NoDoc = Convert.ToDecimal(Txt_Factura.Text),
                               SerieDoc = Txt_Serie.Text,
                           };

                            Report1.LlamaReporte();
                        } // fin if mostrar mensaje

                        Cls_Helper.LimpiarCampos(groupBox1); Cls_Helper.LimpiarCampos(groupBox2);
                        LimpiarFact();
                        BloquearInf(false);
                    }
                    catch (SystemException ex)
                    {
                        Cls_Helper.MostrarMensaje("Error al tratar de guardar la factura. " + ex.Message, "Error", 1);
                    }
                }

                l = 0;
            }
        } // Fin guardar Factura

        public void LimpiarFact(){
             try{

                dataGridView1.DataSource = null;
                dataGridView2.DataSource = null;
            }
            catch { }
        }

        private void Btt_FactRecAct_Click(object sender, EventArgs e)
        {
            try
            {
                if (rBttAll.Checked==true)
                {
                this.tbl_FacturaVerTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_FacturaVer, Convert.ToInt32(Login.Cod_PuntoVenta), DatePkINI.Value, DatePkFin.Value);
                }
                else if (rBttAnulados.Checked==true) {
                    this.tbl_FacturaVerTableAdapter.FillByAnulacion(mODULO_FACT_VECADataSet.Tbl_FacturaVer, Convert.ToInt32(Login.Cod_PuntoVenta), Convert.ToString(cBoxBusqDocum.SelectedValue), DatePkINI.Value, DatePkFin.Value);

                }
                else if (rBttImpresos.Checked== true) {
                    this.tbl_FacturaVerTableAdapter.FillByImpresas(mODULO_FACT_VECADataSet.Tbl_FacturaVer, Convert.ToInt32(Login.Cod_PuntoVenta), Convert.ToString(cBoxBusqDocum.SelectedValue), DatePkINI.Value, DatePkFin.Value);
                }
                else if (rBttNoFact.Checked == true) {
                    this.tbl_FacturaVerTableAdapter.FillByNofact(mODULO_FACT_VECADataSet.Tbl_FacturaVer, Convert.ToInt32(Login.Cod_PuntoVenta), Convert.ToString(cBoxBusqDocum.SelectedValue), Convert.ToDecimal(TextNofact.Text));
                }
            }
            catch { }
            }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                tbl_Det_FactTableAdapter.FillBy_correlativo(mODULO_FACT_VECADataSet.Tbl_Det_Fact,
                    Convert.ToDecimal(dataGridView1.CurrentRow.Cells["CorrelativoBus"].Value));
            }
            catch { }
        }

      
        // Exento de IVA TODO: VALIDAR FUNCIONAMIENTO
        private void Chk_Exenta_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvDetFact.Rows)
                {
                    dgvDetFact.Rows[row.Index].Cells["Precio"].Selected = true;
                    DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(row.Cells["Precio"].ColumnIndex, row.Index);// dgvDetFact.CurrentRow.Index);
                    ActualizarExento(row.Index,args);

                }
            }
            catch { }
                
        }

        private void Btt_Reporte_Click(object sender, EventArgs e)
        {
            FacturasTab.Select();
        }


        // BOTON IMPRIME FACTURAS 
        private void btnImpFac_Click(object sender, EventArgs e)
        {
            try { 
                    if (dataGridView1.RowCount > 0)
                    {
                         Cls_ReportHelper Reporte2 = new Cls_ReportHelper
                       {
                           TipoInforme = Convert.ToString(dataGridView1.CurrentRow.Cells["Tipo_Doc"].Value),
                           SerieDoc = Convert.ToString(dataGridView1.CurrentRow.Cells["Serie"].Value),
                           NoDoc = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["No_Factura"].Value)
                       };
                       Reporte2.LlamaReporte();
                    }
            }
            catch { }
            Btt_FactRecAct.PerformClick();
        }

        private void dgvDetFacServicios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal cantidad, precio, Total;
            decimal Iva = 0;
            decimal Subtotal = 0;
            decimal ventasujeta = 0;
            bool result;
            decimal.TryParse(Txt_Subtotal.Text, out Subtotal);
            decimal.TryParse(Txt_Iva.Text, out Iva);

            dgvDetFacServicios.Rows[e.RowIndex].Cells["No_Linea"].Value = e.RowIndex + 1;
            if (decimal.TryParse(Convert.ToString(dgvDetFacServicios.Rows[e.RowIndex].Cells["cantidad"].Value), out cantidad)
                && decimal.TryParse(Convert.ToString(dgvDetFacServicios.Rows[e.RowIndex].Cells["Precio1"].Value), out precio))
            {
                Total = cantidad * precio;
                dgvDetFacServicios.Rows[e.RowIndex].Cells["Precio_Total"].Value = Total;
                Txt_Subtotal.Text = Convert.ToString(Total);

                //sumatoria 
                foreach (DataGridViewRow row in dgvDetFacServicios.Rows)
                {
                    if (Convert.ToDecimal(dgvDetFacServicios.Rows[row.Index].Cells["Precio_Total"].Value) > 0)
                    {
                        if (bool.TryParse(Convert.ToString(dgvDetFacServicios.Rows[row.Index].Cells["sujeto"].Value), out result) == false)
                        {
                            Subtotal += Convert.ToDecimal(dgvDetFacServicios.Rows[row.Index].Cells["Precio_Total"].Value);
                            Iva += Convert.ToDecimal(dgvDetFacServicios.Rows[row.Index].Cells["Precio_Total"].Value) * Login.iva_empresa;
                        }
                        else
                        {
                            ventasujeta += Convert.ToDecimal(dgvDetFacServicios.Rows[row.Index].Cells["Precio_Total"].Value);
                        }
                    } // fin if

                }// fin foreach
            } // fin if externo 

            Txt_VentaSujeta.Text = Convert.ToString(Math.Round(ventasujeta,2));
            Txt_Subtotal.Text = Convert.ToString(Math.Round(Subtotal,2));
            Txt_Iva.Text = Convert.ToString(Math.Round(Iva,2));
            Txt_RetPer.Text = "0.00"; // TODO VALIDAR CAMPO
            Sumatoria();
        }

        //Evento change del dropdown list de selección de tipo de documento
        private void Cbx_TipoDoc_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable data;
            SqlParameter[] param = 
            {
                new SqlParameter("@CodDoc",SqlDbType.VarChar){ Value = Convert.ToString(Cbx_TipoDoc.SelectedValue)},
                new SqlParameter("@CodPuntoVenta",SqlDbType.Decimal){Value = Login.Cod_PuntoVenta}
            };
            data = con1.GetDataTable("SELECT SERIE_DOC,Correlativo_Actual from Tbl_Doc_PuntoVenta where Cod_Doc = @CodDoc and Cod_PuntoVenta =@CodPuntoVenta", con1.conexion, param);
            try
            {
                Txt_Serie.Text = Convert.ToString(data.Rows[0]["SERIE_DOC"]);
                Txt_Factura.Text = Convert.ToString(data.Rows[0]["Correlativo_Actual"]);
            }
            catch { }
        }


        // Evento controla cuando una linea fué removida.
        private void dgvDetFact_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                dgvDetFacServicios.Rows.Remove(dgvDetFacServicios.Rows[e.RowIndex]);
            }
            catch { }
        }

        private void Btt_Buscar_Click(object sender, EventArgs e)
        {
            VerClientes v = new VerClientes();
            v.MostrarClientes();
            v.TpForm = "MdFact";
            v.MdiParent = this.MdiParent;
            v.Show();
        }

  

        // Fin EnD Edit

        //traer datos de busqueda 

        public void LlenarDatosCliente()
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
                        textBox3.Text = Convert.ToString(row["NIT"]); // NIT
                        textBox3.Enabled = false; // inhabilita control para solo lectura 
                        Txt_Nrc.Text = Convert.ToString(row["Nrc"]); // nRC
                        Txt_Nrc.Enabled = false;
                        Txt_Giro.Text = Convert.ToString(row["Giro"]);
                    }
                }
                if (Txt_IdCliente.Text == "999")
                {
                    BloquearInf(true);
                }
                else {
                    BloquearInf(false);
                }         
        }

        public void BloquearInf(Boolean Stad) {

            Txt_Direccion.Enabled = Stad;
            Txt_Telefono.Enabled = Stad;
            Txt_Movil.Enabled = Stad;
            textBox3.Enabled = Stad; // inhabilita control para solo lectura 
            Txt_Nrc.Enabled = Stad;
            Txt_Giro.Enabled = Stad;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
                Form p1 = (Form)Application.OpenForms["MDIParent1"];
                MDIParent1 f1 = (MDIParent1)p1;
                f1.ClientesToolStripMenuItem.PerformClick();
        }

        private void BttBqFact_Click(object sender, EventArgs e)
        {
            // Asigno datos a las variables globales para monto, fact serie y fact N°
            String _SerieFact = TbxSerieFact.Text;
            String _NoFact = TbxSerieNoFact.Text;
            
            // ve si serie o factura esta vacio
            if (TbxSerieNoFact.Text == "" || TbxSerieFact.Text == "")
            {
                MessageBox.Show("El campo Serie y Factura no pueden estar vacíos. **");
            }
            else
            {
                string mystring = "select f.Correlativo,f.No_factura,f.Fecha, f.Monto_Fact,c.Nombre,c.Nit,c.Id_cliente,f.Tipo_Doc from Tbl_Factura f inner join Tbl_Clientes c on c.Id_cliente=f.Id_cliente " +
                "where f.No_factura= " + Convert.ToDecimal(TbxSerieNoFact.Text) + " and f.Serie= '" + TbxSerieFact.Text.ToUpper() + "'";// +" and f.statusfac='N' and f.DOCENTRY_SAP <> 'NULL'";//agregar  and doctype_sap<>null
                // radtxtSerie.Text = mystring;
                SqlConnection cn = new SqlConnection(Properties.Settings.Default.MODULO_FACT_VECAConnectionString);
                SqlCommand query = new SqlCommand(mystring, cn);
                try
                {
                    cn.Open();
                    query.ExecuteNonQuery();

                }
                catch (Exception msg)
                {
                    MessageBox.Show("No se encontró ningun registro para su busqueda");
                }

                SqlDataReader reader = query.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        TbxMonto.Text = Convert.ToString(reader["Monto_Fact"]);
                        TbxNit.Text = Convert.ToString(reader["Nit"]);
                        TbxNombre.Text = Convert.ToString(reader["Nombre"]);
                        TbxIdCliente.Text = Convert.ToString(reader["Id_cliente"]);
                        dateTimeNC.Value = Convert.ToDateTime(reader["Fecha"]);
                        _SerieFact = Convert.ToString(reader["Tipo_Doc"]);
                    }

                    if (_SerieFact.ToUpper() == "SALCCF")
                    {
                         BttCreateNC.Enabled = true; // aciva boton de crear Nota Credito
                    }
                    else
                    {
                        BttCreateNC.Enabled = false;
                        MessageBox.Show("La transacción de la factura no es de tipo <!-- Credito Fiscal -->", "Aterta!!");
                    }
                }
                else
                {
                    TbxMonto.Text = "";
                    TbxNit.Text = "";
                    TbxNombre.Text = "";
                    TbxIdCliente.Text = "";
                                       MessageBox.Show("No se han encontrado registros. Redefina su busqueda.");
                }

            }
            try
            {
                tbl_Det_FactNCTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Det_FactNC, Convert.ToInt32(TbxSerieNoFact.Text), TbxSerieFact.Text);
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Cls_Helper.LimpiarCampos(groupBox4);
                int i = 0;
                for (i = 0; i < dgvDetFactNc.Rows.Count; i++)
                {
                    this.dgvDetFactNc.Rows.RemoveAt(i);
                }

            }
            catch { }
        }

        private void BttCancelNC_Click(object sender, EventArgs e)
        {
            this.Close();
            button4.PerformClick();
        }
        /// <summary>
        /// Guardar datos de nota de credito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BttCreateNC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de Generar la Nota de credito", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GrabarNC();
            }
            
        }

        private void CbxNC_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable data;
            SqlParameter[] param = 
            {
                new SqlParameter("@CodDoc",SqlDbType.VarChar){ Value = Convert.ToString(CbxNC.SelectedValue)},
                new SqlParameter("@CodPuntoVenta",SqlDbType.Decimal){Value = Login.Cod_PuntoVenta}
            };
            data = con1.GetDataTable("SELECT SERIE_DOC,Correlativo_Actual from Tbl_Doc_PuntoVenta where Cod_Doc = @CodDoc and Cod_PuntoVenta =@CodPuntoVenta", con1.conexion, param);
            try
            {
                if (string.IsNullOrWhiteSpace(Convert.ToString(data.Rows[0]["SERIE_DOC"])) != true)
                {
                    SerieNC.Text = Convert.ToString(data.Rows[0]["SERIE_DOC"]);
                    NoNC.Text = Convert.ToString(data.Rows[0]["Correlativo_Actual"]);
                }
                else {
                    SerieNC.Text = "";
                    NoNC.Text ="";
                }
            }
            catch { }
        }

        public void GrabarNC()
        {
            SqlConnection cn;
            cn = new SqlConnection(Properties.Settings.Default.cnx);
            SqlCommand cmd = new SqlCommand("p_Nota_creditos", cn);//cb_addEncCoti
            cmd.CommandType = CommandType.StoredProcedure;
            //SqlParameter partout = new SqlParameter("@p",SqlDbType.Int);
            cn.Open();
            try
            {
                cmd.Parameters.Add("@Nota", SqlDbType.Int).Value = Convert.ToInt32(NoNC.Text);
                cmd.Parameters.Add("@Serie", SqlDbType.VarChar).Value = this.SerieNC.Text;
                cmd.Parameters.Add("@SerieFact", SqlDbType.VarChar).Value = TbxSerieFact.Text.ToUpper();
                cmd.Parameters.Add("@No_Factura", SqlDbType.Int).Value = Convert.ToString(this.TbxSerieNoFact.Text);
                cmd.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@Monto", SqlDbType.Float).Value = Convert.ToDecimal(TbxMonto.Text);
                cmd.Parameters.Add("@Cod_Empresa", SqlDbType.Int).Value = Convert.ToInt32(Login.Empresa);
                cmd.Parameters.Add("@CorFact", SqlDbType.Int).Value = Convert.ToInt32(0);
                cmd.Parameters.Add("@CorNC", SqlDbType.Int).Value = Convert.ToInt32(0);
                cmd.Parameters.Add("@Cod_PV", SqlDbType.Int).Value = Convert.ToInt32(Login.Cod_PuntoVenta);
                cmd.Parameters.Add("@tipoDoc", SqlDbType.VarChar).Value = Convert.ToString(CbxNC.SelectedValue);

             //   cmd.ExecuteNonQuery();

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Nota de Credito Generada");

                    if (Cls_Helper.MostrarMensaje("¿Desea imprimir la Nota de  Credito?", "Confirmar", 3) == DialogResult.Yes)
                    {
                        Cls_ReportHelper Report3 = new Cls_ReportHelper
                        {
                            TipoInforme = Convert.ToString(CbxNC.SelectedValue),
                            NoDoc = Convert.ToDecimal(NoNC.Text),
                            SerieDoc = SerieNC.Text,
                        };

                        Report3.LlamaReporte();
                    } // fin if mostrar mensaje

                    button4.PerformClick();
                    BttCreateNC.Enabled = false;
                    NumNCActual();

                }
            }
            catch
            {
            }
            cn.Close();
        }

        private void DatePkINI_ValueChanged(object sender, EventArgs e)
        {
            DatePkFin.MinDate = DatePkINI.Value;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbl_Enc_NotaCredVERTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Enc_NotaCredVER, Convert.ToInt32(Login.Cod_PuntoVenta), DatePKIniNC.Value.ToShortDateString(), DatePKFinNC.Value);
            }
            catch { }
            }

        private void DatePKIniNC_ValueChanged(object sender, EventArgs e)
        {
            DatePKFinNC.MinDate = DatePKIniNC.Value;
        }

        private void dataGridView4_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.tbl_Det_NotaCredVERTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Det_NotaCredVER, Convert.ToDecimal(dataGridView4.CurrentRow.Cells["corNC"].Value));
                
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView4.RowCount > 0)
                {
                    Cls_ReportHelper Reporte4 = new Cls_ReportHelper
                    {
                        TipoInforme = Convert.ToString(dataGridView4.CurrentRow.Cells["Tipo_DocNC"].Value),
                        SerieDoc = Convert.ToString(dataGridView4.CurrentRow.Cells["SerieNC1"].Value),
                        NoDoc = Convert.ToDecimal(dataGridView4.CurrentRow.Cells["No_Nota"].Value)
                    };
                    Reporte4.LlamaReporte();
                }
            }
            catch { }
        }
        
        public void SeleccionaTipoDoc(string tipodoc)
        {
            if (CbxNC.Items.Contains(tipodoc))
            {
                CbxNC.SelectedIndex = CbxNC.Items.IndexOf(tipodoc);
            }
            else
            {
                CbxNC.SelectedIndex = 0;
            }
            CbxNC.SelectedValue = tipodoc;
        }

        public void SeleccionaTipoDocNC(string tipodoc)
        {
            if (DdlTipoDocND.Items.Contains(tipodoc))
            {
                DdlTipoDocND.SelectedIndex = DdlTipoDocND.Items.IndexOf(tipodoc);
            }
            else
            {
                DdlTipoDocND.SelectedIndex = 0;
            }
            DdlTipoDocND.SelectedValue = tipodoc;
        }


        public void NumNCActual() {
            DataTable data;
            SqlParameter[] param = 
            {
                new SqlParameter("@CodDoc",SqlDbType.VarChar){ Value = Convert.ToString("SALNC")},
                new SqlParameter("@CodPuntoVenta",SqlDbType.Decimal){Value = Login.Cod_PuntoVenta}
            };
            data = con1.GetDataTable("SELECT SERIE_DOC,Correlativo_Actual from Tbl_Doc_PuntoVenta where Cod_Doc = @CodDoc and Cod_PuntoVenta =@CodPuntoVenta", con1.conexion, param);
            try
            {
                if (string.IsNullOrWhiteSpace(Convert.ToString(data.Rows[0]["SERIE_DOC"])) != true)
                {
                    SerieNC.Text = Convert.ToString(data.Rows[0]["SERIE_DOC"]);
                    NoNC.Text = Convert.ToString(data.Rows[0]["Correlativo_Actual"]);
                }
                else
                {
                    SerieNC.Text = "";
                    NoNC.Text = "";
                }
            }
            catch { }
        }

        public void NumNDActual()
        {
            DataTable data;
            SqlParameter[] param = 
            {
                new SqlParameter("@CodDoc",SqlDbType.VarChar){ Value = Convert.ToString("SALND")},
                new SqlParameter("@CodPuntoVenta",SqlDbType.Decimal){Value = Login.Cod_PuntoVenta}
            };
            data = con1.GetDataTable("SELECT SERIE_DOC,Correlativo_Actual from Tbl_Doc_PuntoVenta where Cod_Doc = @CodDoc and Cod_PuntoVenta =@CodPuntoVenta", con1.conexion, param);
            try
            {
                if (string.IsNullOrWhiteSpace(Convert.ToString(data.Rows[0]["SERIE_DOC"])) != true)
                {
                    this.TbxSerieNotaND.Text = Convert.ToString(data.Rows[0]["SERIE_DOC"]);
                    this.TbxNoNotaND.Text = Convert.ToString(data.Rows[0]["Correlativo_Actual"]);
                }
                else
                {
                    TbxSerieNotaND.Text = "";
                    TbxNoNotaND.Text = "";
                }
            }
            catch { }
        }

        // METODO PARA VALIDAR DATOS DE ENTRADA
        public void ValidarDatosFactura()
        {
            if (Txt_Factura.Text != "" && Cbx_TipoDoc.SelectedValue != "" && Txt_IdCliente.Text != "" && Txt_Serie.Text != "")
                if (Txt_Factura.Text == "")
            {
                l = 1;
                MessageBox.Show("Registro Vacio No Factura ");
            }
                else if (Txt_Serie.Text == "")
            {
                l = 1;
                MessageBox.Show("Registro Vacio Serie");
            }
                else if (Txt_IdCliente.Text == "")
            {
                l = 1;
                MessageBox.Show("Registro Vacio Cliente ");
            }
                else if (Cbx_TipoDoc.SelectedValue == "")
            {
                l = 1;
                MessageBox.Show("Registro Vacio Tipo Documento ");
            }
                else if (ImpTurismo.Text == "" || ImpTurismo.Text == "." || ImpTurismo.Text == " ")
                {
                    ImpTurismo.Text = "0.00";
            }

        }

        private void BttActFact_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbl_FacturaAnulacionTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_FacturaAnulacion, Convert.ToInt32(Login.Cod_PuntoVenta), dateTimePicker2.Value, dateTimePicker3.Value);
            }
            catch { }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.MinDate = dateTimePicker2.Value;
        }

        private void dataGridView6_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.tbl_Det_FactAnulacionTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Det_FactAnulacion,
                    Convert.ToDecimal(dataGridView6.CurrentRow.Cells["CorrelativoANU"].Value));
            }
            catch { }

        }

        private void BttAnularFact_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Estas seguro de Anular la factura", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.tbl_FacturaAnulacionTableAdapter.ActualizarAnul(Convert.ToDecimal(dataGridView6.CurrentRow.Cells["CorrelativoANU"].Value), Convert.ToDecimal(dataGridView6.CurrentRow.Cells["NofactANU"].Value), Convert.ToString(dataGridView6.CurrentRow.Cells["TipoDocANU"].Value));
                }
                BttActFact.PerformClick();
            }
            catch { }
        }

        private void rBttNoFact_CheckedChanged(object sender, EventArgs e)
        {
            if (rBttNoFact.Checked == true) {
                TextNofact.Enabled = true;
            }
            else if (rBttNoFact.Checked == false)
            {
                TextNofact.Enabled = false;
            }
        }

        public void ActualizarExento(int Index,DataGridViewCellEventArgs e) {
            try
            {   decimal ReservaTotal, Precio, TotalGravado, Iva = 0;
                decimal monto_iva = 0;
                decimal Subtotal = 0;
                if (Convert.ToDecimal(dgvDetFact.Rows[Index].Cells["Precio"].Value) >= 0 && dgvDetFact.Rows[Index].Cells["Precio"].Selected)
                {
                    if (Chk_Exenta.Checked == false)
                    {
                        monto_iva = Math.Round(Convert.ToDecimal(dgvDetFact.Rows[e.RowIndex].Cells["precio"].Value) * Login.iva_empresa, 4);
                    }
                    else
                    {
                        monto_iva = Convert.ToDecimal(0.00);
                    }
                    TotalGravado = Convert.ToDecimal(dgvDetFact.Rows[Index].Cells["precio"].Value) + Math.Round(monto_iva, 3);
                    dgvDetFact.Rows[Index].Cells["monto_iva"].Value = monto_iva;
                    dgvDetFact.Rows[Index].Cells["Total_Tarifa"].Value = TotalGravado;
                    ReservaTotal = (Convert.ToDecimal(dgvDetFact.Rows[Index].Cells["TotalReserva"].Value) - Math.Round(TotalGravado, 2, MidpointRounding.AwayFromZero)); // calcula el valor restante de reserva (valor no sujeto)
                        dgvDetFacServicios.Rows[Index].Cells["Precio_Total"].Value = ReservaTotal;
                        dgvDetFacServicios.Rows[Index].Cells["Precio1"].Value = ReservaTotal;
                       DetServi(Index);
                } // fin if

                //sumatoria 
                foreach (DataGridViewRow row in dgvDetFact.Rows)
                {
                    if (Convert.ToDecimal(dgvDetFact.Rows[row.Index].Cells["Total_Tarifa"].Value) > 0)
                    {
                        Subtotal += Math.Round(Convert.ToDecimal(dgvDetFact.Rows[row.Index].Cells["Precio"].Value), 2, MidpointRounding.AwayFromZero);
                        Iva += Math.Round(Convert.ToDecimal(dgvDetFact.Rows[row.Index].Cells["monto_iva"].Value), 2, MidpointRounding.AwayFromZero);
                    } // fin if

                }

                Txt_Subtotal.Text = Convert.ToString(Math.Round(Subtotal, 2));
                Txt_Iva.Text = Convert.ToString(Math.Round(Iva, 2));
                Txt_RetPer.Text = "0.00"; // TODO VALIDAR CAMPO
                Sumatoria();

            }
            catch { }   
        }

        public void DetServi(int Index) {
            decimal cantidad, precio, Total;
            decimal Iva = 0;
            decimal Subtotal = 0;
            decimal ventasujeta = 0;
            bool result;
            decimal.TryParse(Txt_Subtotal.Text, out Subtotal);
            decimal.TryParse(Txt_Iva.Text, out Iva);

            dgvDetFacServicios.Rows[Index].Cells["No_Linea"].Value = Index + 1;
            if (decimal.TryParse(Convert.ToString(dgvDetFacServicios.Rows[Index].Cells["cantidad"].Value), out cantidad)
                && decimal.TryParse(Convert.ToString(dgvDetFacServicios.Rows[Index].Cells["Precio1"].Value), out precio))
            {
                Total = cantidad * precio;
                dgvDetFacServicios.Rows[Index].Cells["Precio_Total"].Value = Total;
                Txt_Subtotal.Text = Convert.ToString(Total);

                //sumatoria 
                foreach (DataGridViewRow row in dgvDetFacServicios.Rows)
                {
                    if (Convert.ToDecimal(dgvDetFacServicios.Rows[row.Index].Cells["Precio_Total"].Value) > 0)
                    {
                        if (bool.TryParse(Convert.ToString(dgvDetFacServicios.Rows[row.Index].Cells["sujeto"].Value), out result) == false)
                        {
                            Subtotal += Convert.ToDecimal(dgvDetFacServicios.Rows[row.Index].Cells["Precio_Total"].Value);
                            Iva += Convert.ToDecimal(dgvDetFacServicios.Rows[row.Index].Cells["Precio_Total"].Value) * Login.iva_empresa;
                        }
                        else
                        {
                            ventasujeta += Convert.ToDecimal(dgvDetFacServicios.Rows[row.Index].Cells["Precio_Total"].Value);
                        }
                    } // fin if

                }// fin foreach
                Txt_VentaSujeta.Text = Convert.ToString(Math.Round(ventasujeta, 2));
                Txt_Subtotal.Text = Convert.ToString(Math.Round(Subtotal, 2));
                Txt_Iva.Text = Convert.ToString(Math.Round(Iva, 2));
                Txt_RetPer.Text = "0.00"; // TODO VALIDAR CAMPO
                Sumatoria();
            } // fin if externo 


        }

        private void DdlTipoDocND_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void BttCreateND_Click(object sender, EventArgs e)
        {

        }

        private void BttBuscarND_Click(object sender, EventArgs e)
        {

        }

        private void BttBuscarND_Click_1(object sender, EventArgs e)
        {

            // Asigno datos a las variables globales para monto, fact serie y fact N°
            String _SerieFact = TbxSerieFacND.Text;
            String _NoFact = TbxNoFacND.Text;


            // ve si serie o factura esta vacio
            if (TbxSerieFacND.Text == "" || TbxNoFacND.Text == "")
            {
                MessageBox.Show("El campo Serie y Factura no pueden estar vacíos. **");
            }
            else
            {
                string mystring = "select f.Correlativo,f.No_factura,f.Fecha, f.Monto_Fact,c.Nombre,c.Nit,c.Id_cliente,f.EstadoExenta,f.Tipo_Doc from Tbl_Factura f inner join Tbl_Clientes c on c.Id_cliente=f.Id_cliente " +
                "where f.No_factura= " + Convert.ToDecimal(TbxNoFacND.Text) + " and f.Serie= '" + TbxSerieFacND.Text.ToUpper() + "'";// +" and f.statusfac='N' and f.DOCENTRY_SAP <> 'NULL'";//agregar  and doctype_sap<>null
                // radtxtSerie.Text = mystring;
                SqlConnection cn = new SqlConnection(Properties.Settings.Default.MODULO_FACT_VECAConnectionString);
                SqlCommand query = new SqlCommand(mystring, cn);
                try
                {
                    cn.Open();
                    query.ExecuteNonQuery();

                }
                catch (Exception msg)
                {
                    MessageBox.Show("No se encontró ningun registro para su busqueda");
                }

                SqlDataReader reader = query.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        TbxMontoFacND.Text = Convert.ToString(reader["Monto_Fact"]);
                        TbxMontoFacND.Tag = Convert.ToString(reader["Monto_Fact"]); // guarda el monto original para referencia
                        TbxNitND.Text = Convert.ToString(reader["Nit"]);
                        TbxNombreCliND.Text = Convert.ToString(reader["Nombre"]);
                        TbxCodCliND.Text = Convert.ToString(reader["Id_cliente"]);
                        dtFechaFacND.Value = Convert.ToDateTime(reader["Fecha"]);
                        ChkEstadoExenta.Checked = Convert.ToBoolean(reader["EstadoExenta"]);
                        _SerieFact = Convert.ToString(reader["Tipo_Doc"]);
                    }

                    if (_SerieFact.ToUpper() == "SALCCF")
                    {
                        BttCreateND.Enabled = true;
                    }
                    else
                    {
                        BttCreateND.Enabled = false;
                        MessageBox.Show("La transacción de la factura no es de tipo <!-- Credito Fiscal -->", "Aterta!!");
                    }
                }
                else
                {
                    TbxMonto.Text = "";
                    TbxNit.Text = "";
                    TbxNombre.Text = "";
                    TbxIdCliente.Text = "";
                    MessageBox.Show("No se han encontrado registros. Redefina su busqueda.");
                }

            }
            try
            {
                tbl_Det_FactNDTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Det_FactND, Convert.ToInt32(TbxNoFacND.Text), TbxSerieFacND.Text);
            }
            catch { }
        }

        private void BttCancelND_Click(object sender, EventArgs e)
        {
            this.Close();
            button4.PerformClick();
        }

        private void DdlTipoDocND_SelectedValueChanged_1(object sender, EventArgs e)
        {
            DataTable data;
            SqlParameter[] param = 
            {
                new SqlParameter("@CodDoc",SqlDbType.VarChar){ Value = Convert.ToString(DdlTipoDocND.SelectedValue)},
                new SqlParameter("@CodPuntoVenta",SqlDbType.Decimal){Value = Login.Cod_PuntoVenta}
            };
            data = con1.GetDataTable("SELECT SERIE_DOC,Correlativo_Actual from Tbl_Doc_PuntoVenta where Cod_Doc = @CodDoc and Cod_PuntoVenta =@CodPuntoVenta", con1.conexion, param);
            try
            {
                TbxSerieNotaND.Text = Convert.ToString(data.Rows[0]["SERIE_DOC"]);
                TbxNoNotaND.Text = Convert.ToString(data.Rows[0]["Correlativo_Actual"]);
            }
            catch { }
        }

        private void BttLimpNotaDebND_Click(object sender, EventArgs e)
        {
            try
            {
                Cls_Helper.LimpiarCampos(groupBox12);
                int i = 0;
                for (i = 0; i < dgvDetFactNd.Rows.Count; i++)
                {
                    this.dgvDetFactNd.Rows.RemoveAt(i);
                }
                int j = 0;
                for (j = 0; j < dgvItemAdicionalND.Rows.Count; j++)
                {
                    this.dgvItemAdicionalND.Rows.RemoveAt(j);
                }

            }
            catch { }
        }

        private void BttCreateND_Click_1(object sender, EventArgs e)
        {
            int cor = 0; decimal no_nota = 0;

            try
            {
                // graba encabezado de nota de débito
                GrabarND(out cor, out no_nota);
                foreach (DataGridViewRow row in dgvItemAdicionalND.Rows)
                {
                    if (Convert.ToInt32(row.Cells["CantidadAdd"].Value) > 0 && Convert.ToDecimal(row.Cells["PrecioAdd"].Value) > 0)
                    {
                        GrabarDetalleND(cor, no_nota, row.Index, Convert.ToDecimal(TbxMontoNota.Text), Convert.ToInt32(row.Cells["IdServicioAdd"].Value),
                             Convert.ToString(row.Cells["DescripcionAdd"].Value), Convert.ToInt32(row.Cells["CantidadAdd"].Value), Convert.ToDecimal(row.Cells["PrecioAdd"].Value),
                             Convert.ToBoolean(row.Cells["sujetoAdd"].Value), Convert.ToDecimal(row.Cells["ivaAdd"].Value));

                    }
                }


                if (cor > 0 && no_nota > 0)
                {
                    Cls_ReportHelper Report3 = new Cls_ReportHelper
                    {
                        TipoInforme = Convert.ToString(DdlTipoDocND.SelectedValue),
                        NoDoc = no_nota,
                        SerieDoc = TbxSerieNotaND.Text,
                    };

                    Report3.LlamaReporte();
                    NumNDActual();
                } // fin if mostrar mensaje
                Cls_Helper.MostrarMensaje("La nota de débito fué creada con éxito.", "Confirmación");

            }
            catch
            {
                Cls_Helper.MostrarMensaje("La nota de débito no ha podido ser creada", "Error", 2);
            }
        }

        public void GrabarND(out int correlativo, out decimal nonota)
        {
            correlativo = 0; nonota = 0;
            int cor = 0; // declare correlativo
            SqlConnection cn;
            cn = new SqlConnection(Properties.Settings.Default.cnx);
            SqlCommand cmd = new SqlCommand("p_Nota_debito", cn);//cb_addEncCoti
            cmd.CommandType = CommandType.StoredProcedure;
            //SqlParameter partout = new SqlParameter("@p",SqlDbType.Int);
            cn.Open();
            try
            {
                cmd.Parameters.Add("@Nota", SqlDbType.Decimal).Value = Convert.ToDecimal(TbxNoNotaND.Text);
                cmd.Parameters.Add("@Serie", SqlDbType.VarChar).Value = TbxSerieNotaND.Text;
                cmd.Parameters.Add("@SerieFact", SqlDbType.VarChar).Value = TbxSerieFacND.Text.ToUpper();
                cmd.Parameters.Add("@No_Factura", SqlDbType.Decimal).Value = Convert.ToDecimal(this.TbxNoFacND.Text);
                cmd.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@Monto", SqlDbType.Decimal).Value = Convert.ToDecimal(TbxMontoNota.Text);
                cmd.Parameters.Add("@Cod_Empresa", SqlDbType.Int).Value = Convert.ToInt32(Login.Empresa);
                cmd.Parameters.Add("@CorFact", SqlDbType.Int).Value = Convert.ToInt32(0);
                cmd.Parameters.Add("@CorNC", SqlDbType.Int).Value = Convert.ToInt32(0);
                cmd.Parameters.Add("@Cod_PV", SqlDbType.Int).Value = Convert.ToInt32(Login.Cod_PuntoVenta);
                cmd.Parameters.Add("@tipoDoc", SqlDbType.VarChar).Value = Convert.ToString(DdlTipoDocND.SelectedValue);
                SqlParameter sal1 = new SqlParameter("@correlativo", SqlDbType.Int);
                sal1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sal1);
                SqlParameter sal2 = new SqlParameter("@no_nota", SqlDbType.Decimal);
                sal2.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sal2);

                //   cmd.ExecuteNonQuery();

                if (cmd.ExecuteNonQuery() > 0)
                {


                    button4.PerformClick();
                    BttCreateNC.Enabled = false;
                    correlativo = Convert.ToInt32(sal1.Value); // agrega el correlativo a la variable cor
                    nonota = Convert.ToDecimal(sal2.Value);

                }
            }
            catch
            {
                Cls_Helper.MostrarMensaje("Ha ocurrido un error al crear la nota débito", "Error", 2);
            }
            finally
            {
                cn.Close();
            }



        }
        // Metodo graba el detalle de nota de debito
        public void GrabarDetalleND(int correlativo, decimal nonota, int no_linea, decimal monto, int IdServicio,
            string detalle, int cantidad, decimal precio, bool su, decimal iva)
        {
            SqlConnection cn;
            cn = new SqlConnection(Properties.Settings.Default.cnx);
            SqlCommand cmd = new SqlCommand("P_DET_NOTA_DEBITO", cn);//cb_addEncCoti
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            try
            {
                cmd.Parameters.Add("@no_nota", SqlDbType.Decimal).Value = nonota;
                cmd.Parameters.Add("@no_linea", SqlDbType.Int).Value = no_linea;
                cmd.Parameters.Add("@Monto", SqlDbType.Decimal).Value = monto;
                cmd.Parameters.Add("@Id_Servicio", SqlDbType.Int).Value = IdServicio;
                cmd.Parameters.Add("@Detalle", SqlDbType.VarChar).Value = detalle;
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = cantidad;
                cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = precio;
                cmd.Parameters.Add("@Correlativo", SqlDbType.Int).Value = correlativo;
                cmd.Parameters.Add("@sujeto", SqlDbType.Bit).Value = su;
                cmd.Parameters.Add("@iva", SqlDbType.Decimal).Value = iva;

                cmd.ExecuteNonQuery();

            }
            catch
            {
                Cls_Helper.MostrarMensaje("Ha ocurrido un error al crear el detalle de la nota de débito", "Error", 2);
            }
            finally
            {
                cn.Close();
            }


        }

        private void dgvItemAdicionalND_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            decimal total = 0;
            dgvItemAdicionalND.CurrentRow.Cells["IdServicioAdd"].Value = "1024"; // servicio genérico  
            if (dgvItemAdicionalND.CurrentRow.Cells["CantidadAdd"].Selected || dgvItemAdicionalND.CurrentRow.Cells["PrecioAdd"].Selected
                || dgvItemAdicionalND.CurrentRow.Cells["sujetoAdd"].Selected)
            {
                dgvItemAdicionalND.CurrentRow.Cells["PrecioTotalAdd"].Value = Convert.ToDecimal(dgvItemAdicionalND.CurrentRow.Cells["CantidadAdd"].Value) *
                    Convert.ToDecimal(dgvItemAdicionalND.CurrentRow.Cells["PrecioAdd"].Value);


                foreach (DataGridViewRow row in dgvItemAdicionalND.Rows)
                {
                    total = total + Convert.ToDecimal(row.Cells["PrecioTotalAdd"].Value) + Convert.ToDecimal(row.Cells["ivaAdd"].Value);

                }
                TbxMontoNota.Text = Convert.ToString(total);

            }
            if (Convert.ToBoolean(dgvItemAdicionalND.CurrentRow.Cells["sujetoAdd"].Value) == true)
            {
                dgvItemAdicionalND.CurrentRow.Cells["ivaAdd"].Value = 0;

            }
            else
            {
                dgvItemAdicionalND.CurrentRow.Cells["ivaAdd"].Value = Convert.ToDecimal(dgvItemAdicionalND.CurrentRow.Cells["PrecioTotalAdd"].Value) * (Login.iva_empresa);

            }
        }

        private void dgvItemAdicionalND_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            TbxMontoNota.Text = "0.00";
        }

        private void BttBusqND_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbl_Enc_NotaDebitVERTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Enc_NotaDebitVER, Convert.ToInt32(Login.Cod_PuntoVenta), DatePkIniND.Value.ToShortDateString(), DatePkFinND.Value);
            }
            catch { }
        }

        private void DatePkIniND_ValueChanged(object sender, EventArgs e)
        {
            DatePkFinND.MinDate = DatePkIniND.Value;
        }

        private void dataGridView8_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.tbl_Det_NotaDebitVERTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Det_NotaDebitVER, Convert.ToDecimal(dataGridView8.CurrentRow.Cells["corND"].Value));

            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView8.RowCount > 0)
                {
                    Cls_ReportHelper Reporte6 = new Cls_ReportHelper
                    {
                        TipoInforme = Convert.ToString(dataGridView8.CurrentRow.Cells["Tipo_DocND"].Value),
                        SerieDoc = Convert.ToString(dataGridView8.CurrentRow.Cells["SerieND"].Value),
                        NoDoc = Convert.ToDecimal(dataGridView8.CurrentRow.Cells["NotaND"].Value)
                    };
                    Reporte6.LlamaReporte();
                }
            }
            catch { }
        }

        private void BttVistaPrev_Click(object sender, EventArgs e)
        {
            if (ImpTurismo.Text == "" || ImpTurismo.Text == "." || ImpTurismo.Text == " ")
            {
                ImpTurismo.Text = "0.00";
            }
            Reportes datos = GenerarReporte();
            Reporte frm = new Reporte(datos);
            if (Cbx_TipoDoc.SelectedValue.ToString() == "SALCCF")
            {
            frm.TipReport = "CCF";
            }else{
            frm.TipReport = "FCF";
            }
            frm.Show();
        }

        private Reportes GenerarReporte()
        {
            Reportes facturacion = new Reportes();

            for (int r = 0; r < dgvDetFact.RowCount; r++)
            {
                try
                {
                    Reportes.Rep_Vista_PreviaRow row = facturacion.Rep_Vista_Previa.NewRep_Vista_PreviaRow();
                    if (string.IsNullOrWhiteSpace(Convert.ToString(dgvDetFact.Rows[r].Cells["Precio"].Value)) != true && string.IsNullOrWhiteSpace(Convert.ToString(dgvDetFact.Rows[r].Cells["Descripcion_User"].Value)) != true)
                    {
                        row.No_factura = Txt_Factura.Text;
                        row.Fecha = dateTimePicker1.Value;
                        row.Monto_Fact = Convert.ToDecimal(Txt_Total.Text);
                        row.Monto_Iva = Convert.ToDecimal(Txt_Iva.Text);
                        row.Monto_Per_Ret = Convert.ToDecimal(Txt_RetPer.Text);
                        row.VentaSujeta = Convert.ToDecimal(Txt_VentaSujeta.Text);
                        row.VentaGravada = Convert.ToDecimal(Txt_Total.Text) - (Convert.ToDecimal(Txt_VentaSujeta.Text) + Convert.ToDecimal(Txt_Iva.Text));
                        row.Cantidad = Convert.ToDecimal(1);
                        row.Precio = Convert.ToDecimal(dgvDetFact.Rows[r].Cells["Precio"].Value);
                        row.Precio_Total = Convert.ToDecimal(dgvDetFact.Rows[r].Cells["Total_Tarifa"].Value);
                        row.Descripcion_User = Convert.ToString(dgvDetFact.Rows[r].Cells["Descripcion_User"].Value);
                        row.sujeto = Convert.ToBoolean(0);
                        row.Nombre = Txt_NombreCliente.Text;
                        row.Direccion = Txt_Direccion.Text;
                        row.Nit = textBox3.Text;
                        row.Nrc = Txt_Nrc.Text;
                        row.Giro = Txt_Giro.Text;
                        row.EstadoExenta = Chk_Exenta.Checked;
                        row.ImpTurismo = Convert.ToDecimal(ImpTurismo.Text);
                        if (Chk_Exenta.Checked==true)
                        {
                            row.VentaExenta = Convert.ToDecimal(Txt_Total.Text) - (Convert.ToDecimal(Txt_VentaSujeta.Text) + Convert.ToDecimal(Txt_Iva.Text));
                        }else{
                        row.VentaExenta = Convert.ToDecimal(0);
                        }
                        facturacion.Rep_Vista_Previa.AddRep_Vista_PreviaRow(row);
                    } 

                }
                catch { }
            }

            

            for (int i = 0; i < dgvDetFacServicios.RowCount; i++)
            {
                try
                {
                    Reportes.Rep_Vista_PreviaRow row1 = facturacion.Rep_Vista_Previa.NewRep_Vista_PreviaRow();
                    if (string.IsNullOrWhiteSpace(Convert.ToString(dgvDetFacServicios.Rows[i].Cells["Precio1"].Value)) != true && string.IsNullOrWhiteSpace(Convert.ToString(dgvDetFacServicios.Rows[i].Cells["Descripcion"].Value)) != true)
                    {
                        //  Reportes.Rep_Vista_PreviaRow row = facturacion.Rep_Vista_Previa.NewRep_Vista_PreviaRow();
                        row1.No_factura = Txt_Factura.Text;
                        row1.Fecha = dateTimePicker1.Value;
                        row1.Monto_Fact = Convert.ToDecimal(Txt_Total.Text);
                        row1.Monto_Iva = Convert.ToDecimal(Txt_Iva.Text);
                        row1.Monto_Per_Ret = Convert.ToDecimal(Txt_RetPer.Text);
                        row1.VentaSujeta = Convert.ToDecimal(Txt_VentaSujeta.Text);
                        row1.VentaGravada = Convert.ToDecimal(Txt_Total.Text) - (Convert.ToDecimal(Txt_VentaSujeta.Text) + Convert.ToDecimal(Txt_Iva.Text));
                        row1.Cantidad = Convert.ToDecimal(1);
                        row1.Precio = Convert.ToDecimal(dgvDetFacServicios.Rows[i].Cells["Precio1"].Value);
                        row1.Precio_Total = Convert.ToDecimal(dgvDetFacServicios.Rows[i].Cells["Precio_Total"].Value);
                        row1.Descripcion_User = Convert.ToString(dgvDetFacServicios.Rows[i].Cells["Descripcion"].Value);
                        row1.sujeto = Convert.ToBoolean(dgvDetFacServicios.Rows[i].Cells["sujeto"].Value);
                        row1.Nombre = Txt_NombreCliente.Text;
                        row1.Direccion = Txt_Direccion.Text;
                        row1.Nit = textBox3.Text;
                        row1.Nrc = Txt_Nrc.Text;
                        row1.Giro = Txt_Giro.Text;
                        row1.EstadoExenta = Chk_Exenta.Checked;
                        row1.ImpTurismo = Convert.ToDecimal(ImpTurismo.Text);
                        if (Chk_Exenta.Checked == true)
                        {
                            row1.VentaExenta = Convert.ToDecimal(Txt_Total.Text) - (Convert.ToDecimal(Txt_VentaSujeta.Text) + Convert.ToDecimal(Txt_Iva.Text));
                        }
                        else
                        {
                            row1.VentaExenta = Convert.ToDecimal(0);
                        }
                        facturacion.Rep_Vista_Previa.AddRep_Vista_PreviaRow(row1);
                    }
                }
                catch { }
            }

            return facturacion;

        }

        private void ImpTurismo_KeyUp(object sender, KeyEventArgs e)
        {
            Sumatoria();
        }

        private void ImpTurismo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
