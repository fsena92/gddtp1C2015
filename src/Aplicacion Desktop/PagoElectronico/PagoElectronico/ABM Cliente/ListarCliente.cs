using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.ABM_Cliente
{
    public partial class ListarCliente : Form
    {
        private char tipo;
        private Int64 ID_Seleccionado;
        public ListarCliente(char t)
        {
            InitializeComponent();
            tipo = t;
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            con.query = "SELECT Nombre, Apellido, Tipo_Doc, Nro_doc FROM dbo.Cliente WHERE 1=1 ";
            if (txtNombre.Text != "")
                con.query = con.query + "AND Nombre = '"+txtNombre.Text+"' ";
            if (txtApellido.Text != "")
                con.query = con.query + "AND Apellido = '" + txtApellido.Text + "' ";
            if (cmbTipo.Text != "")
                con.query = con.query + "AND Tipo_Doc = '" + cmbTipo.Text + "' ";
            if (txtDoc.Text != "")
                con.query = con.query + "AND Nro_Doc = '"+txtDoc.Text+"' ";
            if (txtEmail.Text != "")
                con.query = con.query + "AND Email = '" + txtEmail.Text + "' ";

            con.ejecutarQuery();
            if (!con.leerReader())
            {
                MessageBox.Show("La busqueda no produjo resultados");
                con.query = "";
                con.cerrarConexion();
                return;
            }

            dtvClientes.Rows.Add(new Object[] { con.lector.GetString(0), con.lector.GetString(1),
                                   con.lector.GetString(2) });

            while (con.leerReader())
            {
                dtvClientes.Rows.Add(new Object[] { con.lector.GetString(0), con.lector.GetString(1),
                                   con.lector.GetString(2) });
            }
            con.cerrarConexion();

            //SE GUARDA EL ID DEL CLIENTE SELECCIONADO 
            con.query = "SELECT Cod_Cli FROM dbo.Cliente WHERE Nro_Doc = '" + "SELECT Nro_Doc FROM" + dtvClientes.SelectedColumns + "'";
            con.ejecutarQuery();
            con.leerReader();
            ID_Seleccionado = con.lector.GetInt64(0);
            con.cerrarConexion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if por si es baja (con delete) y sino abre alta cliente con datos
            Conexion con = new Conexion();
            if (tipo == 'B')
            { 
                con.query = "UPDATE dbo.Cliente SET(Estado) = 0 WHERE Cod_Cli = '"+ ID_Seleccionado+"' ";
                con.ejecutarQuery();
                con.cerrarConexion();

              
            }
        }

    }
}
