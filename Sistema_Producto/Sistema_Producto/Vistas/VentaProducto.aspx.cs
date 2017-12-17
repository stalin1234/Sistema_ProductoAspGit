using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Producto.Vistas
{
    public partial class VentaProducto : System.Web.UI.Page
    {

        Conexion Connect1 = new Conexion();
        Conexion Connect2 = new Conexion();
        Conexion Connect3 = new Conexion();
        Conexion Connect4 = new Conexion();
        Conexion Connect5 = new Conexion();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] == " ")
            {

                Response.Redirect("Login.aspx");
            }


            string TipoUser = Convert.ToString(Session["TipoUser"]);
            if(TipoUser == "Empl")
            {

                Reportes.Visible = false;
            }



            TextBox_Fecha.Text = System.DateTime.Now.ToString("dd/MMM/yyy");

            if (IsPostBack == false)
            {

                //string campos = "Codigo, Producto,Precio,Categoria";
                //GridView1.DataSource = Connect1.Consultar2(campos, "Productos");
                //GridView1.DataBind();

                string Campos = " Productos.Codigo, Productos.Categoria,Productos.Producto,Productos.Precio,Bodega.Actual";
                GridView1.DataSource = Connect1.Consultar5(Campos, "Productos", "Bodega", "Productos.Codigo = Bodega.Codigo");
                GridView1.DataBind();

                GridView2.DataSource = Connect2.Consultar2("Id, Cliente", "Clientes");
                GridView2.DataBind();

                GridView3.DataSource = Connect5.Consultar4("*", "Ventas", "Fecha", TextBox_Fecha.Text);
                GridView3.DataBind();

                string campos2 = "Id, Categoria, Producto, Precio, Cantidad, Importe";
                GridView4.DataSource = Connect4.Consultar7(campos2, "Ventas", "Cliente", TextBox_Cliente.Text, "Factura", TextBox_Factura.Text);
                GridView4.DataBind();

            }


        }


        private void GuardarDatos()
        {
            if (TextBox_Producto.Text == "")
            {
                Label_Producto.ForeColor = Color.Red;
                Label_Producto.Text = "Seleccione un producto";
            }
            else
            {
                Label_Producto.ForeColor = Color.Green;
                if (TextBox_Precio.Text == "")
                {
                    Label_Precio.ForeColor = Color.Red;
                    Label_Precio.Text = "ingrese precio";
                    TextBox_Precio.Focus();
                }
                else
                {
                    if (TextBox_Cantidad.Text == "")
                    {

                        Label_Cantidad.ForeColor = Color.Red;
                        Label_Cantidad.Text = "ingrese cnatidad";
                        TextBox_Cantidad.Focus();
                    }
                    else
                    {
                        if (TextBox_Cliente.Text == "")
                        {

                            Label_Cliente.ForeColor = Color.Red;
                            Label_Cliente.Text = "selecione un Cliente";
                        }
                        else
                        {
                            if (TextBox_Importe.Text == "")
                            {


                            }
                            else

                            {


                            Label_Cliente.ForeColor = Color.Green;


                            string sql1, sql2, IdProducto = "", importeBodega1, precio2;
                            double Cantidad2, Precio, PrecioProducto = 0, importe, importeBodega2, PrecioBodega, PrecioIngresar;
                            int Cantidad, CantProducto, IngresarCant, CantidadBodega, IdBodega;

                            Cantidad = Convert.ToInt32(TextBox_Cantidad.Text);

                            foreach (DataRow row in Connect2.Consultar4("*", "Productos", "Producto", TextBox_Producto.Text).Rows)
                            {

                                IdProducto = Convert.ToString(row[1]);
                                PrecioProducto = Convert.ToDouble(row[3]);
                            }

                            foreach (DataRow row in Connect3.Consultar4("*", "Bodega", "Codigo", IdProducto).Rows)
                            {
                                IdBodega = Convert.ToInt32(row[0]);
                                CantidadBodega = Convert.ToInt32(row[2]);
                                PrecioBodega = Convert.ToDouble(row[3]);

                                Cantidad2 = Convert.ToDouble(Cantidad);
                                importeBodega2 = Cantidad2 * PrecioProducto;

                                //importeBodega1 = String.Format("{0: #,###,###,##0.00####}", importeBodega2);

                                IngresarCant = CantidadBodega - Cantidad;
                                PrecioIngresar = PrecioBodega - importeBodega2;
                                importeBodega1 = String.Format("{0: #,###,###,##0.00####}", PrecioIngresar);

                                Precio = Convert.ToDouble(TextBox_Precio.Text);

                                precio2 = String.Format("{0: #,###,###,##0.00####}", Precio);

                                sql1 = " INSERT INTO Ventas (Cliente,Categoria,Producto,Precio,Cantidad,Importe,Fecha,Factura) VALUES ('" + TextBox_Cliente.Text + "','" + TextBox_Categoria.Text + "','" +
                                    TextBox_Producto.Text + "','" + precio2 + "','" +
                                    TextBox_Cantidad.Text + "','" + TextBox_Importe.Text + "','" +
                                    TextBox_Fecha.Text + "','" + TextBox_Factura.Text + "')";



                                if (Connect1.Insertar(sql1))
                                {
                                    string campos = " Codigo ='" + IdProducto + "', Actual = '" +
                                        IngresarCant + "', Importe = '" + importeBodega1 + "'";

                                    if (Connect3.Actualizar("Bodega", campos, " Id = '" + IdBodega + "'"))
                                    {
                                        string campo2 = " CltProv = '" + TextBox_Cliente.Text +
                                            "', Factura = '" + TextBox_Factura.Text + "'";

                                            if (Connect4.Actualizar("Facturas", campo2, " CltProv = '" +
                                                TextBox_Cliente.Text + "'"))
                                            {

                                                TextBox_Producto.Text = "";
                                                TextBox_Precio.Text = "";
                                                TextBox_Cantidad.Text = "";
                                                TextBox_Categoria.Text = "";
                                                TextBox_Importe.Text = "";

                                                Label_Categoria.ForeColor = Color.Black;
                                                Label_Producto.ForeColor = Color.Black;
                                                Label_Precio.ForeColor = Color.Black;
                                                Label_Cantidad.ForeColor = Color.Black;
                                                Label_Importe.ForeColor = Color.Black;

                                                string Campos = " Productos.Codigo, Productos.Categoria,Productos.Producto,Productos.Precio,Bodega.Actual";
                                                GridView1.DataSource = Connect1.Consultar5(Campos, "Productos", "Bodega", "Productos.Codigo = Bodega.Codigo");
                                                GridView1.DataBind();

                                                // GridView2.DataSource = Connect2.Consultar2("Id, Proveedor", "Proveedores");
                                                //                                   GridView2.DataBind();


                                                decimal importe1 = 0;
                                                int a = 0;
                                                Decimal[] Importes;
                                                Importes = new Decimal[100];

                                                foreach (DataRow row1 in Connect3.Consultar7("*", "Ventas", "Cliente", TextBox_Cliente.Text, "Factura", TextBox_Factura.Text).Rows)
                                                {
                                                    Importes[a] = Convert.ToDecimal(row1[6]);
                                                    importe1 += Importes[a];
                                                    a = +1;
                                                }


                                                            TextBox_ImporteTotal.Text = String.Format("{0: #,###,###,##0.00####}", importe1);

                                                            GridView3.DataSource = Connect5.Consultar4("*", "Ventas", "Fecha", TextBox_Fecha.Text);
                                                            GridView3.DataBind();

                                                            string campos3 = "Id,Categoria,Producto,Precio,Cantidad,Importe";
                                                            GridView4.DataSource = Connect4.Consultar7(campos3, "Ventas", "Cliente", TextBox_Cliente.Text, "Factura", TextBox_Factura.Text);
                                                            GridView4.DataBind();

                    

                                            }
                                        }

                                    }
                                }
                            }
                        }

                    }
                }

            }
        }




        protected void Button_Venta_Click(object sender, EventArgs e)
        {

            GuardarDatos();
        }

        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("VentaProducto.aspx");
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {


            TextBox_Codigo.Text = GridView1.SelectedRow.Cells[1].Text;
            TextBox_Categoria.Text = Page.Server.HtmlDecode(GridView1.SelectedRow.Cells[2].Text);
            TextBox_Producto.Text = Page.Server.HtmlDecode(GridView1.SelectedRow.Cells[3].Text);
            TextBox_Precio.Text = GridView1.SelectedRow.Cells[4].Text;

            Label_Categoria.ForeColor = Color.Green;
            Label_Precio.ForeColor = Color.Green;
            if (TextBox_Producto.Text == "")
            {

            }
            else
            {

                Label_Producto.ForeColor = Color.Green;
                Label_Producto.Text = "Producto";
            }
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.PageIndex = e.NewPageIndex;
            string Campos = " Productos.Codigo, Productos.Categoria,Productos.Producto,Productos.Precio,Bodega.Actual";
            GridView1.DataSource = Connect1.Consultar5(Campos, "Productos", "Bodega", "Productos.Codigo = Bodega.Codigo");
            GridView1.DataBind();




        }

       


        protected void TextBox_Buscar1_TextChanged(object sender, EventArgs e)
        {
            string Campos = " Productos.Codigo, Productos.Categoria,Productos.Producto,Productos.Precio,Bodega.Actual";
            GridView1.DataSource = Connect2.Consultar6(Campos, "Productos", "Bodega", "Productos.Codigo = BodegaCodigo", "Producto", TextBox_Buscar1.Text);
            GridView1.DataBind();

            GridView2.DataSource = Connect2.Consultar2("Id, Proveedor", "Proveedores");
            GridView2.DataBind();
        }



        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView1.DataSource = Connect2.Consultar2("Id, Cliente", "Clientes");
            GridView2.DataBind();

        }


        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridView2.Columns[0].Visible = false;
            string Id = GridView2.SelectedRow.Cells[1].Text;

            foreach (DataRow row in Connect1.Consultar4("*", "Clientes", "Id", Id).Rows)
            {

                TextBox_Cliente.Text = Convert.ToString(row[1]);
                TextBox_Direccion.Text = Convert.ToString(row[2]);
                TextBox_Telefono.Text = Convert.ToString(row[3]);
                TextBox_Email.Text = Convert.ToString(row[4]);
                TextBox_ProvFecha.Text = Convert.ToString(row[5]);

            }

            int factura = 0;

            foreach (DataRow row in Connect2.Consultar4("*", "Facturas", "CltProv", TextBox_Cliente.Text).Rows)
            {
                factura = Convert.ToInt16(row[2]);
            }

            factura = factura + 1;
            TextBox_Factura.Text = Convert.ToString(factura);
            Label_Mensaje.Text = "";

            if (TextBox_Cliente.Text == "")
            {

            }
            else
            {
                Label_Cliente.ForeColor = Color.Green;
                Label_Cliente.Text = "Cliente";
            }

            Label_Direccion.ForeColor = Color.Green;
            Label_Telefono.ForeColor = Color.Green;
            Label_Email.ForeColor = Color.Green;
            Label_FechaProv.ForeColor = Color.Green;
            Label_Factura.ForeColor = Color.Green;

            GridView2.CellPadding = 6;
            GridView2.BorderWidth = 6;



        }

        protected void TextBox_Buscar2_TextChanged(object sender, EventArgs e)
        {

            GridView2.DataSource = Connect1.Consultar4("Id, Cliente", "Clientes", "Cliente", TextBox_Buscar2.Text);
            GridView2.DataBind();


        }

        protected void TextBox_Precio_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox_Cantidad_TextChanged(object sender, EventArgs e)
        {

            if (TextBox_Cantidad.Text == "")
            {

            }
            else
            {
                Label_Cantidad.ForeColor = Color.Green;
                Label_Cantidad.Text = "Cantidad";

                double Cantidad, Precio3 = 0, importe;
                string Precio1, Precio2;
                int caracteres, CantidadBodega= 0;
                Cantidad = Convert.ToDouble(TextBox_Cantidad.Text);
                Precio1 = Convert.ToString(TextBox_Precio.Text);
                Precio2 = Precio1.Replace(".", "");


                foreach(DataRow row1 in Connect1.Consultar4("*", "Bodega","Codigo",TextBox_Cliente.Text).Rows)
                {

                    CantidadBodega = Convert.ToInt32(row1[2]);
                }


                if (CantidadBodega == 0)
                {
                    Label_Cantidad.ForeColor = Color.Red;
                    Label_Cantidad.Text = "Producto agotado";
                }
                else
                {

                    Label_Cantidad.ForeColor = Color.Green;

                    if (CantidadBodega < Cantidad)
                    {
                        Label_Cantidad.ForeColor = Color.Red;
                        Label_Cantidad.Text = "Producto insuficiente";
                        Label_Importe.ForeColor = Color.Black;
                        TextBox_Importe.Text = "";
                    }
                    else
                    {
                        Label_Cantidad.ForeColor = Color.Green;


                        
                        caracteres = Precio2.Length;
                        if (caracteres <= 4)
                        {
                            Precio3 = Convert.ToDouble(Precio1);
                        }
                        if (caracteres >= 5)
                        {
                            Precio3 = Convert.ToInt32(Precio2);
                        }


                        importe = Cantidad * Precio3;

                        TextBox_Importe.Text = String.Format("{0: #,###,###,##0.00####}", importe);

                        Label_Importe.ForeColor = Color.Green;
                    }
                }
            }

        }

        protected void TextBox_Importe_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string campos4 = " Cliente,Categoria,Producto,Precio,Cantidad,Importe,Factura";
            GridView3.PageIndex = e.NewPageIndex;
            GridView3.DataSource = Connect4.Consultar4(campos4, "Ventas", "Fecha", TextBox_Fecha.Text);
            GridView3.DataBind();

        }

        protected void TextBox_Buscar3_TextChanged(object sender, EventArgs e)
        {
            string campos4 = " Cliente,Categoria,Producto,Precio,Cantidad,Importe,Factura";
            GridView3.DataSource = Connect1.Consultar8(campos4, "Ventas", "Fecha", TextBox_Fecha.Text, "Cliente", TextBox_Buscar3.Text);
            GridView3.DataBind();
        }


        protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string campos3 = "Id,Categoria,Producto,Precio,Cantidad,Importe";
            GridView4.PageIndex = e.NewPageIndex;
            GridView4.DataSource = Connect4.Consultar7(campos3, "Ventas", "Cliente", TextBox_Cliente.Text, "Factura", TextBox_Factura.Text);
            GridView4.DataBind();

        }


        protected void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string producto, importeBodega2, Id, IdProducto = "", IdBodega = "", PrecioProducto1 = "", PrecioProducto2 = "";
            producto = "";
            double importeBodega = 0, PrecioProducto3 = 0;
            int IngresarCant, CantidadBodega = 0;
            int a = 0, cantidad = 0, caracteres = 0;
            Decimal[] Importes;
            Importes = new Decimal[100];
            Decimal importe1 = 0;

            Id = GridView4.Rows[e.RowIndex].Cells[1].Text;

            foreach (DataRow row in Connect1.Consultar4("*", "Ventas", "Id", Id).Rows)
            {
                producto = Convert.ToString(row[3]);
                cantidad = Convert.ToInt16(row[5]);
            }

            foreach (DataRow row in Connect2.Consultar4("*", "Productos", "Producto", producto).Rows)
            {
                IdProducto = Convert.ToString(row[1]);
                PrecioProducto1 = Convert.ToString(row[3]);
                PrecioProducto2 = PrecioProducto1.Replace(".", "");

                //   PrecioProducto3 = Convert.ToInt32(PrecioProducto2);

            }

            foreach (DataRow row in Connect3.Consultar4("*", "Bodega", "Codigo", IdProducto).Rows)
            {
                IdBodega = Convert.ToString(row[0]);
                CantidadBodega = Convert.ToInt16(row[2]);
            }


            caracteres = PrecioProducto2.Length;
            if (caracteres <= 4)
            {

                PrecioProducto3 = Convert.ToDouble(PrecioProducto1);

            }
            if (caracteres >= 5)
            {
                PrecioProducto3 = Convert.ToInt32(PrecioProducto2);
            }



            IngresarCant = CantidadBodega + cantidad;
            importeBodega = PrecioProducto3 * IngresarCant;
            importeBodega2 = String.Format("{0: #,###,###,##0.00####}", importeBodega);

            string campos = "Codigo = '" + IdProducto + "', Actual = '" + IngresarCant + "', Importe ='" +
                importeBodega2 + "'";


            if (texto.Text == "yes")
            {
                if (Connect1.Actualizar("Bodega", campos, " Id = '" + IdBodega + "'"))
                {
                    if (Connect1.Eliminar("Ventas", " Id = '" + Id + "'"))
                    {
                        foreach (DataRow row in Connect4.Consultar7("*", "Ventas", "Cliente", TextBox_Cliente.Text, "Factura", TextBox_Factura.Text).Rows)
                        {
                            Importes[a] = Convert.ToDecimal(row[6]);
                            importe1 -= Importes[a];
                            a = +1;

                        }

                        string importe2 = Convert.ToString(importe1);
                        decimal importe3 = Convert.ToDecimal(importe2.Replace("-", ""));


                        TextBox_ImporteTotal.Text = String.Format("{0: #,###,###,##0.00####}", importe3);



                        if (GridView4.Rows.Count == 0)
                        {
                            TextBox_ImporteTotal.Text = "";

                        }


                        string Campos1 = " Productos.Codigo, Productos.Categoria, Productos.Producto, Productos.Precio, Bodega.Actual";

                        GridView1.DataSource = Connect3.Consultar5(Campos1, "Productos", "Bodega", "Productos.Codigo = Bodega.Codigo");
                        GridView1.DataBind();

                        string campos2 = " Cliente, Categoria, Producto, Precio , Cantidad, Importe, Factura";

                        GridView3.DataSource = Connect4.Consultar4(campos2, "Ventas", "Fecha", TextBox_Fecha.Text);
                        GridView3.DataBind();


                        string campos3 = "Id,Categoria,Producto,Precio,Cantidad,Importe";

                        GridView4.DataSource = Connect5.Consultar7(campos3, "Ventas", "Cliente",
                            TextBox_Cliente.Text, "Factura", TextBox_Factura.Text);

                        GridView4.DataBind();


                    }
                }
            }

        }

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                ImageButton Lb = (ImageButton)e.Row.Cells[0].Controls[0];
                Lb.Attributes.Add("onclick", "javascript:confirmDelete(); ");
            }

        }

        
    }
    
}
