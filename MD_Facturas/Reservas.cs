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
    public partial class Reservas : Form
    {
        public Reservas()
        {
            InitializeComponent();
        }

        private void Reservas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'mODULO_FACT_VECADataSet.Tbl_Reservas' Puede moverla o quitarla según sea necesario.
            this.tbl_ReservasTableAdapter.Fill(this.mODULO_FACT_VECADataSet.Tbl_Reservas);
            DateFin.MinDate = Convert.ToDateTime(DateInicio.Value);

        }

        private void DateInicio_Validated(object sender, EventArgs e)
        {
            DateFin.MinDate = Convert.ToDateTime(DateInicio.Value);
        }

        private void Btt_Facturar_Click(object sender, EventArgs e)
        {
            MDIParent1 p1 = (MDIParent1)Application.OpenForms["MDIParent1"];
            MDIParent1 f1 = (MDIParent1)p1;
            f1.Mtd_Facturar();
            this.Hide();
        }


    }
}
