using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Producto.Vistas
{
    public partial class ClienteProveedor : System.Web.UI.Page
    {

        Conexion Connect1 = new Conexion();
        Conexion Connect2 = new Conexion();
        Conexion Connect3 = new Conexion();
        Conexion Connect4 = new Conexion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == " ")
            {

                Response.Redirect("Login.aspx");
            }

            if (IsPostBack == false)
            {
                GridView1.DataSource = Connect1.Consultar2("*", "Clientes");
                GridView1.DataBind();

                Label_Cliente.Visible = true;
                Label_Proveedor.Visible = false;


                Button_Actualizar.Visible = false;
                Button_Guardar.Visible = true;
                                
            }

            string TipoUser;
            TipoUser = Convert.ToString(Session["TipoUser"]);
            if (TipoUser == "Empl")
            {
                GridView1.Columns[1].Visible = false;
                PlaceHolder1.Visible = false;
                Reportes.Visible = false;
            }
            else
            {

            }


            TextBox_Fecha.Text = System.DateTime.Now.ToString("dd/MMM/yyy");



        }

        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClienteProveedor.aspx");
        }


        /// metodo para validar el email ingresado


        public static bool validarEmail(string email)
        {

            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }

        //metodo para insertar dats

        private void GuardarDatos()
        {
            if (TextBox_Nombre.Text == "")
            {

               // Label_Cliente.Visible = false;
                //Label_Proveedor.Visible = false;
                TextBox_Nombre.Focus();


                if (RadioButton_Cliente.Checked)

                {

                    Label_Cliente.Visible = true;
                    Label_Proveedor.Visible = false;
                    Label_Cliente.ForeColor = Color.Red;
                    Label_Cliente.Text = "ingrese Nombre";
                }

                if (RadioButton_Proveedor.Checked)
                {

                    Label_Cliente.Visible = false;
                    Label_Proveedor.Visible = true;
                    Label_Proveedor.ForeColor = Color.Red; Label_Proveedor.Text = "ingrese Nombre";
                    Label_Proveedor.Text = "ingrese nombre";
                }

            }
            else
            {

                if (TextBox_Direccion.Text == "")

                {
                    TextBox_Direccion.Focus();
                    Label_Direccion.ForeColor = Color.Red;
                    Label_Direccion.Text = "Ingrese direccion";

                }

                else

                {
                    if (TextBox_Telefono.Text == "")
                    {

                        TextBox_Telefono.Focus();
                        Label_Telefono.ForeColor = Color.Red;
                        Label_Telefono.Text = "Ingrese telefono";

                    }
                    else
                    {
                        if (TextBox_Email.Text == "")
                        {
                            Label_Email.Focus();
                            Label_Email.ForeColor = Color.Red;
                            Label_Email.Text = "ingrese email";

                        }
                        else
                        {

                            if (validarEmail(TextBox_Email.Text))
                            {
                                Label_Mensaje.Text = "";
                                string sql1, sql2, tabla="", nombre="";

                                if (RadioButton_Cliente.Checked)
                                {
                                    tabla = "Clientes";
                                    nombre = "Cliente"; 
                                }
                                if (RadioButton_Proveedor.Checked)
                                {
                                    tabla = "Proveedores";
                                    nombre = "Proveedor";
                                }

                                bool Resultados = Connect1.Consultar3("Email", tabla, "Email", TextBox_Email.Text);

                                if (Resultados)
                                {
                                    TextBox_Email.Focus();
                                    Label_Mensaje.Text = "La id" + nombre + " del prodiucto existe";
                                }
                                else
                                {

                                    sql1 = " INSERT INTO " + tabla + "(" + nombre + ",Direccion,Telefono,Email,Fecha) VALUES ('" + TextBox_Nombre.Text + "', '" + TextBox_Direccion.Text + "','" + TextBox_Telefono.Text + "','" + TextBox_Email.Text + "','" + TextBox_Fecha.Text + "')";

                                    if (Connect2.Insertar(sql1))
                                    {
                                        sql2 = " INSERT INTO  Facturas (CltProv,Factura) VALUES ('" + TextBox_Nombre.Text + "', '" + 0 + "')";


                                        if (Connect3.Insertar(sql2))
                                        {
                                            TextBox_Nombre.Text = "";
                                            TextBox_Direccion.Text = "";
                                            Label_Proveedor.ForeColor = Color.Black;
                                            Label_Proveedor.Text = "Proveedor";
                                            Label_Direccion.ForeColor = Color.Black;
                                            Label_Direccion.Text = "Direccion";
                                            Label_Telefono.ForeColor = Color.Black;
                                            Label_Telefono.Text = "Telefono";
                                            Label_Email.ForeColor = Color.Black;
                                            Label_Email.Text = "Email";
                                            TextBox_Telefono.Text = "";
                                            TextBox_Email.Text = "";

                                            Label_Cliente.ForeColor = Color.Black;
                                            Label_Cliente.Text = "Cliente";


                                            GridView1.DataSource = Connect1.Consultar2("*", tabla);
                                            GridView1.DataBind();
                                        }

                                    }
                                }

                            }
                            else
                            {
                                Label_Email.ForeColor = Color.Red;
                                Label_Email.Text = "direccion de correo no vslido";
                                TextBox_Email.Focus();

                            }
                        }
                    }
                }
            }
        }



        protected void Button_Guardar_Click(object sender, EventArgs e)
        {

            GuardarDatos();


        }

        private void Actualizar()
        {
            Label_Mensaje.Text = "";

            string sql1, sql2, tabla = "", nombre = "", campos;

            if (RadioButton_Cliente.Checked)
            {
                tabla = "Clientes";
                nombre = "Cliente";
            }
            if (RadioButton_Proveedor.Checked)
            {
                tabla = "Proveedores";
                nombre = "Proveedor";
            }

            campos = nombre + "='" + TextBox_Nombre.Text + "', Direccion = '" + TextBox_Direccion.Text + "', Telefono = '" + TextBox_Telefono.Text + "', Email = '" + TextBox_Email.Text + "' ,Fecha = '" + TextBox_Fecha.Text + "'";
        
            if (validarEmail(TextBox_Email.Text))
            {
                Label_Mensaje.Text = "";

                if(Connect1.Actualizar(tabla, campos,"Id = '" + TextBox_Id.Text + "'"))
                {

                    TextBox_Nombre.Text = "";
                    TextBox_Direccion.Text = "";
                    TextBox_Telefono.Text = "";
                    TextBox_Email.Text = "";

                    Label_Cliente.ForeColor = Color.Black;
                    Label_Cliente.Text = "Cliente";
                    Label_Proveedor.ForeColor = Color.Black;
                    Label_Proveedor.Text = "Proveedor";
                    Label_Direccion.ForeColor = Color.Black;
                    Label_Direccion.Text = "Direccion";
                    Label_Telefono.ForeColor = Color.Black;
                    Label_Telefono.Text = "Telefono";
                    Label_Email.ForeColor = Color.Black;
                    Label_Email.Text = "Email";

                    GridView1.DataSource = Connect1.Consultar2("*", tabla);
                    GridView1.DataBind();

                    Button_Actualizar.Visible = false;
                    Button_Guardar.Visible = true;
                }
            }
            else
            {
                Label_Email.ForeColor = Color.Red;
                Label_Mensaje.Text = "emil no vlido";
                TextBox_Email.Focus();
            }
        }



        protected void Button_Actualizar_Click(object sender, EventArgs e)
        {


            Actualizar();

        }

        protected void Button_Tipo_Click(object sender, EventArgs e)
        {

            if (RadioButton_Cliente.Checked)
            {
                Label_Cliente.Visible = true;
                Label_Proveedor.Visible = false;


                GridView1.DataSource = Connect1.Consultar2("*", "Clientes");
                GridView1.DataBind();

                TextBox_Nombre.Text = "";
                TextBox_Direccion.Text = "";
                TextBox_Telefono.Text = "";
                TextBox_Email.Text = "";
                Label_Mensaje.Text = "";


                Label_Cliente.Text = "";
                Label_Proveedor.Text = "";
                Label_Direccion.Text = "";
                Label_Telefono.Text = "";
                Label_Email.Text = "";
                Label_Cliente.ForeColor = Color.Black;
                Label_Cliente.Text = "Cliente";
                Label_Proveedor.ForeColor = Color.Black;
                Label_Proveedor.Text = "Proveedor";
                Label_Direccion.ForeColor = Color.Black;
                Label_Direccion.Text = "Direccion";
                Label_Telefono.ForeColor = Color.Black;
                Label_Telefono.Text = "Telefono";
                Label_Email.ForeColor = Color.Black;
                Label_Email.Text = "Email";

            }

            if (RadioButton_Proveedor.Checked)
            {
                Label_Cliente.Visible = false;
                Label_Proveedor.Visible = true;


                GridView1.DataSource = Connect2.Consultar2("*", "Proveedores");
                GridView1.DataBind();

                TextBox_Nombre.Text = "";
                TextBox_Direccion.Text = "";
                TextBox_Telefono.Text = "";
                TextBox_Email.Text = "";
                Label_Mensaje.Text = "";


                Label_Cliente.Text = "";
                Label_Proveedor.Text = "";
                Label_Direccion.Text = "";
                Label_Telefono.Text = "";
                Label_Email.Text = "";

                Label_Proveedor.ForeColor = Color.Black;
                Label_Proveedor.Text = "Proveedor";
                Label_Direccion.ForeColor = Color.Black;
                Label_Direccion.Text = "Direccion";
                Label_Telefono.ForeColor = Color.Black;
                Label_Telefono.Text = "Telefono";
                Label_Email.ForeColor = Color.Black;
                Label_Email.Text = "Email";

            }



        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.Columns[1].Visible = false;
            TextBox_Id.Text = Page.Server.HtmlDecode(GridView1.SelectedRow.Cells[2].Text);
            TextBox_Nombre.Text = Page.Server.HtmlDecode(GridView1.SelectedRow.Cells[3].Text);
            TextBox_Direccion.Text = Page.Server.HtmlDecode(GridView1.SelectedRow.Cells[4].Text);
            TextBox_Telefono.Text = GridView1.SelectedRow.Cells[5].Text;
            TextBox_Email.Text = Page.Server.HtmlDecode(GridView1.SelectedRow.Cells[6].Text);
            TextBox_Fecha.Text = GridView1.SelectedRow.Cells[7].Text;

            Button_Guardar.Visible = false;
            Button_Actualizar.Visible = true;

            Label_Cliente.ForeColor = Color.Black;
            Label_Cliente.Text = "Cliente";
            Label_Proveedor.ForeColor = Color.Black;
            Label_Proveedor.Text = "Proveedor";
            Label_Direccion.ForeColor = Color.Black;
            Label_Direccion.Text = "Direccion";
            Label_Telefono.ForeColor = Color.Black;
            Label_Telefono.Text = "Telefono";
            Label_Email.ForeColor = Color.Black;
            Label_Email.Text = "Email";

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string nombre,tabla = "", id;
            if (RadioButton_Cliente.Checked)
            {
                tabla = "Clientes";
            }

            if (RadioButton_Proveedor.Checked)
            {
                tabla = "Proveedores";
            }

            id = GridView1.Rows[e.RowIndex].Cells[2].Text;
            nombre = GridView1.Rows[e.RowIndex].Cells[3].Text;

            if (texto.Text == "yes")
            {


                if (Connect1.Eliminar(tabla, "Id = '" + id + "'"))

                {
                    if (Connect2.Eliminar("Facturas", "CltProv ='" + nombre + "'"))
                    {
                        GridView1.DataSource = Connect1.Consultar2("*", tabla);
                        GridView1.DataBind();

                        texto.Text = "";
                    }
                }

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.PageIndex = e.NewPageIndex;


            if (RadioButton_Cliente.Checked)
            {

                GridView1.DataSource = Connect1.Consultar2("*", "Clientes");
                GridView1.DataBind(); 
            }
            if (RadioButton_Proveedor.Checked)
            {
                GridView1.DataSource = Connect2.Consultar2("*", "Proveedores");
                GridView1.DataBind();

            }
        }

        protected void TextBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            

            if (RadioButton_Cliente.Checked)
            {

                GridView1.DataSource = Connect1.Consultar4("*", "Clientes","Cliente", TextBox_Buscar.Text);
                GridView1.DataBind();
            }
            if (RadioButton_Proveedor.Checked)
            {
                GridView1.DataSource = Connect2.Consultar4("*", "Proveedores", "Proveedor", TextBox_Buscar.Text); 
                GridView1.DataBind();

            }



        }

        protected void TextBox_Nombre_TextChanged(object sender, EventArgs e)
        {
            if (RadioButton_Cliente.Checked)
            {
                Label_Cliente.Text = "";
                Label_Direccion.Text = "";
                Label_Telefono.Text = "";
                Label_Email.Text = "";
                Label_Cliente.Visible = true;
                Label_Proveedor.Visible = false;
                Label_Cliente.Text = "Cliente";
                Label_Direccion.Text = "Direccion";
                Label_Telefono.Text = "Telefono";
                Label_Email.Text = "Email";

                if (TextBox_Nombre.Text == "")
                {
                    Label_Cliente.ForeColor = Color.Black;
                }
                else
                {
                    Label_Cliente.ForeColor = Color.Black;

                    if (TextBox_Direccion.Text == "")
                    {
                        Label_Direccion.ForeColor = Color.Black;

                    }
                    else
                    {
                        Label_Direccion.ForeColor = Color.Green;

                        if (TextBox_Telefono.Text == "")
                        {
                            Label_Telefono.ForeColor = Color.Black;

                        }
                        else
                        {
                            Label_Telefono.ForeColor = Color.Green;

                            if (TextBox_Email.Text == "")
                            {
                                Label_Email.ForeColor = Color.Black;

                            }
                            else
                            {
                                Label_Email.ForeColor = Color.Green;

                            }
                        }
                    }
                }
            }


            if (RadioButton_Proveedor.Checked)
            {
                Label_Proveedor.Text = "";
                Label_Direccion.Text = "";
                Label_Telefono.Text = "";
                Label_Email.Text = "";
                Label_Cliente.Visible = false;
                Label_Proveedor.Visible = true;
                Label_Proveedor.Text = "Proveedor";
                Label_Direccion.Text = "Direccion";
                Label_Telefono.Text = "Telefono";
                Label_Email.Text = "Email";

                if (TextBox_Nombre.Text == "")
                {
                    Label_Proveedor.ForeColor = Color.Black;
                }
                else
                {
                    Label_Proveedor.ForeColor = Color.Green;

                    if (TextBox_Direccion.Text == "")
                    {
                        Label_Direccion.ForeColor = Color.Black;

                    }
                    else
                    {
                        Label_Direccion.ForeColor = Color.Green;

                        if (TextBox_Telefono.Text == "")
                        {
                            Label_Telefono.ForeColor = Color.Black;

                        }
                        else
                        {
                            Label_Telefono.ForeColor = Color.Green;

                            if (TextBox_Email.Text == "")
                            {
                                Label_Email.ForeColor = Color.Black;

                            }
                            else
                            {
                                Label_Email.ForeColor = Color.Green;

                            }
                        }
                    }
                }
            }
        }


        protected void TextBox_Direccion_TextChanged(object sender, EventArgs e)
        {
            Label_Cliente.Text = "";
            Label_Proveedor.Text = "";
            Label_Direccion.Text = "";
            Label_Telefono.Text = "";
            Label_Email.Text = "";
            Label_Cliente.Text = "Cliente";
            Label_Proveedor.Text = "Proveedor";
            Label_Direccion.Text = "Direccion";
            Label_Telefono.Text = "Telefono";
            Label_Email.Text = "Email";

            if (TextBox_Nombre.Text == "")
            {
                Label_Cliente.ForeColor = Color.Black;
                Label_Proveedor.ForeColor = Color.Black;
            }
            else
            {
                Label_Cliente.ForeColor = Color.Green;
                Label_Proveedor.ForeColor = Color.Green;

                if (TextBox_Direccion.Text == "")
                {
                    Label_Direccion.ForeColor = Color.Black;

                }
                else
                {
                    Label_Direccion.ForeColor = Color.Green;

                    if (TextBox_Telefono.Text == "")
                    {
                        Label_Telefono.ForeColor = Color.Black;

                    }
                    else
                    {
                        Label_Telefono.ForeColor = Color.Green;

                        if (TextBox_Email.Text == "")
                        {
                            Label_Email.ForeColor = Color.Black;

                        }
                        else
                        {
                            Label_Email.ForeColor = Color.Green;

                        }
                    }
                }
            }
        }




        protected void TextBox_Telefono_TextChanged(object sender, EventArgs e)
        {
            Label_Cliente.Text = "";
            Label_Proveedor.Text = "";
            Label_Direccion.Text = "";
            Label_Telefono.Text = "";
            Label_Email.Text = "";
            Label_Cliente.Text = "Cliente";
            Label_Proveedor.Text = "Proveedor";
            Label_Direccion.Text = "Direccion";
            Label_Telefono.Text = "Telefono";
            Label_Email.Text = "Email";

            if (TextBox_Nombre.Text == "")
            {
                Label_Cliente.ForeColor = Color.Black;
                Label_Proveedor.ForeColor = Color.Black;
            }
            else
            {
                Label_Cliente.ForeColor = Color.Green;
                Label_Proveedor.ForeColor = Color.Green;

                if (TextBox_Direccion.Text == "")
                {
                    Label_Direccion.ForeColor = Color.Black;

                }
                else
                {
                    Label_Direccion.ForeColor = Color.Green;

                    if (TextBox_Telefono.Text == "")
                    {
                        Label_Telefono.ForeColor = Color.Black;

                    }
                    else
                    {
                        Label_Telefono.ForeColor = Color.Green;

                        if (TextBox_Email.Text == "")
                        {
                            Label_Email.ForeColor = Color.Black;

                        }
                        else
                        {
                            Label_Email.ForeColor = Color.Green;

                        }
                    }
                }
            }
        }


        protected void TextBox_Email_TextChanged(object sender, EventArgs e)
        {
            Label_Cliente.Text = "";
            Label_Proveedor.Text = "";
            Label_Direccion.Text = "";
            Label_Telefono.Text = "";
            Label_Email.Text = "";
            Label_Cliente.Text = "Cliente";
            Label_Proveedor.Text = "Proveedor";
            Label_Direccion.Text = "Direccion";
            Label_Telefono.Text = "Telefono";
            Label_Email.Text = "Email";


            if (TextBox_Nombre.Text == "")
            {
                Label_Cliente.ForeColor = Color.Black;
                Label_Proveedor.ForeColor = Color.Black;
            }
            else
            {
                Label_Cliente.ForeColor = Color.Green;
                Label_Proveedor.ForeColor = Color.Green;

                if (TextBox_Direccion.Text == "")
                {
                    Label_Direccion.ForeColor = Color.Black;

                }
                else
                {
                    Label_Direccion.ForeColor = Color.Green;

                    if (TextBox_Telefono.Text == "")
                    {
                        Label_Telefono.ForeColor = Color.Black;

                    }
                    else
                    {
                        Label_Telefono.ForeColor = Color.Green;

                        if (TextBox_Email.Text == "")
                        {
                            Label_Email.ForeColor = Color.Black;

                        }
                        else
                        {
                            Label_Email.ForeColor = Color.Green;

                        }
                    }
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                ImageButton Lb = (ImageButton)e.Row.Cells[1].Controls[0];
                Lb.Attributes.Add("onclick", "javascript:confirmDelete(); ");

            }
        }
    }
}
