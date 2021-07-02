namespace MD_Facturas
{
    partial class MDIParent1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent1));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRepVentasFCF = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRepVentasCF = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesDeVentasGeneralesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.BttBar_NuevoCliente = new System.Windows.Forms.ToolStripButton();
            this.BttBar_NuevoDoc = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.printPreviewToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BttBar_Limpiar = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Lb_Estado = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cargaDeExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarExcelASQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.toolsMenu,
            this.viewMenu,
            this.windowsMenu,
            this.cargaDeExcelToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(880, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClientesToolStripMenuItem,
            this.FacturaToolStripMenuItem,
            this.ConfigAsToolStripMenuItem,
            this.toolStripSeparator4,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(66, 20);
            this.fileMenu.Text = "&Modulos";
            // 
            // ClientesToolStripMenuItem
            // 
            this.ClientesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ClientesToolStripMenuItem.Image")));
            this.ClientesToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem";
            this.ClientesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
            this.ClientesToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.ClientesToolStripMenuItem.Text = "&Clientes";
            this.ClientesToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // FacturaToolStripMenuItem
            // 
            this.FacturaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("FacturaToolStripMenuItem.Image")));
            this.FacturaToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.FacturaToolStripMenuItem.Name = "FacturaToolStripMenuItem";
            this.FacturaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.FacturaToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.FacturaToolStripMenuItem.Text = "&Facturas";
            this.FacturaToolStripMenuItem.Click += new System.EventHandler(this.FacturaToolStripMenuItem_Click);
            // 
            // ConfigAsToolStripMenuItem
            // 
            this.ConfigAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ConfigAsToolStripMenuItem.Image")));
            this.ConfigAsToolStripMenuItem.Name = "ConfigAsToolStripMenuItem";
            this.ConfigAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.ConfigAsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.ConfigAsToolStripMenuItem.Text = "Configuraciones";
            this.ConfigAsToolStripMenuItem.Click += new System.EventHandler(this.ConfigAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(199, 6);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(199, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.exitToolStripMenuItem.Text = "&Salir";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // toolsMenu
            // 
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuRepVentasFCF,
            this.MenuRepVentasCF,
            this.reportesDeVentasGeneralesToolStripMenuItem});
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(65, 20);
            this.toolsMenu.Text = "&Reportes";
            // 
            // MenuRepVentasFCF
            // 
            this.MenuRepVentasFCF.Name = "MenuRepVentasFCF";
            this.MenuRepVentasFCF.Size = new System.Drawing.Size(262, 22);
            this.MenuRepVentasFCF.Text = "Reporte de Ventas a Consumidores";
            this.MenuRepVentasFCF.Click += new System.EventHandler(this.MenuRepVentasFCF_Click);
            // 
            // MenuRepVentasCF
            // 
            this.MenuRepVentasCF.Name = "MenuRepVentasCF";
            this.MenuRepVentasCF.Size = new System.Drawing.Size(262, 22);
            this.MenuRepVentasCF.Text = "Reporte de Ventas a Contribuyentes";
            this.MenuRepVentasCF.Click += new System.EventHandler(this.MenuRepVentasCF_Click);
            // 
            // reportesDeVentasGeneralesToolStripMenuItem
            // 
            this.reportesDeVentasGeneralesToolStripMenuItem.Name = "reportesDeVentasGeneralesToolStripMenuItem";
            this.reportesDeVentasGeneralesToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.reportesDeVentasGeneralesToolStripMenuItem.Text = "Reportes de Ventas Generales";
            this.reportesDeVentasGeneralesToolStripMenuItem.Click += new System.EventHandler(this.reportesDeVentasGeneralesToolStripMenuItem_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarToolStripMenuItem,
            this.statusBarToolStripMenuItem});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(36, 20);
            this.viewMenu.Text = "&Ver";
            // 
            // toolBarToolStripMenuItem
            // 
            this.toolBarToolStripMenuItem.Checked = true;
            this.toolBarToolStripMenuItem.CheckOnClick = true;
            this.toolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            this.toolBarToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.toolBarToolStripMenuItem.Text = "&Barra de herramientas";
            this.toolBarToolStripMenuItem.Click += new System.EventHandler(this.ToolBarToolStripMenuItem_Click);
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.Checked = true;
            this.statusBarToolStripMenuItem.CheckOnClick = true;
            this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.statusBarToolStripMenuItem.Text = "&Barra de estado";
            this.statusBarToolStripMenuItem.Click += new System.EventHandler(this.StatusBarToolStripMenuItem_Click);
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowToolStripMenuItem,
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(67, 20);
            this.windowsMenu.Text = "&Ventanas";
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.newWindowToolStripMenuItem.Text = "&Nueva ventana";
            this.newWindowToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascada";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.tileVerticalToolStripMenuItem.Text = "Mosaico &vertical";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Mosaico &horizontal";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.closeAllToolStripMenuItem.Text = "C&errar todo";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.arrangeIconsToolStripMenuItem.Text = "&Organizar iconos";
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BttBar_NuevoCliente,
            this.BttBar_NuevoDoc,
            this.toolStripButton1,
            this.printPreviewToolStripButton,
            this.toolStripSeparator2,
            this.BttBar_Limpiar});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(880, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // BttBar_NuevoCliente
            // 
            this.BttBar_NuevoCliente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BttBar_NuevoCliente.Image = ((System.Drawing.Image)(resources.GetObject("BttBar_NuevoCliente.Image")));
            this.BttBar_NuevoCliente.ImageTransparentColor = System.Drawing.Color.Black;
            this.BttBar_NuevoCliente.Name = "BttBar_NuevoCliente";
            this.BttBar_NuevoCliente.Size = new System.Drawing.Size(23, 22);
            this.BttBar_NuevoCliente.Text = "Nuevo";
            this.BttBar_NuevoCliente.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // BttBar_NuevoDoc
            // 
            this.BttBar_NuevoDoc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BttBar_NuevoDoc.Image = ((System.Drawing.Image)(resources.GetObject("BttBar_NuevoDoc.Image")));
            this.BttBar_NuevoDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BttBar_NuevoDoc.Name = "BttBar_NuevoDoc";
            this.BttBar_NuevoDoc.Size = new System.Drawing.Size(23, 22);
            this.BttBar_NuevoDoc.Text = "toolStripButton2";
            this.BttBar_NuevoDoc.Click += new System.EventHandler(this.BttBar_NuevoDoc_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // printPreviewToolStripButton
            // 
            this.printPreviewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printPreviewToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripButton.Image")));
            this.printPreviewToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.printPreviewToolStripButton.Name = "printPreviewToolStripButton";
            this.printPreviewToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printPreviewToolStripButton.Text = "Vista previa de impresión";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // BttBar_Limpiar
            // 
            this.BttBar_Limpiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BttBar_Limpiar.Image = ((System.Drawing.Image)(resources.GetObject("BttBar_Limpiar.Image")));
            this.BttBar_Limpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BttBar_Limpiar.Name = "BttBar_Limpiar";
            this.BttBar_Limpiar.Size = new System.Drawing.Size(23, 22);
            this.BttBar_Limpiar.Text = "toolStripButton2";
            this.BttBar_Limpiar.Click += new System.EventHandler(this.BttBar_Limpiar_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.Lb_Estado});
            this.statusStrip.Location = new System.Drawing.Point(0, 593);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(880, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel.Text = "Seccion";
            // 
            // Lb_Estado
            // 
            this.Lb_Estado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Lb_Estado.Name = "Lb_Estado";
            this.Lb_Estado.Size = new System.Drawing.Size(10, 17);
            this.Lb_Estado.Text = ".";
            // 
            // cargaDeExcelToolStripMenuItem
            // 
            this.cargaDeExcelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importarExcelASQLToolStripMenuItem});
            this.cargaDeExcelToolStripMenuItem.Name = "cargaDeExcelToolStripMenuItem";
            this.cargaDeExcelToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.cargaDeExcelToolStripMenuItem.Text = "Migracion de Datos";
            // 
            // importarExcelASQLToolStripMenuItem
            // 
            this.importarExcelASQLToolStripMenuItem.Name = "importarExcelASQLToolStripMenuItem";
            this.importarExcelASQLToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.importarExcelASQLToolStripMenuItem.Text = "Importar Excel a SQL";
            this.importarExcelASQLToolStripMenuItem.Click += new System.EventHandler(this.importarExcelASQLToolStripMenuItem_Click);
            // 
            // MDIParent1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(880, 615);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIParent1";
            this.Text = "VECA -- Facturación";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDIParent1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem FacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConfigAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem toolBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton BttBar_NuevoCliente;
        private System.Windows.Forms.ToolStripButton printPreviewToolStripButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripButton BttBar_NuevoDoc;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        public System.Windows.Forms.ToolStripStatusLabel Lb_Estado;
        private System.Windows.Forms.ToolStripButton BttBar_Limpiar;
        public System.Windows.Forms.ToolStripMenuItem ClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuRepVentasFCF;
        private System.Windows.Forms.ToolStripMenuItem MenuRepVentasCF;
        private System.Windows.Forms.ToolStripMenuItem reportesDeVentasGeneralesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargaDeExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarExcelASQLToolStripMenuItem;
    }
}



