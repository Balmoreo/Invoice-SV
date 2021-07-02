using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MD_Facturas.classes;

namespace MD_Facturas
{
    public partial class Control_RangoFechas : UserControl
    {
        
        //propiedades
        public DateTime Desde { get { return DatePickerDesde.Value; } set { DatePickerDesde.Value = value; } }
        public DateTime Hasta { get { return DatePickerHasta.Value; } set { DatePickerHasta.Value = value; } }
        public string Mensaje { get; set; }

        public Control_RangoFechas()
        {
            InitializeComponent();
            DatePickerDesde.Value = DateTime.Now;
           // DatePickerHasta.MinDate = DatePickerDesde.Value;
           Desde = DateTime.Now;
            Hasta = DateTime.Now;
        }

        private void DatePickerHasta_ValueChanged(object sender, EventArgs e)
        {
            if (DatePickerHasta.Value < DatePickerDesde.Value)
            {
                Mensaje = "La fecha seleccionada no puede ser menor a la fecha de inicio!";
                Cls_Helper.MostrarMensaje(Mensaje, "Advertencia", 2);
            }
            else { /*do nothing */}
        }

        private void DatePickerDesde_ValueChanged(object sender, EventArgs e)
        {
            DatePickerHasta.MinDate = DatePickerDesde.Value;
        }
         
     

    }
}
