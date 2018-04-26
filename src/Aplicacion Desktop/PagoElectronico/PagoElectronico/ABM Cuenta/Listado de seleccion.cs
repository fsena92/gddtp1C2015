using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.ABM_Cuenta
{
    public partial class Listado_de_seleccion_Cuenta : Form
    {
        private char tipoDeSeleccion;
        private Login.Tablero padre;
        Conexion con = new Conexion();
        private String rolActual;

        public Listado_de_seleccion_Cuenta(Login.Tablero ruta, char tipo, String usuario, String rol)
        {
            InitializeComponent();
            tipoDeSeleccion = tipo;
            padre = ruta;
            rolActual = rol;
            /*Llena usuarios*/
            if (rol == "Administrador")
            {
                con.query = "SELECT Usuario FROM ESCUADRON_SUICIDA.RolPorUsuario RU JOIN ESCUADRON_SUICIDA.Roles R ON(RU.Id_Rol=R.Id_Rol) WHERE R.Nombre='Cliente'";
                con.ejecutarQuery();
                while (con.leerReader())
                {
                    cbUsuario.Items.Add(con.lector.GetString(0));
                }
                con.cerrarConexion();
            }
            else 
            {
                cbUsuario.Items.Add(usuario);
            }
            /*Llena paises*/
            con.query = "SELECT Descripcion FROM ESCUADRON_SUICIDA.Pais";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cbPais.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();
            /*Llena tipos*/
            con.query = "SELECT Tipo_Cuenta FROM ESCUADRON_SUICIDA.TipoCuenta";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cbTipo.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();

        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            cbTipo.Text = "";
            cbPais.Text = "";
            cbUsuario.Text= "";
            chCerrada.Checked = false;
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (dtvCuentas.Rows.Count <= 0) { MessageBox.Show("Primero se debe realizar una busqueda"); return; }
       
            String nroCuenta = dtvCuentas.CurrentRow.Cells[0].Value.ToString();

            con.query = "SELECT * FROM ESCUADRON_SUICIDA.Cuenta WHERE Estado='Cerrada' AND Nro_Cuenta=" + nroCuenta;
            con.ejecutarQuery();
            if (con.leerReader())
            {
                MessageBox.Show("Su cuenta se encuentra cerrada, no puede realizar esta operacion");
                con.cerrarConexion();
                return;
            }
            con.cerrarConexion();

            con.query = "SELECT Estado FROM ESCUADRON_SUICIDA.Cuenta WHERE Nro_Cuenta=" + nroCuenta+ " AND Estado='Inhabilitada'";
            con.ejecutarQuery();
            if (con.leerReader())
            {
                MessageBox.Show("La cuenta esta inhabilitada y no puede realizar ningun tipo de transaccion, realize la facturacion para continuar");
                con.cerrarConexion();
                return;
            }
            con.cerrarConexion();

            if (tipoDeSeleccion == 'B')
            {

                con.query = "SELECT Estado FROM ESCUADRON_SUICIDA.Cuenta WHERE Nro_Cuenta=" + nroCuenta + " AND Estado='Pendiente'";
                con.ejecutarQuery();
                if (con.leerReader())
                {
                    MessageBox.Show("La cuenta se encuentra Pendiente, por favor realice la facturacion correspondiente antes de cerrarla");
                    con.cerrarConexion();
                    return;
                }
                con.cerrarConexion();

                con.query = "UPDATE ESCUADRON_SUICIDA.Cuenta SET Estado = 'Cerrada' WHERE Nro_Cuenta = " + nroCuenta;
                con.ejecutarNoQuery();
                MessageBox.Show("La Cuenta ha sido cerrado");
                padre.Show();
                this.Close();
            }
            else
            {
                ModificarCuentas form_ModifCue = new ModificarCuentas(padre, nroCuenta, rolActual);
                form_ModifCue.Show();
                this.Close();
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            dtvCuentas.Rows.Clear();
            if (rolActual!= "Administrador")
            {
                if (cbUsuario.Text == "")
                {
                    MessageBox.Show("Debe ingresar su usuario");
                }
                else
                {
                    con.query = "SELECT Nro_Cuenta ,Tipo_Cuenta, Estado, Tipo_Moneda, Cod_Pais FROM ESCUADRON_SUICIDA.Cuenta WHERE 1=1"+
                    "AND Cod_Cli = (SELECT Cod_Cli FROM ESCUADRON_SUICIDA.Cliente Where Usuario = '" + cbUsuario.Text + "')";
                    if (cbTipo.Text != "")
                        con.query = con.query + "AND Tipo_Cuenta = '" + cbTipo.Text + "' ";
                    if (cbPais.Text != "")
                        con.query = con.query + "AND Cod_Pais = (SELECT Cod_Pais FROM ESCUADRON_SUICIDA.Pais WHERE Descripcion = '" + cbPais.Text + "')";
                    if (chCerrada.Checked)
                        con.query = con.query + "AND Estado = 'Cerrada'";

                    con.ejecutarQuery();
                    if (!con.leerReader())
                    {
                        MessageBox.Show("La busqueda no produjo resultados");
                        con.query = "";
                        con.cerrarConexion();
                        return;
                    }

                    dtvCuentas.Rows.Add(new Object[] { con.lector.GetDecimal(0), con.lector.GetString(1),
                                   con.lector.GetString(2), con.lector.GetString(3),con.lector.GetDecimal(4)});

                    while (con.leerReader())
                    {
                        dtvCuentas.Rows.Add(new Object[] { con.lector.GetDecimal(0), con.lector.GetString(1),
                                   con.lector.GetString(2), con.lector.GetString(3),con.lector.GetDecimal(4)});
                    }
                    con.cerrarConexion();
                }
            }
            else
            {
            con.query = "SELECT Nro_Cuenta ,Tipo_Cuenta, Estado, Tipo_Moneda, Cod_Pais FROM ESCUADRON_SUICIDA.Cuenta WHERE 1=1 ";
            if (cbTipo.Text != "")
                con.query = con.query + "AND Tipo_Cuenta = '" + cbTipo.Text + "' ";
            if (cbUsuario.Text != "")
                con.query = con.query + "AND Cod_Cli = (SELECT Cod_Cli FROM ESCUADRON_SUICIDA.Cliente Where Usuario = '" + cbUsuario.Text + "')";
            if (cbPais.Text != "")
                con.query = con.query + "AND Cod_Pais = (SELECT Cod_Pais FROM ESCUADRON_SUICIDA.Pais WHERE Descripcion = '" + cbPais.Text + "')";
            if (chCerrada.Checked)
                con.query = con.query + "AND Estado = 'Cerrada'";
            
            con.ejecutarQuery();
            if (!con.leerReader())
            {
                MessageBox.Show("La busqueda no produjo resultados");
                con.query = "";
                con.cerrarConexion();
                return;
            }

            dtvCuentas.Rows.Add(new Object[] { con.lector.GetDecimal(0), con.lector.GetString(1),
                                   con.lector.GetString(2), con.lector.GetString(3),con.lector.GetDecimal(4)});

            while (con.leerReader())
            {
                dtvCuentas.Rows.Add(new Object[] { con.lector.GetDecimal(0), con.lector.GetString(1),
                                   con.lector.GetString(2), con.lector.GetString(3),con.lector.GetDecimal(4)});
            }
            con.cerrarConexion();
            }   
        }


        
    }
}
