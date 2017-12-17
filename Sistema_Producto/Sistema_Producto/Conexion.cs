using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace Sistema_Producto
{
    public class Conexion
    {

        public SqlConnection con;
        public DataSet ds = new DataSet();
        public SqlDataAdapter da;
        public SqlCommand comando;
        public DataTable dt;


        public void Conectar()
        {

            String cadena = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            con = new SqlConnection(cadena);

        }

        public Conexion()
        {

            Conectar();
        }

//        public bool Consultar1(String sql)

        public bool Consultar1(String tabla,string campo1,string campo2,string campo3,string campo4)
        {

            string sql = "SELECT * FROM " + tabla + " WHERE " + campo1 + "='" + campo2 + "'AND " + campo3 + "='" + campo4 + "'";
            con.Open();
            da = new SqlDataAdapter(sql, con);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if(dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {

                return false;
            }

        }

  
        public DataTable Consultar2(string campos,string  tabla)
        {
            string sql = "SELECT " + campos + " FROM " + tabla;
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();
            da.Fill(ds, tabla);
            con.Close();
            dt = new DataTable();
            dt = ds.Tables[tabla];
            return dt;

        }
        
        public bool Insertar(string sql)
        {
            con.Open();
            comando = new SqlCommand(sql, con);
            int i = comando.ExecuteNonQuery();
            con.Close();

            if(i > 0)
            {
                return true;
            }else
            {
                return false;
            }


        }


        public bool Consultar3(string campo1, string tabla, string campo2,string campo3)
        {

            string sql = "SELECT " + campo1 + " FROM " + tabla + " WHERE "  + campo2 + "='" + campo3 + "'";
            con.Open();

            da = new SqlDataAdapter(sql, con);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if(dt.Rows.Count > 0)
            {
                return true;
            }else
            {
                return false;
            }
       
        }


        
        public bool Actualizar(string tabla, string campos, string condicion)
        {

            string sql = "UPDATE " + tabla + " SET " + campos + " WHERE " + condicion;
             con.Open();

            comando = new SqlCommand(sql, con);
            int i = comando.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public bool Eliminar(string tabla, string condicion)
        {

            string sql = " DELETE FROM " + tabla + " WHERE " + condicion;
            con.Open();

            comando = new SqlCommand(sql, con);
            int i = comando.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public DataTable Consultar4(string campo1,string tabla, string campo2, string campo3)
        {

            string sql = "SELECT " + campo1 + " FROM " + tabla + " WHERE " + campo2 + " LIKE '%" + campo3 + "%'";
         //   con.Open();
            da = new SqlDataAdapter(sql, con);
           // ds = new DataSet();
            da.Fill(ds, tabla);
            con.Close();

            dt = new DataTable();
            dt = ds.Tables[tabla];
//            con.Close();


            return dt;

        }


        public DataTable Consultar5(string campo1, string tabla1, string tabla2,string condicion)
        {
            string sql = " SELECT " + campo1 + " FROM " + tabla1 + " Inner Join " + tabla2 + " ON " + condicion;
            con.Open();

            da = new SqlDataAdapter(sql, con);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();

            return dt;

        }


        public DataTable Consultar6(string campo1, string tabla1, string tabla2, string condicion, string campo2, string campo3)
        {
            string sql = " SELECT " + campo1 + " FROM " + tabla1 + " Inner Join " + tabla2 + " ON " + 
                condicion + " WHERE " + campo2 + " LIKE '%" + campo3 + "%'";
            con.Open();

            da = new SqlDataAdapter(sql, con);
            dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;

        }


        public DataTable Consultar7(string campo1, string tabla, string campo2, string campo3, string campo4, string campo5)
        {
            string sql = " SELECT " + campo1 + " FROM " + tabla + " WHERE " + campo2 + " = '" + campo3 + "' AND " + campo4 + " = '" + campo5 + "'";
            con.Open();

            da = new SqlDataAdapter(sql, con);
            dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;

        }


        public DataTable Consultar8(string campo1, string tabla, string campo2, string campo3, string campo4, string campo5)
        {
            string sql = " SELECT " + campo1 + " FROM " + tabla + " WHERE " + campo2 + " = '" + campo3 + "' AND " + campo4 + " LIKE '%" + campo5 + "%'";
            con.Open();

            da = new SqlDataAdapter(sql, con);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }


        public DataTable Consultar9(string campo1, string tabla, string campo2, string campo3)
        {

            string sql = "SELECT " + campo1 + " FROM " + tabla + " WHERE " + campo2 + "='" + campo3 + "'";

            con.Open();

            da = new SqlDataAdapter(sql, con);
            dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;
        }


        public DataTable Consultar10(string campo1, string tabla, string campo2, string campo3, string campo4, string
            campo5, string campo6, string campo7)
        {

            string sql = "SELECT " + campo1 + " FROM " + tabla + " WHERE " + campo2 + "='" + campo3 + 
                "' AND " + campo4 + "='" + campo5 + "' AND " + campo6 + " LIKE '%" + campo7 + "%'";



            con.Open();

            da = new SqlDataAdapter(sql, con);
            dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;
        }



    }
}