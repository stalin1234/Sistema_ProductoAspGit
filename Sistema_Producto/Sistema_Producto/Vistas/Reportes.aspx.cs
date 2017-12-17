using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Sistema_Producto.Vistas
{
    public partial class Reportes : System.Web.UI.Page
    {

        Conexion Connect1 = new Conexion();
        Conexion Connect2 = new Conexion();
        Conexion Connect3 = new Conexion();
        Conexion Connect4 = new Conexion();
        Conexion Connect5 = new Conexion();


        string[] Meses = { "ene.", "feb.", "mar.", "abr.", "may.", "jun.", "jul.", "ago.", "sept.",
            "oct.","nov.","dic.", };


        public string fecha = System.DateTime.Now.ToString("dd/MMM/yyy");


        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (Session["usuario"] == " ")
            {

                Response.Redirect("Login.aspx");
            }

            /*if (Session["TipoUser"] == "Empl ")
            {

                RadioButton_Cliente.Visible = false;
                RadioButton_Proveedor.Visible = false;
            }*/
            

            string TipoUser = Convert.ToString(Session["TipoUser"]);

            if(TipoUser == "Empl")
            {

                Reporte.Visible = false;
            }



            if (IsPostBack == false)
            {

                    GridView1.DataSource = Connect1.Consultar2("Producto, Categoria", "Productos");
                    GridView1.DataBind();


                DataTable table = new DataTable();

                table.Columns.Add(new DataColumn("Mes", typeof(string)));
                table.Columns.Add(new DataColumn("Cant Cpra", typeof(string)));
                table.Columns.Add(new DataColumn("Impt Cpra", typeof(string)));
                table.Columns.Add(new DataColumn("Cant Vta", typeof(string)));
                table.Columns.Add(new DataColumn("Impt Vta", typeof(string)));
                table.Columns.Add(new DataColumn("Perdidas", typeof(string)));
                table.Columns.Add(new DataColumn("Ganacias", typeof(string)));

                for(int i = 0; i <= 11; i++)
                {

                    DataRow row = table.NewRow();

                    row[0] = Meses[i];
                    table.Rows.Add(row);

                    table.AcceptChanges();

                    GridView2.DataSource = table;
                    GridView2.DataBind();

                }




            }


        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = Connect1.Consultar2("Producto,Categoria", "Productos");
            GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable table = new DataTable();

            table.Columns.Add(new DataColumn("Mes", typeof(string)));
            table.Columns.Add(new DataColumn("Cant Cpra", typeof(string)));
            table.Columns.Add(new DataColumn("Impt Cpra", typeof(string)));
            table.Columns.Add(new DataColumn("Cant Vta", typeof(string)));
            table.Columns.Add(new DataColumn("Impt Vta", typeof(string)));
            table.Columns.Add(new DataColumn("Perdidas", typeof(string)));
            table.Columns.Add(new DataColumn("Ganacias", typeof(string)));


            string año = System.DateTime.Now.ToString("/yyy");

            string tabla, producto, fecha;
            producto = GridView1.SelectedRow.Cells[1].Text;
            tabla = "";
            int a , b,c, cantidad = 0, CpraCantidad, VtaCantidad;

            decimal importe1 = 0, ImporteTotal = 0, GananciaTotal= 0;
            decimal importe2 = 0, GananciaUnidad = 0, Ganancias= 0;
            decimal PrecioProducto = 0;


            a = 0;
            b = 0;
            c = 0;
            CpraCantidad = 0;
            VtaCantidad = 0;

            int[] cantidades1 = new int[100];
            int[] cantidades2 = new int[100];
            int[] cantidades3 = new int[100];

            decimal[] importes1 = new decimal[100];
            decimal[] importes2 = new decimal[100];


            if (RadioButton_Compras.Checked)
            {
                tabla = "Compras";
            }
            if (RadioButton_Ventas.Checked)
            {
                tabla = "Ventas";
            }

            for(int i = 0; i <= 11; i++)
            {
                fecha = Meses[i] + año;

                DataTable datos1;
                datos1 = Connect2.Consultar8("*", tabla, "Producto", producto, "Fecha", fecha);

                foreach(DataRow row1 in datos1.Rows)
                {

                    cantidades1[a] = Convert.ToInt16(row1[5]);
                    cantidad += cantidades1[a];
                    a = +1;
                }

                datos1.Clear();

                if( cantidad != 0)
                {
                    Chart1.Series[0].Points.Add(cantidad);
                }
                else
                {
                    Chart1.Series[0].Points.Add(0);
                }

                Chart1.ChartAreas[0].AxisX.Interval = 1;

                Chart1.ChartAreas[0].AxisX.Interval = Double.NaN;
                Chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;

                Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
                Chart1.Series[0].Points[i].AxisLabel = Meses[i];

                Chart1.Series[0].IsValueShownAsLabel = true;
                Chart1.Series[0].LabelForeColor = Color.Red;


                Chart1.Palette = ChartColorPalette.None;

                Chart1.Series[0].Palette = ChartColorPalette.Pastel;


                DataTable datos2;
                datos2 = Connect3.Consultar8("*","Compras", "Producto", producto, "Fecha", fecha);

                foreach(DataRow row2 in datos2.Rows)
                {
                    cantidades2[b] = Convert.ToInt16(row2[5]);
                    CpraCantidad = cantidades2[b];

                    importes1[b] = Convert.ToDecimal(row2[6]);

                    importe1 += importes1[b];


                    b = +1; 

                }

                datos2.Clear();


                DataTable datos3;
                datos3 = Connect3.Consultar8("*", "Ventas", "Producto", producto, "Fecha", fecha);

                foreach (DataRow row3 in datos3.Rows)
                {
                    cantidades3[c] = Convert.ToInt16(row3[5]);
                    VtaCantidad += cantidades3[c];

                    importes2[c] = Convert.ToDecimal(row3[6]);

                    importe2 += importes2[c];


                    c = +1;

                }

                
                datos3.Clear();            

                foreach(DataRow row1 in Connect5.Consultar4("*", "Productos", "Producto",
                    producto).Rows)
                {
                    PrecioProducto = Convert.ToDecimal(row1[3]);
                }

                if(CpraCantidad != 0 && VtaCantidad != 0)
                {



                    ImporteTotal = CpraCantidad * PrecioProducto;
                    GananciaTotal = ImporteTotal - importe1;
                    GananciaUnidad = GananciaTotal / CpraCantidad;
                }

                Ganancias = VtaCantidad * GananciaUnidad;



                DataRow row4 = table.NewRow();

                row4[0] = Meses[i];
                row4[1] = CpraCantidad;
                row4[2] = String.Format("{0: #,###,###,##0.00####}", importe1);
                row4[3] = VtaCantidad;
                row4[4] = String.Format("{0: #,###,###,##0.00####}", importe2);
                row4[6] = String.Format("{0: #,###,###,##0.00####}", Ganancias);

                table.Rows.Add(row4);

                table.AcceptChanges();

                GridView2.DataSource = table;
                GridView2.DataBind();



                cantidad = 0;
                importe1 = 0;
                importe2 = 0;
                CpraCantidad = 0;
                VtaCantidad = 0;
                a = 0;
                b = 0;
                c = 0;
            }

        }

        protected void TextBox_Buscar_TextChanged(object sender, EventArgs e)
        {
          
            GridView1.DataSource = Connect1.Consultar4("Producto,Categoria", "Productos","Producto",
            TextBox_Buscar.Text);
            GridView1.DataBind();

        }
    }
}