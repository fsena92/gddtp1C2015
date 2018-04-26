using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.Login
{
    public partial class Tablero : Form
    {
        String usuarioActual; 
        String rolActual; 
        Login padre;
        public Tablero(Login ruta ,String usuario,String rol)
        {
            InitializeComponent();
            usuarioActual = usuario;
            padre = ruta;
            Conexion con=new Conexion();
            rolActual = rol;
            if (rolActual == "Cliente")
            {
                gbAdmin.Visible = false;

                con.query="SELECT C.Estado"+
                          " FROM ESCUADRON_SUICIDA.Usuario U"+
                          " JOIN ESCUADRON_SUICIDA.Cliente C ON (C.Usuario=U.Usuario)"+
                          " WHERE U.Usuario='"+ usuario +"'";

                con.ejecutarQuery();
                if (con.leerReader())
                {
                    if (!(con.lector.GetBoolean(0)))
                    {
                        groupBox1.Visible = false;
                        gbUsuario.Visible = false;
                        Label.Text = "Usted se encuentra inhabilitado para realizar operaciones (Cliente inhabilitado)";
                        this.Width = 400;
                        this.Height = 100;
                        Label.Top = 10;
                        Label.Left = 12;
                        btnDesloguearse2.Top = 35;
                        btnDesloguearse2.Left = 125;
                    }
                    else
                    {
                        btnDesloguearse2.Visible = false;
                    }
                }
                else
                {
                    groupBox1.Visible = false;
                    gbUsuario.Visible = false;
                    Label.Text = "Usted no posee un usuario asociado";
                    this.Width = 200;
                    this.Height = 100;
                    Label.Top = 10;
                    Label.Left = 12;
                    btnDesloguearse2.Top = 35;
                    btnDesloguearse2.Left = 25;
                }
            }
            else
            {
                btnAsociar.Visible = false;
                btnModifTar.Visible = false;
                btnDesAsociar.Visible = false;
                btnDesloguearse2.Visible = false;
                Label.Visible = false;
            }
        }

        private void btn_AltaCli_Click(object sender, EventArgs e)
         {
            ABM_Cliente.AltaCliente form_AltaCli = new PagoElectronico.ABM_Cliente.AltaCliente(this);
            this.Hide();
            form_AltaCli.Show();
        }

        private void btn_ModiCli_Click(object sender, EventArgs e)
        {
            ABM_Cliente.Listado_de_seleccion_cliente form_ModiCli = new PagoElectronico.ABM_Cliente.Listado_de_seleccion_cliente(this,'M');
            this.Hide();
            form_ModiCli.Show();
        }

        private void btn_BajaCli_Click(object sender, EventArgs e)
        {
            ABM_Cliente.Listado_de_seleccion_cliente form_BajaCli = new PagoElectronico.ABM_Cliente.Listado_de_seleccion_cliente(this, 'B');
            this.Hide();
            form_BajaCli.Show();
        }

        private void btn_AltaCuen_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            con.query = "SELECT * FROM ESCUADRON_SUICIDA.Cuenta WHERE Cod_Cli=(SELECT Cod_Cli FROM ESCUADRON_SUICIDA.Cliente WHERE Usuario='" + usuarioActual.ToString() + "') AND Estado='InHabilitada'";
            con.ejecutarQuery();
            if (con.leerReader())
            {
                MessageBox.Show("Usted tiene una cuenta Inhabilitada. Por favor facture su cuenta");
                con.cerrarConexion();
            }
            else
            {
                con.cerrarConexion();
                ABM_Cuenta.AltaCuenta form_AltaCue = new PagoElectronico.ABM_Cuenta.AltaCuenta(this, usuarioActual, rolActual);
                this.Hide();
                form_AltaCue.Show();
            }
        }

        private void btn_ModiCue_Click(object sender, EventArgs e)
        {
             ABM_Cuenta.Listado_de_seleccion_Cuenta form_ModiCue = new PagoElectronico.ABM_Cuenta.Listado_de_seleccion_Cuenta(this, 'M',usuarioActual,rolActual);
             this.Hide();
             form_ModiCue.Show();
        }

        private void btn_BajaCue_Click(object sender, EventArgs e)
        {
             ABM_Cuenta.Listado_de_seleccion_Cuenta form_BajaCue = new PagoElectronico.ABM_Cuenta.Listado_de_seleccion_Cuenta(this, 'B',usuarioActual,rolActual);
             this.Hide();
             form_BajaCue.Show();
        }
        /*
        private void btn_AltaUs_Click(object sender, EventArgs e)
        {
            ABM_de_Usuario.AltaUsuario form_AltaUs = new PagoElectronico.ABM_de_Usuario.AltaUsuario(this);
            this.Hide();
            form_AltaUs.Show();
        }

        private void btn_ModiUs_Click(object sender, EventArgs e)
        {
            ABM_de_Usuario.Listado_de_seleccion_usuario form_ModiUs = new PagoElectronico.ABM_de_Usuario.Listado_de_seleccion_usuario(this, 'M');
            this.Hide();
            form_ModiUs.Show();
        }

        private void btn_BajaUs_Click(object sender, EventArgs e)
        {
            ABM_de_Usuario.Listado_de_seleccion_usuario form_BajaUs = new PagoElectronico.ABM_de_Usuario.Listado_de_seleccion_usuario(this, 'B');
            this.Hide();
            form_BajaUs.Show();
        }*/

        private void btn_AltaRol_Click(object sender, EventArgs e)
        {
            ABM_Rol.AltaRol form_AltaRol = new PagoElectronico.ABM_Rol.AltaRol(this);
            this.Hide();
            form_AltaRol.Show();
        }

        private void btn_ModiRol_Click(object sender, EventArgs e)
        {
            ABM_Rol.Listado_de_seleccion_Rol form_ModiRol = new PagoElectronico.ABM_Rol.Listado_de_seleccion_Rol(this, 'M');
            this.Hide();
            form_ModiRol.Show();
        }

        private void btn_BajaRol_Click(object sender, EventArgs e)
        {
            ABM_Rol.Listado_de_seleccion_Rol form_BajaRol = new PagoElectronico.ABM_Rol.Listado_de_seleccion_Rol(this, 'B');
            this.Hide();
            form_BajaRol.Show();
        }

        private void btnAsociar_Click(object sender, EventArgs e)
        {
            ABM_Cliente.AsociarTarjetas form_AsoTar = new PagoElectronico.ABM_Cliente.AsociarTarjetas (this,'A',usuarioActual,"");
            this.Hide();
            form_AsoTar.Show();
        }

        private void btnDesAsociar_Click(object sender, EventArgs e)
        {
            ABM_Cliente.SeleccionDeTarjetas form_DesTar = new PagoElectronico.ABM_Cliente.SeleccionDeTarjetas(this,'B', usuarioActual);
            this.Hide();
            form_DesTar.Show();
        }

        private void btnModifTar_Click(object sender, EventArgs e)
        {
            ABM_Cliente.SeleccionDeTarjetas form_ModTar = new PagoElectronico.ABM_Cliente.SeleccionDeTarjetas(this, 'M', usuarioActual);
            this.Hide();
            form_ModTar.Show();
        }

        private void btnTransf_Click(object sender, EventArgs e)
        {
            Transferencias.Realizar_Transferencia form_RTrans = new PagoElectronico.Transferencias.Realizar_Transferencia(this,usuarioActual,rolActual);
            this.Hide();
            form_RTrans.Show();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            Facturacion.Facturar form_Fact = new PagoElectronico.Facturacion.Facturar(this, rolActual, usuarioActual);
            this.Hide();
            form_Fact.Show();
        }

        private void btnConSal_Click(object sender, EventArgs e)
        {
            Consulta_Saldos.Consulta_de_saldo form_Cons =new PagoElectronico.Consulta_Saldos.Consulta_de_saldo(this, rolActual, usuarioActual);
            this.Hide();
            form_Cons.Show();
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            Listados.Listado form_List = new PagoElectronico.Listados.Listado(this);
            this.Hide();
            form_List.Show();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }

        private void btnRetiro_Click(object sender, EventArgs e)
        {
            Retiros.Listado form_Ret = new PagoElectronico.Retiros.Listado(this, usuarioActual,rolActual);
            this.Hide();
            form_Ret.Show();
        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            Depositos.Listado form_Dep = new PagoElectronico.Depositos.Listado(this, usuarioActual,rolActual);
            this.Hide();
            form_Dep.Show();
        }

        private void btnDesloguearse2_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }

    }
}
