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
    public partial class ModificarCuentas : Form
    {
        private Login.Tablero padre;
        String cuentaActual;
        private String anteriorTipo;
        String rolActual;

        public ModificarCuentas(Login.Tablero ruta, String cuenta, String rol)
        {
            InitializeComponent();
            padre = ruta;
            cuentaActual = cuenta;
            Conexion con= new Conexion();
            con.query = "SELECT Descripcion, Tipo_Moneda, Estado, Tipo_Cuenta FROM ESCUADRON_SUICIDA.Cuenta C Join ESCUADRON_SUICIDA.Pais P ON(C.Cod_Pais=P.Cod_Pais) WHERE Nro_Cuenta="+cuenta;
            con.ejecutarQuery();
            con.leerReader();
            cbPais.Text = con.lector.GetString(0);
            cbMoneda.Text = con.lector.GetString(1);
            cbEstado.Text = con.lector.GetString(2);
            cbCuenta.Text = con.lector.GetString(3);
            con.cerrarConexion();
            rolActual = rol;
            anteriorTipo = cbCuenta.Text;

            if (rol != "Administrador")
            {
                cbEstado.Enabled = false;
                btnEstado.Visible = false;
            }

            /*Llena paises*/
            con.query = "SELECT Descripcion FROM ESCUADRON_SUICIDA.Pais";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cbPais.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();

            //Llenar Tipo de Moneda
            con.query = "SELECT Tipo_Moneda FROM ESCUADRON_SUICIDA.TipoMoneda";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cbMoneda.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();

            //Llena Tipo de cuenta
            con.query = "SELECT Tipo_Cuenta FROM ESCUADRON_SUICIDA.TipoCuenta";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cbCuenta.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();

            //Llena Estado
            con.query = "SELECT Estado FROM ESCUADRON_SUICIDA.Estado";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cbEstado.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();

            //Completa usuario y cuenta
            con.query = "SELECT Usuario FROM ESCUADRON_SUICIDA.Cliente C Join ESCUADRON_SUICIDA.Cuenta K ON (C.Cod_Cli=K.Cod_Cli) WHERE Nro_Cuenta="+cuenta;
            con.ejecutarQuery();
            con.leerReader();
            txtUsuario.Text = con.lector.GetString(0);
            con.cerrarConexion();

            txtCuenta.Text = cuenta.ToString();

            txtCuenta.Enabled = false;
            txtUsuario.Enabled = false;
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            con.query = "UPDATE ESCUADRON_SUICIDA.Cuenta SET Tipo_Moneda='" + cbMoneda.Text + "' WHERE Nro_Cuenta="+cuentaActual;
            con.ejecutarNoQuery();
            con.query = "UPDATE ESCUADRON_SUICIDA.Cuenta SET Cod_Pais=(SELECT Cod_Pais FROM ESCUADRON_SUICIDA.Pais WHERE Descripcion='" + cbPais.Text + "') WHERE Nro_Cuenta=" + cuentaActual;
            con.ejecutarNoQuery();
            MessageBox.Show("Cuenta modificada correctamente");
        }

        private void btnTipo_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();

             if(cbCuenta.Text==anteriorTipo)
                {
                    MessageBox.Show("La cuenta ya es de este tipo");
                    return;
                }
            if (cbEstado.Text=="Inhabilitada"){MessageBox.Show("La cuenta esta inhabilitada y no puede realizar ningun tipo de transaccion");return;}

            if (rolActual == "Cliente")
            {
                if (cbEstado.Text == "Cerrada"){MessageBox.Show("La cuenta no puede modificarse porque ya esta cerrada"); return;}

                if (cbCuenta.Text != "Gratuita")
                {
                    con.query = "UPDATE ESCUADRON_SUICIDA.Cuenta SET Tipo_Cuenta='" + cbCuenta.Text + "',Estado='Pendiente' WHERE Nro_Cuenta=" + cuentaActual;
                    con.ejecutarNoQuery();

                    con.query = "INSERT INTO ESCUADRON_SUICIDA.Transferencia (Fecha_Transf,Importe,Cuenta_Origen,Cuenta_Destino,Costo,Tipo_Moneda) "+
                                "VALUES ('" + lectorConfig.Config.fechaSystem() + " 00:00:00.000', 0," + cuentaActual + "," + cuentaActual + 
                                ",(SELECT TC.Costo_Apertura * C.Periodo_Suscripcion FROM ESCUADRON_SUICIDA.TipoCuenta TC JOIN ESCUADRON_SUICIDA.Cuenta C ON(TC.Tipo_Cuenta=C.Tipo_Cuenta)"+
                                "WHERE C.Nro_Cuenta="+cuentaActual+"),(SELECT TC.Tipo_Moneda FROM ESCUADRON_SUICIDA.TipoCuenta TC JOIN ESCUADRON_SUICIDA.Cuenta C ON(TC.Tipo_Cuenta=C.Tipo_Cuenta)"+
                                "WHERE C.Nro_Cuenta="+cuentaActual+"))";
                    con.ejecutarNoQuery();

                    if (corroborarTransferencias())
                    {

                        MessageBox.Show("Cuenta modificada correctamente, por la cantidad de transacciones acumuladas la cuenta ha sido inhabilitada");
                        padre.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cuenta modificada correctamente");
                        padre.Show();
                        this.Close();    
                    }
                }
                else 
                { 
                    MessageBox.Show("Esta intentando cambiar el tipo a gratuita, cree una nueva cuenta"); 
                    return;
                }
            }
            if (rolActual == "Administrador") 
            {
               
                    con.query = "UPDATE ESCUADRON_SUICIDA.Cuenta SET Tipo_Cuenta='" + cbCuenta.Text + "',Estado='Pendiente' WHERE Nro_Cuenta=" + cuentaActual;
                    con.ejecutarNoQuery();
                                        
                    con.query = "INSERT INTO ESCUADRON_SUICIDA.Transferencia (Fecha_Transf,Importe,Cuenta_Origen,Cuenta_Destino,Costo,Tipo_Moneda) " +
                                "VALUES ('" + lectorConfig.Config.fechaSystem() + " 00:00:00.000', 0," + cuentaActual + "," + cuentaActual +
                                ",(SELECT TC.Costo_Apertura * C.Periodo_Suscripcion FROM ESCUADRON_SUICIDA.TipoCuenta TC JOIN ESCUADRON_SUICIDA.Cuenta C ON(TC.Tipo_Cuenta=C.Tipo_Cuenta)" +
                                "WHERE C.Nro_Cuenta=" + cuentaActual + "),(SELECT TC.Tipo_Moneda FROM ESCUADRON_SUICIDA.TipoCuenta TC JOIN ESCUADRON_SUICIDA.Cuenta C ON(TC.Tipo_Cuenta=C.Tipo_Cuenta)" +
                                "WHERE C.Nro_Cuenta=" + cuentaActual + "))";
                    con.ejecutarNoQuery();
                    
                    corroborarTransferencias();
                    
                    MessageBox.Show("Cuenta modificada correctamente");
                    padre.Show();
                    this.Close();
                }
            }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
                      
            if (cbEstado.Text == "Cerrada")
            {
                MessageBox.Show("Para cerrar la cuenta utilize la opcion borrar cuenta del menu principal");
                return;
            }

            con.query = "UPDATE ESCUADRON_SUICIDA.Cuenta SET Estado='"+cbEstado.Text+"' WHERE Nro_Cuenta=" + cuentaActual;
            con.ejecutarNoQuery();

            MessageBox.Show("Estado modificado correctamente");
            padre.Show();
            this.Close();
        }

        private bool corroborarTransferencias(){
        
            Conexion con= new Conexion();

            con.query="SELECT COUNT (*) FROM ESCUADRON_SUICIDA.Transferencia WHERE Cuenta_Origen="+cuentaActual+" AND Facturado=0";
            con.ejecutarQuery();
            con.leerReader();

            if (con.lector.GetInt32(0) >= 5)
            {
                con.cerrarConexion();
                con.query = "UPDATE ESCUADRON_SUICIDA.Cuenta SET Estado='Inhabilitada' WHERE Nro_Cuenta=" + cuentaActual;
                con.ejecutarNoQuery();
                cbEstado.Text = "Inhabilitada";
                return true;
            }
            else { return false; }
        }
    }
}
