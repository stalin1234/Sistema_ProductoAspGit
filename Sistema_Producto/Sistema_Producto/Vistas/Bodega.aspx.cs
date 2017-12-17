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
    public partial class Bodega : System.Web.UI.Page
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

            string TipoUser;
            TipoUser = Convert.ToString(Session["TipoUser"]);
            if(TipoUser = "Empl")
            {

            }


            if (IsPostBack == false)
           
                //string campos = "Codigo, Producto,Precio,Categoria";
                //GridView1.DataSource = Connect1.Consultar2(campos, "Productos");
                //GridView1.DataBind();

                string Campos = " Productos.Codigo, Productos.Categoria,Productos.Producto,Productos.Precio,Bodega.Actual,Bodega.Importe";
                GridView1.DataSource = Connect1.Consultar5(Campos, "Productos", "Bodega", "Productos.Codigo = Bodega.Codigo");
                GridView1.DataBind();

            }

        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            TextBox_Codigo.Text = GridView1.SelectedRow.Cells[1].Text;
            TextBox_Producto.Text = GridView1.SelectedRow.Cells[3].Text;
            TextBox_Precio.Text = GridView1.SelectedRow.Cells[4].Text;
            TextBox_Actual.Text = GridView1.SelectedRow.Cells[5].Text;

            Label_Producto.ForeColor = Color.Green;
            Label_Precio.ForeColor = Color.Green;
            Label_Actual.ForeColor = Color.Green;
            Label1_Mensaje.Text ="";


        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.PageIndex = e.NewPageIndex;
            string Campos =

                "Productos.Codigo,Productos.Categoria,Productos.Producto,Productos.Precio,Bodega.Actual, Bodega.Importe";

            GridView1.DataSource = Connect1.Consultar5(Campos, "Productos", "Bodega","Productos.Codigo = Bodega.Codigo");
            GridView1.DataBind();



        }


        private void GuardarDatos()
        {

            if(TextBox_Producto.Text == "")
            {
                Label1_Mensaje.Text = "selecione un produc";
            }
            else
            {

                if(TextBox_Importe.Text == "")
                {
                    Label1_Mensaje.Text = "Modifica cantidad";
                    TextBox_Actual.Focus();
                }
                else
                {

                    string codigo, IdBodega;
                    codigo = TextBox_Codigo.Text;

                    foreach (DataRow row in Connect3.Consultar4("*", "Bodega", "Codigo",
                        codigo).Rows) 
                    {

                        IdBodega = Convert.ToString(row[0]);
                    }

                    string campos = "Actual = '" + TextBox_Actual.Text + "' , Importe = '" +
                        TextBox_Importe.Text + "'";

                    if(Connect3.Actualizar("Bodega", campos, "Id = '" + IdBodega + "'"))
                    {
                        Response.Redirect("Bodega.aspx");
                    }

                                                          

                }

            }
        }

        protected void Button_Guardar_Click(object sender, EventArgs e)
        {

            GuardarDatos();

        }

        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Bodega.aspx");

        }

        protected void TextBox_Actual_TextChanged(object sender, EventArgs e)
        {

            string precio1, precio2;
            int ingresarCant, caracteres;
            double precio3 = 0, importeBodega;

            precio1 = TextBox_Precio.Text;
            precio2 = precio1.Replace(".", "");
            caracteres = precio2.Length;

            if(caracteres <= 4)
            {
                precio3 = Convert.ToDouble(precio1);
            }
            if(caracteres >= 5)
            {
                precio3 = Convert.ToInt16(precio2);
            }

            ingresarCant = Convert.ToInt32(TextBox_Actual.Text);
            importeBodega = ingresarCant * precio3;
            TextBox_Importe.Text = String.Format("{0: #,###,###,##0.00####}", importeBodega);
            Label_Importe.ForeColor = Color.Green;
            Label1_Mensaje.Text = "";

        }

        protected void TextBox_Buscar_TextChanged(object sender, EventArgs e)
        {

              string Campos =

                "Productos.Codigo,Productos.Categoria,Productos.Producto,Productos.Precio,Bodega.Actual, Bodega.Importe";

            GridView1.DataSource = Connect1.Consultar6(Campos, "Productos", "Bodega",
                "Productos.Codigo = Bodega.Codigo","Producto", TextBox_Buscar.Text);
            GridView1.DataBind();

        }
    }
}