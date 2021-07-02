namespace MD_Facturas
{
    partial class Frm_Clientes
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Clientes));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Txt_Correo = new System.Windows.Forms.TextBox();
            this.lbCorreo = new System.Windows.Forms.Label();
            this.Txt_Movil = new System.Windows.Forms.TextBox();
            this.Lb_Movil = new System.Windows.Forms.Label();
            this.Txt_Telefono = new System.Windows.Forms.TextBox();
            this.Lb_Telefono = new System.Windows.Forms.Label();
            this.Txt_Direccion = new System.Windows.Forms.TextBox();
            this.Lb_Direccion = new System.Windows.Forms.Label();
            this.Txt_NombreCliente = new System.Windows.Forms.TextBox();
            this.Lb_Nombre = new System.Windows.Forms.Label();
            this.Txt_IdCliente = new System.Windows.Forms.TextBox();
            this.Lb_Idcliente = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk_ModNrc = new System.Windows.Forms.CheckBox();
            this.chk_ModNit = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.MaskedTextBox();
            this.Txt_Dui = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_Usuario = new System.Windows.Forms.TextBox();
            this.Lb_Usuario = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Lb_Fecha = new System.Windows.Forms.Label();
            this.Txt_Pasaporte = new System.Windows.Forms.TextBox();
            this.Lb_Pasaporte = new System.Windows.Forms.Label();
            this.Txt_Giro = new System.Windows.Forms.TextBox();
            this.Txt_Nrc = new System.Windows.Forms.TextBox();
            this.Lb_Giro = new System.Windows.Forms.Label();
            this.Lb_Nrc = new System.Windows.Forms.Label();
            this.Lb_Nit = new System.Windows.Forms.Label();
            this.Cbx_TipoContr = new System.Windows.Forms.ComboBox();
            this.Lb_TipoContr = new System.Windows.Forms.Label();
            this.Cbx_TipoCliente = new System.Windows.Forms.ComboBox();
            this.Lb_TipoCliente = new System.Windows.Forms.Label();
            this.Cbx_Pais = new System.Windows.Forms.ComboBox();
            this.Lb_Pais = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Btt_Cancelar = new System.Windows.Forms.Button();
            this.Btt_Actualizar = new System.Windows.Forms.Button();
            this.Btt_Guardar = new System.Windows.Forms.Button();
            this.Btt_Buscar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BindingSourceTblClientes = new System.Windows.Forms.BindingSource(this.components);
            this.mODULO_FACT_VECADataSet = new MD_Facturas.MODULO_FACT_VECADataSet();
            this.tbl_ClientesTableAdapter = new MD_Facturas.MODULO_FACT_VECADataSetTableAdapters.Tbl_ClientesTableAdapter();
            this.groupBoxSeleccion = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTblClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mODULO_FACT_VECADataSet)).BeginInit();
            this.groupBoxSeleccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Txt_Correo);
            this.groupBox1.Controls.Add(this.lbCorreo);
            this.groupBox1.Controls.Add(this.Txt_Movil);
            this.groupBox1.Controls.Add(this.Lb_Movil);
            this.groupBox1.Controls.Add(this.Txt_Telefono);
            this.groupBox1.Controls.Add(this.Lb_Telefono);
            this.groupBox1.Controls.Add(this.Txt_Direccion);
            this.groupBox1.Controls.Add(this.Lb_Direccion);
            this.groupBox1.Controls.Add(this.Txt_NombreCliente);
            this.groupBox1.Controls.Add(this.Lb_Nombre);
            this.groupBox1.Controls.Add(this.Txt_IdCliente);
            this.groupBox1.Controls.Add(this.Lb_Idcliente);
            this.groupBox1.Location = new System.Drawing.Point(12, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(849, 127);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Generales";
            // 
            // Txt_Correo
            // 
            this.Txt_Correo.Location = new System.Drawing.Point(63, 82);
            this.Txt_Correo.Name = "Txt_Correo";
            this.Txt_Correo.Size = new System.Drawing.Size(767, 20);
            this.Txt_Correo.TabIndex = 5;
            // 
            // lbCorreo
            // 
            this.lbCorreo.AutoSize = true;
            this.lbCorreo.Location = new System.Drawing.Point(6, 85);
            this.lbCorreo.Name = "lbCorreo";
            this.lbCorreo.Size = new System.Drawing.Size(38, 13);
            this.lbCorreo.TabIndex = 10;
            this.lbCorreo.Text = "Correo";
            // 
            // Txt_Movil
            // 
            this.Txt_Movil.Location = new System.Drawing.Point(725, 53);
            this.Txt_Movil.Name = "Txt_Movil";
            this.Txt_Movil.Size = new System.Drawing.Size(105, 20);
            this.Txt_Movil.TabIndex = 4;
            // 
            // Lb_Movil
            // 
            this.Lb_Movil.AutoSize = true;
            this.Lb_Movil.Location = new System.Drawing.Point(689, 56);
            this.Lb_Movil.Name = "Lb_Movil";
            this.Lb_Movil.Size = new System.Drawing.Size(32, 13);
            this.Lb_Movil.TabIndex = 8;
            this.Lb_Movil.Text = "Movil";
            // 
            // Txt_Telefono
            // 
            this.Txt_Telefono.Location = new System.Drawing.Point(577, 53);
            this.Txt_Telefono.Name = "Txt_Telefono";
            this.Txt_Telefono.Size = new System.Drawing.Size(105, 20);
            this.Txt_Telefono.TabIndex = 3;
            // 
            // Lb_Telefono
            // 
            this.Lb_Telefono.AutoSize = true;
            this.Lb_Telefono.Location = new System.Drawing.Point(526, 56);
            this.Lb_Telefono.Name = "Lb_Telefono";
            this.Lb_Telefono.Size = new System.Drawing.Size(49, 13);
            this.Lb_Telefono.TabIndex = 6;
            this.Lb_Telefono.Text = "Telefono";
            // 
            // Txt_Direccion
            // 
            this.Txt_Direccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_Direccion.Location = new System.Drawing.Point(63, 53);
            this.Txt_Direccion.Name = "Txt_Direccion";
            this.Txt_Direccion.Size = new System.Drawing.Size(457, 20);
            this.Txt_Direccion.TabIndex = 2;
            // 
            // Lb_Direccion
            // 
            this.Lb_Direccion.AutoSize = true;
            this.Lb_Direccion.Location = new System.Drawing.Point(5, 56);
            this.Lb_Direccion.Name = "Lb_Direccion";
            this.Lb_Direccion.Size = new System.Drawing.Size(52, 13);
            this.Lb_Direccion.TabIndex = 4;
            this.Lb_Direccion.Text = "Direccion";
            // 
            // Txt_NombreCliente
            // 
            this.Txt_NombreCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Txt_NombreCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Txt_NombreCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_NombreCliente.Location = new System.Drawing.Point(216, 23);
            this.Txt_NombreCliente.Name = "Txt_NombreCliente";
            this.Txt_NombreCliente.Size = new System.Drawing.Size(614, 20);
            this.Txt_NombreCliente.TabIndex = 1;
            this.toolTip1.SetToolTip(this.Txt_NombreCliente, "Escriba el nombre del cliente y una vez seleccionado presione ENTER");
            this.Txt_NombreCliente.TextChanged += new System.EventHandler(this.Txt_NombreCliente_TextChanged);
            this.Txt_NombreCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_NombreCliente_KeyDown);
            // 
            // Lb_Nombre
            // 
            this.Lb_Nombre.AutoSize = true;
            this.Lb_Nombre.Location = new System.Drawing.Point(166, 26);
            this.Lb_Nombre.Name = "Lb_Nombre";
            this.Lb_Nombre.Size = new System.Drawing.Size(44, 13);
            this.Lb_Nombre.TabIndex = 2;
            this.Lb_Nombre.Text = "Nombre";
            // 
            // Txt_IdCliente
            // 
            this.Txt_IdCliente.Enabled = false;
            this.Txt_IdCliente.Location = new System.Drawing.Point(63, 23);
            this.Txt_IdCliente.Name = "Txt_IdCliente";
            this.Txt_IdCliente.Size = new System.Drawing.Size(79, 20);
            this.Txt_IdCliente.TabIndex = 0;
            // 
            // Lb_Idcliente
            // 
            this.Lb_Idcliente.AutoSize = true;
            this.Lb_Idcliente.Location = new System.Drawing.Point(6, 26);
            this.Lb_Idcliente.Name = "Lb_Idcliente";
            this.Lb_Idcliente.Size = new System.Drawing.Size(51, 13);
            this.Lb_Idcliente.TabIndex = 0;
            this.Lb_Idcliente.Text = "Id Cliente";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chk_ModNrc);
            this.groupBox2.Controls.Add(this.chk_ModNit);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.Txt_Dui);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Txt_Usuario);
            this.groupBox2.Controls.Add(this.Lb_Usuario);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.Lb_Fecha);
            this.groupBox2.Controls.Add(this.Txt_Pasaporte);
            this.groupBox2.Controls.Add(this.Lb_Pasaporte);
            this.groupBox2.Controls.Add(this.Txt_Giro);
            this.groupBox2.Controls.Add(this.Txt_Nrc);
            this.groupBox2.Controls.Add(this.Lb_Giro);
            this.groupBox2.Controls.Add(this.Lb_Nrc);
            this.groupBox2.Controls.Add(this.Lb_Nit);
            this.groupBox2.Location = new System.Drawing.Point(12, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(849, 167);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos";
            // 
            // chk_ModNrc
            // 
            this.chk_ModNrc.AutoSize = true;
            this.chk_ModNrc.Location = new System.Drawing.Point(447, 30);
            this.chk_ModNrc.Name = "chk_ModNrc";
            this.chk_ModNrc.Size = new System.Drawing.Size(89, 17);
            this.chk_ModNrc.TabIndex = 28;
            this.chk_ModNrc.Text = "Modificar Nrc";
            this.chk_ModNrc.UseVisualStyleBackColor = true;
            this.chk_ModNrc.Visible = false;
            this.chk_ModNrc.CheckedChanged += new System.EventHandler(this.chk_ModNrc_CheckedChanged);
            // 
            // chk_ModNit
            // 
            this.chk_ModNit.AutoSize = true;
            this.chk_ModNit.Location = new System.Drawing.Point(176, 30);
            this.chk_ModNit.Name = "chk_ModNit";
            this.chk_ModNit.Size = new System.Drawing.Size(85, 17);
            this.chk_ModNit.TabIndex = 27;
            this.chk_ModNit.Text = "Modificar Nit";
            this.chk_ModNit.UseVisualStyleBackColor = true;
            this.chk_ModNit.Visible = false;
            this.chk_ModNit.CheckedChanged += new System.EventHandler(this.chk_ModNit_CheckedChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(34, 28);
            this.textBox3.Mask = "####-######-###-#";
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(135, 20);
            this.textBox3.TabIndex = 1;
            // 
            // Txt_Dui
            // 
            this.Txt_Dui.Location = new System.Drawing.Point(616, 28);
            this.Txt_Dui.Name = "Txt_Dui";
            this.Txt_Dui.Size = new System.Drawing.Size(105, 20);
            this.Txt_Dui.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(587, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Dui";
            // 
            // Txt_Usuario
            // 
            this.Txt_Usuario.Location = new System.Drawing.Point(577, 111);
            this.Txt_Usuario.Name = "Txt_Usuario";
            this.Txt_Usuario.Size = new System.Drawing.Size(144, 20);
            this.Txt_Usuario.TabIndex = 25;
            // 
            // Lb_Usuario
            // 
            this.Lb_Usuario.AutoSize = true;
            this.Lb_Usuario.Location = new System.Drawing.Point(528, 114);
            this.Lb_Usuario.Name = "Lb_Usuario";
            this.Lb_Usuario.Size = new System.Drawing.Size(43, 13);
            this.Lb_Usuario.TabIndex = 24;
            this.Lb_Usuario.Text = "Usuario";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(297, 111);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // Lb_Fecha
            // 
            this.Lb_Fecha.AutoSize = true;
            this.Lb_Fecha.Location = new System.Drawing.Point(254, 114);
            this.Lb_Fecha.Name = "Lb_Fecha";
            this.Lb_Fecha.Size = new System.Drawing.Size(37, 13);
            this.Lb_Fecha.TabIndex = 22;
            this.Lb_Fecha.Text = "Fecha";
            // 
            // Txt_Pasaporte
            // 
            this.Txt_Pasaporte.Location = new System.Drawing.Point(59, 111);
            this.Txt_Pasaporte.Name = "Txt_Pasaporte";
            this.Txt_Pasaporte.Size = new System.Drawing.Size(174, 20);
            this.Txt_Pasaporte.TabIndex = 8;
            // 
            // Lb_Pasaporte
            // 
            this.Lb_Pasaporte.AutoSize = true;
            this.Lb_Pasaporte.Location = new System.Drawing.Point(1, 114);
            this.Lb_Pasaporte.Name = "Lb_Pasaporte";
            this.Lb_Pasaporte.Size = new System.Drawing.Size(55, 13);
            this.Lb_Pasaporte.TabIndex = 20;
            this.Lb_Pasaporte.Text = "Pasaporte";
            // 
            // Txt_Giro
            // 
            this.Txt_Giro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_Giro.Location = new System.Drawing.Point(34, 68);
            this.Txt_Giro.Name = "Txt_Giro";
            this.Txt_Giro.Size = new System.Drawing.Size(687, 20);
            this.Txt_Giro.TabIndex = 4;
            // 
            // Txt_Nrc
            // 
            this.Txt_Nrc.Location = new System.Drawing.Point(336, 28);
            this.Txt_Nrc.Name = "Txt_Nrc";
            this.Txt_Nrc.Size = new System.Drawing.Size(105, 20);
            this.Txt_Nrc.TabIndex = 2;
            // 
            // Lb_Giro
            // 
            this.Lb_Giro.AutoSize = true;
            this.Lb_Giro.Location = new System.Drawing.Point(2, 71);
            this.Lb_Giro.Name = "Lb_Giro";
            this.Lb_Giro.Size = new System.Drawing.Size(26, 13);
            this.Lb_Giro.TabIndex = 12;
            this.Lb_Giro.Text = "Giro";
            // 
            // Lb_Nrc
            // 
            this.Lb_Nrc.AutoSize = true;
            this.Lb_Nrc.Location = new System.Drawing.Point(308, 31);
            this.Lb_Nrc.Name = "Lb_Nrc";
            this.Lb_Nrc.Size = new System.Drawing.Size(24, 13);
            this.Lb_Nrc.TabIndex = 12;
            this.Lb_Nrc.Text = "Nrc";
            // 
            // Lb_Nit
            // 
            this.Lb_Nit.AutoSize = true;
            this.Lb_Nit.Location = new System.Drawing.Point(8, 31);
            this.Lb_Nit.Name = "Lb_Nit";
            this.Lb_Nit.Size = new System.Drawing.Size(20, 13);
            this.Lb_Nit.TabIndex = 10;
            this.Lb_Nit.Text = "Nit";
            // 
            // Cbx_TipoContr
            // 
            this.Cbx_TipoContr.FormattingEnabled = true;
            this.Cbx_TipoContr.Location = new System.Drawing.Point(616, 22);
            this.Cbx_TipoContr.Name = "Cbx_TipoContr";
            this.Cbx_TipoContr.Size = new System.Drawing.Size(152, 21);
            this.Cbx_TipoContr.TabIndex = 7;
            // 
            // Lb_TipoContr
            // 
            this.Lb_TipoContr.AutoSize = true;
            this.Lb_TipoContr.Location = new System.Drawing.Point(514, 25);
            this.Lb_TipoContr.Name = "Lb_TipoContr";
            this.Lb_TipoContr.Size = new System.Drawing.Size(96, 13);
            this.Lb_TipoContr.TabIndex = 18;
            this.Lb_TipoContr.Text = "Tipo Contribuyente";
            // 
            // Cbx_TipoCliente
            // 
            this.Cbx_TipoCliente.FormattingEnabled = true;
            this.Cbx_TipoCliente.Location = new System.Drawing.Point(86, 22);
            this.Cbx_TipoCliente.Name = "Cbx_TipoCliente";
            this.Cbx_TipoCliente.Size = new System.Drawing.Size(152, 21);
            this.Cbx_TipoCliente.TabIndex = 6;
            this.Cbx_TipoCliente.SelectedIndexChanged += new System.EventHandler(this.Cbx_TipoCliente_SelectedIndexChanged);
            // 
            // Lb_TipoCliente
            // 
            this.Lb_TipoCliente.AutoSize = true;
            this.Lb_TipoCliente.Location = new System.Drawing.Point(17, 25);
            this.Lb_TipoCliente.Name = "Lb_TipoCliente";
            this.Lb_TipoCliente.Size = new System.Drawing.Size(63, 13);
            this.Lb_TipoCliente.TabIndex = 16;
            this.Lb_TipoCliente.Text = "Tipo Cliente";
            // 
            // Cbx_Pais
            // 
            this.Cbx_Pais.FormattingEnabled = true;
            this.Cbx_Pais.Location = new System.Drawing.Point(315, 22);
            this.Cbx_Pais.Name = "Cbx_Pais";
            this.Cbx_Pais.Size = new System.Drawing.Size(152, 21);
            this.Cbx_Pais.TabIndex = 5;
   
            // 
            // Lb_Pais
            // 
            this.Lb_Pais.AutoSize = true;
            this.Lb_Pais.Location = new System.Drawing.Point(282, 25);
            this.Lb_Pais.Name = "Lb_Pais";
            this.Lb_Pais.Size = new System.Drawing.Size(27, 13);
            this.Lb_Pais.TabIndex = 14;
            this.Lb_Pais.Text = "Pais";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.Btt_Cancelar);
            this.groupBox3.Controls.Add(this.Btt_Actualizar);
            this.groupBox3.Controls.Add(this.Btt_Guardar);
            this.groupBox3.Controls.Add(this.Btt_Buscar);
            this.groupBox3.Location = new System.Drawing.Point(12, 424);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(849, 100);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Opciones";
            // 
            // Btt_Cancelar
            // 
            this.Btt_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("Btt_Cancelar.Image")));
            this.Btt_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btt_Cancelar.Location = new System.Drawing.Point(692, 32);
            this.Btt_Cancelar.Name = "Btt_Cancelar";
            this.Btt_Cancelar.Size = new System.Drawing.Size(75, 62);
            this.Btt_Cancelar.TabIndex = 15;
            this.Btt_Cancelar.Text = "Cancelar";
            this.Btt_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btt_Cancelar.UseVisualStyleBackColor = true;
            this.Btt_Cancelar.Click += new System.EventHandler(this.Btt_Cancelar_Click);
            // 
            // Btt_Actualizar
            // 
            this.Btt_Actualizar.Image = ((System.Drawing.Image)(resources.GetObject("Btt_Actualizar.Image")));
            this.Btt_Actualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btt_Actualizar.Location = new System.Drawing.Point(471, 32);
            this.Btt_Actualizar.Name = "Btt_Actualizar";
            this.Btt_Actualizar.Size = new System.Drawing.Size(75, 62);
            this.Btt_Actualizar.TabIndex = 14;
            this.Btt_Actualizar.Text = "Actualizar";
            this.Btt_Actualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btt_Actualizar.UseVisualStyleBackColor = true;
            this.Btt_Actualizar.Click += new System.EventHandler(this.Btt_Actualizar_Click);
            // 
            // Btt_Guardar
            // 
            this.Btt_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("Btt_Guardar.Image")));
            this.Btt_Guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btt_Guardar.Location = new System.Drawing.Point(268, 32);
            this.Btt_Guardar.Name = "Btt_Guardar";
            this.Btt_Guardar.Size = new System.Drawing.Size(75, 62);
            this.Btt_Guardar.TabIndex = 13;
            this.Btt_Guardar.Text = "Guardar";
            this.Btt_Guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btt_Guardar.UseVisualStyleBackColor = true;
            this.Btt_Guardar.Click += new System.EventHandler(this.Btt_Guardar_Click);
            // 
            // Btt_Buscar
            // 
            this.Btt_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("Btt_Buscar.Image")));
            this.Btt_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btt_Buscar.Location = new System.Drawing.Point(64, 32);
            this.Btt_Buscar.Name = "Btt_Buscar";
            this.Btt_Buscar.Size = new System.Drawing.Size(75, 62);
            this.Btt_Buscar.TabIndex = 12;
            this.Btt_Buscar.Text = "Ver Todos";
            this.Btt_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btt_Buscar.UseVisualStyleBackColor = true;
            this.Btt_Buscar.Click += new System.EventHandler(this.Btt_Buscar_Click);
            // 
            // BindingSourceTblClientes
            // 
            this.BindingSourceTblClientes.DataMember = "Tbl_Clientes";
            this.BindingSourceTblClientes.DataSource = this.mODULO_FACT_VECADataSet;
            // 
            // mODULO_FACT_VECADataSet
            // 
            this.mODULO_FACT_VECADataSet.DataSetName = "MODULO_FACT_VECADataSet";
            this.mODULO_FACT_VECADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_ClientesTableAdapter
            // 
            this.tbl_ClientesTableAdapter.ClearBeforeFill = true;
            // 
            // groupBoxSeleccion
            // 
            this.groupBoxSeleccion.Controls.Add(this.Lb_TipoCliente);
            this.groupBoxSeleccion.Controls.Add(this.Cbx_TipoCliente);
            this.groupBoxSeleccion.Controls.Add(this.Lb_Pais);
            this.groupBoxSeleccion.Controls.Add(this.Cbx_Pais);
            this.groupBoxSeleccion.Controls.Add(this.Lb_TipoContr);
            this.groupBoxSeleccion.Controls.Add(this.Cbx_TipoContr);
            this.groupBoxSeleccion.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSeleccion.Name = "groupBoxSeleccion";
            this.groupBoxSeleccion.Size = new System.Drawing.Size(849, 52);
            this.groupBoxSeleccion.TabIndex = 12;
            this.groupBoxSeleccion.TabStop = false;
            this.groupBoxSeleccion.Text = "Seleccion";
            // 
            // Frm_Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(880, 544);
            this.Controls.Add(this.groupBoxSeleccion);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Clientes";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Frm_Clientes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTblClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mODULO_FACT_VECADataSet)).EndInit();
            this.groupBoxSeleccion.ResumeLayout(false);
            this.groupBoxSeleccion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label Lb_Nombre;
        private System.Windows.Forms.TextBox Txt_IdCliente;
        private System.Windows.Forms.Label Lb_Idcliente;
        private System.Windows.Forms.TextBox Txt_Telefono;
        private System.Windows.Forms.Label Lb_Telefono;
        private System.Windows.Forms.TextBox Txt_Direccion;
        private System.Windows.Forms.Label Lb_Direccion;
        private System.Windows.Forms.TextBox Txt_Movil;
        private System.Windows.Forms.Label Lb_Movil;
        private System.Windows.Forms.TextBox Txt_Correo;
        private System.Windows.Forms.Label lbCorreo;
        private System.Windows.Forms.TextBox Txt_Nrc;
        private System.Windows.Forms.Label Lb_Nrc;
        private System.Windows.Forms.Label Lb_Nit;
        private System.Windows.Forms.TextBox Txt_Giro;
        private System.Windows.Forms.Label Lb_Giro;
        private System.Windows.Forms.TextBox Txt_Usuario;
        private System.Windows.Forms.Label Lb_Usuario;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label Lb_Fecha;
        private System.Windows.Forms.TextBox Txt_Pasaporte;
        private System.Windows.Forms.Label Lb_Pasaporte;
        private System.Windows.Forms.ComboBox Cbx_TipoContr;
        private System.Windows.Forms.Label Lb_TipoContr;
        private System.Windows.Forms.ComboBox Cbx_TipoCliente;
        private System.Windows.Forms.Label Lb_TipoCliente;
        private System.Windows.Forms.ComboBox Cbx_Pais;
        private System.Windows.Forms.Label Lb_Pais;
        private System.Windows.Forms.Button Btt_Cancelar;
        private System.Windows.Forms.Button Btt_Actualizar;
        private System.Windows.Forms.Button Btt_Guardar;
        private System.Windows.Forms.Button Btt_Buscar;
        private System.Windows.Forms.TextBox Txt_Dui;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox textBox3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.BindingSource BindingSourceTblClientes;
        private MODULO_FACT_VECADataSet mODULO_FACT_VECADataSet;
        private MODULO_FACT_VECADataSetTableAdapters.Tbl_ClientesTableAdapter tbl_ClientesTableAdapter;
        private System.Windows.Forms.CheckBox chk_ModNrc;
        private System.Windows.Forms.CheckBox chk_ModNit;
        public System.Windows.Forms.TextBox Txt_NombreCliente;
        private System.Windows.Forms.GroupBox groupBoxSeleccion;
    }
}

