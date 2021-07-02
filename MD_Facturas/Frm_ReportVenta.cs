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
    public partial class Frm_ReportVenta : Form
    {
        public Frm_ReportVenta()
        {
            InitializeComponent();
        }

        private void rBttNoFact_CheckedChanged(object sender, EventArgs e)
        {
            if (rBttNoFact.Checked == true) {
                TextNofact.Enabled = true;
            }else if(rBttNoFact.Checked == false) {
                TextNofact.Enabled = false;
            }
               
        }

        private void DatePkINI_ValueChanged(object sender, EventArgs e)
        {
            DatePkFin.MinDate = DatePkINI.Value;
        }

        private void Frm_ReportVenta_Load(object sender, EventArgs e)
        {
            this.tbl_Tipo_DocReportTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Tipo_DocReport, Convert.ToInt32(Login.CodPais));
            this.tbl_Punto_VentaBusquedaTableAdapter.Fill(mODULO_FACT_VECADataSet.Tbl_Punto_VentaBusqueda, Convert.ToInt32(Login.Empresa));
        }

        private void Btt_FactRecAct_Click(object sender, EventArgs e)
        { String TpBusq = "";
        String TpPV= "";

            if(rBttAll.Checked==true){
                TpBusq = "TD";
            }else if(rBttAnulados.Checked==true){
                TpBusq= "AN";
            }else if(rBttNoFact.Checked==true){
                 TpBusq= "NF";            
            }else if(this.rBttImpresos.Checked==true){
                 TpBusq= "IM";
            }

            if(CboxAllPv.Checked==true){
                TpPV = "TD";
            }else{
                TpPV = "NA";
            }



            if (TextNofact.Text == "") { TextNofact.Text = "0"; }
            Cls_ReportHelper Report = new Cls_ReportHelper()
            {
                Desde = Convert.ToDateTime(DatePkINI.Value),
                Hasta = Convert.ToDateTime(DatePkFin.Value),
                TipoInforme = "VentaGnal",
                TipoDoc = Convert.ToString(cBoxBusqDocum.SelectedValue),
                PuntoVenta = Convert.ToDecimal(CboxPVfact.SelectedValue),
                TpBusqueda=TpBusq,
                NoFactura=Convert.ToDecimal(TextNofact.Text),
                TipoPV = TpPV
            };

            Report.LlamaReporte(); // llama Reporte           
            
            // "VentaGnal"
        }

        private void CboxAllPv_CheckedChanged(object sender, EventArgs e)
        {
            if (CboxAllPv.Checked) {
                CboxPVfact.Enabled = false;
            } else {
                CboxPVfact.Enabled = true;
            }
            }
    }
}
