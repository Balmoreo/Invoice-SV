using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MD_Facturas.classes;

namespace MD_Facturas
{
    public partial class VerClientes : Form
    {
        public string TpForm { get; set; }
        public VerClientes()
        {
            InitializeComponent();
        }

        public void MostrarClientes()
        {
            Cls_Con c = new Cls_Con();
          gvClientes.DataSource=  c.GetDataTable("SELECT * FROM tbl_CLIENTES");
                      
        }


        public void BCliente()
        {
            if (TxtBusCliente.Text != "") {
                Cls_Con c2 = new Cls_Con();
              SqlParameter[] p = { new SqlParameter("@NOMBRE",SqlDbType.VarChar){Value =  Convert.ToString(Cls_Helper.BusquedaPro(TxtBusCliente)) }
            }; 
                gvClientes.DataSource = c2.GetDataTable("SELECT * FROM TBL_CLIENTES WHERE NOMBRE LIKE @NOMBRE", c2.conexion,p);
            }
            else if (TxtBusCliente.Text == "")
            {
                MostrarClientes();

            }       
            
        }

        private void Btt_Buscar_Click(object sender, EventArgs e)
        {
            BCliente();
        }

        private void gvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           try
             {
                 if (e.RowIndex >= 0)
                 {
                     if (TpForm != "MdFact")
                     {
                         Form p1 = (Form)Application.OpenForms["Frm_Clientes"];
                         Frm_Clientes f1 = (Frm_Clientes)p1;

                         if (f1 != null)
                         {
                             f1.Txt_NombreCliente.Text = Convert.ToString(gvClientes.Rows[e.RowIndex].Cells["Nombre"].Value) + " | " + Convert.ToString(gvClientes.Rows[e.RowIndex].Cells["Id_cliente"].Value);
                             f1.llenarInforCliente();
                             this.Close();
                         }
                     }

                     else if (TpForm == "MdFact")
                     {
                         Form p1 = (Form)Application.OpenForms["Facturar_Manual"];
                         Facturar_Manual f1 = (Facturar_Manual)p1;

                         if (f1 != null)
                         {
                             f1.Txt_IdCliente.Text = Convert.ToString(gvClientes.Rows[e.RowIndex].Cells["Id_cliente"].Value);
                             f1.Txt_NombreCliente.Text = Convert.ToString(gvClientes.Rows[e.RowIndex].Cells["Nombre"].Value) + " | " + Convert.ToString(gvClientes.Rows[e.RowIndex].Cells["Id_cliente"].Value);
                             f1.LlenarDatosCliente();
                             this.Close();
                         }

                     }
                 }
           }catch{}


        }

        private void TxtBusCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Btt_Buscar.PerformClick();
            }
        }




    }
}
