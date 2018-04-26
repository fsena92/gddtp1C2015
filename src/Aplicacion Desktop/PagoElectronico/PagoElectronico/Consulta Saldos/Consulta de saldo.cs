using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.Consulta_Saldos
{
    public partial class Consulta_de_saldo : Form
    {
        private Login.Tablero padre;
        private Conexion con = new Conexion();

        public Consulta_de_saldo(Login.Tablero ruta, String rol,String usuario)
        {
            InitializeComponent();
            padre=ruta;

            if (rol == "Administrador")
            {
                con.query = "SELECT Usuario FROM ESCUADRON_SUICIDA.RolPorUsuario RU JOIN ESCUADRON_SUICIDA.Roles R ON (R.Id_Rol=RU.Id_Rol)"+
                            "WHERE Nombre='Cliente'";
                con.ejecutarQuery();
                while (con.leerReader())
                {
                    cbUsuario.Items.Add(con.lector.GetString(0));
                }
                con.cerrarConexion();
            }
            else 
            {
                cbUsuario.Text = usuario;
                cbUsuario.Enabled = false;
                con.query = "SELECT Nro_Cuenta FROM ESCUADRON_SUICIDA.Cuenta WHERE Cod_Cli=(SELECT Cod_Cli FROM ESCUADRON_SUICIDA.Cliente WHERE Usuario='"+usuario+"')";
                con.ejecutarQuery();
                while (con.leerReader())
                {
                    cbCuenta.Items.Add(con.lector.GetDecimal(0).ToString());
                }
                con.cerrarConexion();
            }
        }

        private void cbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCuenta.Items.Clear();
            cbCuenta.Text = "";

            con.query = "SELECT Nro_Cuenta FROM ESCUADRON_SUICIDA.Cuenta WHERE Cod_Cli=(SELECT Cod_Cli FROM ESCUADRON_SUICIDA.Cliente WHERE Usuario='" + cbUsuario.Text + "')";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cbCuenta.Items.Add(con.lector.GetDecimal(0).ToString());
            }
            con.cerrarConexion();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cbUsuario.Text == "") { MessageBox.Show("Seleccione un usuario"); return; }
            if (cbCuenta.Text == "") { MessageBox.Show("Seleccione una cuenta"); return; }

            dtvDeposito.Rows.Clear();
            dtvRetiro.Rows.Clear();
            dtvTrans.Rows.Clear();

            con.query = "SELECT Saldo, Tipo_Moneda FROM ESCUADRON_SUICIDA.Cuenta WHERE Nro_Cuenta ="+cbCuenta.Text;
            con.ejecutarQuery();
            con.leerReader();
            txtSaldo.Text = con.lector.GetDecimal(0).ToString();
            txtMoneda.Text = con.lector.GetString(1);
            con.cerrarConexion();
            con.query = "SELECT TOP 5 Fecha_Deposito, Importe, Tipo_Moneda FROM ESCUADRON_SUICIDA.Deposito WHERE Nro_Cuenta=" + cbCuenta.Text+" ORDER BY Fecha_Deposito desc";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                dtvDeposito.Rows.Add(new Object[] { Convert.ToDateTime(con.lector.GetDateTime(0)), con.lector.GetDecimal(1), con.lector.GetString(2) });
            }
            con.cerrarConexion();
            con.query = "SELECT TOP 5 Fecha_Retiro, Importe FROM ESCUADRON_SUICIDA.Retiro WHERE Nro_Cuenta=" + cbCuenta.Text + " ORDER BY Fecha_Retiro desc";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                dtvRetiro.Rows.Add(new Object[] { Convert.ToDateTime(con.lector.GetDateTime(0)), con.lector.GetDecimal(1) });
            }
            con.cerrarConexion();
            con.query = "SELECT TOP 10 Fecha_Transf, Cuenta_Destino, Importe, Costo FROM ESCUADRON_SUICIDA.Transferencia WHERE Cuenta_Origen=" + 
                        cbCuenta.Text + " AND Cuenta_Destino !="+cbCuenta.Text+" ORDER BY Fecha_Transf desc";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                dtvTrans.Rows.Add(new Object[] { Convert.ToDateTime(con.lector.GetDateTime(0)), con.lector.GetDecimal(1), con.lector.GetDecimal(2), con.lector.GetDecimal(3) });
            }
            con.cerrarConexion();
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }
    }
}
