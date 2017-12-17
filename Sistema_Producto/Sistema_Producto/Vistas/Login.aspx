<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sistema_Producto.Vistas.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">

    <div class="content">

        <asp:Image ID="imgLogin" runat="server" ImageUrl="~/Images/banner-inventario2.png"  AlternateText="imagen no disponible " ImageAlign="TextTop"/>
        
        <form id="form1" runat="server">
            <div id="form">
                <h3>Iniciar session</h3>
               
                 <p><asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label></p>
                 <asp:TextBox ID="TextBox_User" runat="server" CssClass="CampoTexto"></asp:TextBox>
                
                 <p><asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label></p>
                 <asp:TextBox ID="TextBox_Password" runat="server" CssClass="CampoTexto" TextMode="Password"></asp:TextBox>
                
                <br />
                <br />

                <asp:Button ID="Button_Entrar" runat="server" Text="Entrar" BorderStyle="None" CssClass="Button" OnClick="Button_Entrar_Click"/>
               <p><asp:Label ID="Label_Mensaje" runat="server" Font-Bold="true" ForeColor="#ff0066"></asp:Label></p>
            </div>
        </form>

    </div>


</asp:Content>
