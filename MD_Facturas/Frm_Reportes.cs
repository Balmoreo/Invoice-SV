using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MD_Facturas.classes;

namespace MD_Facturas
{
    public partial class Frm_Reportes : Form
    {
        public string TipoRep { get; set; }

        public Frm_Reportes()
        {
            InitializeComponent();
            this.tbl_Tipo_DocTableAdapter.FillBy_Pais(this.mODULO_FACT_VECADataSet.Tbl_Tipo_Doc, Login.CodPais);

        }

        private void btnCancelarVistaReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Reportes_Load(object sender, EventArgs e)
        {
            control_RangoFechas2.Desde = DateTime.Now;
            control_RangoFechas2.Hasta = DateTime.Now;

        }

        public void SeleccionaTipoDoc(string tipodoc)
        {
       //     this.tbl_Tipo_DocTableAdapter.FillBy_Pais(this.mODULO_FACT_VECADataSet.Tbl_Tipo_Doc, Login.CodPais);

            if (ddlTiposDoc.Items.Contains(tipodoc))
            {
                ddlTiposDoc.SelectedIndex = ddlTiposDoc.Items.IndexOf(tipodoc);
            }
            else
            {
                ddlTiposDoc.SelectedIndex = 0;
            }
            ddlTiposDoc.SelectedValue= tipodoc;
        }


        // BOTON GENERA REPORTE
        private void btnGeneraReporte_Click(object sender, EventArgs e)
        {
            Cls_ReportHelper Report = new Cls_ReportHelper()
            {
                Desde = control_RangoFechas2.Desde,
                Hasta = control_RangoFechas2.Hasta,
                TipoInforme = TipoRep,
                TipoDoc = Convert.ToString(ddlTiposDoc.SelectedValue)
            };

            Report.LlamaReporte(); // llama Reporte
        
        }


    }
}
