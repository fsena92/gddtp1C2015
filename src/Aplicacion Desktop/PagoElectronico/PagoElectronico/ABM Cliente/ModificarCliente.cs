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
    public partial class ModificarCliente : Form
    {
        private Login.Tablero padre;
        private int codigo;
        private String usuario;

        public ModificarCliente(Login.Tablero ruta, int codCli)
        {
            InitializeComponent();
            padre=ruta;
            codigo=codCli;
            Conexion con = new Conexion();
            con.query = "SELECT Nombre, Apellido, D.Descripcion, Nro_Doc, Mail, Calle, Nro_Calle, Piso, Depto, Localidad, Nacionalidad, P.Descripcion, Fecha_Nac, Estado"+
            " FROM ESCUADRON_SUICIDA.Cliente C JOIN ESCUADRON_SUICIDA.Pais P ON (C.Cod_Pais=P.Cod_Pais) JOIN ESCUADRON_SUICIDA.Documento D ON (D.Tipo_Doc=C.Tipo_Doc) WHERE Cod_Cli = " + codCli + "";
            con.ejecutarQuery();
            con.leerReader();
            txtNombre.Text = con.lector.GetString(0);
            txtApellido.Text = con.lector.GetString(1);
            cbTipo.Text = con.lector.GetString(2);
            txtNroID.Text = con.lector.GetDecimal(3).ToString();
            txtMail.Text = con.lector.GetString(4);
            txtCalle.Text = con.lector.GetString(5);
            txtNroDom.Text = con.lector.GetDecimal(6).ToString();
            txtPiso.Text = con.lector.GetDecimal(7).ToString();
            checkHab.Checked = (con.lector.GetBoolean(13));
            if (!(con.lector.GetString(8)==""))
            {
                txtDepto.Text = con.lector.GetString(8);   
            }
            
            txtLocalidad.Text = con.lector.GetString(9);
            
            txtNacionalidad.Text = con.lector.GetString(10);

            cbPais.Text = con.lector.GetString(11);

            dtpFecNac.Value = Convert.ToDateTime(con.lector.GetDateTime(12));
            

            con.cerrarConexion();

            /*Llena Tipo de doc*/
            con.query = "SELECT Descripcion FROM ESCUADRON_SUICIDA.Documento";
            con.ejecutarQuery();
            while(con.leerReader())
            {
                cbTipo.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();
            /*Llena Paises*/
            con.query = "SELECT Descripcion FROM ESCUADRON_SUICIDA.Pais";
            con.ejecutarQuery();
            while(con.leerReader())
            {
                cbPais.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();

            con.query = "SELECT Usuario FROM ESCUADRON_SUICIDA.Cliente WHERE Cod_Cli=" + codCli;
            con.ejecutarQuery();
            con.leerReader();
            usuario=con.lector.GetString(0);
            con.cerrarConexion();

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {            
            Conexion con = new Conexion();
            
            /*Validaciones*/

            if (txtNombre.Text=="")
            {
                MessageBox.Show("Ingrese un nombre");
                return;
            }

            if (txtApellido.Text=="")
            {
                MessageBox.Show("Ingrese un Apellido");
                return;
            }

            if (cbTipo.Text == "")
            {
                MessageBox.Show("Seleccione el tipo de documento");
                return;
            }

            if (!txtNroID.Text.IsNumeric() || txtNroID.Text.Length>18 || txtNroID.Text == "")
            {
                MessageBox.Show("El documento debe ser numerico con una longitud menor de 18 digitos");
                return;
            }

            if (txtMail.Text == "")
            {
                MessageBox.Show("Ingrese un mail");
                return;
            }

            if (cbPais.Text == "")
            {
                MessageBox.Show("Seleccione un pais");
                return;
            }

            if (txtCalle.Text=="")
            {
                MessageBox.Show("Ingrese un domicilio");
                return;
            }

            if (txtNroDom.Text == "" || !txtNroDom.Text.IsNumeric())
            {
                MessageBox.Show("Ingrese un numero de domicilio");
                return;
            }

            if (txtLocalidad.Text == "")
            {
                MessageBox.Show("Ingrese la localidad");
                return;
            }

            if (txtNacionalidad.Text == "") 
            {
                MessageBox.Show("Ingrese la nacionalidad");
                return;
            }
            con.query = "SELECT Usuario FROM ESCUADRON_SUICIDA.Cliente WHERE Mail='" + txtMail.Text + "' AND Cod_Cli <> " + codigo;
            con.ejecutarQuery();
            if (con.leerReader())
            {
                MessageBox.Show("Ya existe un cliente con este mail");
                return;
            }
            con.cerrarConexion();

            con.query = "SELECT * FROM ESCUADRON_SUICIDA.Cliente "+
            "WHERE Tipo_Doc=(SELECT Tipo_Doc FROM ESCUADRON_SUICIDA.Documento WHERE Descripcion='" + cbTipo.Text + "') AND Nro_Doc=" + txtNroID.Text+" AND Cod_Cli <> "+codigo;
            con.ejecutarQuery();
            if (con.leerReader())
            {
                MessageBox.Show("El Tipo y Numero de Documento ya existen");
                return;
            }
            con.cerrarConexion();
            
            /*Hace los cambios*/

            con.query = "UPDATE ESCUADRON_SUICIDA.Cliente SET Nombre='" + txtNombre.Text + "'WHERE Cod_Cli=" + codigo;
            con.ejecutarNoQuery();
            con.query = "UPDATE ESCUADRON_SUICIDA.Cliente SET Apellido='" + txtApellido.Text + "'WHERE Cod_Cli=" + codigo;
            con.ejecutarNoQuery();
            con.query = "UPDATE ESCUADRON_SUICIDA.Cliente SET Tipo_Doc= (SELECT Tipo_Doc FROM ESCUADRON_SUICIDA.Documento WHERE Descripcion='" + cbTipo.Text + "') WHERE Cod_Cli=" + codigo;
            con.ejecutarNoQuery();
            con.query = "UPDATE ESCUADRON_SUICIDA.Cliente SET Nro_Doc=" + txtNroID.Text + "WHERE Cod_Cli=" + codigo;
            con.ejecutarNoQuery();
            con.query = "UPDATE ESCUADRON_SUICIDA.Cliente SET Mail='" + txtMail.Text + "'WHERE Cod_Cli=" + codigo;
            con.ejecutarNoQuery();
            con.query = "UPDATE ESCUADRON_SUICIDA.Cliente SET Calle='" + txtCalle.Text + "'WHERE Cod_Cli=" + codigo;
            con.ejecutarNoQuery();
            con.query = "UPDATE ESCUADRON_SUICIDA.Cliente SET Nro_Calle=" + txtNroDom.Text + "WHERE Cod_Cli=" + codigo;
            con.ejecutarNoQuery();
            con.query = "UPDATE ESCUADRON_SUICIDA.Cliente SET Piso='" + txtPiso.Text + "'WHERE Cod_Cli=" + codigo;
            con.ejecutarNoQuery();
            con.query = "UPDATE ESCUADRON_SUICIDA.Cliente SET Depto='" + txtDepto.Text + "'WHERE Cod_Cli=" + codigo;
            con.ejecutarNoQuery();
            con.query = "UPDATE ESCUADRON_SUICIDA.Cliente SET Localidad='" + txtLocalidad.Text + "'WHERE Cod_Cli=" + codigo;
            con.ejecutarNoQuery();
            con.query = "UPDATE ESCUADRON_SUICIDA.Cliente SET Nacionalidad='" + txtNacionalidad.Text + "'WHERE Cod_Cli=" + codigo;
            con.ejecutarNoQuery();
            con.query = "UPDATE ESCUADRON_SUICIDA.Cliente SET Fecha_Nac='" + dtpFecNac.Value.ToString("yyyy-dd-MM") + "' WHERE Cod_Cli=" + codigo;
            con.ejecutarNoQuery();
            con.query = "UPDATE ESCUADRON_SUICIDA.Cliente SET Cod_Pais= (SELECT Cod_Pais FROM ESCUADRON_SUICIDA.Pais WHERE descripcion='" + cbPais.Text + "') WHERE Cod_Cli=" + codigo;
            con.ejecutarNoQuery();
            int estadoActual;
            if (checkHab.Checked) { estadoActual = 1; } else { estadoActual = 0; };

            con.query = "UPDATE ESCUADRON_SUICIDA.Cliente SET Estado= (" + estadoActual + ") WHERE Cod_Cli = " + codigo;
            con.ejecutarNoQuery();

            MessageBox.Show("Los datos han sido actualizados correctamente");
            padre.Show();
            this.Close();
        }

        private void btnAsociar_Click(object sender, EventArgs e)
        {
            ABM_Cliente.AsociarTarjetas form_Asoc = new AsociarTarjetas(padre, 'A', usuario, "");
            form_Asoc.Show();
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ABM_Cliente.SeleccionDeTarjetas form_Modi = new SeleccionDeTarjetas(padre,'M',usuario);
            form_Modi.Show();
            this.Close();
        }

        private void btnDesasociar_Click(object sender, EventArgs e)
        {
            ABM_Cliente.SeleccionDeTarjetas form_Modi = new SeleccionDeTarjetas(padre, 'B', usuario);
            form_Modi.Show();
            this.Close();
        }

        private void checkHab_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
