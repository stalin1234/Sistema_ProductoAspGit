﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Producto.Vistas
{
    public partial class CerrarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["usuario"] = " ";
            Response.Redirect("Login.aspx");
        }
    }
}