using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Comparadores;

namespace PagoElectronico.ABM_Cuenta
{
    public partial class AltaCuenta : Form
    {
        private Login.Tablero padre;

        public AltaCuenta(Login.Tablero ruta, String usuario, String rol)
        {
            InitializeComponent();
            padre=ruta;
            Conexion con = new Conexion();
            /*Llena usuarios*/
            if(rol=="Administrador"){
                con.query = "SELECT Usuario FROM ESCUADRON_SUICIDA.RolPorUsuario RU JOIN ESCUADRON_SUICIDA.Roles R ON(RU.Id_Rol=R.Id_Rol) WHERE R.Nombre='Cliente'";
                con.ejecutarQuery();
                while (con.leerReader()) {
                    cbUsuario.Items.Add(con.lector.GetString(0));
                }
                con.cerrarConexion();
            }
            else{
                con.cerrarConexion();
                cbUsuario.Text=usuario;
                cbUsuario.Enabled = false;
            }

            /*Llena paises*/
            con.query = "SELECT Descripcion FROM ESCUADRON_SUICIDA.Pais";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cbPais.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();
            /*Llena moneda*/
            con.query="SELECT Tipo_Moneda FROM ESCUADRON_SUICIDA.TipoMoneda";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cbMoneda.Items.Add(con.lector.GetString(0));
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

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            Conexion con2 = new Conexion();
            Conexion con3 = new Conexion();

            /*Se fija que el usuario pueda realizar esta transaccion*/

            con.query = "SELECT Nro_Cuenta FROM ESCUADRON_SUICIDA.Cuenta Cu JOIN ESCUADRON_SUICIDA.Cliente Cl ON (Cu.Cod_Cli=Cl.Cod_Cli) WHERE Cl.Usuario='" + cbUsuario.Text + "' AND Cu.Estado='Inhabilitada'";
            con.ejecutarQuery();
            if(con.leerReader())
            {
                MessageBox.Show("Este usuario posee cuentas inhabilitadas, realize la facturacion antes abrir una nueva cuenta");
                con.cerrarConexion();
                return;
            }
            con.cerrarConexion();
                        
            /*Corrobora que los campos esten completos*/
           
            if (cbUsuario.Text == "") {MessageBox.Show("Seleccione el usuario");return;}
            if (cbMoneda.Text == "") {MessageBox.Show("Seleccione tipo de moneda");return;}
            if (cbPais.Text == "") {MessageBox.Show("Seleccione el pais");return;}
            if (cbTipo.Text == "") { MessageBox.Show("Seleccione tipo de cuenta"); return; }
            if (txtSusc.Text == "" || !(txtSusc.Text.IsNumeric()) || txtSusc.Text=="0") { MessageBox.Show("Seleccione una cantidad de suscripciones numerica mayor a 0"); return; }
            con.query = "SELECT Cod_Cli FROM ESCUADRON_SUICIDA.Cliente WHERE Usuario='" + cbUsuario.Text + "'";
            con.ejecutarQuery();
            if (!con.leerReader()) { MessageBox.Show("Este usuario no posee ningun cliente asociado"); return; }
            con.cerrarConexion();

            /*Crea una cuenta*/
            /*Se fija si la cuenta es Gratuita*/
            if (cbTipo.Text == "Gratuita")
            {
                /*La inserta habilitada porque no produce tiene costo*/
                con.query = "INSERT INTO ESCUADRON_SUICIDA.Cuenta (Cod_Cli, Fecha_Creacion, Estado, Cod_Pais, Tipo_Cuenta, Tipo_Moneda, Periodo_Suscripcion)" +
                              "VALUES ((SELECT Cod_Cli FROM ESCUADRON_SUICIDA.Cliente WHERE Usuario='" + cbUsuario.Text + "'),'" + lectorConfig.Config.fechaSystem() + " 00:00:00.000'"+
                              ", 'Habilitada', (SELECT Cod_Pais FROM ESCUADRON_SUICIDA.Pais WHERE Descripcion ='" + cbPais.Text + "'), '" + cbTipo.Text + "','" + cbMoneda.Text + "'," + 1 + ")";
                con.ejecutarNoQuery();
            }
            else
            {
                /*La inserta pendiente y tambien inserta una transferencia que simboliza el costo de apertura*/
                con.query = "INSERT INTO ESCUADRON_SUICIDA.Cuenta (Cod_Cli, Fecha_Creacion, Estado, Cod_Pais, Tipo_Cuenta, Tipo_Moneda, Periodo_Suscripcion)" +
                            "VALUES ((SELECT Cod_Cli FROM ESCUADRON_SUICIDA.Cliente WHERE Usuario='" + cbUsuario.Text + "'),'" + lectorConfig.Config.fechaSystem() + " 00:00:00.000'"+
                            ", 'Pendiente', (SELECT Cod_Pais FROM ESCUADRON_SUICIDA.Pais WHERE Descripcion ='" + cbPais.Text + "'), '" + cbTipo.Text + "','" + cbMoneda.Text + "'," + txtSusc.Text + ")";
                con.ejecutarNoQuery();

                con2.query = "SELECT TOP 1 Nro_Cuenta FROM ESCUADRON_SUICIDA.Cuenta Cu JOIN ESCUADRON_SUICIDA.Cliente Cl ON (Cu.Cod_Cli=Cl.Cod_Cli) WHERE Cl.Usuario= '" + cbUsuario.Text + "' ORDER BY Nro_Cuenta Desc";
                con2.ejecutarQuery();
                con2.leerReader();

                con3.query = "SELECT Costo_Apertura FROM ESCUADRON_SUICIDA.TipoCuenta WHERE Tipo_Cuenta='" + cbTipo.Text + "'";
                con3.ejecutarQuery();
                con3.leerReader();

                con.query = "INSERT INTO ESCUADRON_SUICIDA.Transferencia (Fecha_Transf,Importe,Cuenta_Origen,Cuenta_Destino,Costo,Tipo_Moneda) VALUES ('" + lectorConfig.Config.fechaSystem() + " 00:00:00.000', 0," + con2.lector.GetDecimal(0) + "," + con2.lector.GetDecimal(0) + ",(" + con3.lector.GetDecimal(0).ToString().Replace(',', '.')+"*"+txtSusc.Text + "),'" + cbMoneda.Text + "')";
                con.ejecutarNoQuery();
                        
            }

            MessageBox.Show("La cuenta se creo correctamente");
            padre.Show();
            this.Close();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            cbTipo.Text = "";
            cbMoneda.Text="";
            cbPais.Text="";
            cbUsuario.Text="";
            txtSusc.Text = "";
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipo.Text == "Gratuita")
            {
                txtSusc.Text = "1";
                txtSusc.Enabled = false;
            }
            else { txtSusc.Enabled = true; }
        }

        private void cbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AltaCuenta_Load(object sender, EventArgs e)
        {

        }

    }
}
