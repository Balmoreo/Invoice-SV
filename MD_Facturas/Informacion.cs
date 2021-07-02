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
using MD_Facturas.MODULO_FACT_VECADataSetTableAdapters;
using System.Globalization;


namespace MD_Facturas
{
    public partial class Informacion : Form
    {
        public string tipoInf{ get; set; }
        public Informacion()
        {
            InitializeComponent();
        }
        
        public void Busqueda()
        {

            switch (tipoInf)
            {
                case "pais":
                    if (TxtBusCliente.Text != "")
                    {
                        Cls_Con c2 = new Cls_Con();
                        SqlParameter[] p = { new SqlParameter("@Gen",SqlDbType.VarChar){Value =  Convert.ToString(Cls_Helper.BusquedaPro(TxtBusCliente)) }
                    };
                        DataGridInformacion.DataSource = c2.GetDataTable("SELECT  Cod_Pais, Nombre_Pais, Nacionalidad, Iniciales FROM Tbl_Pais WHERE Nombre_Pais LIKE @Gen", c2.conexion, p);
                    }
                    return;

                case "empresa":
                    if (TxtBusCliente.Text != "")
                    {
                        Cls_Con c2 = new Cls_Con();
                        SqlParameter[] p = { new SqlParameter("@Gen",SqlDbType.VarChar){Value =  Convert.ToString(Cls_Helper.BusquedaPro(TxtBusCliente)) }
                    };
                        DataGridInformacion.DataSource = c2.GetDataTable("SELECT e.Cod_empresa AS 'Codigo Empresa', e.Nombre_Comercial AS 'Nombre Empresa', p.Nombre_Pais AS 'Pais', e.Telefono_Empresa AS 'Telefono Empresa', pv.Nombre_Punto AS 'Punto de Venta', pv.Direccion AS 'Direccion Punto venta', pv.TelefonoPv AS 'Telefono Punto venta', e.Nit, e.Nrc, c.Tipo_Contribuyente AS 'Contribuyente' FROM  Tbl_Empresa AS e INNER JOIN Tbl_Pais AS p ON e.Cod_Pais = p.Cod_Pais INNER JOIN Tbl_Contribuyente AS c ON e.Id_Tipo_Contribuyecte = c.Id_Tipo_Contribuyecte INNER JOIN  Tbl_Punto_Venta AS pv ON e.Cod_empresa = pv.Cod_empresa WHERE e.Nombre_Comercial LIKE @gen", c2.conexion, p);
                    }
                    return;
                case "servicio":
                    if (TxtBusCliente.Text != "")
                    {
                        Cls_Con c2 = new Cls_Con();
                        SqlParameter[] p = { new SqlParameter("@Gen",SqlDbType.VarChar){Value =  Convert.ToString(Cls_Helper.BusquedaPro(TxtBusCliente)) }
                    };
                        DataGridInformacion.DataSource = c2.GetDataTable("SELECT e.Nombre_Comercial AS 'Empresa', p.Nombre_Pais AS 'Pais', s.Cod_Servicio AS 'Codigo Servicio', s.Descripcion, s.FechaCreacion AS 'Fecha Creacion', s.Estado, s.Nota FROM Tbl_Servicios AS s INNER JOIN Tbl_Empresa AS e ON s.Cod_empresa = e.Cod_empresa INNER JOIN  Tbl_Pais AS p ON e.Cod_Pais = p.Cod_Pais WHERE s.Descripcion LIKE @Gen", c2.conexion, p);
                    }
                    return;
                case "empleado":
                    if (TxtBusCliente.Text != "")
                    {
                        Cls_Con c2 = new Cls_Con();
                        SqlParameter[] p = { new SqlParameter("@Gen",SqlDbType.VarChar){Value =  Convert.ToString(Cls_Helper.BusquedaPro(TxtBusCliente)) }
                    };
                        DataGridInformacion.DataSource = c2.GetDataTable("SELECT em.Cod_Empleado AS 'Codigo', em.Nombre, em.Cargo, em.Departamento, p.Nombre_Pais AS 'Pais', em.Direccion, em.Telefono, e.Nombre_Comercial AS 'Empresa', pv.Nombre_Punto AS 'Punto Venta', em.FechaEmp AS 'Fecha' FROM Tbl_Empleados AS em INNER JOIN Tbl_Empresa AS e ON em.Cod_Empresa = e.Cod_empresa INNER JOIN Tbl_Punto_Venta AS pv ON e.Cod_empresa = pv.Cod_empresa AND em.Cod_Punto_Venta = pv.Cod_Punto_Venta INNER JOIN Tbl_Pais AS p ON em.Cod_Pais = p.Cod_Pais WHERE em.Nombre LIKE @Gen", c2.conexion, p);
                    }
                    return;

                case "usuario":
                    if (TxtBusCliente.Text != "")
                    {
                        Cls_Con c2 = new Cls_Con();
                        SqlParameter[] p = { new SqlParameter("@Gen",SqlDbType.VarChar){Value =  Convert.ToString(Cls_Helper.BusquedaPro(TxtBusCliente)) }
                    };
                        DataGridInformacion.DataSource = c2.GetDataTable("SELECT e.Cod_Empleado AS 'Codigo Empleado', u.Usuario, u.Nombre_Empleado AS 'Nombre', u.Caja, u.Ventas, u.Encargado, u.Supervisor, u.Gerente, u.FechaIn AS 'Fecha' FROM Tbl_Usuarios AS u INNER JOIN Tbl_Empleados AS e ON u.Id_Empleado = e.Id_Empleado WHERE u.Usuario LIKE @Gen", c2.conexion, p);
                    }
                    return;
                case "TpCliente":
                    if (TxtBusCliente.Text != "")
                    {
                        Cls_Con c2 = new Cls_Con();
                        SqlParameter[] p = { new SqlParameter("@Gen",SqlDbType.VarChar){Value =  Convert.ToString(Cls_Helper.BusquedaPro(TxtBusCliente)) }
                    };
                        DataGridInformacion.DataSource = c2.GetDataTable("select t.Id_Tipo_Cliente as 'Codigo',t.Tipo_Cliente as 'Tipo Cliente', p.Nombre_Pais as 'Pais' from Tbl_Tipo_Cliente t inner join Tbl_Pais p on t.cod_pais =p.Cod_Pais WHERE t.Tipo_Cliente LIKE @Gen", c2.conexion, p);
                    }
                    return;

                case "TpContri":
                    if (TxtBusCliente.Text != "")
                    {
                        Cls_Con c2 = new Cls_Con();
                        SqlParameter[] p = { new SqlParameter("@Gen",SqlDbType.VarChar){Value =  Convert.ToString(Cls_Helper.BusquedaPro(TxtBusCliente)) }
                    };
                        DataGridInformacion.DataSource = c2.GetDataTable("select c.Id_Tipo_Contribuyecte as 'Codigo' ,c.Tipo_Contribuyente as 'Tipo Contribuyente' , p.Nombre_Pais as 'Pais' from Tbl_Contribuyente c inner join Tbl_Pais p on c.Pais =p.Cod_Pais WHERE c.Tipo_Contribuyente LIKE @Gen", c2.conexion, p);
                    }
                    return;

                case "TpDoc":
                    if (TxtBusCliente.Text != "")
                    {
                        Cls_Con c2 = new Cls_Con();
                        SqlParameter[] p = { new SqlParameter("@Gen",SqlDbType.VarChar){Value =  Convert.ToString(Cls_Helper.BusquedaPro(TxtBusCliente)) }
                    };
                   //     DataGridInformacion.DataSource = c2.GetDataTable("SELECT t.Cod_Doc AS 'Codigo Documento', t.Tipo_Doc AS 'Tipo Documento', p.Nombre_Pais AS 'Pais', t.vigente, t.Fecha_Creado AS 'Fecha Creacion' FROM  Tbl_Tipo_Doc AS t INNER JOIN  Tbl_Pais AS p ON t.Cod_Pais = p.Cod_Pais WHERE t.Tipo_Doc LIKE @Gen", c2.conexion, p);
                        DataGridInformacion.DataSource = c2.GetDataTable("SELECT  t.Cod_Doc AS 'Codigo Documento',t.Tipo_Doc AS 'Tipo Documento',tb.Serie_Doc as 'Serie',tb.Correlativo_ini as 'Correlativo Ini',tb.Correlativo_fin as 'Correlativo Fin',pv.Nombre_Punto as 'Punto de venta',  p.Nombre_Pais AS 'Pais', t.vigente, t.Fecha_Creado AS 'Fecha Creacion'  FROM Tbl_Tipo_Doc AS t INNER JOIN Tbl_Pais AS p ON t.Cod_Pais = p.Cod_Pais inner join Tbl_Doc_PuntoVenta tb on t.Cod_Doc=tb.Cod_Doc inner join Tbl_Punto_Venta pv on tb.Cod_PuntoVenta=pv.Cod_Punto_Venta WHERE t.Tipo_Doc LIKE @Gen", c2.conexion, p);


                    
                    }

                    return;

            }
        }

        private void Btt_Buscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }

        private void TxtBusCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter){

                Btt_Buscar.PerformClick();
            }
        }

        private void DataGridInformacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    switch (tipoInf) {
                        case "pais":
                            Form p1 = (Form)Application.OpenForms["Configuraciones"];
                            Configuraciones f1 = (Configuraciones)p1;

                    if (f1 != null)
                    {
                        f1.Txt_NombrePais.Text = Convert.ToString(DataGridInformacion.Rows[e.RowIndex].Cells["Nombre_Pais"].Value) + " | " + Convert.ToString(DataGridInformacion.Rows[e.RowIndex].Cells["Cod_Pais"].Value);
                        f1.TpInf = "pais";
                        f1.TraerInformacion();
                        this.Close();
                    }
                    return;

                        case "empresa":
                    Form p2 = (Form)Application.OpenForms["Configuraciones"];
                    Configuraciones f2 = (Configuraciones)p2;

                    if (f2 != null)
                    {
                        f2.Txt_NombreEmpresa.Text = Convert.ToString(DataGridInformacion.Rows[e.RowIndex].Cells["Nombre Empresa"].Value) + " | " + Convert.ToString(DataGridInformacion.Rows[e.RowIndex].Cells["Codigo Empresa"].Value);
                        f2.TpInf = "empresa";
                        f2.TraerInformacion();
                        this.Close();
                    }
                    return;

                        case "empleado":
                    Form p3 = (Form)Application.OpenForms["Configuraciones"];
                    Configuraciones f3 = (Configuraciones)p3;

                    if (f3 != null)
                    {
                        f3.TxtNombEMP.Text = Convert.ToString(DataGridInformacion.Rows[e.RowIndex].Cells["Nombre"].Value) + " | " + Convert.ToString(DataGridInformacion.Rows[e.RowIndex].Cells["Codigo"].Value);
                        f3.TpInf = "empleado";
                        f3.TraerInformacion();
                        this.Close();
                    }
                    return;

                        case "TpDoc":
                    Form p4 = (Form)Application.OpenForms["Configuraciones"];
                    Configuraciones f4 = (Configuraciones)p4;

                    if (f4 != null)
                    {
                        f4.TxtTpDocGrl.Text = Convert.ToString(DataGridInformacion.Rows[e.RowIndex].Cells["Tipo Documento"].Value) + " | " + Convert.ToString(DataGridInformacion.Rows[e.RowIndex].Cells["Codigo Documento"].Value);
                        f4.TpInf = "TpDoc";
                        f4.TraerInformacion();

                        this.Close();
                    }
                    return;


                }
                    
                }
            }
            catch { }

        }

    }
}
