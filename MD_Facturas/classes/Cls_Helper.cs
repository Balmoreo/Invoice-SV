//written by Juan Carlos Menjivar
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace MD_Facturas.classes
{
    public static class Cls_Helper
    {
        /// <summary>
        /// Metodo para mostrar un mensaje de error personalizado. 0: info, 1: error , 2: alerta, 3: pregunta
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="header"></param>
        /// <param name="opc"></param>
        public static DialogResult MostrarMensaje(string mensaje, string header, int opc = 0)
        {
            DialogResult d = DialogResult.None;
            switch (opc)
            {
                case 0:
                    d = MessageBox.Show("" + mensaje, "" + header, MessageBoxButtons.OK, MessageBoxIcon.Information); // Icono info
                    break;
                case 1:
                    d = MessageBox.Show("" + mensaje, "" + header, MessageBoxButtons.OK, MessageBoxIcon.Error); // Icono error
                    break;
                case 2:
                    d = MessageBox.Show("" + mensaje, "" + header, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // Icono exclamacion
                    break;
                case 3:
                    d = MessageBox.Show("" + mensaje, "" + header, MessageBoxButtons.YesNo, MessageBoxIcon.Question);// Icono Pregunta
                    break;
                default:
                    d = MessageBox.Show("" + mensaje, "" + header, MessageBoxButtons.OK, MessageBoxIcon.None);
                    break;

            }
            return d;
        } // in mostrar mensaje

        /// <summary>
        /// AutoCompletar helper
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="data"></param>
        /// <param name="columnavalor"></param>
        public static void AutoCompletar(TextBox nombre, DataTable data, string columnavalor)
        {
            try
            {
                nombre.AutoCompleteMode = AutoCompleteMode.Suggest;
                nombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection autostring = new AutoCompleteStringCollection();
                foreach (DataRow d in data.Rows)
                {
                    autostring.Add(Convert.ToString(d[columnavalor]));
                }
                nombre.AutoCompleteCustomSource = autostring;
            }
            catch { }
        } // Fin autocomplete

        /// <summary>
        /// AutoCompletar helper dos campos a la vez
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="data"></param>
        /// <param name="columnavalor"></param>
        public static void AutoCompletar(TextBox nombre, DataTable data, string columnavalor, string columnavalor2)
        {
            nombre.AutoCompleteMode = AutoCompleteMode.Suggest;
            nombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection autostring = new AutoCompleteStringCollection();
            AutoCompleteStringCollection autostring2 = new AutoCompleteStringCollection();
            foreach (DataRow d in data.Rows)
            {
                autostring.Add(Convert.ToString(d[columnavalor]) + " | " + Convert.ToString(d[columnavalor2]));
                
            }
            nombre.AutoCompleteCustomSource = autostring;
           
        } // Fin autocomplete

        ///<summary>
        ///<para> Metodo de Busqueda con dos o más palabras (by Lorenzo). Recibe ControlName del control donde se hace la bùsqueda.</para>
        ///<para>Retorna string con el formato para búsqueda. Para implementacion completar select query con la cadena modificada usado "LIKE".</para>
        ///</summary>
        public static string BusquedaPro(Control controlname)
        {
            string s = controlname.Text;
            string buscar = "";
            string word1;
            string[] words = s.Split(' ');

            foreach (string word in words)
            {
                word1 = "%" + word;
                buscar = buscar + word1;
            }
            buscar = buscar + "%";
            return buscar;
        }

        ///<summary> 
        /// Llena cualquier  drop down list a partir de un data table existente .. recibe .---existingDataSet(opcional),nombre display_member y value member.
        ///</summary>
        public static void LlenaComboBox(ComboBox controlname, DataTable dataTable, string Display, string Value)
        {
            controlname.DisplayMember = Display;
            controlname.ValueMember = Value;
            controlname.DataSource = dataTable;
        }

        /// <summary>
        ///  Limpiar todos los controles de una vez. Recibe nombre de Control conetenedor (DocumentWindow)
        /// </summary>
        /// <param name="control"></param>
        public static void LimpiarCampos(Control control)
        {
            int count = 1;
            if (control.HasChildren)
            {
                // MessageBox.Show("Si tiene hijos");
                foreach (Control c in control.Controls)
                {
                    if (c.HasChildren)
                    {
                        LimpiarCampos(c);
                    }
                    else
                    {
                        if (c is TextBox) { ((TextBox)c).Text = ""; }
                        else if (c is MaskedTextBox) { ((MaskedTextBox)c).Text = ""; }
                        else if (c is ComboBox) { ((ComboBox)c).SelectedIndex = 0; }
                        else if (c is DataGridView) { ((DataGridView)c).DataSource = ""; }
                        count++;
                    }

                }
            }// Fin Primer IF
            else
            { MessageBox.Show("NO hay ningun control"); }

        }// Fin Limpiar Campos   


        /// <summary>
        /// Llena un ComboBoxColumn a partir de un DataTable.
        /// </summary>
        public static void ComboBoxColumn_Fill(DataGridView NombreGrid, string NombreColumna, DataTable NombreDataTable, string DisplayMember, string ValueMember)
        {
            ((DataGridViewComboBoxColumn)NombreGrid.Columns[NombreColumna]).DataSource = NombreDataTable;
            ((DataGridViewComboBoxColumn)NombreGrid.Columns[NombreColumna]).DisplayMember = DisplayMember;
            ((DataGridViewComboBoxColumn)NombreGrid.Columns[NombreColumna]).ValueMember = ValueMember;
        }
        /// <summary>
        /// Llena un ComboBoxColumn a partir de un query string y conexión (opcional)
        /// </summary>
        public static void ComboBoxColumn_Fill(DataGridView NombreGrid, string NombreColumna, string DisplayMember, string ValueMember, string query, SqlConnection cn = null)
        {
            Cls_Con cn1 = new Cls_Con();
            if (cn == null) { cn = cn1.conexion; }
            ((DataGridViewComboBoxColumn)NombreGrid.Columns[NombreColumna]).DataSource = cn1.GetDataTable(query, cn);
            ((DataGridViewComboBoxColumn)NombreGrid.Columns[NombreColumna]).DisplayMember = DisplayMember;
            ((DataGridViewComboBoxColumn)NombreGrid.Columns[NombreColumna]).ValueMember = ValueMember;
        }


    }
}
