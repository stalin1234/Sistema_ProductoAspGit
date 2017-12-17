<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ClienteProveedor.aspx.cs" Inherits="Sistema_Producto.Vistas.ClienteProveedor" %>
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
            
            <form id="form1" runat="server">
                <div class="Formularios">

                        <h4> Cliente/Proveedor</h4>
                        
                         <asp:TextBox ID="TextBox_Id" runat="server" Visible="false"></asp:TextBox>
                       

                        <asp:Label ID="Label_Cliente" runat="server" Text="Cliente"></asp:Label>
                        <asp:Label ID="Label_Proveedor" runat="server" Text="Proveedor"></asp:Label>
             
                        <br />
             
                        <br />
                        
                        <asp:TextBox ID="TextBox_Nombre" AutoPostBack=" true" runat="server" CssClass="CampoTexto" onkeypress="return soloLetras(event);" OnTextChanged="TextBox_Nombre_TextChanged"></asp:TextBox>
                        <br />
                  
                        <asp:Label ID="Label_Direccion" runat="server" Text="Direccion"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_Direccion" AutoPostBack="true" runat="server" CssClass="CampoTexto" onkeypress="return soloLetras(event);" OnTextChanged="TextBox_Direccion_TextChanged"></asp:TextBox>
                        <br />
                        
                        <asp:Label ID="Label_Telefono" runat="server" Text="Telefono"></asp:Label>
                        <br />
                        <br />
                        <asp:TextBox ID="TextBox_Telefono" AutoPostBack="true" runat="server" CssClass="CampoTexto" onkeypress="return soloNumeros(event);" OnTextChanged="TextBox_Telefono_TextChanged"></asp:TextBox>
                        <br />

                        <asp:Label ID="Label_Email" runat="server" Text="Email"></asp:Label>
                        <br />
                        <br />
                        <asp:TextBox ID="TextBox_Email" AutoPostBack="true" runat="server" CssClass="CampoTexto" OnTextChanged="TextBox_Email_TextChanged" ></asp:TextBox>
                        <br /> 
                        
                        <asp:Label ID="Label1" runat="server" Text="Fecha"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_Fecha" runat="server" CssClass="CampoTexto" ReadOnly="true" ></asp:TextBox>
                        <br />                  
                        <asp:TextBox ID="texto" runat="server" Visible="true" value=""></asp:TextBox>
                        <br />
                        <br />

                   

                    

                    <asp:Button ID="Button_Guardar" runat="server" Text="Guardar" BorderStyle="None" CssClass="Button" OnClick="Button_Guardar_Click"/>
                    <asp:Button ID="Button_Actualizar" runat="server" Text="Actualizar" BorderStyle="None" CssClass="Button" OnClick="Button_Actualizar_Click"/>

                    <asp:Button ID="Button_Cancelar" runat="server" Text="Cancelar" BorderStyle="None" CssClass="Button" OnClick="Button_Cancelar_Click"/>
                    <br />
                    <br />

                </div>

                <div class="Formularios">

                    <!--<br />-->
                  <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BackColor="White" BorderColor="Lime" BorderStyle="Solid" BorderWidth="2px" CellPadding="4"  PageSize="8" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound">
                       <AlternatingRowStyle BackColor="White" ForeColor="#ff0066" />

                        <Columns>
                            <asp:CommandField ButtonType="Image" HeaderText="Editar" SelectImageUrl="~/Images/Sign_up_Icon_256.png" ShowSelectButton="True" />
                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Eliminar_Icon.png" HeaderText="Eliminar" ShowDeleteButton="True" />
                        </Columns>
               
                        <EditRowStyle BackColor="#33cc33" />
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView>
                   
                    
                    <asp:Image ID="Image1" runat="server" Height="34px" ImageUrl="~/Images/Vista_Elements_Icons.png" Width="39px"/>
                    <asp:TextBox ID="TextBox_Buscar" runat="server" AutoCompleteType="Search" AutoPostBack="True" CssClass="CampoTexto" Width="101px" OnTextChanged="TextBox_Buscar_TextChanged"></asp:TextBox>
    
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                    <asp:RadioButton ID="RadioButton_Cliente" runat="server" Checked="True" GroupName="Tipo" Text="Cliente" />
                    <asp:RadioButton ID="RadioButton_Proveedor" runat="server" GroupName="Tipo" Text="Proveedor" />
                    <asp:Button ID="Button_Tipo" runat="server" BorderStyle="None" CssClass="Button" Text="Tipo" OnClick="Button_Tipo_Click" />
                    </asp:PlaceHolder>
                    
                    <asp:Label ID="Label_Mensaje" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </div>
            </form>

        </section>

    </section>


</asp:Content>
