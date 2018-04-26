using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.Listados
{
    public partial class Listado : Form
    {
        private Conexion con = new Conexion();
        private Login.Tablero padre;

        public Listado(Login.Tablero ruta)
        {
            InitializeComponent();
            cbTrimestre.Items.Add("1er Trimestre");
            cbTrimestre.Items.Add("2do Trimestre");
            cbTrimestre.Items.Add("3er Trimestre");
            cbTrimestre.Items.Add("4to Trimestre");
            padre = ruta;
            con.query = "SELECT Tipo_Cuenta FROM ESCUADRON_SUICIDA.TipoCuenta WHERE Tipo_Cuenta != 'Gratuita'";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                cbTipoDeCuenta.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();
        }

        private void btnClientePropias_Click(object sender, EventArgs e)
        {           
            if (txtAnio.Text == "")
            {
                MessageBox.Show("Escriba un año");
                return;
            }
            if (cbTrimestre.Text == "")
            {
                MessageBox.Show("Seleccione un trimestre");
                return;
            }

            borrarColumnas();
            dvTabla.Columns.Add("Usuario", "Usuario");
            dvTabla.Columns.Add("Nombre", "Nombre");
            dvTabla.Columns.Add("Apellido", "Apellido");
            dvTabla.Columns.Add("Movimientos", "Movimientos");


            int min = getMinimo();
            int max = getMaximo();

            con.query = "SELECT TOP 5 Usuario,Nombre,Apellido,COUNT (Id_Transf) AS Total " +
                        " FROM ESCUADRON_SUICIDA.Transferencia T " +
                        " JOIN ESCUADRON_SUICIDA.Cuenta CU ON (T.Cuenta_Origen=CU.Nro_Cuenta)" +
                        " JOIN ESCUADRON_SUICIDA.Cliente C ON(CU.Cod_Cli= C.Cod_Cli)" +
                        " WHERE YEAR(Fecha_Transf)="+txtAnio.Text+" AND MONTH(Fecha_Transf) BETWEEN "+min+" AND "+max+
                        " AND T.Cuenta_Destino IN (SELECT DISTINCT C2.Nro_Cuenta FROM ESCUADRON_SUICIDA.Cuenta C2 WHERE C2.Cod_Cli = CU.Cod_Cli) " + //Faltaba esta lìnea
                        " GROUP BY Usuario,Nombre,Apellido ORDER BY Total DESC";

            con.ejecutarQuery();
            while (con.leerReader())
            {
                dvTabla.Rows.Add(new Object[] { con.lector.GetString(0), con.lector.GetString(1), con.lector.GetString(2), con.lector.GetInt32(3) });
            }
            con.cerrarConexion();

            
        }

        private void btnPaises_Click(object sender, EventArgs e)
        {
            if (txtAnio.Text == "")
            {
                MessageBox.Show("Escriba un año");
                return;
            }
            if (cbTrimestre.Text=="")
            {
                MessageBox.Show("Seleccione un trimestre");
                return;
            }

            borrarColumnas();
            dvTabla.Columns.Add("Pais", "Pais");
            dvTabla.Columns.Add("Movimientos", "Movimientos");


            int min= getMinimo();
            int max= getMaximo();

            con.query = "SELECT TOP 5 Descripcion, (SELECT COUNT (Id_Transf)"+
                                                    " FROM ESCUADRON_SUICIDA.Transferencia T " +
                                                        " JOIN ESCUADRON_SUICIDA.Cuenta C ON (T.Cuenta_Origen=C.Nro_Cuenta OR T.Cuenta_Destino=C.Nro_Cuenta)" +
                                                        " WHERE C.Cod_Pais = P.Cod_Pais AND T.Cuenta_Destino!=T.Cuenta_Origen" +
                                                        " AND YEAR (T.Fecha_Transf) = " + txtAnio.Text + 
                                                        " AND MONTH(T.Fecha_Transf) BETWEEN " + min + " AND " + max + ")" +
                        " FROM ESCUADRON_SUICIDA.Pais P" +
                        " Group BY P.Cod_Pais,P.Descripcion" +
                        " ORDER BY 2 DESC";

            con.ejecutarQuery();

            while (con.leerReader())
            {
                dvTabla.Rows.Add(new Object[] { con.lector.GetString(0), con.lector.GetInt32(1) });
            }
            con.cerrarConexion();
            
        }

        private void btnInhabilitadas_Click(object sender, EventArgs e)
        {
            if (txtAnio.Text == "")
            {
                MessageBox.Show("Escriba un año");
                return;
            }
            if (cbTrimestre.Text == "")
            {
                MessageBox.Show("Seleccione un trimestre");
                return;
            }

            borrarColumnas();
            dvTabla.Columns.Add("Usuario", "Usuario");
            dvTabla.Columns.Add("Nombre", "Nombre");
            dvTabla.Columns.Add("Apellido", "Apellido");
            /*dvTabla.Columns.Add("Cuenta", "Cuenta");*/

            int min = getMinimo();
            int max = getMaximo();

            con.query = "SELECT TOP 5 U.Usuario, Cl.Nombre, Cl.Apellido"+ 
                        " FROM ESCUADRON_SUICIDA.Usuario U"+
                        " JOIN ESCUADRON_SUICIDA.Cliente Cl ON (U.Usuario = Cl.Usuario)"+
                        " JOIN ESCUADRON_SUICIDA.Cuenta Cu ON (Cl.Cod_Cli = Cu.Cod_Cli)"+
					    " JOIN ESCUADRON_SUICIDA.Transferencia T ON (Cu.Nro_Cuenta=T.Cuenta_Origen)"+
                        " WHERE YEAR(T.Fecha_Transf)="+txtAnio.Text+
                        " AND MONTH(T.Fecha_Transf) BETWEEN "+ min +" AND " + max +
                        " AND Cu.Estado='Inhabilitada'"+
                        " GROUP BY U.Usuario, Cl.Nombre, Cl.Apellido";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                dvTabla.Rows.Add(new Object[] { con.lector.GetString(0), con.lector.GetString(1), con.lector.GetString(2) });
            }
            con.cerrarConexion();
            
        }

        private void btnFacturado_Click(object sender, EventArgs e)
        {
            if (txtAnio.Text == "")
            {
                MessageBox.Show("Escriba un año");
                return;
            }
            if (cbTrimestre.Text == "")
            {
                MessageBox.Show("Seleccione un trimestre");
                return;
            }
            borrarColumnas();
            dvTabla.Columns.Add("Usuario", "Usuario");
            dvTabla.Columns.Add("Nombre", "Nombre");
            dvTabla.Columns.Add("Apellido", "Apellido");
            dvTabla.Columns.Add("Cantidad", "Cantidad");


            int min = getMinimo();
            int max = getMaximo();

            con.query = "SELECT TOP 5 C.Usuario,C.Nombre, C.Apellido, COUNT(Id_Item)" +
                        " FROM ESCUADRON_SUICIDA.Cliente C " +
                        " JOIN ESCUADRON_SUICIDA.Factura F ON(F.Cod_Cli=C.Cod_Cli)" +
                        " JOIN ESCUADRON_SUICIDA.Item I ON (I.Id_Factura=F.Id_Factura)" +
                        " WHERE YEAR(F.Fecha)="+txtAnio.Text+" AND MONTH (F.Fecha) BETWEEN "+min+" AND "+max+
                        " Group BY C.Usuario, C.Apellido,C.Nombre" +
                        " Order BY 4 Desc";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                dvTabla.Rows.Add(new Object[] { con.lector.GetString(0), con.lector.GetString(1), con.lector.GetString(2), con.lector.GetInt32(3) });
            }
            con.cerrarConexion();
            
        }

        private void totalFacturado_Click(object sender, EventArgs e)
        {
            if (txtAnio.Text == "")
            {
                MessageBox.Show("Escriba un año");
                return;
            }
            if (cbTrimestre.Text == "")
            {
                MessageBox.Show("Seleccione un trimestre");
                return;
            }

            if (cbTipoDeCuenta.Text == "")
            {
                MessageBox.Show("Seleccione un tipo de cuenta");
                return;
            }

            int min = getMinimo();
            int max = getMaximo();

            borrarColumnas();
            dvTabla.Columns.Add("Tipo", "Tipo de Cuenta");
            dvTabla.Columns.Add("Total", "Total");

            con.query = "SELECT TC.Tipo_Cuenta, SUM(I.Importe) FROM ESCUADRON_SUICIDA.Transferencia T"+
                        " JOIN ESCUADRON_SUICIDA.Item I ON (T.Id_Transf=I.Id_Item)"+
                        " JOIN ESCUADRON_SUICIDA.Cuenta C ON (T.Cuenta_Origen=C.Nro_Cuenta)"+
                        " JOIN ESCUADRON_SUICIDA.TipoCuenta TC ON (TC.Tipo_Cuenta='" + cbTipoDeCuenta.Text + "')" +
                        " JOIN ESCUADRON_SUICIDA.Factura F ON (F.Id_Factura=I.Id_Factura)"+
                        " WHERE T.Facturado=1 AND (T.Costo = TC.Costo_Apertura * C.Periodo_Suscripcion OR T.Costo = TC.Costo)"+
                        " AND YEAR(F.Fecha) = "+txtAnio.Text+" AND MONTH(F.Fecha) BETWEEN "+min+" AND "+max+
                        " GROUP BY TC.Tipo_Cuenta";
            con.ejecutarQuery();
            while (con.leerReader())
            {
                dvTabla.Rows.Add(new Object[] { con.lector.GetString(0), con.lector.GetDecimal(1) });
            }
            con.cerrarConexion();
            
        }





        private int getMinimo()
        {
            if (cbTrimestre.Text == "1er Trimestre")
            {
                return 1;
            }
            else
            {
                if (cbTrimestre.Text == "2do Trimestre")
                {
                    return 4;
                }
                else
                {
                    if (cbTrimestre.Text == "3er Trimestre")
                    {
                        return 7;
                    }
                    else
                    {
                        if (cbTrimestre.Text == "4to Trimestre")
                        {
                            return 10;
                        }
                    }
                }
            }
            return 0;
        }

        private int getMaximo()
        {
            if (cbTrimestre.Text == "1er Trimestre")
            {
                return 3;
            }
            else
            {
                if (cbTrimestre.Text == "2do Trimestre")
                {
                    return 6;
                }
                else
                {
                    if (cbTrimestre.Text == "3er Trimestre")
                    {
                        return 9;
                    }
                    else
                    {
                        if (cbTrimestre.Text == "4to Trimestre")
                        {
                            return 12;
                        }
                    }
                }
            }
            return 0;
        }

        private void borrarColumnas()
        {
            dvTabla.Rows.Clear();
            dvTabla.Columns.Clear();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            padre.Show();
            this.Close();
        }
    }
}
