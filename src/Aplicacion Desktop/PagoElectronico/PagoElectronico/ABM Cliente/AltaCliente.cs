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
    public partial class AltaCliente : Form
    {
        private Login.Tablero padre;

        public AltaCliente(Login.Tablero ruta)
        {
            InitializeComponent();
            this.padre = ruta;
            Conexion con = new Conexion();
            con.query = "SELECT descripcion FROM ESCUADRON_SUICIDA.Pais";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cbPais.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();
            con.query = "SELECT Descripcion FROM ESCUADRON_SUICIDA.Documento";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cbTipo.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();

            con.query = "SELECT U.Usuario, C.Cod_Cli FROM ESCUADRON_SUICIDA.RolPorUsuario U LEFT "+ 
							"JOIN ESCUADRON_SUICIDA.Cliente C ON (U.Usuario=C.Usuario) "+
							"JOIN ESCUADRON_SUICIDA.Roles RR ON (U.Id_Rol=RR.Id_Rol) WHERE C.Cod_Cli is null AND RR.Nombre='Cliente'";
            con.ejecutarQuery();
            if (con.leerReader())
            {
                cbUsuario.Items.Add(con.lector.GetString(0));
                while (con.leerReader())
                {
                    cbUsuario.Items.Add(con.lector.GetString(0));
                }
            }
            else 
            {                
                this.Width = 220;
                this.Height = 80;
                groupBox1.Visible = false;
                LabelA.Top = 5;
                btnCancelar2.Top = 20;
                return;
            }
            con.cerrarConexion();
            LabelA.Visible = false;
            btnCancelar2.Visible = false;

        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            
            //Verifica que el Usuario sea correcto
                        
            if (cbUsuario.Text == "") { MessageBox.Show("Seleccione el usuario"); return; }
                        
            //Verifica que los campos esten completos

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
            
            if (txtPiso.Text == "" || !txtPiso.Text.IsNumeric())
            {
                txtPiso.Text="0";
            }

            if (txtDepto.Text == "")
            {
                txtDepto.Text = "0";
            }

                
            //Verifica que los campos no esten repetidos y sean validos

            con.query = "SELECT Usuario FROM ESCUADRON_SUICIDA.Cliente WHERE Tipo_Doc=(select Tipo_Doc from ESCUADRON_SUICIDA.Documento where Descripcion='" + cbTipo.Text + "') AND Nro_Doc=" + txtNroID.Text;
            con.ejecutarQuery();
            if (con.leerReader())
            {
                MessageBox.Show("Ya existe un cliente con este tipo y numero de documento");
                return;
            }
            con.cerrarConexion();
            
            con.query = "SELECT Usuario FROM ESCUADRON_SUICIDA.Cliente WHERE Mail='" + txtMail.Text + "'";
            con.ejecutarQuery();
            if (con.leerReader())
            {
                MessageBox.Show("Ya existe un cliente con este mail");
                return;
            }
            con.cerrarConexion();
       

            /*Hace el Insert*/

            con.query = "INSERT INTO ESCUADRON_SUICIDA.Cliente" +
                      "(Nombre,Apellido,Tipo_Doc,Nro_Doc,Mail,Calle,Nro_Calle,Piso,Depto,Localidad,Nacionalidad,Fecha_Nac,Cod_Pais,Usuario)" +
                      "VALUES ('" + txtNombre.Text + "','" + txtApellido.Text + "',(SELECT Tipo_Doc FROM ESCUADRON_SUICIDA.Documento WHERE Descripcion='"+cbTipo.Text+"')"+
                      "," + txtNroID.Text + ",'" + txtMail.Text + "','" + txtCalle.Text + "',"+txtNroDom.Text+"," + txtPiso.Text + ",'" + txtDepto.Text + 
                      "','" + txtLocalidad.Text + "','" + txtNacionalidad.Text + "','" + dtpFecNac.Value.ToString("yyyy-dd-MM") + "',"+
                      "(SELECT Cod_Pais FROM ESCUADRON_SUICIDA.Pais WHERE Descripcion ='" + cbPais.Text + "'),'" + cbUsuario.Text + "')";
            con.ejecutarNoQuery();
            con.cerrarConexion();
            MessageBox.Show("El cliente ha sido agregado con exito");
            this.Close();
            padre.Show();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            padre.Show();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Text = "";
            txtCalle.Text = "";
            txtDepto.Text = "";
            txtMail.Text = "";
            txtNacionalidad.Text = "";
            cbPais.Text = "";
            txtPiso.Text = "";
            cbUsuario.Text = "";
            txtNroID.Text = "";
            cbTipo.Text = "";
            txtNombre.Text = "";
            txtNroDom.Text = "";
            txtLocalidad.Text = "";
        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar2_Click(object sender, EventArgs e)
        {
            this.Close();
            padre.Show();
        }
    }
}
