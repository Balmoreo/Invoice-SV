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
using MD_Facturas.MODULO_FACT_VECADataSetTableAdapters;
using System.Globalization;

namespace MD_Facturas
{
    public partial class Configuraciones : Form
    {
        public string CodUsuarioLgn { get; set; }

        public Cls_Con con = new Cls_Con();
        int AddMon = 0;
        int AddImp = 0;
        int AddPv = 0;
        int AddService = 0;
        int AddTpDoc = 0;
        int z = 0;//validacion pais
        int z1 = 0;//validacion empresa
        int z2 = 0;//validacion usuario
        int z3 = 0;//validacion empleado
        int z4 = 0; // validacion servicios
        int z5 = 0; //validacion tipo doc
        public string TpInf { get; set; }

        public Configuraciones()
        {
            InitializeComponent();
        }

        private void Configuraciones_Load(object sender, EventArgs e)
        {
            ActualizacionesDataSet();//carga de la informacion a los dataset
            cobUsuarioDoc.SelectedValue =Convert.ToInt32(CodUsuarioLgn);

        }

        public void ActualizacionesDataSet() {
            try
            {
                this.tbl_UsuariosTpDocTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_UsuariosTpDoc);
                this.tbl_PaisTpDocGralTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_PaisTpDocGral);
                this.tbl_PaisUsuarioTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_PaisUsuario);
                this.tbl_PaisEmpleadoTableAdapter.Fill(this.mODULO_FACT_VECADataSet2.Tbl_PaisEmpleado);
                this.tbl_EmpresaServiciosTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_EmpresaServicios);
                this.tbl_Pais2TableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Pais2);
                this.tbl_Pais1TableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Pais1);
                this.tbl_ContribuyenteTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Contribuyente);
                this.tbl_Tipo_ClienteTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Tipo_Cliente);
            }
            catch { }
        }

        ////////////Informacion general de Pais, Moneda e Impuestos//////////

        //Datos de pais
        private void Btt_Guardar_Click(object sender, EventArgs e)
        {//codigo para agregar pais
            if (MessageBox.Show("Estas seguro de agregar un nuevo Registro", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ValidarPais();
                if(z!=1){
                this.tbl_PaisTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Pais, Txt_NombrePais.Text);
                try
                {
                    if (mODULO_FACT_VECADataSet.Tbl_Pais.Rows.Count != 1)
                    {
                        this.tbl_PaisTableAdapter1.Insertar(Txt_NombrePais.Text, Txt_Nacionalidad.Text, Txt_AbrevPais.Text);
                        this.tbl_PaisTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Pais, Txt_NombrePais.Text);
                        if (mODULO_FACT_VECADataSet.Tbl_Pais.Rows.Count == 1)
                        {
                            foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_Pais)
                            {
                                Txt_CodPais.Text = Convert.ToString(row["Cod_Pais"]);
                                Txt_Nacionalidad.Text = Convert.ToString(row["Nacionalidad"]);
                                Txt_AbrevPais.Text = Convert.ToString(row["Iniciales"]);
                                Txt_NombrePais.Text = Convert.ToString(row["Nombre_Pais"]);
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_Pais)
                        {
                            Txt_CodPais.Text = Convert.ToString(row["Cod_Pais"]);
                            Txt_Nacionalidad.Text = Convert.ToString(row["Nacionalidad"]);
                            Txt_AbrevPais.Text = Convert.ToString(row["Iniciales"]);
                            Txt_NombrePais.Text = Convert.ToString(row["Nombre_Pais"]);
                        }
                    }  
                //codigo para agregar moneda e impuestos  
                    this.tbl_PaisTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Pais, Txt_NombrePais.Text);
                    if (mODULO_FACT_VECADataSet.Tbl_Pais.Rows.Count == 1)
                    {
                        int i = 0;
                        for (i = 0; i < DataGridMoneda.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(DataGridMoneda.Rows[i].Cells["Cod_Moneda"].Value) < 1000)
                            {
                                this.tbl_MonedaCursoTableAdapter.Insertar(Convert.ToInt32(Txt_CodPais.Text), Convert.ToString(DataGridMoneda.Rows[i].Cells["Codigo_Ref"].Value), Convert.ToString(DataGridMoneda.Rows[i].Cells["Nombre_Moneda"].Value), Convert.ToInt32(DataGridMoneda.Rows[i].Cells["Tasa_Conv_USD"].Value));
                            }
                        }
                        AddMon = 0;
                    }
                    else
                    {
                        Cls_Helper.MostrarMensaje("Seleccione un pais ", "Datos faltantes", 0);
                    }        
                    this.tbl_PaisTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Pais, Txt_NombrePais.Text);
                    if (mODULO_FACT_VECADataSet.Tbl_Pais.Rows.Count == 1)
                    {
                        int i = 0;
                        for (i = 0; i < DataGridImpuestos.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(DataGridImpuestos.Rows[i].Cells["Cod_Impuesto"].Value) < 1000)
                            {
                                this.tbl_ImpuestoTableAdapter.Insertar(Convert.ToString(DataGridImpuestos.Rows[i].Cells["Cod_Ref"].Value), Convert.ToString(DataGridImpuestos.Rows[i].Cells["Nombre_Imp"].Value), Convert.ToInt32(DataGridImpuestos.Rows[i].Cells["Valor_Imp"].Value), Convert.ToBoolean(DataGridImpuestos.Rows[i].Cells["Porcentaje"].Value), Convert.ToBoolean(DataGridImpuestos.Rows[i].Cells["Sujeto"].Value), Convert.ToBoolean(DataGridImpuestos.Rows[i].Cells["Gravado"].Value), Convert.ToString(Convert.ToDateTime(DataGridImpuestos.Rows[i].Cells["validez"].Value)), Convert.ToInt32(Txt_CodPais.Text));
                            }
                        }
                        AddImp = 0;
                    }
                    else
                    {
                        Cls_Helper.MostrarMensaje("Seleccione un pais ", "Datos faltantes", 0);
                    }
                    Cls_Helper.MostrarMensaje("Registro Agregado exitosamente", "Datos Agregados", 0);
                    ActualizacionesDataSet();
                }
                catch { }
            }
            }
            z = 0;

        }

        public void ValidarPais()
        {
            int i = 0;
            for (i = 0; i < DataGridMoneda.Rows.Count; i++)
            {
                if (this.DataGridMoneda.Rows[i].Cells["Codigo_Ref"].Value == null)
                {
                    z = 1;
                    MessageBox.Show("Registro Vacio Codigo Referencia ! ");
                      break;
                }
                else if (this.DataGridMoneda.Rows[i].Cells["Nombre_Moneda"].Value == null)
                {
                    z = 1;
                    MessageBox.Show("Registro Vacio Nombre Moneda ! ");
                       break;
                }
                else if (this.DataGridMoneda.Rows[i].Cells["Tasa_Conv_USD"].Value == null)
                {
                    z = 1;
                    MessageBox.Show("Registro Vacio Tasa conv! ");
                   break;
                }
            }

   
            int j = 0;
            for (j = 0; j < DataGridImpuestos.Rows.Count; j++)
            {
                if (DataGridImpuestos.Rows[j].Cells["Cod_Ref"].Value == null)
                {
                    z = 1;
                    MessageBox.Show("Registro Vacio Codigo Referencia ! ");
                        break;
                }
                else if (DataGridImpuestos.Rows[j].Cells["Nombre_Imp"].Value == null)
                {
                    z = 1;
                    MessageBox.Show("Registro Vacio Nombre Impuesto ! ");
                          break;
                }
                else if (DataGridImpuestos.Rows[j].Cells["Valor_Imp"].Value == null)
                {
                    z = 1;
                    MessageBox.Show("Registro Vacio Valor Imp! ");
                   break;
                }
                else if (DataGridImpuestos.Rows[j].Cells["validez"].Value == null)
                {
                    z = 1;
                    MessageBox.Show("Registro Vacio Validez! ");
                   break;
                }
            }
            if (Txt_NombrePais.Text == "")
            {
                z = 1;
                MessageBox.Show("Registro Vacio Nombre de pais ! ");
            }
            else if (Txt_Nacionalidad.Text == "")
            {
                z = 1;
                MessageBox.Show("Registro Vacio Nacionalidad ! ");
            }
            else if (Txt_AbrevPais.Text == "")
            {
                z = 1;
                MessageBox.Show("Registro Vacio Iniciales ! ");
            }
        }

        private void Txt_NombrePais_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Txt_NombrePais.TextLength > 4)
                {
                    SqlParameter[] p = { new SqlParameter("@NombrePais", SqlDbType.VarChar) { Value = Cls_Helper.BusquedaPro(Txt_NombrePais) } };
                    Cls_Helper.AutoCompletar(Txt_NombrePais, con.GetDataTable("SELECT * FROM TBL_pais WHERE Nombre_Pais LIKE @NombrePais", con.conexion, p), "Nombre_Pais", "Cod_Pais");
                }
            }
            catch { }
        }

        private void Txt_NombrePais_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Txt_NombrePais.Text = Txt_NombrePais.Text.Remove(Txt_NombrePais.Text.LastIndexOf('|')).Trim();
                    this.tbl_PaisTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Pais, Txt_NombrePais.Text);
                    if (mODULO_FACT_VECADataSet.Tbl_Pais.Rows.Count == 1)
                    {
                        //llena el formulario con resultado 
                        foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_Pais)
                        {
                            Txt_CodPais.Text = Convert.ToString(row["Cod_Pais"]);
                            Txt_Nacionalidad.Text = Convert.ToString(row["Nacionalidad"]);
                            Txt_AbrevPais.Text = Convert.ToString(row["Iniciales"]);
                            Txt_NombrePais.Text = Convert.ToString(row["Nombre_Pais"]);

                            this.tbl_MonedaCursoTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_MonedaCurso, Convert.ToInt32(Txt_CodPais.Text));
                            DataGridMoneda.DataSource = mODULO_FACT_VECADataSet.Tbl_MonedaCurso;

                            this.tbl_ImpuestoTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Impuesto, Convert.ToInt32(Txt_CodPais.Text));
                            DataGridImpuestos.DataSource = mODULO_FACT_VECADataSet.Tbl_Impuesto;
                            AddMon = 0;
                            AddImp = 0;
                        }
                    }
                  }
            }
            catch { }
        }

        private void Btt_Agregar_Click(object sender, EventArgs e)//agregar datos de impuestos
        {
            try
            {
                decimal Vimp = Convert.ToDecimal(Txt_ValorImp.Text);

                if (Txt_CodPais.Text == "" && Txt_CodRefImp.Text != "" && Txt_NombreImpuesto.Text != "")
                {
                    DataGridImpuestos.Rows.Add(Txt_CodRefImp.Text, Txt_NombreImpuesto.Text, Vimp, Ck_PorcentajeImp.Checked, Rbtt_Sujeto.Checked, Rbbt_Gravado.Checked, DateValidez.Value, AddImp);
                }
                else if (Txt_CodRefImp.Text != "" && Txt_NombreImpuesto.Text!="")
                {
                    this.tbl_PaisTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Pais, Txt_NombrePais.Text);
                    DataTable dt = (DataTable)DataGridImpuestos.DataSource;
                    DataRow row = dt.NewRow();
                    row["Cod_Ref"] = Txt_CodRefImp.Text;
                    row["Nombre_Imp"] = Txt_NombreImpuesto.Text;
                    row["Valor_Imp"] = Vimp;
                    row["Porcentaje"] = Ck_PorcentajeImp.Checked;
                    row["Sujeto"] = Rbtt_Sujeto.Checked;
                    row["Gravado"] = Rbbt_Gravado.Checked;
                    row["validez"] = DateValidez.Value;               
                    row["Cod_Impuesto"] = AddImp;
                    dt.Rows.Add(row);
                    DataGridImpuestos.DataSource = dt;
                   
                }
                AddImp++;
            }
            catch { }
        }

        private void BttAgregarMon_Click(object sender, EventArgs e)//agregar datos de moneda
        {
            try
            {
                decimal Tc = Convert.ToDecimal(Txt_TasaConv.Text);
                if (Txt_CodPais.Text == "" && Txt_NbMoneda.Text != "" && Txt_CodRefMon.Text != "")
                {
                    DataGridMoneda.Rows.Add(Txt_NbMoneda.Text, Tc, Txt_CodRefMon.Text, AddMon);
                }

                else if (Txt_NbMoneda.Text != "" && Txt_CodRefMon.Text!="")
                {
                    this.tbl_PaisTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Pais, Txt_NombrePais.Text);
                    DataTable dt = (DataTable)DataGridMoneda.DataSource;
                    DataRow row = dt.NewRow();
                    row["Nombre_Moneda"] = Txt_NbMoneda.Text;
                    row["Tasa_Conv_USD"] = Tc;
                    row["Codigo_Ref"] = Txt_CodRefMon.Text;
                    row["Cod_Moneda"] = AddMon;
                    dt.Rows.Add(row);
                    DataGridMoneda.DataSource = dt;
                    
                }
                AddMon++;
            }
            catch { }

        }


        private void Btt_Actualizar_Click(object sender, EventArgs e)//Boton actualizar
        {
            if (MessageBox.Show("Estas seguro que Modificar la Informacion", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ValidarPais();
                if (z != 1)
                {
                    try
                    {
                        this.tbl_PaisTableAdapter1.Modificar(Txt_NombrePais.Text, Txt_Nacionalidad.Text, Txt_AbrevPais.Text, Convert.ToInt32(Txt_CodPais.Text));
                        this.tbl_PaisTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Pais, Txt_NombrePais.Text);
                        if (mODULO_FACT_VECADataSet.Tbl_Pais.Rows.Count == 1)
                        {
                            foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_Pais)
                            {
                                Txt_CodPais.Text = Convert.ToString(row["Cod_Pais"]);
                                Txt_Nacionalidad.Text = Convert.ToString(row["Nacionalidad"]);
                                Txt_AbrevPais.Text = Convert.ToString(row["Iniciales"]);
                                Txt_NombrePais.Text = Convert.ToString(row["Nombre_Pais"]);
                            }
                        }


                        //      this.tbl_PaisTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Pais, Txt_NombrePais.Text);
                        if (mODULO_FACT_VECADataSet.Tbl_Pais.Rows.Count == 1)
                        {
                            int i = 0;
                            for (i = 0; i < DataGridMoneda.Rows.Count; i++)
                            {
                                this.tbl_MonedaCursoTableAdapter.ModificarMon(Convert.ToString(DataGridMoneda.Rows[i].Cells["Codigo_Ref"].Value), Convert.ToString(DataGridMoneda.Rows[i].Cells["Nombre_Moneda"].Value), Convert.ToInt32(DataGridMoneda.Rows[i].Cells["Tasa_Conv_USD"].Value), Convert.ToInt32(DataGridMoneda.Rows[i].Cells["Cod_Moneda"].Value));
                            }
                            AddMon = 0;
                        }
                        else
                        {
                            Cls_Helper.MostrarMensaje("Seleccione un pais para actualizar datos de moneda ", "Datos faltantes", 0);
                        }

                        //                this.tbl_PaisTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Pais, Txt_NombrePais.Text);
                        if (mODULO_FACT_VECADataSet.Tbl_Pais.Rows.Count == 1)
                        {
                            int i = 0;
                            for (i = 0; i < DataGridImpuestos.Rows.Count; i++)
                            {
                                this.tbl_ImpuestoTableAdapter.ModificarIMP(Convert.ToString(DataGridImpuestos.Rows[i].Cells["Cod_Ref"].Value), Convert.ToString(DataGridImpuestos.Rows[i].Cells["Nombre_Imp"].Value), Convert.ToInt32(DataGridImpuestos.Rows[i].Cells["Valor_Imp"].Value), Convert.ToBoolean(DataGridImpuestos.Rows[i].Cells["Porcentaje"].Value), Convert.ToBoolean(DataGridImpuestos.Rows[i].Cells["Sujeto"].Value), Convert.ToBoolean(DataGridImpuestos.Rows[i].Cells["Gravado"].Value), Convert.ToString(Convert.ToDateTime(DataGridImpuestos.Rows[i].Cells["validez"].Value)), Convert.ToInt32(DataGridImpuestos.Rows[i].Cells["Cod_Impuesto"].Value));
                            }
                            AddImp = 0;
                        }
                        else
                        {
                            Cls_Helper.MostrarMensaje("Seleccione un pais Para actualizar datos de impuestos ", "Datos faltantes", 0);
                        }
                        Cls_Helper.MostrarMensaje("Informacion modificada exitosamente", "Datos Modificados", 0);
                        this.tbl_MonedaCursoTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_MonedaCurso, Convert.ToInt32(Txt_CodPais.Text));
                        DataGridMoneda.DataSource = mODULO_FACT_VECADataSet.Tbl_MonedaCurso;

                        this.tbl_ImpuestoTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Impuesto, Convert.ToInt32(Txt_CodPais.Text));
                        DataGridImpuestos.DataSource = mODULO_FACT_VECADataSet.Tbl_Impuesto;

                        ActualizacionesDataSet();
                    }
                    catch { }
                }
            }
            z = 0;
        }
                private void DataGridMoneda_CellClick(object sender, DataGridViewCellEventArgs e)
                   {
                       try
                       {
                           if (e.RowIndex >= 0)
                           {

                               if (this.DataGridMoneda.Columns[e.ColumnIndex].Name == "Eliminar")
                               {
                                   if (MessageBox.Show("Estas seguro que Eliminar Registro", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                   {
                                       this.tbl_MonedaCursoTableAdapter.Eliminar(Convert.ToInt32(DataGridMoneda.Rows[e.RowIndex].Cells["Cod_Moneda"].Value), Convert.ToInt32(Txt_CodPais.Text));

                                       this.tbl_MonedaCursoTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_MonedaCurso, Convert.ToInt32(Txt_CodPais.Text));
                                       DataGridMoneda.DataSource = mODULO_FACT_VECADataSet.Tbl_MonedaCurso;
                                   }
                               }
                           }
                       }
                       catch { }
                  }



                private void DataGridImpuestos_CellClick(object sender, DataGridViewCellEventArgs e)
                {
                    try
                    {

                    if (e.RowIndex >= 0)
                    {

                            if (this.DataGridImpuestos.Columns[e.ColumnIndex].Name == "EliminarImp")
                            {
                                if (MessageBox.Show("Estas seguro que Eliminar Registro", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                this.tbl_ImpuestoTableAdapter.EliminarImp(Convert.ToInt32(DataGridImpuestos.Rows[e.RowIndex].Cells["Cod_Impuesto"].Value), Convert.ToInt32(Txt_CodPais.Text));

                                this.tbl_ImpuestoTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Impuesto, Convert.ToInt32(Txt_CodPais.Text));
                                DataGridImpuestos.DataSource = mODULO_FACT_VECADataSet.Tbl_Impuesto;
                                }
                             }
                    }
                    }
                    catch { }
                }


                private void Btt_Cancelar_Click(object sender, EventArgs e)
                {
                    Close();
                }
                private void BttLimpiarPais_Click(object sender, EventArgs e)
                {
                    try
                    {
                        Cls_Helper.LimpiarCampos(GrpPais);
                        Cls_Helper.LimpiarCampos(GrpMoneda);
                        Cls_Helper.LimpiarCampos(Gb_Impuesto);
                        int i = 0;
                        int j = 0;
                        for (i = 0; i < DataGridMoneda.Rows.Count; i++)
                        {
                            this.DataGridMoneda.Rows.RemoveAt(i);
                        }
                        for (j = 0; j < DataGridImpuestos.Rows.Count; j++)
                        {
                            this.DataGridImpuestos.Rows.RemoveAt(j);
                        }
                    }
                    catch { }
                }


                /////////////////////Datos de tipo cliente y contribuyente

                private void CbxPaisConfig_SelectedIndexChanged(object sender, EventArgs e){
                
                    try{
                    tbl_Cont_SelectTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Cont_Select, Convert.ToInt32(CbxPaisConfig.SelectedValue));
                    tbl_Tipo_Cliente_ConfigTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Tipo_Cliente_Config, Convert.ToInt32(CbxPaisConfig.SelectedValue));
                    }
                    catch { }

                }




                private void button3_Click(object sender, EventArgs e)
          {
                    if (MessageBox.Show("Estas seguro de agregar un nuevo Registro", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            if (Rbbt_TipoCliente.Checked == true && Txt_TipoCliente.Text != "")
                            {
                                this.tbl_Tipo_ClienteTableAdapter.Insertar(Txt_TipoCliente.Text, Convert.ToInt32(CbxPaisConfig.SelectedValue));
                                tbl_Tipo_Cliente_ConfigTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Tipo_Cliente_Config, Convert.ToInt32(CbxPaisConfig.SelectedValue));
                            }
                            if (Rbbt_TipoContr.Checked == true && Txt_nombreCOntri.Text != "")
                            {
                                this.tbl_ContribuyenteTableAdapter.Insertar(Txt_nombreCOntri.Text, Convert.ToInt32(CbxPaisConfig.SelectedValue));
                                tbl_Cont_SelectTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Cont_Select, Convert.ToInt32(CbxPaisConfig.SelectedValue));
                            }

                            Cls_Helper.MostrarMensaje("Registro Agregado", "Datos", 0);
                            ActualizacionesDataSet();
                        }
                        catch { }
                    }
        }

        private void Cbox_TipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Txt_TipoCliente.Text = Cbox_TipoCliente.Text;
            Txt_CodTpCliente.Text = Convert.ToString(Cbox_TipoCliente.SelectedValue);
        }

        private void button2_Click(object sender, EventArgs e)//modificar datos de cliente y contribuyecte
        {
            if (MessageBox.Show("Estas seguro que Modificar la Informacion", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (Rbbt_TipoCliente.Checked == true && Txt_CodTpCliente.Text != "")
                    {
                        this.tbl_Tipo_ClienteTableAdapter.Modificar(Txt_TipoCliente.Text, Convert.ToInt32(Txt_CodTpCliente.Text));
                        this.tbl_Tipo_Cliente_ConfigTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Tipo_Cliente_Config, Convert.ToInt32(CbxPaisConfig.SelectedValue));
                    }
                    if (Rbbt_TipoContr.Checked == true && Txt_TpContri.Text != "")
                    {
                        this.tbl_ContribuyenteTableAdapter.Modificar(Txt_nombreCOntri.Text, Convert.ToInt32(CbxPaisConfig.SelectedValue), Convert.ToInt32(Txt_TpContri.Text));
                        this.tbl_Cont_SelectTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Cont_Select, Convert.ToInt32(CbxPaisConfig.SelectedValue));
                    }
                    Cls_Helper.MostrarMensaje("Registro Modificado", "Datos Modificados", 0);
                    ActualizacionesDataSet();
                }
                catch { }
            }

        }

        private void BttLimpiarTCli_Click(object sender, EventArgs e)
        {
            Cls_Helper.LimpiarCampos(Gbox_TipoCliente);
            Cls_Helper.LimpiarCampos(Gbox_TipoCont);

        }

        private void EliminaTpoCC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro desea Eliminar la Informacion", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {


                    if (Rbbt_TipoCliente.Checked == true && Txt_CodTpCliente.Text != "")
                    {
                        this.tbl_Tipo_ClienteTableAdapter.DeleteQuery(Convert.ToInt32(Txt_CodTpCliente.Text));
                        tbl_Tipo_Cliente_ConfigTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Tipo_Cliente_Config, Convert.ToInt32(CbxPaisConfig.SelectedValue));
                    }
                    if (Rbbt_TipoContr.Checked == true && Txt_TpContri.Text != "")
                    {
                        this.tbl_ContribuyenteTableAdapter.EliminarCont(Convert.ToInt32(Txt_TpContri.Text));
                        tbl_Cont_SelectTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Cont_Select, Convert.ToInt32(CbxPaisConfig.SelectedValue));
                    }
                }
                catch { }
            }

        }


        //////////////////Datos de servicios
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (Txt_codServi.Text != "" && txtDescripService.Text != "" && Txt_NotaService.Text!="")
                {
                    DataTable dt = (DataTable)DataGridService.DataSource;
                    DataRow row = dt.NewRow();
                    row["Cod_Servicio"] = Txt_codServi.Text;
                    row["Cod_Descripcion"] = txtDescripService.Text;
                    row["Nota"] = Txt_NotaService.Text;
                    row["Estado"] = CkServicio.Checked;
                    row["FechaCreacion"] = Convert.ToDateTime(DateService.Value);
                    row["Id_Servicio"] = AddService;
                    dt.Rows.Add(row);
                    DataGridService.DataSource = dt;
                    AddService++;
                }
            //    }
            }
            catch { }
        }

        ////////////////datos de empresa

        private void BttAgrPV_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbl_EmpresaTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Empresa, Txt_NombreEmpresa.Text);
                if (mODULO_FACT_VECADataSet.Tbl_Empresa.Rows.Count != 1 && Txt_NbPuntoVen.Text != "" && Txt_TelefonoPV.Text != "" && TxtDireccionPV.Text != "" && Txt_EncargadoPV.Text != "")
                {
                    DataGrid_PuntoVen.Rows.Add(Txt_NbPuntoVen.Text, TxtDireccionPV.Text, Txt_TelefonoPV.Text, Txt_EncargadoPV.Text, FechaPV.Value, AddPv);
                }
                else if (Txt_NbPuntoVen.Text != "" && Txt_TelefonoPV.Text != "" && TxtDireccionPV.Text != "" && Txt_EncargadoPV.Text!="")
                {
                    DataTable dt = (DataTable)DataGrid_PuntoVen.DataSource;
                    DataRow row = dt.NewRow();
                    row["Nombre_Punto"] = Txt_NbPuntoVen.Text;
                    row["TelefonoPv"] = Txt_TelefonoPV.Text;
                    row["Direccion"] = TxtDireccionPV.Text;
                    row["Encargado"] = Txt_EncargadoPV.Text;
                    row["Fecha"] = Convert.ToDateTime(FechaPV.Value);
                    row["Cod_Punto_Venta"] = AddPv;
                    dt.Rows.Add(row);
                    DataGrid_PuntoVen.DataSource = dt;
                  
                }
                AddPv++;
            }
            catch { }

        }

        private void Txt_NombreEmpresa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Txt_NombreEmpresa.TextLength > 4)
                {
                    SqlParameter[] p = { new SqlParameter("@NombreEmpresa", SqlDbType.VarChar) { Value = Cls_Helper.BusquedaPro(Txt_NombreEmpresa) } };
                    Cls_Helper.AutoCompletar(Txt_NombreEmpresa, con.GetDataTable("SELECT * FROM TBL_Empresa WHERE Nombre_Comercial LIKE @NombreEmpresa", con.conexion, p), "Nombre_Comercial", "Cod_empresa");
                }
            }
            catch { }
        }

        private void Txt_NombreEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Txt_NombreEmpresa.Text = Txt_NombreEmpresa.Text.Remove(Txt_NombreEmpresa.Text.LastIndexOf('|')).Trim();
                    this.tbl_EmpresaTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Empresa, Txt_NombreEmpresa.Text);
                    if (mODULO_FACT_VECADataSet.Tbl_Empresa.Rows.Count == 1)
                    {
                        //llena el formulario con resultado 
                        foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_Empresa)
                        {
                            this.Txt_CodEmpresa.Text = Convert.ToString(row["Cod_empresa"]);
                            this.Txt_Direccion.Text = Convert.ToString(row["Direccion_empresa"]);
                            this.Txt_Telefono.Text = Convert.ToString(row["Telefono_Empresa"]);
                            this.Txt_RazonSocial.Text = Convert.ToString(row["Razon_Social"]);
                            this.Txt_Nrc.Text = Convert.ToString(row["Nrc"]);
                            this.Mtxt_Nit.Text = Convert.ToString(row["Nit"]);
                            this.Cbx_Pais.SelectedValue = Convert.ToInt32(row["Cod_Pais"]);
                            this.Cbx_TipoContr.SelectedValue = Convert.ToInt32(row["Id_Tipo_Contribuyecte"]);
                            this.DateEmpresa.Value = Convert.ToDateTime(row["Fecha"]);

                            this.tbl_Punto_VentaTableAdapter1.Fill(this.mODULO_FACT_VECADataSet.Tbl_Punto_Venta, Convert.ToInt32(Txt_CodEmpresa.Text));
                            DataGrid_PuntoVen.DataSource = mODULO_FACT_VECADataSet.Tbl_Punto_Venta;
                            AddPv = 0;
                        }
                    }
                }
            }
            catch { }
        }

        private void BttGrabarEmpresa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que Agregar Un nuevo Registro", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ValidarEmpresa();
                if (z1 != 1)
                {
                    this.tbl_EmpresaTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Empresa, Txt_NombreEmpresa.Text);
                    try
                    {
                        if (mODULO_FACT_VECADataSet.Tbl_Empresa.Rows.Count != 1)
                        {
                            this.tbl_EmpresaTableAdapter1.InsertarEmpresa(Txt_Direccion.Text, Convert.ToInt32(Cbx_Pais.SelectedValue), Txt_RazonSocial.Text, Txt_NombreEmpresa.Text, Txt_Telefono.Text, Mtxt_Nit.Text, Txt_Nrc.Text, Convert.ToInt32(Cbx_TipoContr.SelectedValue), Convert.ToString(Convert.ToDateTime(DateEmpresa.Value)));
                            this.tbl_EmpresaTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Empresa, Txt_NombreEmpresa.Text);
                            if (mODULO_FACT_VECADataSet.Tbl_Empresa.Rows.Count == 1)
                            {
                                foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_Empresa)
                                {
                                    this.Txt_CodEmpresa.Text = Convert.ToString(row["Cod_empresa"]);
                                    this.Txt_Direccion.Text = Convert.ToString(row["Direccion_empresa"]);
                                    this.Txt_Telefono.Text = Convert.ToString(row["Telefono_Empresa"]);
                                    this.Txt_RazonSocial.Text = Convert.ToString(row["Razon_Social"]);
                                    this.Txt_Nrc.Text = Convert.ToString(row["Nrc"]);
                                    this.Mtxt_Nit.Text = Convert.ToString(row["Nit"]);
                                    this.Cbx_Pais.SelectedValue = Convert.ToInt32(row["Cod_Pais"]);
                                    this.Cbx_TipoContr.SelectedValue = Convert.ToInt32(row["Id_Tipo_Contribuyecte"]);
                                    this.DateEmpresa.Value = Convert.ToDateTime(row["Fecha"]);
                                }
                            }
                        }
                        else
                        {
                            foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_Empresa)
                            {
                                this.Txt_CodEmpresa.Text = Convert.ToString(row["Cod_empresa"]);
                                this.Txt_Direccion.Text = Convert.ToString(row["Direccion_empresa"]);
                                this.Txt_Telefono.Text = Convert.ToString(row["Telefono_Empresa"]);
                                this.Txt_RazonSocial.Text = Convert.ToString(row["Razon_Social"]);
                                this.Txt_Nrc.Text = Convert.ToString(row["Nrc"]);
                                this.Mtxt_Nit.Text = Convert.ToString(row["Nit"]);
                                this.Cbx_Pais.SelectedValue = Convert.ToInt32(row["Cod_Pais"]);
                                this.Cbx_TipoContr.SelectedValue = Convert.ToInt32(row["Id_Tipo_Contribuyecte"]);
                                this.DateEmpresa.Value = Convert.ToDateTime(row["Fecha"]);
                            }
                        }

                        this.tbl_EmpresaTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Empresa, Txt_NombreEmpresa.Text);
                        if (mODULO_FACT_VECADataSet.Tbl_Empresa.Rows.Count == 1)
                        {
                            int i = 0;
                            for (i = 0; i < this.DataGrid_PuntoVen.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(DataGrid_PuntoVen.Rows[i].Cells["CodPunto"].Value) < 300)
                                {
                                    this.tbl_Punto_VentaTableAdapter1.InsertarPV(Convert.ToInt32(Txt_CodEmpresa.Text), Convert.ToString(DataGrid_PuntoVen.Rows[i].Cells["Nombre_Punto"].Value), Convert.ToString(DataGrid_PuntoVen.Rows[i].Cells["TelefonoPv"].Value), Convert.ToString(DataGrid_PuntoVen.Rows[i].Cells["Direccion"].Value), Convert.ToString(DataGrid_PuntoVen.Rows[i].Cells["Encargado"].Value), Convert.ToString(Convert.ToDateTime(DataGrid_PuntoVen.Rows[i].Cells["Fecha"].Value)));
                                }
                            }
                            AddPv = 0;
                        }
                        else
                        {
                            Cls_Helper.MostrarMensaje("Seleccione una Empresa ", "Datos faltantes", 0);
                        }
                        Cls_Helper.MostrarMensaje("Informacion Agregada exitosamente", "Datos Agregados", 0);
                        ActualizacionesDataSet();
                    }
                    catch { }
                }
            }
            z1 = 0;
        }

        public void ValidarEmpresa()
        {
            int j = 0;
              for (j = 0; j < DataGrid_PuntoVen.Rows.Count; j++)
              {
                  if (DataGrid_PuntoVen.Rows[j].Cells["Nombre_Punto"].Value == null)
                  {
                      z1 = 1;
                      MessageBox.Show("Registro Vacio Nombre Punto ! ");
                      break;
                  }
                  else if (DataGrid_PuntoVen.Rows[j].Cells["TelefonoPv"].Value == null)
                  {
                      z1 = 1;
                      MessageBox.Show("Registro Vacio Nombre Telefono ! ");
                      break;
                  }
                  else if (DataGrid_PuntoVen.Rows[j].Cells["Direccion"].Value == null)
                  {
                      z1 = 1;
                      MessageBox.Show("Registro Vacio Direccion ! ");
                      break;
                  }
                  else if (DataGrid_PuntoVen.Rows[j].Cells["Encargado"].Value == null)
                  {
                      z1 = 1;
                      MessageBox.Show("Registro Vacio Encargado! ");
                      break;
                  }
                  else if (DataGrid_PuntoVen.Rows[j].Cells["Fecha"].Value == null)
                  {
                      z1 = 1;
                      MessageBox.Show("Registro Vacio Fecha ! ");
                      break;
                  }
              }

            if (Txt_Direccion.Text == "")
            {
                z1 = 1;
                MessageBox.Show("Registro Vacio Direccion ! ");
            }
            else if (Txt_RazonSocial.Text == "")
            {
                z1 = 1;
                MessageBox.Show("Registro Vacio Razon social ! ");
            }
            else if (Txt_NombreEmpresa.Text == "")
            {
                z1 = 1;
                MessageBox.Show("Registro Vacio Nombre Empresa! ");
            }
            else if (Txt_Telefono.Text == "")
            {
                z1 = 1;
                MessageBox.Show("Registro Vacio Telefono! ");
            }
            else if (Mtxt_Nit.Text == "")
            {
                z1 = 1;
                MessageBox.Show("Registro Vacio Nit! ");
            }
            else if (Txt_Nrc.Text == "")
            {
                z1 = 1;
                MessageBox.Show("Registro Vacio Nrc ! ");
            }
            else if (Cbx_TipoContr.SelectedValue== null)
            {
                z1 = 1;
                MessageBox.Show("Registro Vacio contribuyente! ");
            }
            
        }

        private void Cbx_Pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.tbl_Contribuyente1TableAdapter.Fill(this.mODULO_FACT_VECADataSet1.Tbl_Contribuyente1, Convert.ToInt32(Cbx_Pais.SelectedValue));
            }
            catch { }
        }

        private void DataGrid_PuntoVen_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (DataGrid_PuntoVen.Columns[e.ColumnIndex].Name == "Fecha" && e.FormattedValue.ToString().Length > 0)
                {
                    string fecha = e.FormattedValue.ToString();

                    CultureInfo es = new CultureInfo("en-US");
                    DateTime dateValue;

                    if (!DateTime.TryParseExact(fecha, "dd/MM/yyyy", es, DateTimeStyles.None, out dateValue))
                    {
                        MessageBox.Show("Formato de fecha incorrecto, asegurese de introducir el formato correcto. Ej.01/12/2014");
                        DataGrid_PuntoVen.Rows[e.RowIndex].ErrorText = "Formato de fecha incorrecto";
                        e.Cancel = true;
                    }
                }
            }
            catch { }
        }



        private void BttLimpiarEmpresa_Click(object sender, EventArgs e)
        {
            
            try
            {
                Cls_Helper.LimpiarCampos(Gb_DatosEmpresa);
               // Cls_Helper.LimpiarCampos(groupBoxTpDocGrl);
                int i = 0;
                for (i = 0; i < DataGrid_PuntoVen.Rows.Count; i++)
                {
                    this.DataGrid_PuntoVen.Rows.RemoveAt(i);
                }
            }
            catch { }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que Modificar la Informacion", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (z1 != 1)
                {
                    try
                    {
                        this.tbl_EmpresaTableAdapter1.ModificarEmpresa(Txt_Direccion.Text, Convert.ToInt32(Cbx_Pais.SelectedValue), Txt_RazonSocial.Text, Txt_NombreEmpresa.Text, Txt_Telefono.Text, Mtxt_Nit.Text, Txt_Nrc.Text, Convert.ToInt32(Cbx_TipoContr.SelectedValue), Convert.ToString(Convert.ToDateTime(DateEmpresa.Value)), Convert.ToInt32(Txt_CodEmpresa.Text));

                        this.tbl_EmpresaTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Empresa, Txt_NombreEmpresa.Text);
                        if (mODULO_FACT_VECADataSet.Tbl_Empresa.Rows.Count == 1)
                        {
                            foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_Empresa)
                            {
                                this.Txt_CodEmpresa.Text = Convert.ToString(row["Cod_empresa"]);
                                this.Txt_Direccion.Text = Convert.ToString(row["Direccion_empresa"]);
                                this.Txt_Telefono.Text = Convert.ToString(row["Telefono_Empresa"]);
                                this.Txt_RazonSocial.Text = Convert.ToString(row["Razon_Social"]);
                                this.Txt_Nrc.Text = Convert.ToString(row["Nrc"]);
                                this.Mtxt_Nit.Text = Convert.ToString(row["Nit"]);
                                this.Cbx_Pais.SelectedValue = Convert.ToInt32(row["Cod_Pais"]);
                                this.Cbx_TipoContr.SelectedValue = Convert.ToInt32(row["Id_Tipo_Contribuyecte"]);
                                this.DateEmpresa.Value = Convert.ToDateTime(row["Fecha"]);
                            }
                        }


                        if (mODULO_FACT_VECADataSet.Tbl_Empresa.Rows.Count == 1)
                        {
                            int i = 0;
                            for (i = 0; i < DataGrid_PuntoVen.Rows.Count; i++)
                            {
                                this.tbl_Punto_VentaTableAdapter1.ModificarPV(Convert.ToString(DataGrid_PuntoVen.Rows[i].Cells["Nombre_Punto"].Value), Convert.ToString(DataGrid_PuntoVen.Rows[i].Cells["TelefonoPv"].Value), Convert.ToString(DataGrid_PuntoVen.Rows[i].Cells["Direccion"].Value), Convert.ToString(DataGrid_PuntoVen.Rows[i].Cells["Encargado"].Value), Convert.ToString(Convert.ToDateTime(DataGrid_PuntoVen.Rows[i].Cells["Fecha"].Value)), Convert.ToInt32(DataGrid_PuntoVen.Rows[i].Cells["CodPunto"].Value), Convert.ToInt32(Txt_CodEmpresa.Text));

                            }
                            AddPv = 0;
                        }
                        else
                        {
                            Cls_Helper.MostrarMensaje("Seleccione una empresa para actualizar datos de punto de venta ", "Datos faltantes", 0);
                        }
                        Cls_Helper.MostrarMensaje("Informacion modificada exitosamente", "Datos Modificados", 0);
                        ActualizacionesDataSet();
                    }
                    catch { }
                }
            }
            z1 = 0;
        }

                private void button19_Click(object sender, EventArgs e)
        {
            Close();
        }

                private void Cbox_TipoContri_SelectedIndexChanged(object sender, EventArgs e)
                {
                    this.tbl_BusquedaContriTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_BusquedaContri, Convert.ToInt32(Cbox_TipoContri.SelectedValue));
                    if (mODULO_FACT_VECADataSet.Tbl_BusquedaContri.Rows.Count == 1)
                    {
                        foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_BusquedaContri)
                        {
                            this.Txt_TpContri.Text = Convert.ToString(row["Id_Tipo_Contribuyecte"]);
                            this.Txt_nombreCOntri.Text = Convert.ToString(row["Tipo_Contribuyente"]);
                           // this.Cbox_Pais.SelectedValue = Convert.ToInt32(row["Pais"]);

                        }
                    }
                }

                private void CbxEmpresaService_SelectedIndexChanged(object sender, EventArgs e)
                {
                    try
                    {
                        this.tbl_ServiciosConfigTableAdapter1.Fill(this.mODULO_FACT_VECADataSet.Tbl_ServiciosConfig, Convert.ToInt32(CbxEmpresaService.SelectedValue));
                        DataGridService.DataSource = mODULO_FACT_VECADataSet.Tbl_ServiciosConfig;
                        AddService = 0;
                    }
                    catch { }
                }

                private void BttGrabarService_Click(object sender, EventArgs e)
                {
                    if (MessageBox.Show("Estas seguro que Agregar un nuevo registro", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ValidarServicios();
                        if (z4 != 1)
                        {
                            try
                            {
                                //this.tbl_EmpresaTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Empresa, Txt_NombreEmpresa.Text);
                                if (Convert.ToInt32(CbxEmpresaService.SelectedValue) != 0)
                                {
                                    int i = 0;
                                    for (i = 0; i < this.DataGridService.Rows.Count; i++)
                                    {
                                        if (Convert.ToInt32(DataGridService.Rows[i].Cells["Id_Servicio"].Value) < 1000)
                                        {
                                            this.tbl_ServiciosConfigTableAdapter1.InsertarService(Convert.ToInt32(CbxEmpresaService.SelectedValue), Convert.ToString(DataGridService.Rows[i].Cells["Cod_Servicio"].Value), Convert.ToString(DataGridService.Rows[i].Cells["Cod_Descripcion"].Value), Convert.ToString(DataGridService.Rows[i].Cells["Nota"].Value), Convert.ToBoolean(DataGridService.Rows[i].Cells["Estado"].Value), Convert.ToString(Convert.ToDateTime(DataGridService.Rows[i].Cells["FechaCreacion"].Value)));
                                        }
                                    }
                                    AddService = 0;
                                }
                                else
                                {
                                    Cls_Helper.MostrarMensaje("Seleccione Una Empresa ", "Datos faltantes", 0);
                                }
                                ActualizacionesDataSet();
                            }
                            catch { }
                        }
                        z4 = 0;
                    }
                }


                public void ValidarServicios()
                {
                    int j = 0;
                    for (j = 0; j < DataGridService.Rows.Count; j++)
                    {
                        if (DataGridService.Rows[j].Cells["Cod_Servicio"].Value == null)
                        {
                            z4 = 1;
                            MessageBox.Show("Registro Vacio Codigo ! ");
                            break;
                        }
                        else if (DataGridService.Rows[j].Cells["Cod_Descripcion"].Value == null)
                        {
                            z4 = 1;
                            MessageBox.Show("Registro Vacio Descripcion! ");
                            break;
                        }
                        else if (DataGridService.Rows[j].Cells["Nota"].Value == null)
                        {
                            z4 = 1;
                            MessageBox.Show("Registro Vacio Nota ! ");
                            break;
                        }
                        else if (DataGridService.Rows[j].Cells["FechaCreacion"].Value == null)
                        {
                            z4 = 1;
                            MessageBox.Show("Registro Vacio Fecha! ");
                            break;
                        }
                        
                    }         

                }

                private void BttModificarServi_Click(object sender, EventArgs e)
                {
                    if (MessageBox.Show("Estas seguro que Modificar la Informacion", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                                if (Convert.ToInt32(CbxEmpresaService.SelectedValue) != 0)
                                {
                           
                                int i = 0;
                                for (i = 0; i < DataGridService.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(DataGridService.Rows[i].Cells["Id_Servicio"].Value) >= 1000)
                                    {
                                        this.tbl_ServiciosConfigTableAdapter1.ModificarServicio(Convert.ToString(DataGridService.Rows[i].Cells["Cod_Servicio"].Value), Convert.ToString(DataGridService.Rows[i].Cells["Cod_Descripcion"].Value), Convert.ToString(DataGridService.Rows[i].Cells["Nota"].Value), Convert.ToBoolean(DataGridService.Rows[i].Cells["Estado"].Value), Convert.ToString(Convert.ToDateTime(DataGridService.Rows[i].Cells["FechaCreacion"].Value)), Convert.ToInt32(DataGridService.Rows[i].Cells["Id_Servicio"].Value), Convert.ToInt32(CbxEmpresaService.SelectedValue));
                                    }
                                }
                                AddService = 0;
                            }
                            else
                            {
                                Cls_Helper.MostrarMensaje("Seleccione una empresa para actualizar los datos ", "Datos faltantes", 0);
                            }
                            Cls_Helper.MostrarMensaje("Informacion modificada exitosamente", "Datos Modificados", 0);
                            ActualizacionesDataSet();
                        }
                        catch { }
                    }
                 }

                private void TxtNombEMP_TextChanged(object sender, EventArgs e)
                {
                    try
                    {
                        if (TxtNombEMP.TextLength > 4)
                        {
                            SqlParameter[] p = { new SqlParameter("@NombreEmpleado", SqlDbType.VarChar) { Value = Cls_Helper.BusquedaPro(TxtNombEMP) } };
                            Cls_Helper.AutoCompletar(TxtNombEMP, con.GetDataTable("SELECT * FROM Tbl_Empleados WHERE Nombre LIKE @NombreEmpleado", con.conexion, p), "Nombre", "Id_Empleado");
                        }
                    }
                    catch { }
                }

                private void TxtNombEMP_KeyDown(object sender, KeyEventArgs e)
               {
                    try
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            TxtNombEMP.Text = TxtNombEMP.Text.Remove(TxtNombEMP.Text.LastIndexOf('|')).Trim();
                            tbl_EmpleadosConfigTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_EmpleadosConfig,TxtNombEMP.Text);
                           if (mODULO_FACT_VECADataSet.Tbl_EmpleadosConfig.Rows.Count == 1)
                            {
                                foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_EmpleadosConfig)
                                {
                                    this.TxtCodEmpleado.Text = Convert.ToString(row["Id_Empleado"]);
                                    this.TxtCodEMP.Text = Convert.ToString(row["Cod_Empleado"]);
                                    this.TxtNombEMP.Text = Convert.ToString(row["Nombre"]);
                                    this.TxtDirEMP.Text = Convert.ToString(row["Direccion"]);
                                    this.TxtTelEMP.Text = Convert.ToString(row["Telefono"]);
                                    this.TxtCargoEMP.Text = Convert.ToString(row["Cargo"]);
                                    this.TxtDepEMP.Text = Convert.ToString(row["Departamento"]);
                                    this.CboxPaisEmp.SelectedValue = Convert.ToInt32(row["Cod_Pais"]);
                                    this.tbl_EmpresaEmpleadoTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_EmpresaEmpleado, Convert.ToInt32(row["Cod_Pais"]));
                                    this.CmbEmpresaEMP.SelectedValue = Convert.ToInt32(row["Cod_Empresa"]);
                                    this.tbl_Punto_VentaEMPLEADOTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Punto_VentaEMPLEADO, Convert.ToInt32(row["Cod_Empresa"]));
                                    this.CbxPVEMP.SelectedValue = Convert.ToInt32(row["Cod_Punto_Venta"]);
                                    this.DateEMP.Value = Convert.ToDateTime(row["FechaEmp"]);

                                }
                            }
                        }
                    }
                    catch { }
                }

                private void CmbEmpresaEMP_SelectedIndexChanged(object sender, EventArgs e)
                {
                    try
                    {
                        this.tbl_Punto_VentaEMPLEADOTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Punto_VentaEMPLEADO, Convert.ToInt32(CmbEmpresaEMP.SelectedValue));
                    }
                    catch { }
                }

                private void CboxPaisEmp_SelectedIndexChanged(object sender, EventArgs e)
                {
                    try
                    {
                        this.tbl_EmpresaEmpleadoTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_EmpresaEmpleado, Convert.ToInt32(CboxPaisEmp.SelectedValue));
                    }
                    catch { }
                }

                private void BttLimpiarEMPL_Click(object sender, EventArgs e)
                {
                    Cls_Helper.LimpiarCampos(groupBoxEmpleados);
                }

                private void BttAgregarEMPL_Click(object sender, EventArgs e)
                {
        
                    if (MessageBox.Show("Estas seguro que Agregar Un nuevo Registro", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    { ValidarEmpleado();
                        if(z3!=1){
                        this.tbl_EmpleadosConfigTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_EmpleadosConfig, TxtNombEMP.Text);
                        try
                        {
                            if (mODULO_FACT_VECADataSet.Tbl_EmpleadosConfig.Rows.Count != 1)
                            {
                                this.tbl_EmpleadosConfigTableAdapter1.InsertarEmpleados(TxtCodEMP.Text, TxtNombEMP.Text, TxtDirEMP.Text, TxtTelEMP.Text, TxtCargoEMP.Text, Convert.ToInt32(CboxPaisEmp.SelectedValue), Convert.ToInt32(CmbEmpresaEMP.SelectedValue), Convert.ToInt32(CbxPVEMP.SelectedValue), TxtDepEMP.Text, Convert.ToString(Convert.ToDateTime(DateEMP.Value)));
                                this.tbl_EmpleadosConfigTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_EmpleadosConfig, TxtNombEMP.Text);
   
                                if (mODULO_FACT_VECADataSet.Tbl_EmpleadosConfig.Rows.Count == 1)
                                {
                                    foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_EmpleadosConfig)
                                    {
                                        this.TxtCodEmpleado.Text = Convert.ToString(row["Id_Empleado"]);
                                        this.TxtCodEMP.Text = Convert.ToString(row["Cod_Empleado"]);
                                        this.TxtNombEMP.Text = Convert.ToString(row["Nombre"]);
                                        this.TxtDirEMP.Text = Convert.ToString(row["Direccion"]);
                                        this.TxtTelEMP.Text = Convert.ToString(row["Telefono"]);
                                        this.TxtCargoEMP.Text = Convert.ToString(row["Cargo"]);
                                        this.TxtDepEMP.Text = Convert.ToString(row["Departamento"]);
                                        this.CboxPaisEmp.SelectedValue = Convert.ToInt32(row["Cod_Pais"]);
                                        this.tbl_EmpresaEmpleadoTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_EmpresaEmpleado, Convert.ToInt32(row["Cod_Pais"]));
                                        this.CmbEmpresaEMP.SelectedValue = Convert.ToInt32(row["Cod_Empresa"]);
                                        this.tbl_Punto_VentaEMPLEADOTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Punto_VentaEMPLEADO, Convert.ToInt32(row["Cod_Empresa"]));
                                        this.CbxPVEMP.SelectedValue = Convert.ToInt32(row["Cod_Punto_Venta"]);
                                        this.DateEMP.Value = Convert.ToDateTime(row["FechaEmp"]);

                                    }
                                }

                            }
                            else
                            {
                                foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_EmpleadosConfig)
                                {
                                    this.TxtCodEmpleado.Text = Convert.ToString(row["Id_Empleado"]);
                                    this.TxtCodEMP.Text = Convert.ToString(row["Cod_Empleado"]);
                                    this.TxtNombEMP.Text = Convert.ToString(row["Nombre"]);
                                    this.TxtDirEMP.Text = Convert.ToString(row["Direccion"]);
                                    this.TxtTelEMP.Text = Convert.ToString(row["Telefono"]);
                                    this.TxtCargoEMP.Text = Convert.ToString(row["Cargo"]);
                                    this.TxtDepEMP.Text = Convert.ToString(row["Departamento"]);
                                    this.CboxPaisEmp.SelectedValue = Convert.ToInt32(row["Cod_Pais"]);
                                    this.tbl_EmpresaEmpleadoTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_EmpresaEmpleado, Convert.ToInt32(row["Cod_Pais"]));
                                    this.CmbEmpresaEMP.SelectedValue = Convert.ToInt32(row["Cod_Empresa"]);
                                    this.tbl_Punto_VentaEMPLEADOTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Punto_VentaEMPLEADO, Convert.ToInt32(row["Cod_Empresa"]));
                                    this.CbxPVEMP.SelectedValue = Convert.ToInt32(row["Cod_Punto_Venta"]);
                                    this.DateEMP.Value = Convert.ToDateTime(row["FechaEmp"]);

                                }
                            }
                            ActualizacionesDataSet();
                        }
                        catch { }
                    }
                        z3=0;
                    }
                }

                public void ValidarEmpleado(){
                    try
                    {
                        if (TxtCodEMP.Text == "")
                        {
                            z3 = 1;
                            MessageBox.Show("Registro Vacio Codigo ! ");
                        }
                        else if (TxtNombEMP.Text == "")
                        {
                            z3 = 1;
                            MessageBox.Show("Registro Vacio Nombre ! ");
                        }
                        else if (TxtDirEMP.Text == "")
                        {
                            z3 = 1;
                            MessageBox.Show("Registro Vacio Direccion ! ");
                        }
                        else if (TxtTelEMP.Text == "")
                        {
                            z3 = 1;
                            MessageBox.Show("Registro Vacio Telefono! ");
                        }
                        else if (TxtCargoEMP.Text == "")
                        {
                            z3 = 1;
                            MessageBox.Show("Registro Vacio Cargo! ");
                        }
                        else if (TxtDepEMP.Text == "")
                        {
                            z3 = 1;
                            MessageBox.Show("Registro Vacio Departamento ! ");
                        }
                        else if (CmbEmpresaEMP.SelectedValue == null)
                        {
                            z3 = 1;
                            MessageBox.Show("Registro Vacio Empresa ! ");
                        }
                        else if (CbxPVEMP.SelectedValue == null)
                        {
                            z3 = 1;
                            MessageBox.Show("Registro Vacio Punto de ventas ! ");
                        }
                    }
                    catch { }

                }

                private void BttModificarEMPL_Click(object sender, EventArgs e)
                {
                    if (MessageBox.Show("Estas seguro que Modificar la Informacion", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            this.tbl_EmpleadosConfigTableAdapter1.ModificarEmpleado(TxtCodEMP.Text, TxtNombEMP.Text, TxtDirEMP.Text, TxtTelEMP.Text, TxtCargoEMP.Text, Convert.ToInt32(CboxPaisEmp.SelectedValue), Convert.ToInt32(CmbEmpresaEMP.SelectedValue), Convert.ToInt32(CbxPVEMP.SelectedValue), TxtDepEMP.Text, Convert.ToString(Convert.ToDateTime(DateEMP.Value)), Convert.ToInt32(TxtCodEmpleado.Text));
                         
                            this.tbl_EmpleadosConfigTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_EmpleadosConfig, TxtNombEMP.Text);

                            if (mODULO_FACT_VECADataSet.Tbl_EmpleadosConfig.Rows.Count == 1)
                            {
                                foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_EmpleadosConfig)
                                {
                                    this.TxtCodEmpleado.Text = Convert.ToString(row["Id_Empleado"]);
                                    this.TxtCodEMP.Text = Convert.ToString(row["Cod_Empleado"]);
                                    this.TxtNombEMP.Text = Convert.ToString(row["Nombre"]);
                                    this.TxtDirEMP.Text = Convert.ToString(row["Direccion"]);
                                    this.TxtTelEMP.Text = Convert.ToString(row["Telefono"]);
                                    this.TxtCargoEMP.Text = Convert.ToString(row["Cargo"]);
                                    this.TxtDepEMP.Text = Convert.ToString(row["Departamento"]);
                                    this.CboxPaisEmp.SelectedValue = Convert.ToInt32(row["Cod_Pais"]);
                                    this.tbl_EmpresaEmpleadoTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_EmpresaEmpleado, Convert.ToInt32(row["Cod_Pais"]));
                                    this.CmbEmpresaEMP.SelectedValue = Convert.ToInt32(row["Cod_Empresa"]);
                                    this.tbl_Punto_VentaEMPLEADOTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Punto_VentaEMPLEADO, Convert.ToInt32(row["Cod_Empresa"]));
                                    this.CbxPVEMP.SelectedValue = Convert.ToInt32(row["Cod_Punto_Venta"]);
                                    this.DateEMP.Value = Convert.ToDateTime(row["FechaEmp"]);

                                }
                            }
                           Cls_Helper.MostrarMensaje("Informacion modificada exitosamente", "Datos Modificados", 0);
                           ActualizacionesDataSet();
                        }
                        catch { }
                    }
                }

                private void CBoxPVDocumentos_SelectedIndexChanged(object sender, EventArgs e)//ver errror
                {
                    try
                    {
                        this.tbl_Doc_PuntoVentaConfigTableAdapter1.Fill(this.mODULO_FACT_VECADataSet.Tbl_Doc_PuntoVentaConfig, Convert.ToInt32(CBoxPVDocumentos.SelectedValue));
                        DataGridTpDoc.DataSource = mODULO_FACT_VECADataSet.Tbl_Doc_PuntoVentaConfig;
                        AddTpDoc = 0;
                    }
                    catch { }
                }

                private void BttAddTipoDoc_Click(object sender, EventArgs e){                
                    try{
                    int i=0,l=0;
                       for (i = 0; i < this.DataGridTpDoc.Rows.Count; i++){   
                       if (Convert.ToString(DataGridTpDoc.Rows[i].Cells["Cod_Doc"].Value) == TxtCodPVGrl.Text)
                       {
                           l = 1;
                           break;
                       }
                       }
                       if (l != 1) {
              this.tbl_Tipo_DocConfigTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Tipo_DocConfig, TxtTpDocGrl.Text,Login.CodPais);
              if (cobUsuarioDoc.SelectedValue != null && CBoxPVDocumentos.SelectedValue != null && TxtSerieDoc.Text != "" && TxtCorreIni.Text != "" && TxtCorreFin.Text !="")
              {
                        DataTable dt = (DataTable)DataGridTpDoc.DataSource;
                        DataRow row = dt.NewRow();
                        row["Usuario"] = Convert.ToInt32(cobUsuarioDoc.SelectedValue); //TxtTpUsuario
                        row["Cod_PuntoVenta"] = Convert.ToInt32(CBoxPVDocumentos.SelectedValue);
                        row["Serie_Doc"] = TxtSerieDoc.Text;
                        row["Correlativo_ini"] = TxtCorreIni.Text;
                        row["Correlativo_fin"] = TxtCorreFin.Text;
                        row["Fecha_Actualizado"] = Convert.ToDateTime(DateTpDoc.Value);
                        row["Resolucion"] = Tbx_TpdResolucion.Text;
                        row["Cod_Doc"] = "In0";

                        dt.Rows.Add(row);
                        DataGridTpDoc.DataSource = dt;
                      AddTpDoc++;
              }
                        l = 0;
                                   }
                    }
                    catch { }      
                }

                private void BttGrabarTDoc_Click(object sender, EventArgs e)
                {
                    if (MessageBox.Show("Estas seguro que Agregar un nuevo registro", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ValidarTpDocumentos();
                        if (z5 != 1)
                        {
                            try
                            {
                                this.tbl_Tipo_DocConfigTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Tipo_DocConfig, TxtTpDocGrl.Text,Login.CodPais);
                                if (mODULO_FACT_VECADataSet.Tbl_Tipo_DocConfig.Rows.Count == 1)

                                {
                                    foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_Tipo_DocConfig)
                                    {
                                        TxtCodPVGrl.Text = Convert.ToString(row["Cod_Doc"]);
                                        TxtTpDocGrl.Text = Convert.ToString(row["Tipo_Doc"]);
                                        comboBoxPaisGrl.SelectedValue = Convert.ToUInt32(row["Cod_Pais"]);
                                        CkActivoDoc.Checked = Convert.ToBoolean(row["vigente"]);
                                        DatePvGral.Value = Convert.ToDateTime(row["Fecha_Creado"]);
                                    }
                                }
                            }
                            catch { }
                            try
                            {
                                this.tbl_Tipo_DocConfigTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Tipo_DocConfig, TxtTpDocGrl.Text, Login.CodPais);
                                if (mODULO_FACT_VECADataSet.Tbl_Tipo_DocConfig.Rows.Count == 1)
                                {
                                    int i = 0;
                                    for (i = 0; i < this.DataGridTpDoc.Rows.Count; i++)
                                    {
                                        if (Convert.ToString(DataGridTpDoc.Rows[i].Cells["Cod_Doc"].Value) == "In0")
                                        {
                                            this.tbl_Doc_PuntoVentaConfigTableAdapter1.InsertarTipoDoc(TxtCodPVGrl.Text, Convert.ToInt32(DataGridTpDoc.Rows[i].Cells["Cod_PuntoVenta"].Value), Convert.ToString(DataGridTpDoc.Rows[i].Cells["Serie_Doc"].Value), Convert.ToString(DataGridTpDoc.Rows[i].Cells["Correlativo_ini"].Value), Convert.ToString(DataGridTpDoc.Rows[i].Cells["Correlativo_fin"].Value), Convert.ToDateTime(DataGridTpDoc.Rows[i].Cells["Fecha_Actualizado"].Value), Convert.ToInt32(cobUsuarioDoc.SelectedValue), Convert.ToString(DataGridTpDoc.Rows[i].Cells["Resolucion"].Value));
                                        }
                                    }
                                }
                                else
                                {
                                    Cls_Helper.MostrarMensaje("Seleccione Un tipo de documento ", "Datos faltantes", 0);
                                }
                                ActualizacionesDataSet();
                            }
                            catch { }
                        }
                        z5 = 0;
                        }
                }


                public void ValidarTpDocumentos()
                {
                    //   Convert.ToString(DataGridTpDoc.Rows[i].Cells["Correlativo_fin"].Value), Convert.ToDateTime(DataGridTpDoc.Rows[i].Cells["Fecha_Actualizado"].Value), Convert.ToInt32(cobUsuarioDoc.SelectedValue));

                    int j = 0;
                    for (j = 0; j < DataGridTpDoc.Rows.Count; j++)
                    {
                        if (DataGridTpDoc.Rows[j].Cells["Cod_PuntoVenta"].Value == null)
                        {
                            z5 = 1;
                            MessageBox.Show("Registro Vacio Punto Venta! ");
                            break;
                        }
                        else if (DataGridTpDoc.Rows[j].Cells["Serie_Doc"].Value == null)
                        {
                            z5 = 1;
                            MessageBox.Show("Registro Vacio Serie Documento ! ");
                            break;
                        }
                        else if (DataGridTpDoc.Rows[j].Cells["Correlativo_ini"].Value == null)
                        {
                            z5 = 1;
                            MessageBox.Show("Registro Vacio Correlarico Ini ! ");
                            break;
                        }
                        else if (DataGridTpDoc.Rows[j].Cells["Correlativo_fin"].Value == null)
                        {
                            z5 = 1;
                            MessageBox.Show("Registro Vacio Correlativo Fin! ");
                            break;
                        }
                        else if (DataGridTpDoc.Rows[j].Cells["Fecha_Actualizado"].Value == null)
                        {
                            z5 = 1;
                            MessageBox.Show("Registro Vacio Fecha ! ");
                            break;
                        }
                    }
                   
                }



                private void BttModificarTpDoc_Click(object sender, EventArgs e)
                {

                    if (MessageBox.Show("Estas seguro que Modificar la Informacion", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            this.tbl_Tipo_DocConfigTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Tipo_DocConfig, TxtTpDocGrl.Text, Login.CodPais);
                            if (mODULO_FACT_VECADataSet.Tbl_Tipo_DocConfig.Rows.Count == 1)
                            {
                                foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_Tipo_DocConfig)
                                {
                                    TxtCodPVGrl.Text = Convert.ToString(row["Cod_Doc"]);
                                    TxtTpDocGrl.Text = Convert.ToString(row["Tipo_Doc"]);
                                    comboBoxPaisGrl.SelectedValue = Convert.ToUInt32(row["Cod_Pais"]);
                                    CkActivoDoc.Checked = Convert.ToBoolean(row["vigente"]);
                                    DatePvGral.Value = Convert.ToDateTime(row["Fecha_Creado"]);
                                }
                            }
                                int i = 0;
                                for (i = 0; i < this.DataGridTpDoc.Rows.Count; i++)
                                {
                                               this.tbl_Doc_PuntoVentaConfigTableAdapter1.ModificarTp( Convert.ToString(DataGridTpDoc.Rows[i].Cells["Serie_Doc"].Value), Convert.ToString(DataGridTpDoc.Rows[i].Cells["Correlativo_ini"].Value), Convert.ToString(DataGridTpDoc.Rows[i].Cells["Correlativo_fin"].Value), Convert.ToDateTime(DataGridTpDoc.Rows[i].Cells["Fecha_Actualizado"].Value), Convert.ToInt32(cobUsuarioDoc.SelectedValue), Convert.ToString(DataGridTpDoc.Rows[i].Cells["Resolucion"].Value),Convert.ToString(DataGridTpDoc.Rows[i].Cells["Cod_Doc"].Value), Convert.ToInt32(DataGridTpDoc.Rows[i].Cells["Cod_PuntoVenta"].Value));
                                }

                            Cls_Helper.MostrarMensaje("Informacion modificada exitosamente", "Datos Modificados", 0);
                            ActualizacionesDataSet();
                        }
                        catch { }
                    }


                }

                private void BttLimpiarTpDoc_Click(object sender, EventArgs e)
                {
                    try
                    {
                        Cls_Helper.LimpiarCampos(groupBoxTpDoc);
                        Cls_Helper.LimpiarCampos(groupBoxTpDocGrl);
                        int i = 0;
                        for (i = 0; i < DataGridTpDoc.Rows.Count; i++)
                        {
                            this.DataGridTpDoc.Rows.RemoveAt(i);
                        }
                    }
                    catch { }
                }



                //validacion numeros grid tipodoc
                private void DataGridTpDoc_KeyPress(object sender, KeyPressEventArgs e)
                {
                    try
                    {
                        if (DataGridTpDoc.Columns[DataGridTpDoc.CurrentCell.ColumnIndex].Name == "Correlativo_ini")
                        {
                            if (e.KeyChar == (char)Keys.Back || char.IsNumber(e.KeyChar))
                                e.Handled = false;
                            else
                                e.Handled = true;
                        }
                        if (DataGridTpDoc.Columns[DataGridTpDoc.CurrentCell.ColumnIndex].Name == "Correlativo_fin")
                        {
                            if (e.KeyChar == (char)Keys.Back || char.IsNumber(e.KeyChar))
                                e.Handled = false;
                            else
                                e.Handled = true;
                        }
                    }
                    catch { }
                }

                private void DataGridTpDoc_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
                {
                    try
                    {
                        if (DataGridTpDoc.Columns[DataGridTpDoc.CurrentCell.ColumnIndex].Name == "Correlativo_ini")
                        {
                            TextBox txt = e.Control as TextBox;
                            if (txt != null)
                            {
                                txt.KeyPress -= new KeyPressEventHandler(DataGridTpDoc_KeyPress);
                                txt.KeyPress += new KeyPressEventHandler(DataGridTpDoc_KeyPress);
                            }
                        }
                        if (DataGridTpDoc.Columns[DataGridTpDoc.CurrentCell.ColumnIndex].Name == "Correlativo_fin")
                        {
                            TextBox txt = e.Control as TextBox;
                            if (txt != null)
                            {
                                txt.KeyPress -= new KeyPressEventHandler(DataGridTpDoc_KeyPress);
                                txt.KeyPress += new KeyPressEventHandler(DataGridTpDoc_KeyPress);
                            }
                        }
                    }
                    catch { }
                }

                private void DataGridTpDoc_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
                {
                    try
                    {
                        if (DataGridTpDoc.Columns[e.ColumnIndex].Name == "Fecha_Actualizado" && e.FormattedValue.ToString().Length > 0)
                        {
                            string fecha = e.FormattedValue.ToString();

                            CultureInfo es = new CultureInfo("en-US");
                            DateTime dateValue;

                            if (!DateTime.TryParseExact(fecha, "dd/MM/yyyy", es, DateTimeStyles.None, out dateValue))
                            {
                                MessageBox.Show("Formato de fecha incorrecto, asegurese de introducir el formato correcto. Ej.01/12/2014");
                                DataGridTpDoc.Rows[e.RowIndex].ErrorText = "Formato de fecha incorrecto";
                                e.Cancel = true;
                            }
                        }
                    }
                    catch { }
                }
         

                private void comboBoxEmpUser_SelectedIndexChanged(object sender, EventArgs e)
                {
                    try
                    {
                        this.tbl_UsuariosConfigTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_UsuariosConfig, Convert.ToInt32(comboBoxEmpUser.SelectedValue));
                        if (mODULO_FACT_VECADataSet.Tbl_UsuariosConfig.Rows.Count == 1)
                        {
                            foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_UsuariosConfig)
                            {
                                this.TxtCodUsuarios.Text = Convert.ToString(row["Cod_Usuario"]);
                                this.TxtUsuario.Text = Convert.ToString(row["Usuario"]);
                                this.TxtPasswprd.Text = Convert.ToString(row["Password"]);
                                if (Convert.ToString(row["Caja"]) == "S")
                                {
                                    this.CkCaja.Checked = true;
                                }
                                else { this.CkCaja.Checked = false; }
                                if (Convert.ToString(row["Ventas"]) == "S")
                                {
                                    this.CkVentas.Checked = true;
                                }
                                else { this.CkVentas.Checked = false; }

                                if (Convert.ToString(row["Supervisor"]) == "S")
                                {
                                    this.CkSupervisor.Checked = true;
                                }
                                else { this.CkSupervisor.Checked = false; }
                                if (Convert.ToString(row["Gerente"]) == "S")
                                {
                                    this.CkAdmin.Checked = true;
                                }
                                else { this.CkAdmin.Checked = false; }
                                if (Convert.ToString(row["Encargado"]) == "S")
                                {
                                    this.CkEncargado.Checked = true;
                                }
                                else { this.CkEncargado.Checked = false; }
                                this.DateUsuario.Value = Convert.ToDateTime(row["FechaIn"]);
                            }
                        }
                    }
                    catch { }
                }

                private void BttLimpiarUsuario_Click(object sender, EventArgs e)
                {
                    try
                    {
                        Cls_Helper.LimpiarCampos(groupBoxUser);
                        this.CkCaja.Checked = false;
                        this.CkVentas.Checked = false;
                        this.CkSupervisor.Checked = false;
                        this.CkAdmin.Checked = false;
                        this.CkEncargado.Checked = false;
                    }
                    catch { }
                    
                }

                private void BttAgregarUsuario_Click(object sender, EventArgs e)
                {
                    if (MessageBox.Show("Estas seguro que Agregar un nuevo registro", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ValidarUsuario();
                        if (z2 != 1)
                        {
                            try
                            {
                                string cajack, venta, supervisor, encargado, gerente;
                                if (CkCaja.Checked == true)
                                {
                                    cajack = "S";
                                }
                                else { cajack = "N"; }
                                if (this.CkVentas.Checked == true)
                                {
                                    venta = "S";
                                }
                                else { venta = "N"; }
                                if (this.CkSupervisor.Checked == true)
                                {
                                    supervisor = "S";
                                }
                                else { supervisor = "N"; }
                                if (this.CkEncargado.Checked == true)
                                {
                                    encargado = "S";
                                }
                                else { encargado = "N"; }
                                if (this.CkAdmin.Checked == true)
                                {
                                    gerente = "S";
                                }
                                else { gerente = "N"; }


                                this.tbl_UsuariosConfigTableAdapter1.InsertarUsuario(Convert.ToInt32(comboBoxEmpUser.SelectedValue), this.TxtUsuario.Text, this.TxtPasswprd.Text, Convert.ToString(comboBoxEmpUser.Text), cajack, venta, encargado, supervisor, gerente, Convert.ToString(Convert.ToDateTime(DateUsuario.Value)));

                                this.tbl_UsuariosConfigTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_UsuariosConfig, Convert.ToInt32(comboBoxEmpUser.SelectedValue));
                                if (mODULO_FACT_VECADataSet.Tbl_UsuariosConfig.Rows.Count == 1)
                                {
                                    foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_UsuariosConfig)
                                    {
                                        this.TxtCodUsuarios.Text = Convert.ToString(row["Cod_Usuario"]);
                                        this.TxtUsuario.Text = Convert.ToString(row["Usuario"]);
                                        this.TxtPasswprd.Text = Convert.ToString(row["Password"]);
                                        if (Convert.ToString(row["Caja"]) == "S")
                                        {
                                            this.CkCaja.Checked = true;
                                        }
                                        else { this.CkCaja.Checked = false; }
                                        if (Convert.ToString(row["Ventas"]) == "S")
                                        {
                                            this.CkVentas.Checked = true;
                                        }
                                        else { this.CkVentas.Checked = false; }

                                        if (Convert.ToString(row["Supervisor"]) == "S")
                                        {
                                            this.CkSupervisor.Checked = true;
                                        }
                                        else { this.CkSupervisor.Checked = false; }
                                        if (Convert.ToString(row["Gerente"]) == "S")
                                        {
                                            this.CkAdmin.Checked = true;
                                        }
                                        else { this.CkAdmin.Checked = false; }
                                        if (Convert.ToString(row["Encargado"]) == "S")
                                        {
                                            this.CkEncargado.Checked = true;
                                        }
                                        else { this.CkEncargado.Checked = false; }
                                        this.DateUsuario.Value = Convert.ToDateTime(row["FechaIn"]);
                                    }
                                }
                                Cls_Helper.MostrarMensaje("Registro Agregado exitosamente", "Datos Agregados", 0);
                                ActualizacionesDataSet();
                            }
                            catch {
                                Cls_Helper.MostrarMensaje("Registro no se agrego", "Aviso", 1);
                            }
                        }
                    }
                    z2 = 0;
                }


                public void ValidarUsuario()
                {
                    try
                    {
                        if (this.TxtUsuario.Text == "")
                        {
                            z2 = 1;
                            MessageBox.Show("Registro Vacio Usuario ! ");
                        }
                        else if (this.TxtPasswprd.Text == "")
                        {
                            z2 = 1;
                            MessageBox.Show("Registro Vacio Password ! ");
                        }
                        else if (comboBoxEmpUser.SelectedValue == null)
                        {
                            z2 = 1;
                            MessageBox.Show("Registro Vacio Empleado ! ");
                        }
                    }
                    catch { }
 
                }

                private void BttActualizarUser_Click(object sender, EventArgs e)
                {
                    if (MessageBox.Show("Estas seguro que Modificar la Informacion", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ValidarUsuario();
                        if (z2 != 1)
                        {
                            try
                            {
                                string cajack, venta, supervisor, encargado, gerente;
                                if (CkCaja.Checked == true)
                                {
                                    cajack = "S";
                                }
                                else { cajack = "N"; }
                                if (this.CkVentas.Checked == true)
                                {
                                    venta = "S";
                                }
                                else { venta = "N"; }
                                if (this.CkSupervisor.Checked == true)
                                {
                                    supervisor = "S";
                                }
                                else { supervisor = "N"; }
                                if (this.CkEncargado.Checked == true)
                                {
                                    encargado = "S";
                                }
                                else { encargado = "N"; }
                                if (this.CkAdmin.Checked == true)
                                {
                                    gerente = "S";
                                }
                                else { gerente = "N"; }


                                this.tbl_UsuariosConfigTableAdapter1.ModificarUsuarios(Convert.ToInt32(comboBoxEmpUser.SelectedValue), this.TxtUsuario.Text, this.TxtPasswprd.Text, Convert.ToString(comboBoxEmpUser.Text), cajack, venta, encargado, supervisor, gerente, Convert.ToString(Convert.ToDateTime(DateUsuario.Value)), Convert.ToInt32(TxtCodUsuarios.Text));

                                this.tbl_UsuariosConfigTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_UsuariosConfig, Convert.ToInt32(comboBoxEmpUser.SelectedValue));
                                if (mODULO_FACT_VECADataSet.Tbl_UsuariosConfig.Rows.Count == 1)
                                {
                                    foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_UsuariosConfig)
                                    {
                                        this.TxtCodUsuarios.Text = Convert.ToString(row["Cod_Usuario"]);
                                        this.TxtUsuario.Text = Convert.ToString(row["Usuario"]);
                                        this.TxtPasswprd.Text = Convert.ToString(row["Password"]);
                                        if (Convert.ToString(row["Caja"]) == "S")
                                        {
                                            this.CkCaja.Checked = true;
                                        }
                                        else { this.CkCaja.Checked = false; }
                                        if (Convert.ToString(row["Ventas"]) == "S")
                                        {
                                            this.CkVentas.Checked = true;
                                        }
                                        else { this.CkVentas.Checked = false; }

                                        if (Convert.ToString(row["Supervisor"]) == "S")
                                        {
                                            this.CkSupervisor.Checked = true;
                                        }
                                        else { this.CkSupervisor.Checked = false; }
                                        if (Convert.ToString(row["Gerente"]) == "S")
                                        {
                                            this.CkAdmin.Checked = true;
                                        }
                                        else { this.CkAdmin.Checked = false; }
                                        if (Convert.ToString(row["Encargado"]) == "S")
                                        {
                                            this.CkEncargado.Checked = true;
                                        }
                                        else { this.CkEncargado.Checked = false; }
                                        this.DateUsuario.Value = Convert.ToDateTime(row["FechaIn"]);
                                    }
                                }
                                Cls_Helper.MostrarMensaje("Registro Modificado", "Datos Modificados", 0);
                                ActualizacionesDataSet();
                            }
                            catch { }
                        }
                    }
                    z2 = 0;
                }

                private void comboBoxPaisUser_SelectedIndexChanged(object sender, EventArgs e)
                {
                    try
                    {
                        this.tbl_EmpleadosUsuariosTableAdapter.Fill(this.mODULO_FACT_VECADataSet3.Tbl_EmpleadosUsuarios, Convert.ToInt32(comboBoxPaisUser.SelectedValue));
                    }
                    catch { }
                }

                private void TxtTpDocGrl_TextChanged(object sender, EventArgs e)
                {
                    try
                    {
                        if (TxtTpDocGrl.TextLength > 2)
                        {
                            SqlParameter[] p = { new SqlParameter("@TipoDoc", SqlDbType.VarChar) { Value = Cls_Helper.BusquedaPro(TxtTpDocGrl) } };
                            Cls_Helper.AutoCompletar(TxtTpDocGrl, con.GetDataTable("SELECT * FROM Tbl_Tipo_Doc WHERE Tipo_Doc LIKE @TipoDoc", con.conexion, p), "Tipo_Doc", "Cod_Doc");
                        }
                    }
                    catch { }

                }

                private void TxtTpDocGrl_KeyDown(object sender, KeyEventArgs e)
                {
                    try
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            TxtTpDocGrl.Text = TxtTpDocGrl.Text.Remove(TxtTpDocGrl.Text.LastIndexOf('|')).Trim();
                            this.tbl_Tipo_DocConfigTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Tipo_DocConfig, TxtTpDocGrl.Text, Login.CodPais);
                            if (mODULO_FACT_VECADataSet.Tbl_Tipo_DocConfig.Rows.Count == 1)
                            {
                                //llena el formulario con resultado 
                                foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_Tipo_DocConfig)
                                {
                                    TxtCodPVGrl.Text = Convert.ToString(row["Cod_Doc"]);
                                    TxtTpDocGrl.Text = Convert.ToString(row["Tipo_Doc"]);
                                    comboBoxPaisGrl.SelectedValue = Convert.ToUInt32(row["Cod_Pais"]);
                                    CkActivoDoc.Checked= Convert.ToBoolean(row["vigente"]);
                                    DatePvGral.Value = Convert.ToDateTime(row["Fecha_Creado"]);
                                    this.tbl_PV_DocumentosTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_PV_Documentos, Convert.ToInt32(row["Cod_Pais"]));

                                    AddTpDoc = 0;
                                }
                            }
                        }
                    }
                    catch { }

                }

                private void comboBoxPaisGrl_SelectedIndexChanged(object sender, EventArgs e)
                {
                    try
                    {
                        this.tbl_PV_DocumentosTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_PV_Documentos, Convert.ToInt32(comboBoxPaisGrl.SelectedValue));

                        this.tipoDocVisorTableAdapter1.Fill(mODULO_FACT_VECADataSet.TipoDocVisor, Convert.ToInt32(comboBoxPaisGrl.SelectedValue));
                        
                    }
                    catch { }
                }



                private void DataGridMoneda_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
                {
                    try
                    {
                        if (DataGridMoneda.Columns[DataGridMoneda.CurrentCell.ColumnIndex].Name == "Tasa_Conv_USD")
                        {
                            TextBox txt = e.Control as TextBox;
                            if (txt != null)
                            {
                                txt.KeyPress -= new KeyPressEventHandler(DataGridMoneda_KeyPress);
                                txt.KeyPress += new KeyPressEventHandler(DataGridMoneda_KeyPress);
                            }
                        }
                    }
                    catch { }
                }
                


                private void DataGridMoneda_KeyPress(object sender, KeyPressEventArgs e)
                {
                    try {
                        if (DataGridMoneda.Columns[DataGridMoneda.CurrentCell.ColumnIndex].Name == "Tasa_Conv_USD")
                     {
                        if (e.KeyChar == (char)Keys.Back || char.IsNumber(e.KeyChar)|| e.KeyChar=='.')
                            e.Handled = false;
                        else
                            e.Handled = true;
                    }
                    }catch{}
                }

                private void DataGridImpuestos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
                {
                    try
                    {
                        if (DataGridImpuestos.Columns[DataGridImpuestos.CurrentCell.ColumnIndex].Name == "Valor_Imp")
                        {
                            TextBox txt1 = e.Control as TextBox;
                            if (txt1 != null)
                            {
                                txt1.KeyPress -= new KeyPressEventHandler(DataGridImpuestos_KeyPress);
                                txt1.KeyPress += new KeyPressEventHandler(DataGridImpuestos_KeyPress);
                            }
                        }
                    }
                    catch { }
                }

                private void DataGridImpuestos_KeyPress(object sender, KeyPressEventArgs e)
                {
                    try
                    {
                        if (DataGridImpuestos.Columns[DataGridImpuestos.CurrentCell.ColumnIndex].Name == "Valor_Imp")
                        {
                            if (e.KeyChar == (char)Keys.Back || char.IsNumber(e.KeyChar) || e.KeyChar == '.')
                                e.Handled = false;
                            else
                                e.Handled = true;
                        }
                    }
                    catch { }
                }

                private void DataGridImpuestos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
                {
                    try { 
                    if (DataGridImpuestos.Columns[e.ColumnIndex].Name == "Validez" && e.FormattedValue.ToString().Length > 0)
                    {
                        string fecha = e.FormattedValue.ToString();
                       
                        CultureInfo es = new CultureInfo("en-US");
                        DateTime dateValue;

                        if (!DateTime.TryParseExact(fecha, "dd/MM/yyyy", es, DateTimeStyles.None, out dateValue))
                        {
                            MessageBox.Show("Formato de fecha incorrecto, asegurese de introducir el formato correcto. Ej.01/12/2014");
                            DataGridImpuestos.Rows[e.RowIndex].ErrorText = "Formato de fecha incorrecto";
                            e.Cancel = true;
                        }
                    }
                    }
                    catch { }
                }
        /// ///Visores de informacion
                private void Btt_Buscar_Click(object sender, EventArgs e)
                {
                    try
                    {
                        Informacion inf = new Informacion();
                        this.tbl_Pais1TableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Pais1);
                        inf.DataGridInformacion.DataSource = mODULO_FACT_VECADataSet.Tbl_Pais1;
                        inf.MdiParent = this.MdiParent;
                        inf.label1.Text = "Pais :";
                        inf.tipoInf = "pais";
                        inf.Show();
                    }
                    catch { }
                }

                private void BttoVisorEmpresa_Click(object sender, EventArgs e)
                {
                    try {
                    Informacion inf = new Informacion();
                    this.visorEmpresaTableAdapter1.Fill(mODULO_FACT_VECADataSet.VisorEmpresa);
                    inf.DataGridInformacion.DataSource = mODULO_FACT_VECADataSet.VisorEmpresa;
                    inf.MdiParent = this.MdiParent;
                    inf.label1.Text = "Empresa :";
                    inf.tipoInf = "empresa";
                    inf.Show();
                    }
                    catch { }
                }


                private void BttoVisorDoc_Click(object sender, EventArgs e)
                {
                    try
                    {
                        Informacion inf = new Informacion();
                        visorDocumentosTableAdapter1.Fill(mODULO_FACT_VECADataSet.VisorDocumentos);
                        inf.DataGridInformacion.DataSource = mODULO_FACT_VECADataSet.VisorDocumentos;
                        inf.MdiParent = this.MdiParent;
                        inf.label1.Text = "Tipo Documentos :";
                        inf.tipoInf = "TpDoc";
                        inf.Show();
                    }
                    catch { }
                }

                private void BttoVisorServicios_Click(object sender, EventArgs e)
                {
                    try
                    {
                        Informacion inf = new Informacion();
                        visorServiciosTableAdapter1.Fill(mODULO_FACT_VECADataSet.VisorServicios);
                        inf.DataGridInformacion.DataSource = mODULO_FACT_VECADataSet.VisorServicios;
                        inf.MdiParent = this.MdiParent;
                        inf.label1.Text = "Servicio :";
                        inf.tipoInf = "servicio";
                        inf.Show();
                    }
                    catch { }
                }

                private void BttoVisorEmpleados_Click(object sender, EventArgs e)
                {
                    try
                    {
                        Informacion inf = new Informacion();
                        visorEmpleadosTableAdapter1.Fill(mODULO_FACT_VECADataSet.VisorEmpleados);
                        inf.DataGridInformacion.DataSource = mODULO_FACT_VECADataSet.VisorEmpleados;
                        inf.MdiParent = this.MdiParent;
                        inf.label1.Text = "Empleado :";
                        inf.tipoInf = "empleado";
                        inf.Show();
                    }
                    catch { }
                }

                private void BttoVIsorUsuario_Click(object sender, EventArgs e)
                {
                    try
                    {
                        Informacion inf = new Informacion();
                        this.visorUsuariosTableAdapter1.Fill(mODULO_FACT_VECADataSet.VisorUsuarios);
                        inf.DataGridInformacion.DataSource = mODULO_FACT_VECADataSet.VisorUsuarios;
                        inf.MdiParent = this.MdiParent;
                        inf.label1.Text = "Usuario :";
                        inf.tipoInf = "usuario";
                        inf.Show();
                    }
                    catch { }
                }

                private void BttoVisorTcC_Click(object sender, EventArgs e)
                { try
                    {
                    if (Rbbt_TipoCliente.Checked == true)
                    {
                        Informacion inf = new Informacion();
                        this.visorTipoClienteTableAdapter1.Fill(mODULO_FACT_VECADataSet.VisorTipoCliente);
                        inf.DataGridInformacion.DataSource = mODULO_FACT_VECADataSet.VisorTipoCliente;
                        inf.MdiParent = this.MdiParent;
                        inf.label1.Text = "Tipo cliente :";
                        inf.tipoInf = "TpCliente";
                        inf.Show();
                    }
                    if (Rbbt_TipoContr.Checked == true)
                    {
                        Informacion inf = new Informacion();
                        this.vistoContrinbuyenteTableAdapter1.Fill(mODULO_FACT_VECADataSet.VistoContrinbuyente);
                        inf.DataGridInformacion.DataSource = mODULO_FACT_VECADataSet.VistoContrinbuyente;
                        inf.MdiParent = this.MdiParent;
                        inf.label1.Text = "Tipo Contribuyente :";
                        inf.tipoInf = "TpContri";
                        inf.Show();
                    }
                    }
                catch { }
                }

                private void DataGridService_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
                {
                    try
                    {
                        if (DataGridService.Columns[e.ColumnIndex].Name == "FechaCreacion" && e.FormattedValue.ToString().Length > 0)
                        {
                            string fecha = e.FormattedValue.ToString();

                            CultureInfo es = new CultureInfo("en-US");
                            DateTime dateValue;

                            if (!DateTime.TryParseExact(fecha, "dd/MM/yyyy", es, DateTimeStyles.None, out dateValue))
                            {
                                MessageBox.Show("Formato de fecha incorrecto, asegurese de introducir el formato correcto. Ej.01/12/2014");
                                DataGridService.Rows[e.RowIndex].ErrorText = "Formato de fecha incorrecto";
                                e.Cancel = true;
                            }
                        }
                    }
                    catch { }
                }

                private void BttoSalirUSer_Click(object sender, EventArgs e)
                {
                    Close();
                }

                private void BttoSalirEMple_Click(object sender, EventArgs e)
                {
                    Close();
                }

                private void BttonSalirServ_Click(object sender, EventArgs e)
                {
                    Close();
                }

                private void BttoSalirDOc_Click(object sender, EventArgs e)
                {
                    Close();
                }

                private void BttoSalirCOnfCli_Click(object sender, EventArgs e)
                {
                    Close();
                }

                public void TraerInformacion()
                {
                    switch (TpInf) { 
                        case "pais":
                                Txt_NombrePais.Text = Txt_NombrePais.Text.Remove(Txt_NombrePais.Text.LastIndexOf('|')).Trim();
                                this.tbl_PaisTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Pais, Txt_NombrePais.Text);
                                if (mODULO_FACT_VECADataSet.Tbl_Pais.Rows.Count == 1)
                                {
                                    //llena el formulario con resultado 
                                    foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_Pais)
                                    {
                                        Txt_CodPais.Text = Convert.ToString(row["Cod_Pais"]);
                                        Txt_Nacionalidad.Text = Convert.ToString(row["Nacionalidad"]);
                                        Txt_AbrevPais.Text = Convert.ToString(row["Iniciales"]);
                                        Txt_NombrePais.Text = Convert.ToString(row["Nombre_Pais"]);

                                        this.tbl_MonedaCursoTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_MonedaCurso, Convert.ToInt32(Txt_CodPais.Text));
                                        DataGridMoneda.DataSource = mODULO_FACT_VECADataSet.Tbl_MonedaCurso;

                                        this.tbl_ImpuestoTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Impuesto, Convert.ToInt32(Txt_CodPais.Text));
                                        DataGridImpuestos.DataSource = mODULO_FACT_VECADataSet.Tbl_Impuesto;
                                        AddMon = 0;
                                        AddImp = 0;
                                    }
                                }
                    return;

                        case "empresa": 
                                                Txt_NombreEmpresa.Text = Txt_NombreEmpresa.Text.Remove(Txt_NombreEmpresa.Text.LastIndexOf('|')).Trim();
                    this.tbl_EmpresaTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Empresa, Txt_NombreEmpresa.Text);
                    if (mODULO_FACT_VECADataSet.Tbl_Empresa.Rows.Count == 1)
                    {
                        //llena el formulario con resultado 
                        foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_Empresa)
                        {
                            this.Txt_CodEmpresa.Text = Convert.ToString(row["Cod_empresa"]);
                            this.Txt_Direccion.Text = Convert.ToString(row["Direccion_empresa"]);
                            this.Txt_Telefono.Text = Convert.ToString(row["Telefono_Empresa"]);
                            this.Txt_RazonSocial.Text = Convert.ToString(row["Razon_Social"]);
                            this.Txt_Nrc.Text = Convert.ToString(row["Nrc"]);
                            this.Mtxt_Nit.Text = Convert.ToString(row["Nit"]);
                            this.Cbx_Pais.SelectedValue = Convert.ToInt32(row["Cod_Pais"]);
                            this.Cbx_TipoContr.SelectedValue = Convert.ToInt32(row["Id_Tipo_Contribuyecte"]);
                            this.DateEmpresa.Value = Convert.ToDateTime(row["Fecha"]);

                            this.tbl_Punto_VentaTableAdapter1.Fill(this.mODULO_FACT_VECADataSet.Tbl_Punto_Venta, Convert.ToInt32(Txt_CodEmpresa.Text));
                            DataGrid_PuntoVen.DataSource = mODULO_FACT_VECADataSet.Tbl_Punto_Venta;
                            AddPv = 0;
                        }
                    }
                    return;

                        case "empleado":

                                TxtNombEMP.Text = TxtNombEMP.Text.Remove(TxtNombEMP.Text.LastIndexOf('|')).Trim();
                            tbl_EmpleadosConfigTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_EmpleadosConfig,TxtNombEMP.Text);
                            if (mODULO_FACT_VECADataSet.Tbl_EmpleadosConfig.Rows.Count == 1)
                            {
                                foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_EmpleadosConfig)
                                {
                                    this.TxtCodEmpleado.Text = Convert.ToString(row["Id_Empleado"]);
                                    this.TxtCodEMP.Text = Convert.ToString(row["Cod_Empleado"]);
                                    this.TxtNombEMP.Text = Convert.ToString(row["Nombre"]);
                                    this.TxtDirEMP.Text = Convert.ToString(row["Direccion"]);
                                    this.TxtTelEMP.Text = Convert.ToString(row["Telefono"]);
                                    this.TxtCargoEMP.Text = Convert.ToString(row["Cargo"]);
                                    this.TxtDepEMP.Text = Convert.ToString(row["Departamento"]);
                                    this.CboxPaisEmp.SelectedValue = Convert.ToInt32(row["Cod_Pais"]);
                                    this.tbl_EmpresaEmpleadoTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_EmpresaEmpleado, Convert.ToInt32(row["Cod_Pais"]));
                                    this.CmbEmpresaEMP.SelectedValue = Convert.ToInt32(row["Cod_Empresa"]);
                                    this.tbl_Punto_VentaEMPLEADOTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Punto_VentaEMPLEADO, Convert.ToInt32(row["Cod_Empresa"]));
                                    this.CbxPVEMP.SelectedValue = Convert.ToInt32(row["Cod_Punto_Venta"]);
                                    this.DateEMP.Value = Convert.ToDateTime(row["FechaEmp"]);

                                }
                            }
                    return;
                        case "TpDoc":

                            TxtTpDocGrl.Text = TxtTpDocGrl.Text.Remove(TxtTpDocGrl.Text.LastIndexOf('|')).Trim();
                            this.tbl_Tipo_DocConfigTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Tipo_DocConfig, TxtTpDocGrl.Text, Login.CodPais);
                            if (mODULO_FACT_VECADataSet.Tbl_Tipo_DocConfig.Rows.Count == 1)
                            {
                                //llena el formulario con resultado 
                                foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_Tipo_DocConfig)
                                {
                                    TxtCodPVGrl.Text = Convert.ToString(row["Cod_Doc"]);
                                    TxtTpDocGrl.Text = Convert.ToString(row["Tipo_Doc"]);
                                    comboBoxPaisGrl.SelectedValue = Convert.ToUInt32(row["Cod_Pais"]);
                                    CkActivoDoc.Checked= Convert.ToBoolean(row["vigente"]);
                                    DatePvGral.Value = Convert.ToDateTime(row["Fecha_Creado"]);
                                    this.tbl_PV_DocumentosTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_PV_Documentos, Convert.ToInt32(row["Cod_Pais"]));

                                    AddTpDoc = 0;
                                }
                            }

                    return;
                }


                }

                private void CboxTipoDocCn_SelectedValueChanged(object sender, EventArgs e)
                {
                    try
                    {
                        this.tbl_Tipo_DocConfigTableAdapter1.Fill(mODULO_FACT_VECADataSet.Tbl_Tipo_DocConfig, Convert.ToString(CboxTipoDocCn.SelectedValue), Login.CodPais);
                        if (mODULO_FACT_VECADataSet.Tbl_Tipo_DocConfig.Rows.Count == 1)
                        {
                            //llena el formulario con resultado 
                            foreach (DataRow row in mODULO_FACT_VECADataSet.Tbl_Tipo_DocConfig)
                            {
                                TxtCodPVGrl.Text = Convert.ToString(row["Cod_Doc"]);
                                TxtTpDocGrl.Text = Convert.ToString(row["Tipo_Doc"]);
                                comboBoxPaisGrl.SelectedValue = Convert.ToUInt32(row["Cod_Pais"]);
                                CkActivoDoc.Checked = Convert.ToBoolean(row["vigente"]);
                                DatePvGral.Value = Convert.ToDateTime(row["Fecha_Creado"]);
                                this.tbl_PV_DocumentosTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_PV_Documentos, Convert.ToInt32(row["Cod_Pais"]));

                                AddTpDoc = 0;
                            }
                        }
                    }
                    catch { }
                }



    }
}
