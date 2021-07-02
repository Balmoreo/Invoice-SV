using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MD_Facturas
{
    public partial class MDIParent1 : Form
    {
        public string Tipo_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }

        public string Usuario { get; set; }
        public string Punto_venta { get; set; }
        public string Seccion { get; set; }
        public string CodUsuarioLg { get; set; }

        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            if(Seccion=="Activa"){
            Form childForm = new Frm_Clientes();
               
          //  childForm = Nombre_Usuario;
            childForm.MdiParent = this;
            
            childForm.Show();
            }
            else{
                Login childForm = new Login();
                childForm.MdiParent = this;
                childForm.Show();
            }

        }


        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            Seccion = "Inactiva";
            Lb_Estado.Text = Seccion;
            Lb_Estado.ForeColor = System.Drawing.Color.Red;
        }

        private void FacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Seccion == "Activa")
            {
//modulo factura
                Reservas childForm = new Reservas();
                childForm.MdiParent = this;
                childForm.Show();
            }
            else
            {
                Login childForm = new Login();
                childForm.MdiParent = this;
                childForm.Show();
            }
        }

        private void ConfigAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Seccion == "Activa" && Tipo_Usuario == "G")
            {
                Configuraciones childForm = new Configuraciones();
                childForm.MdiParent = this;
                childForm.CodUsuarioLgn = CodUsuarioLg;
                childForm.Show();
//configuraciones
            }
            else
            {
                Login childForm = new Login();
                childForm.MdiParent = this;
                childForm.Show();
            }
        }

        public void Mtd_Facturar()
        {
            Facturar_Manual childForm = new Facturar_Manual();
            childForm.usuario = Usuario;
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void BttBar_Limpiar_Click(object sender, EventArgs e)
        {
            
        }

        private void BttBar_NuevoDoc_Click(object sender, EventArgs e)
        {
            FacturaToolStripMenuItem.PerformClick();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ConfigAsToolStripMenuItem.PerformClick();
        }



        /**************************** Llama Pantalla de Reportes ********************************/
       
        //  llama form de parametros Reporte Ventas SAL Consumidores FCF
        private void MenuRepVentasFCF_Click(object sender, EventArgs e)
        {
            if (Seccion == "Activa")
            {
                Frm_Reportes childForm = new Frm_Reportes();
                childForm.MdiParent = this;
                childForm.SeleccionaTipoDoc("SALFCF");
                childForm.TipoRep = "SALVENDIAFCF";
                childForm.Text = "Reporte de ventas - SAL - Consumidores";
                childForm.Show();
            }
            else
            {
                Login childForm = new Login();
                childForm.MdiParent = this;
                childForm.Show();
            }
        }

        // Llama form de parametros Reporte ventas SAL Contribuyentes
        private void MenuRepVentasCF_Click(object sender, EventArgs e)
        {
            if (Seccion == "Activa")
            {
                Frm_Reportes childForm = new Frm_Reportes();
                childForm.MdiParent = this;
                childForm.SeleccionaTipoDoc("SALCCF");
                childForm.Text = "Reporte de ventas - SAL - Contribuyentes";
                childForm.TipoRep = "SALVENDIACF";
                childForm.Show();
            }
            else
            {
                Login childForm = new Login();
                childForm.MdiParent = this;
                childForm.Show();
            }
        }

        private void reportesDeVentasGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Seccion == "Activa")
            {
                Frm_ReportVenta childForm = new Frm_ReportVenta();
                childForm.MdiParent = this;
             //   childForm.SeleccionaTipoDoc("SALCCF");
                childForm.Text = "Reporte de ventas - SAL";
               // childForm.TipoRep = "SALVENDIACF";
                childForm.Show();
            }
            else
            {
                Login childForm = new Login();
                childForm.MdiParent = this;
                childForm.Show();
            }
        }

        private void importarExcelASQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Seccion == "Activa")
            {
                OpenFileDialog myFileDialog = new OpenFileDialog();
                string xSheet = "";

                myFileDialog.Filter = "Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
                myFileDialog.Title = "Open File";
                myFileDialog.ShowDialog();
                if (myFileDialog.FileName.ToString() != "")
                {
                    string ExcelFile = myFileDialog.FileName.ToString();


                    try
                    {

                        ImporData childForm = new ImporData();
                        childForm.Fichero = ExcelFile;
                        string hojas = Microsoft.VisualBasic.Interaction.InputBox("Insertar Nombre de Excel para cargar", "Nombre de Hoja de Excel", "Hoja");
                        if (hojas != "")
                        {
                            childForm.ExportarDataGridViewExcel(childForm.DataGExcel, ExcelFile, hojas);
                            childForm.MdiParent = this;
                            childForm.Show();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                }
              }
            else
            {
                Login childForm = new Login();
                childForm.MdiParent = this;
                childForm.Show();
            }




        }

     

    }
}
