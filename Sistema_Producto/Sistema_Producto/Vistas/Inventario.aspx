<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="Sistema_Producto.Inventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">

    <section id="contenedor">
        <section id="ListaMenu">

           <nav id="menu">

                <ul>
                    <li><a href="Inventario.aspx" id="enlaces">Inventario</a></li>
                    <li runat="server" id="Producto"><a href="CategoriasProductos.aspx" id="enlaces">Categoria Producto</a></li>
                    <li><a href="CompraProductos.aspx" id="enlaces">Compra de Producto</a></li>
                  <!-- <li><a href="CompraRealizada.aspx" id="enlaces">Compras realizada</a></li>-->
                    <li><a href="VentaProducto.aspx" id="enlaces">Venta de Producto</a></li>
                    <li><a href="Facturacion.aspx" id="enlaces">Facturacion</a></li>
                    <li runat="server" id="Reportes"><a href="Reportes.aspx" id="enlaces">Repportes/a></li>
                    <li><a href="Bodega.aspx" id="enlaces">Bodega/productos</a></li>
                    <li><a href="ClienteProveedor.aspx" id="enlaces">Cliente/Proveedor</a></li>

                </ul>
            </nav>

        </section>
      
        <section id="Contenido">
            <center>
                 
                <asp:Image ID="img" runat="server" ImageUrl="~/Images/banner-inventario1.png" AlternateText="Imagen no disponible" ImageAlign="TextTop"></asp:Image>
            
            </center>
        </section>

    </section>

</asp:Content>
