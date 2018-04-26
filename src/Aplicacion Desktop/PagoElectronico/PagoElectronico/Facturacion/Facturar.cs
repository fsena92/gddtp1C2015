using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.Facturacion
{
    public partial class Facturar : Form
    {
        private Login.Tablero padre;
        private Conexion con = new Conexion();

        public Facturar(Login.Tablero ruta, String rol, String usuario)
        {
            InitializeComponent();
            padre = ruta;
            if (rol == "Administrador") 
            { 
                con.query = "SELECT R.Usuario From ESCUADRON_SUICIDA.Roles U JOIN ESCUADRON_SUICIDA.RolPorUsuario R ON (U.Id_Rol=R.Id_Rol) WHERE U.Nombre='Cliente'";
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
        }

        private void cbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            chbCuentas.Items.Clear();
            con.query = "SELECT CU.Nro_Cuenta FROM ESCUADRON_SUICIDA.Cuenta CU JOIN ESCUADRON_SUICIDA.Cliente CL ON(CU.Cod_Cli=CL.Cod_Cli)WHERE CL.Usuario='" + cbUsuario.Text + "' AND CU.Estado!='Cerrada'";
            con.ejecutarQuery();
            while (con.leerReader()) 
            {
                chbCuentas.Items.Add(con.lector.GetDecimal(0));
            }
            con.cerrarConexion();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cbUsuario.Text == "") 
            {
                MessageBox.Show("Seleccione un usuario para hacer la facturacion"); 
                return; 
            }

            bool hayCuentasSel=false;

            foreach (object items in chbCuentas.CheckedItems) 
            {
                hayCuentasSel= true;
            }

            if(!hayCuentasSel)
            {
                MessageBox.Show("Seleccione una cuenta o mas para hacer la facturacion");
                return;
            }
            
            con.query="INSERT INTO ESCUADRON_SUICIDA.Factura (Fecha,Cod_Cli) VALUES('" + lectorConfig.Config.fechaSystem() + " 00:00:00.000', (SELECT Cod_Cli FROM ESCUADRON_SUICIDA.Cliente WHERE Usuario='"+cbUsuario.Text+"'))";
            con.ejecutarNoQuery();
            con.query = "SELECT TOP 1 Id_Factura FROM ESCUADRON_SUICIDA.Factura WHERE Cod_Cli=(SELECT Cod_Cli FROM ESCUADRON_SUICIDA.Cliente WHERE Usuario='"+cbUsuario.Text+"') ORDER BY Id_Factura desc";
            con.ejecutarQuery();
            con.leerReader();
            Decimal factura = con.lector.GetDecimal(0);
            con.cerrarConexion();

            foreach (object cuenta in chbCuentas.CheckedItems)
            {
                Conexion con2 = new Conexion();
                Conexion con3 = new Conexion();

                /*con.query = "SELECT Estado, (T.Costo_Apertura * C.Periodo_Suscripcion), T.Tipo_Moneda FROM ESCUADRON_SUICIDA.Cuenta C JOIN ESCUADRON_SUICIDA.TipoCuenta T ON(C.Tipo_Cuenta=T.Tipo_Cuenta) WHERE Nro_Cuenta=" + cuenta.ToString();
                con.ejecutarQuery();
                if (con.leerReader())
                {
                    /*if (con.lector.GetString(0) == "Pendiente")
                    {
                        //con2.query = "INSERT INTO ESCUADRON_SUICIDA.Transferencia (Fecha_Transf,Importe,Cuenta_Origen,Cuenta_Destino,Costo,Tipo_Moneda) VALUES ('" + lectorConfig.Config.fechaSystem() + " 00:00:00.000', 0," + cuenta.ToString() + "," + cuenta.ToString() + "," + con.lector.GetDecimal(1).ToString().Replace(',', '.') + ",'" + con.lector.GetString(2) + "')";
                        //con2.query = "INSERT INTO ESCUADRON_SUICIDA.Item (ID_Factura,Descripcion,Importe, Tipo_Moneda) VALUES(" + factura + ",'Comision apertura de cuenta.'," + con.lector.GetDecimal(1).ToString().Replace(',','.') + ",'"+con.lector.GetString(2)+"')";
                        
                        //con2.ejecutarNoQuery();
                        //con3.ejecutarNoQuery();
                    }*
                }*
                con.cerrarConexion();*/
                con.query = "SELECT Costo, Id_Transf, Tipo_Moneda, Cuenta_Destino FROM ESCUADRON_SUICIDA.Transferencia WHERE Cuenta_Origen=" + cuenta.ToString() + " AND Facturado = 0 ";
                con.ejecutarQuery();
                while (con.leerReader())
                {
                    if (con.lector.GetDecimal(3).ToString() == cuenta.ToString())
                    {
                        con3.query = "SELECT Id_Transf FROM ESCUADRON_SUICIDA.Transferencia WHERE Cuenta_Origen=" + cuenta.ToString() + " AND Cuenta_Destino=" + cuenta.ToString() + " AND Id_Transf !=" + con.lector.GetDecimal(1).ToString();
                        con3.ejecutarQuery();
                        if (con3.leerReader())
                        {
                            con2.query = "INSERT INTO ESCUADRON_SUICIDA.Item (ID_Factura,Descripcion,Importe, Tipo_Moneda) VALUES(" + factura + ",'Comision por cambio de tipo.'," + con.lector.GetDecimal(0).ToString().Replace(',', '.') + ",'" + con.lector.GetString(2) + "')";
                            con2.ejecutarNoQuery();
                        }
                        else
                        {
                            con2.query = "INSERT INTO ESCUADRON_SUICIDA.Item (ID_Factura,Descripcion,Importe, Tipo_Moneda) VALUES(" + factura + ",'Comision por apertura.'," + con.lector.GetDecimal(0).ToString().Replace(',', '.') + ",'" + con.lector.GetString(2) + "')";
                            con2.ejecutarNoQuery();
                        }
                        con3.cerrarConexion();
                    }
                    else
                    {
                        con2.query = "INSERT INTO ESCUADRON_SUICIDA.Item (ID_Factura,Descripcion,Importe, Tipo_Moneda) VALUES(" + factura + ",'Comision por transferencia.'," + con.lector.GetDecimal(0).ToString().Replace(',', '.') + ",'" + con.lector.GetString(2) + "')";
                        con2.ejecutarNoQuery();
                    }

                    con3.query = "UPDATE ESCUADRON_SUICIDA.Transferencia SET Facturado = 1 WHERE Id_Transf=" + con.lector.GetDecimal(1).ToString();
                    con3.ejecutarNoQuery();
                   }

                con.cerrarConexion();

                con3.query = "UPDATE ESCUADRON_SUICIDA.Cuenta SET Estado='Habilitada' WHERE Nro_Cuenta=" + cuenta.ToString();
                con3.ejecutarNoQuery();

            }

            bool hayItems = false;
            con.query = "SELECT Id_Item From ESCUADRON_SUICIDA.Item Where Id_Factura=" + factura;
            con.ejecutarQuery();
            while (con.leerReader()) { hayItems = true; }
            con.cerrarConexion();
            if (!hayItems) 
            {
                con.query = "DELETE FROM ESCUADRON_SUICIDA.Factura WHERE Id_Factura=" + factura;
                con.ejecutarNoQuery();
                MessageBox.Show("No hay nada que facturar en las cuentas seleccionadas");
                return;
            }
            
            MessageBox.Show("Se ha realizado la facturacion correctamente");
            padre.Show();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }
    }
}
