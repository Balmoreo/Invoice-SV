using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MD_Facturas.classes;
using MD_Facturas.reportes;
namespace MD_Facturas
{
    public partial class Visor_Informe : Form
    {
        public Visor_Informe()
        {
            InitializeComponent();
        }

        public void GeneraDocumento(DataTable datos)
        {
            if (datos.Rows.Count > 0)
            {
                FCF fac = new FCF();
               fac.SetDataSource(datos);
               GeneralViewer1.ReportSource = fac;
                GeneralViewer1.Show();
            }
            else
            {
                Cls_Helper.MostrarMensaje("No hay datos para el reporte", "Error", 1);
            }
        }


    }
}
