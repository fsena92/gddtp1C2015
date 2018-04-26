using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Comparadores;

namespace PagoElectronico.ABM_Cliente
{
    public partial class Listado_de_seleccion_cliente : Form
    {
        private char tipoDeSeleccion;
        private Login.Tablero padre;

        public Listado_de_seleccion_cliente(Login.Tablero ruta, char tipo)
        {
            InitializeComponent();
            tipoDeSeleccion = tipo;
            padre = ruta;
            Conexion con = new Conexion();
            con.query = "SELECT Descripcion FROM ESCUADRON_SUICIDA.Documento";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cmbTipo.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Text="";
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtDoc.Text = "";
            cmbTipo.Text= "";


        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            dtvClientes.Rows.Clear();

            if (!txtDoc.Text.IsNumeric()&& !(txtDoc.Text=="")|| txtDoc.Text.Length>18)
            {
                MessageBox.Show("El documendo debe ser un numero, con menos de 18 digitos");
                return;
            }

            Conexion con = new Conexion();
            con.query = "SELECT Nombre, Apellido, Descripcion, Nro_doc, Cod_Cli"+
                            " FROM ESCUADRON_SUICIDA.Cliente C"+
                            " JOIN ESCUADRON_SUICIDA.Documento D ON(C.Tipo_Doc=D.Tipo_Doc)"+
                            " WHERE 1=1 ";
            if (txtNombre.Text != "")
                con.query = con.query + "AND Nombre = '" + txtNombre.Text + "' ";
            if (txtApellido.Text != "")
                con.query = con.query + "AND Apellido = '" + txtApellido.Text + "' ";
            if (cmbTipo.Text != "")
                con.query = con.query + "AND Descripcion='" + cmbTipo.Text + "'";
            if (txtDoc.Text != "")
                con.query = con.query + "AND Nro_Doc = " + txtDoc.Text;
            if (txtEmail.Text != "")
                con.query = con.query + "AND Mail = '" + txtEmail.Text + "' ";

            con.ejecutarQuery();
            if (!con.leerReader())
            {
                MessageBox.Show("La busqueda no produjo resultados");
                con.query = "";
                con.cerrarConexion();
                return;
            }

            dtvClientes.Rows.Add(new Object[] { con.lector.GetString(0), con.lector.GetString(1),
                                   con.lector.GetString(2), con.lector.GetSqlDecimal(3), con.lector.GetInt32(4) });

            while (con.leerReader())
            {
                dtvClientes.Rows.Add(new Object[] { con.lector.GetString(0), con.lector.GetString(1),
                                   con.lector.GetString(2), con.lector.GetDecimal(3), con.lector.GetInt32(4) });
            }
            con.cerrarConexion();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (dtvClientes.Rows.Count <= 0) { MessageBox.Show("Primero se debe realizar una busqueda"); return; }
                        
            Conexion con = new Conexion();

            int codCli = dtvClientes.CurrentRow.Cells[4].Value.GetHashCode();

            if (tipoDeSeleccion == 'B')
            {
                con.query = "UPDATE ESCUADRON_SUICIDA.Cliente SET Estado = 0 WHERE Cod_Cli = " + codCli;
                con.ejecutarNoQuery();
                MessageBox.Show("El cliente ha sido eliminado");
                padre.Show();
                this.Close();
            }
            else 
            {
                ModificarCliente form_ModifCli = new ModificarCliente(padre,codCli);
                form_ModifCli.Show();
                this.Close();
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }

    }
}
