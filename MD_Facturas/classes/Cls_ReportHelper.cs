using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using MD_Facturas.reportes;
using MD_Facturas.MODULO_FACT_VECADataSetTableAdapters;
using MD_Facturas.ReportesTableAdapters;

namespace MD_Facturas.classes
{
    class Cls_ReportHelper
    {
        private decimal _NoDoc = 0; // No de factura
        private string _SerieDoc = ""; // Serie Documento
        private string _TipoDoc = "";// Tipo documento
       
        private DateTime _Desde;
        private DateTime _Hasta;
        private string _TipoInforme = "";
        private string _TpBusqueda = "";
        private Decimal _NoFactura = 0;
        private Decimal _PuntoVenta = 0;
        private string _TipoPV= "";

        // Propiedades 
        public decimal NoDoc { get { return _NoDoc; } set { _NoDoc = value; } }
        public string SerieDoc { get { return _SerieDoc; } set { _SerieDoc = value; } }
        public string TipoDoc { get { return _TipoDoc; } set { _TipoDoc = value; } }
        public DateTime Desde { get { return _Desde; } set { _Desde = value; } }
        public DateTime Hasta { get { return _Hasta; } set { _Hasta = value; } }
        public string TipoInforme { get { return _TipoInforme; } set { _TipoInforme = value; } }

        public Decimal PuntoVenta { get { return _PuntoVenta; } set { _PuntoVenta = value; } }
        public string TpBusqueda { get { return _TpBusqueda; } set { _TpBusqueda = value; } }
        public Decimal NoFactura { get { return _NoFactura; } set { _NoFactura = value; } }
        public string TipoPV { get { return _TipoPV; } set { _TipoPV = value; } }

       /// <summary>
       /// Método llama Reporte. Usa propiedades para saber tipo de documento 
       /// </summary>
        public void LlamaReporte()
        {
            switch (TipoInforme)
            {
                case "SALFCF":
                   FCF(); // llama consumidor final 
                break;
                case "SALCCF":
                   CF(); // llama credito fiscal 
                break;
                case "SALNC": 
                    NC(); // llama Nota Crédito El Salvador
                break;
                case "SALND":
                    ND(); // llma Nota de Débito El Salvador
                break;
                case "SALVENDIAFCF":
                    SALReporteVentasDiariasFCF(); // Llama Reporte Ventas Diarias para El salvador Consumidor Final
                break;
                case "SALVENDIACF":
                    SALReporteVentasDiariasCF(); // Llama Reporte Ventas Diarias para El Salvador para Contribuyentes
                break;
                case "GUAFCF":
                FCFGUA(); // llama consumidor final 
                break;
                case "GUAATOETK":
                GUAATOETK(); // llama FACTURA 
                break;
                case "GUAATOBAG":
               GUAATOBAG(); // llama EQUIPAJE EXTRA
                break;
                case "VentaGnal":
                SALReporteVentasGnal();
                break;


                default:
                break;
             }// Fin switch
         }          
        
        
        /// <summary>
        /// Genera el dataset para factura consumidor final. El Salvador
        /// </summary>
        private void FCF() // Factura consumidor final
        {
            Reportes.REP_DOCUMENTOS_FISCALESDataTable dt = new Reportes.REP_DOCUMENTOS_FISCALESDataTable();
            REP_DOCUMENTOS_FISCALESTableAdapter ta = new REP_DOCUMENTOS_FISCALESTableAdapter();
            DataTable t;
            FCF fac = new FCF();
            ta.Fill_BYNOFACT(dt, NoDoc, Login.Empresa, SerieDoc);
            t = dt;
            fac.SetDataSource(t);
            if (MostrarReporte(fac, "Consumidor Final"))
            {
                foreach (DataRow n in dt.Rows)
                {
                    ta.Update_Impresa_DocFiscal(Convert.ToDecimal(n["No_factura"]),Convert.ToString(n["Tipo_Doc"]),Convert.ToString(n["Serie"]));
                   // adapter.UPDATE_IMPRESA(Convert.ToDecimal(n["no_fact"]), Convert.ToDecimal(n["no_tx"]), Empresa1, Convert.ToString(n["tipo_tx"]));
                }
            }
        } // fin FCF

        /// <summary>
        /// Genera dataset para comprobante credito fiscal El Salvador 
        /// </summary>
        private void CF()
        {
            Reportes.REP_DOCUMENTOS_FISCALESDataTable dt = new Reportes.REP_DOCUMENTOS_FISCALESDataTable();
            REP_DOCUMENTOS_FISCALESTableAdapter ta = new REP_DOCUMENTOS_FISCALESTableAdapter();
            DataTable t;
            CF credito = new CF();
            ta.Fill_BYNOFACT(dt, NoDoc, Login.Empresa, SerieDoc);
            t = dt;
            credito.SetDataSource(t);
            if (MostrarReporte(credito, "Comprobante Crédito Fiscal"))
            {
                foreach (DataRow n in dt.Rows)
                {
                    ta.Update_Impresa_DocFiscal(Convert.ToDecimal(n["No_factura"]), Convert.ToString(n["Tipo_Doc"]), Convert.ToString(n["Serie"]));
                   // adapter.UPDATE_IMPRESA(Convert.ToDecimal(n["no_fact"]), Convert.ToDecimal(n["no_tx"]), Empresa1, Convert.ToString(n["tipo_tx"]));
                }
            }
        } // Fin CCF

        /// <summary>
        /// Genera  Nota Credito El Salvador
        /// </summary>
        private void NC() 
        {
            Reportes.Nota_CreditoDataTable dt = new Reportes.Nota_CreditoDataTable();
            Nota_CreditoTableAdapter ta = new Nota_CreditoTableAdapter();
            DataTable t;
            SAL_NC credito = new SAL_NC();
            ta.Fill(dt, NoDoc, Login.Empresa, SerieDoc);
            t = dt;
            credito.SetDataSource(t);
            if (MostrarReporte(credito, "Nota de Credito"))
            {
                foreach (DataRow n in dt.Rows)
                {
                    ta.Updte_Impresa_NotaCredito(Convert.ToDecimal(n["No_Nota"]), Convert.ToString(n["Tipo_Doc"]), Convert.ToString(n["Serie"]));
                    // adapter.UPDATE_IMPRESA(Convert.ToDecimal(n["no_fact"]), Convert.ToDecimal(n["no_tx"]), Empresa1, Convert.ToString(n["tipo_tx"]));
                }
            }
        }// FIn NC

        /// <summary>
        /// Genera Nota de Débito El Salvador
        /// </summary>
        private void ND()
        {
            Reportes.Nota_CreditoDataTable dt = new Reportes.Nota_CreditoDataTable();
            Nota_CreditoTableAdapter ta = new Nota_CreditoTableAdapter();
            DataTable t;
            SAL_ND credito = new SAL_ND();
            ta.FillBy_NOTA_DEBITO(dt, NoDoc, Login.Empresa, SerieDoc);
            t = dt;
            credito.SetDataSource(t);
            if (MostrarReporte(credito, "Nota de Débito"))
            {
                foreach (DataRow n in dt.Rows)
                {
                   // ta.Update_Impresa_NotaDebito(Convert.ToDecimal(n["No_Nota"]), Convert.ToString(n["Tipo_Doc"]), Convert.ToString(n["Serie"]));
                    // adapter.UPDATE_IMPRESA(Convert.ToDecimal(n["no_fact"]), Convert.ToDecimal(n["no_tx"]), Empresa1, Convert.ToString(n["tipo_tx"]));
                }
            }
        }

        /// <summary>
        /// Reporte de Ventas Diarias El Salvador - Consumidor Final
        /// /// </summary>
        private void SALReporteVentasDiariasFCF()
        {
            Reportes.REP_VENTAS_CONSUMIDORESDataTable dt = new Reportes.REP_VENTAS_CONSUMIDORESDataTable();
            REP_VENTAS_CONSUMIDORESTableAdapter ta = new REP_VENTAS_CONSUMIDORESTableAdapter();
            DataTable t;
            SAL_VENTASDIARIASFCF rep = new SAL_VENTASDIARIASFCF();
            ta.Fill(dt, Desde, Hasta, TipoDoc);
            t = dt;
            rep.SetDataSource(t);
            MostrarReporte(rep, "Ventas Diarias - Consumidor Final"); // llama Reporte

        }

        /// <summary>
        /// Reporte de Ventas Diarias El Salvador - Contribuyente
        /// </summary>
        private void SALReporteVentasDiariasCF()
        {
            Reportes.Rep_VentasDataTable dt = new Reportes.Rep_VentasDataTable();
            Rep_VentasTableAdapter ta = new Rep_VentasTableAdapter();
            DataTable t;
            SAL_VENTASDIARIAS_CF rep = new SAL_VENTASDIARIAS_CF();
            ta.Fill_ReporteVenta(dt, Desde, Hasta, TipoDoc);
            t = dt;
            rep.SetDataSource(t);
            MostrarReporte(rep, "Ventas Diarias - Contribuyentes"); // llama Reporte
        }


        /// <summary>
        /// Genera el dataset para factura consumidor final. GUATEMALA
        /// </summary>
        private void FCFGUA() // Factura consumidor final
        {
            Reportes.REP_DOCUMENTOS_FISCALESDataTable dt = new Reportes.REP_DOCUMENTOS_FISCALESDataTable();
            REP_DOCUMENTOS_FISCALESTableAdapter ta = new REP_DOCUMENTOS_FISCALESTableAdapter();
            DataTable t;
            FCF fac = new FCF();
            ta.Fill_BYNOFACT(dt, NoDoc, Login.Empresa, SerieDoc);
            t = dt;
            fac.SetDataSource(t);
            if (MostrarReporte(fac, "Consumidor Final"))
            {
                foreach (DataRow n in dt.Rows)
                {
                    ta.Update_Impresa_DocFiscal(Convert.ToDecimal(n["No_factura"]), Convert.ToString(n["Tipo_Doc"]), Convert.ToString(n["Serie"]));
                }
            }
        } // fin FCF

        /// <summary>
        /// Genera dataset para comprobante FACTURA GUATEMALA
        /// </summary>
        private void GUAATOETK()
        {
            Reportes.REP_DOCUMENTOS_FISCALESDataTable dt = new Reportes.REP_DOCUMENTOS_FISCALESDataTable();
            REP_DOCUMENTOS_FISCALESTableAdapter ta = new REP_DOCUMENTOS_FISCALESTableAdapter();
            DataTable t;
            CF credito = new CF();
            ta.Fill_BYNOFACT(dt, NoDoc, Login.Empresa, SerieDoc);
            t = dt;
            credito.SetDataSource(t);
            if (MostrarReporte(credito, "Comprobante Crédito Fiscal"))
            {
                foreach (DataRow n in dt.Rows)
                {
                    ta.Update_Impresa_DocFiscal(Convert.ToDecimal(n["No_factura"]), Convert.ToString(n["Tipo_Doc"]), Convert.ToString(n["Serie"]));
                }
            }
        } // Fin CCF


        /// <summary>
        /// Genera dataset para comprobante EQUIPAJE EXTRA GUATEMALA
        /// </summary>
        private void GUAATOBAG()
        {
            Reportes.REP_DOCUMENTOS_FISCALESDataTable dt = new Reportes.REP_DOCUMENTOS_FISCALESDataTable();
            REP_DOCUMENTOS_FISCALESTableAdapter ta = new REP_DOCUMENTOS_FISCALESTableAdapter();
            DataTable t;
            CF credito = new CF();
            ta.Fill_BYNOFACT(dt, NoDoc, Login.Empresa, SerieDoc);
            t = dt;
            credito.SetDataSource(t);
            if (MostrarReporte(credito, "Comprobante Equipaje Extra"))
            {
                foreach (DataRow n in dt.Rows)
                {
                    ta.Update_Impresa_DocFiscal(Convert.ToDecimal(n["No_factura"]), Convert.ToString(n["Tipo_Doc"]), Convert.ToString(n["Serie"]));
                }
            }
        } // Fin CCF






        /// <summary>
        /// Reporte de Ventas General
        /// </summary>
        private void SALReporteVentasGnal()
        {
            Reportes.Rep_Venta_GeneralDataTable dt = new Reportes.Rep_Venta_GeneralDataTable();
            Rep_Venta_GeneralTableAdapter ta = new Rep_Venta_GeneralTableAdapter();
            DataTable t;
            SAL_VENTASDIARIAS_GNRAL rep = new SAL_VENTASDIARIAS_GNRAL();

            if (TpBusqueda=="TD")
            {
                if (TipoPV == "NA")
                {
                    ta.FillAll(dt, Convert.ToDecimal(PuntoVenta), Desde, Hasta);
                }
                else if (TipoPV=="TD") {
                    ta.FillByAllPventa(dt, Desde, Hasta);
                }
            }
            else if (TpBusqueda == "NF")
            {
                ta.FillByNofact(dt, Convert.ToDecimal(PuntoVenta), TipoDoc, Convert.ToDecimal(NoFactura));
            }
            else if (TpBusqueda == "AN")
            {
                if (TipoPV == "NA")
                {
                    ta.FillByAnulacion(dt, Convert.ToDecimal(PuntoVenta), TipoDoc, Desde, Hasta);
                }
                else if (TipoPV == "TD")
                {
                    ta.FillByAnulacionPventa(dt, TipoDoc, Desde, Hasta);
                }
            }
            else if (TpBusqueda == "IM")
            {
                if (TipoPV == "NA")
                {
                    ta.FillByImpresas(dt, Convert.ToDecimal(PuntoVenta), TipoDoc, Desde, Hasta);
                }
                else if (TipoPV == "TD")
                {
                    ta.FillByImpresasPventa(dt,TipoDoc, Desde, Hasta);
                }
            }


            t = dt;
            rep.SetDataSource(t);
            MostrarReporte(rep, "Ventas Diarias - Contribuyentes"); // llama Reporte
        }


        
        /// <summary>
        /// Metodo para visualizar reporte. Recibe instacia del reporte a generar y el texto de cabecera
        /// </summary>
        /// <param name="instanciareporte"></param>
        /// <param name="headervisor"></param>
        /// <returns></returns>
        private bool MostrarReporte(ReportClass instanciareporte, string headervisor)
        {
            bool impreso = false;
            Visor_Informe viewer = new Visor_Informe();
            viewer.GeneralViewer1.ReportSource = instanciareporte;
            if (instanciareporte.HasRecords)
            {
                try
                {
                    viewer.Text = headervisor;
                    viewer.Show(); // lo muestra si hay records en el reporte.
                    impreso = true;
                }
                catch (SystemException ex)
                {
                    throw ex;
                }
            }
            else
            {
                Cls_Helper.MostrarMensaje("No se encontraron datos para el criterio de búsqueda. El reporte está vacío", "Alerta", 2);
            }
            return impreso;
        } // Fin MOSTRAR REPORTE
       


    }
}
