using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Producto.Vistas
{
    public partial class Facturacion : System.Web.UI.Page
    {
        Conexion Connect1 = new Conexion();
        Conexion Connect2 = new Conexion();
        Conexion Connect3 = new Conexion();
        Conexion Connect4 = new Conexion();
        Conexion Connect5 = new Conexion();

       public string fecha = System.DateTime.Now.ToString("dd/MMM/yyy");


        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["usuario"] == " ")
            {

                Response.Redirect("Login.aspx");
            }

            String TipoUser;

            TipoUser = Convert.ToString(Session["TipoUser"]);

            if (TipoUser == "Empl")
            {

                RadioButton_Cliente.Visible = false;
                RadioButton_Proveedor.Visible = false;
                Reportes.Visible = false;

            }


            //string fecha = System.DateTime.Now.ToString("dd/MMM/yyy");

            if (IsPostBack == false)
            {

                if (RadioButton_Cliente.Checked)
                {
                    GridView3.DataSource = Connect1.Consultar2("Cliente", "Clientes");
                    GridView3.DataBind();


                    string campos = "Categoria, Producto, Precio, Cantidad, Importe, Factura";
                    GridView1.DataSource = Connect2.Consultar9(campos, "Ventas", "Fecha", fecha);
                    GridView1.DataBind();
                }
                if (RadioButton_Proveedor.Checked)
                {

                    GridView3.DataSource = Connect2.Consultar2("Proveedor", "Proveedores");
                    GridView3.DataBind();


                    string campos = "Categoria, Producto, Precio, Cantidad, Importe, Factura";
                    GridView1.DataSource = Connect1.Consultar9(campos, "Compras", "Fecha", fecha);
                    GridView1.DataBind();


                }


            }

        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            string cliProv1, tabla, cliProv2;
            cliProv1 = "";
            tabla = "";

            string campos = "Categoria,Producto,Precio,Cantidad,Importe,Factura";

            if (RadioButton_Cliente.Checked)
            {
                cliProv1 = "Cliente";
                tabla = "Ventas";
            }
            if (RadioButton_Proveedor.Checked)
            {
                cliProv1 = "Proveedor";
                tabla = "Compras";
            }

            if(TextBox_CliProv.Text == "")
            {
                GridView1.DataSource = Connect1.Consultar9(campos, tabla, "Fecha", fecha);
                GridView1.DataBind();
            }
            else
            {
                cliProv2 = GridView3.SelectedRow.Cells[1].Text;
                GridView1.DataSource = Connect1.Consultar7(campos, tabla, cliProv1, cliProv2, "Fecha", TextBox_Fecha.Text);
                GridView1.DataBind();
            }

            Label_Mensaje.Text = "";

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int factura = Convert.ToInt32(GridView1.SelectedRow.Cells[6].Text);
            TextBox_Fecha.Text = System.DateTime.Now.ToString("dd/MMM/yyy");
            string cliProv, tabla;
            cliProv = "";
            tabla = "";
            if (RadioButton_Cliente.Checked)
            {
                cliProv = "Cliente";
                tabla = "Ventas";
            }
            if (RadioButton_Proveedor.Checked)
            {
                cliProv = "Proveedor";
                tabla = "Compras";
            }
            if(TextBox_CliProv.Text == "")
            {
                Label_Mensaje.Text = " Seleccione un " + cliProv;
            }
            else
            {
                Decimal importe = 0;
                int i = 0;
                Decimal[] Importes;
                Importes = new Decimal[100];
              //  TextBox_Fecha.Text = factura;

                string factura2 = Convert.ToString(factura);
                TextBox_Factura.Text = factura2;

                foreach (DataRow row1 in Connect1.Consultar7("*", tabla, "Factura", factura2, cliProv, TextBox_CliProv.Text).Rows)
                {
                    Importes[i] = Convert.ToDecimal(row1[6]);
                    importe += Importes[i];
                    i = +1;
                }

                TextBox_Importe.Text = String.Format("{0: #,###,###,##0.00####}", importe);
                string campos = "Categoria,Producto,Precio,Cantidad,Importe";
                GridView2.DataSource = Connect2.Consultar7(campos, tabla, "Factura", factura2,
                    cliProv, TextBox_CliProv.Text);
                GridView2.DataBind();

                
            }

        }


        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView2.PageIndex = e.NewPageIndex;
            string cliProv1, tabla, cliProv2;
            cliProv1 = "";
            tabla = "";

            string campos = "Categoria,Producto,Precio,Cantidad,Importe";

            if (RadioButton_Cliente.Checked)
            {
                cliProv1 = "Cliente";
                tabla = "Ventas";
            }
            if (RadioButton_Proveedor.Checked)
            {
                cliProv1 = "Proveedor";
                tabla = "Compras";
            }

            if (TextBox_CliProv.Text == "")
            {
                GridView2.DataSource = Connect1.Consultar9(campos, tabla, "Fecha", fecha);
                GridView2.DataBind();
            }
            else
            {
                cliProv2 = GridView3.SelectedRow.Cells[1].Text;
                GridView2.DataSource = Connect1.Consultar7(campos, tabla, cliProv1, cliProv2, "Fecha", TextBox_Fecha.Text);
                GridView2.DataBind();
            }

            Label_Mensaje.Text = "";

        }


        protected void TextBox_Buscar1_TextChanged(object sender, EventArgs e)
        {

            string cliProv1, tabla, cliProv2;
            cliProv1 = "";
            tabla = "";
            string campos = "Categoria,Producto,Precio,Cantidad,Importe,Factura";


            if (RadioButton_Cliente.Checked)
            {
                cliProv1 = "Cliente";
                tabla = "Ventas";
            }
            if (RadioButton_Proveedor.Checked)
            {
                cliProv1 = "Proveedor";
                tabla = "Compras";
            }

            if(TextBox_CliProv.Text == "")
            {

                GridView1.DataSource = Connect1.Consultar4(campos, tabla, "Producto", TextBox_Buscar1.Text);
                GridView1.DataBind();

            }
            else
            {
                cliProv2 = GridView1.SelectedRow.Cells[1].Text;
                GridView1.DataSource = Connect1.Consultar10(campos, tabla, cliProv1, cliProv2, "Fecha",
                    TextBox_Fecha.Text, "Producto", TextBox_Buscar1.Text);
                GridView1.DataBind();
            }
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;

            if (RadioButton_Cliente.Checked)
            {
                GridView3.DataSource = Connect1.Consultar2("Cliente", "Clientes");
                GridView1.DataBind();
            }
            if (RadioButton_Proveedor.Checked)
            {
                GridView3.DataSource = Connect1.Consultar2("Proveedor", "Proveedores");
                GridView3.DataBind();
            }

        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cliProv1,cliProv2, tabla;
            cliProv1 = "";
            tabla = "";

            if (RadioButton_Cliente.Checked)
            {
                cliProv1 = "Cliente";
                tabla = "Ventas";
            }
            if (RadioButton_Proveedor.Checked)
            {
                cliProv1 = "Proveedor";
                tabla = "Compras";
            }

            TextBox_Fecha.Text = fecha;


            cliProv2 = GridView3.SelectedRow.Cells[1].Text;
            TextBox_CliProv.Text = cliProv2;

            string campos = "Categoria, Producto,Precio,Cantidad,Importe,Factura";
            GridView1.DataSource = Connect1.Consultar7(campos, tabla, cliProv1, cliProv2, "Fecha", TextBox_Fecha.Text);
            GridView1.DataBind();
            Label_Mensaje.Text = "";
                       
        }

        protected void TextBox_Buscar2_TextChanged(object sender, EventArgs e)
        {

            string cliProv1, tabla;
            cliProv1 = "";
            tabla = "Ventas";

            if (RadioButton_Cliente.Checked)
            {
                cliProv1 = "Cliente";
                tabla = "Clientes";
            }
            if (RadioButton_Proveedor.Checked)
            {
                cliProv1 = "Proveedor";
                tabla = "Proveedores";
            }

            GridView3.DataSource = Connect1.Consultar4(cliProv1, tabla, cliProv1,
                TextBox_Buscar2.Text);
            GridView3.DataBind();


        }

        protected void RadioButton_Cliente_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_Cliente.Checked)
            {
                string fecha = System.DateTime.Now.ToString("dd/MMM/yyy");
                Label_CliProv.Text = "Cliente";
                TextBox_CliProv.Text = "";
                TextBox_Factura.Text = "";
                TextBox_Importe.Text = "";
                Label_Mensaje.Text = "";

                GridView3.DataSource = Connect1.Consultar2("Cliente", "Clientes");
                GridView3.DataBind();
                string campos = "Categoria,Producto,Precio,Cantidad,Importe,Factura";
                GridView1.DataSource = Connect2.Consultar9(campos, "Ventas", "Fecha", fecha);
                GridView1.DataBind();

            }
        }

        protected void RadioButton_Proveedor_CheckedChanged(object sender, EventArgs e)
        {

            if (RadioButton_Proveedor.Checked)
            {
                string fecha = System.DateTime.Now.ToString("dd/MMM/yyy");
                Label_CliProv.Text = "Cliente";
                TextBox_CliProv.Text = "";
                TextBox_Factura.Text = "";
                TextBox_Importe.Text = "";
                Label_Mensaje.Text = "";

                GridView3.DataSource = Connect1.Consultar2("Proveedor", "Proveedores");
                GridView3.DataBind();
                string campos = "Categoria,Producto,Precio,Cantidad,Importe,Factura";
                GridView1.DataSource = Connect2.Consultar9(campos, "Compras", "Fecha", fecha);
                GridView1.DataBind();

            }



        }

        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Facturacion.aspx");
        }
    }
}