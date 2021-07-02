using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MD_Facturas.reportes;

namespace MD_Facturas
{
    public partial class Reporte : Form
    {
        Reportes _datosreporte;
        public String TipReport { get; set; }
        public Reporte()
        {
            InitializeComponent();
        }
        public Reporte(Reportes datos)
            : this()
        {
            _datosreporte = datos;
        }
        private void Reporte_Load(object sender, EventArgs e)
        {
            if(TipReport=="CCF"){
             reportes.CFPrevio _factura = new reportes.CFPrevio();
            _factura.SetDataSource(_datosreporte);
            crystalReportViewer1.ReportSource = _factura;
            }else{
            reportes.FCFPrevio _factura = new reportes.FCFPrevio();
                _factura.SetDataSource(_datosreporte);
            crystalReportViewer1.ReportSource = _factura;
            }
            
        }

    }
}
