namespace MD_Facturas
{
    partial class Frm_Reportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gp1RangoFecha = new System.Windows.Forms.GroupBox();
            this.control_RangoFechas2 = new MD_Facturas.Control_RangoFechas();
            this.gp2ParamAdicionales = new System.Windows.Forms.GroupBox();
            this.ddlTiposDoc = new System.Windows.Forms.ComboBox();
            this.tblTipoDocBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mODULO_FACT_VECADataSet = new MD_Facturas.MODULO_FACT_VECADataSet();
            this.chkTipoDocAll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tblTipoDocFacTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StatusBar1 = new System.Windows.Forms.StatusStrip();
            this.gp3Opciones = new System.Windows.Forms.GroupBox();
            this.btnCancelarVistaReporte = new System.Windows.Forms.Button();
            this.btnGeneraReporte = new System.Windows.Forms.Button();
            this.tbl_Tipo_DocTableAdapter = new MD_Facturas.MODULO_FACT_VECADataSetTableAdapters.Tbl_Tipo_DocTableAdapter();
            this.tbl_Tipo_DocFacTTableAdapter = new MD_Facturas.MODULO_FACT_VECADataSetTableAdapters.Tbl_Tipo_DocFacTTableAdapter();
            this.gp1RangoFecha.SuspendLayout();
            this.gp2ParamAdicionales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblTipoDocBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mODULO_FACT_VECADataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTipoDocFacTBindingSource)).BeginInit();
            this.gp3Opciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // gp1RangoFecha
            // 
            this.gp1RangoFecha.Controls.Add(this.control_RangoFechas2);
            this.gp1RangoFecha.Location = new System.Drawing.Point(12, 13);
            this.gp1RangoFecha.Name = "gp1RangoFecha";
            this.gp1RangoFecha.Size = new System.Drawing.Size(361, 158);
            this.gp1RangoFecha.TabIndex = 0;
            this.gp1RangoFecha.TabStop = false;
            this.gp1RangoFecha.Text = "Seleccione Fechas";
            // 
            // control_RangoFechas2
            // 
            this.control_RangoFechas2.Desde = new System.DateTime(2015, 3, 31, 0, 0, 0, 0);
            this.control_RangoFechas2.Hasta = new System.DateTime(2015, 3, 31, 0, 0, 0, 0);
            this.control_RangoFechas2.Location = new System.Drawing.Point(7, 20);
            this.control_RangoFechas2.Mensaje = null;
            this.control_RangoFechas2.Name = "control_RangoFechas2";
            this.control_RangoFechas2.Size = new System.Drawing.Size(348, 132);
            this.control_RangoFechas2.TabIndex = 0;
              // 
            // gp2ParamAdicionales
            // 
            this.gp2ParamAdicionales.Controls.Add(this.ddlTiposDoc);
            this.gp2ParamAdicionales.Controls.Add(this.chkTipoDocAll);
            this.gp2ParamAdicionales.Controls.Add(this.label1);
            this.gp2ParamAdicionales.Location = new System.Drawing.Point(379, 13);
            this.gp2ParamAdicionales.Name = "gp2ParamAdicionales";
            this.gp2ParamAdicionales.Size = new System.Drawing.Size(360, 233);
            this.gp2ParamAdicionales.TabIndex = 1;
            this.gp2ParamAdicionales.TabStop = false;
            this.gp2ParamAdicionales.Text = "Seleccione Criterios";
            // 
            // ddlTiposDoc
            // 
            this.ddlTiposDoc.DataSource = this.tblTipoDocBindingSource;
            this.ddlTiposDoc.DisplayMember = "Tipo_Doc";
            this.ddlTiposDoc.Enabled = false;
            this.ddlTiposDoc.FormattingEnabled = true;
            this.ddlTiposDoc.Location = new System.Drawing.Point(136, 42);
            this.ddlTiposDoc.Name = "ddlTiposDoc";
            this.ddlTiposDoc.Size = new System.Drawing.Size(190, 21);
            this.ddlTiposDoc.TabIndex = 32;
            this.ddlTiposDoc.ValueMember = "Cod_Doc";
            // 
            // tblTipoDocBindingSource
            // 
            this.tblTipoDocBindingSource.DataMember = "Tbl_Tipo_Doc";
            this.tblTipoDocBindingSource.DataSource = this.mODULO_FACT_VECADataSet;
            // 
            // mODULO_FACT_VECADataSet
            // 
            this.mODULO_FACT_VECADataSet.DataSetName = "MODULO_FACT_VECADataSet";
            this.mODULO_FACT_VECADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chkTipoDocAll
            // 
            this.chkTipoDocAll.AutoSize = true;
            this.chkTipoDocAll.Enabled = false;
            this.chkTipoDocAll.Location = new System.Drawing.Point(18, 46);
            this.chkTipoDocAll.Name = "chkTipoDocAll";
            this.chkTipoDocAll.Size = new System.Drawing.Size(97, 17);
            this.chkTipoDocAll.TabIndex = 2;
            this.chkTipoDocAll.Text = "Todos los tipos";
            this.chkTipoDocAll.UseVisualStyleBackColor = true;
            this.chkTipoDocAll.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo de Documento";
            // 
            // tblTipoDocFacTBindingSource
            // 
            this.tblTipoDocFacTBindingSource.DataMember = "Tbl_Tipo_DocFacT";
            this.tblTipoDocFacTBindingSource.DataSource = this.mODULO_FACT_VECADataSet;
            // 
            // StatusBar1
            // 
            this.StatusBar1.Location = new System.Drawing.Point(0, 249);
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Size = new System.Drawing.Size(752, 22);
            this.StatusBar1.TabIndex = 2;
            // 
            // gp3Opciones
            // 
            this.gp3Opciones.Controls.Add(this.btnCancelarVistaReporte);
            this.gp3Opciones.Controls.Add(this.btnGeneraReporte);
            this.gp3Opciones.Location = new System.Drawing.Point(0, 181);
            this.gp3Opciones.Name = "gp3Opciones";
            this.gp3Opciones.Size = new System.Drawing.Size(373, 65);
            this.gp3Opciones.TabIndex = 2;
            this.gp3Opciones.TabStop = false;
            this.gp3Opciones.Text = "Opciones";
            // 
            // btnCancelarVistaReporte
            // 
            this.btnCancelarVistaReporte.Location = new System.Drawing.Point(204, 20);
            this.btnCancelarVistaReporte.Name = "btnCancelarVistaReporte";
            this.btnCancelarVistaReporte.Size = new System.Drawing.Size(97, 39);
            this.btnCancelarVistaReporte.TabIndex = 1;
            this.btnCancelarVistaReporte.Text = "Cancelar";
            this.btnCancelarVistaReporte.UseVisualStyleBackColor = true;
            this.btnCancelarVistaReporte.Click += new System.EventHandler(this.btnCancelarVistaReporte_Click);
            // 
            // btnGeneraReporte
            // 
            this.btnGeneraReporte.Location = new System.Drawing.Point(77, 20);
            this.btnGeneraReporte.Name = "btnGeneraReporte";
            this.btnGeneraReporte.Size = new System.Drawing.Size(97, 39);
            this.btnGeneraReporte.TabIndex = 0;
            this.btnGeneraReporte.Text = "Generar Informe";
            this.btnGeneraReporte.UseVisualStyleBackColor = true;
            this.btnGeneraReporte.Click += new System.EventHandler(this.btnGeneraReporte_Click);
            // 
            // tbl_Tipo_DocTableAdapter
            // 
            this.tbl_Tipo_DocTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_Tipo_DocFacTTableAdapter
            // 
            this.tbl_Tipo_DocFacTTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 271);
            this.Controls.Add(this.gp3Opciones);
            this.Controls.Add(this.StatusBar1);
            this.Controls.Add(this.gp2ParamAdicionales);
            this.Controls.Add(this.gp1RangoFecha);
            this.Name = "Frm_Reportes";
            this.Text = "Parámetros de Reportes";
            this.Load += new System.EventHandler(this.Frm_Reportes_Load);
            this.gp1RangoFecha.ResumeLayout(false);
            this.gp2ParamAdicionales.ResumeLayout(false);
            this.gp2ParamAdicionales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblTipoDocBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mODULO_FACT_VECADataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTipoDocFacTBindingSource)).EndInit();
            this.gp3Opciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gp1RangoFecha;
        private System.Windows.Forms.GroupBox gp2ParamAdicionales;
        private System.Windows.Forms.StatusStrip StatusBar1;
        private System.Windows.Forms.GroupBox gp3Opciones;
        private Control_RangoFechas control_RangoFechas1;
        private System.Windows.Forms.CheckBox chkTipoDocAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelarVistaReporte;
        private System.Windows.Forms.Button btnGeneraReporte;
        private MODULO_FACT_VECADataSet mODULO_FACT_VECADataSet;
        private System.Windows.Forms.BindingSource tblTipoDocBindingSource;
        private MODULO_FACT_VECADataSetTableAdapters.Tbl_Tipo_DocTableAdapter tbl_Tipo_DocTableAdapter;
        private Control_RangoFechas control_RangoFechas2;
        private System.Windows.Forms.ComboBox ddlTiposDoc;
        private System.Windows.Forms.BindingSource tblTipoDocFacTBindingSource;
        private MODULO_FACT_VECADataSetTableAdapters.Tbl_Tipo_DocFacTTableAdapter tbl_Tipo_DocFacTTableAdapter;
    }
}