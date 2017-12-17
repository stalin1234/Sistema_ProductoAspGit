<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CategoriasProductos.aspx.cs" Inherits="Sistema_Producto.Vistas.CategoriasProductos" %>
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

                    <asp:PlaceHolder ID="PlaceHolder_Producto" runat="server">
                        <asp:TextBox ID="texto" runat="server" Visible="false" value=""></asp:TextBox>
                        <asp:TextBox ID="TextBox_IdProducto" runat="server" Visible="false"></asp:TextBox>
                        <asp:Label ID="Label_Igresar" runat="server" Text="Ingresar producto" Font-Bold="true"></asp:Label>
                        <br />
                        <br />

                        <asp:Label ID="Label1" runat="server" Text="Codigo"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_Codigo" runat="server" CssClass="CampoTexto" onkeypress="return soloNumeros(event);"></asp:TextBox>
                        <br />
                  
                        <asp:Label ID="Label2" runat="server" Text="Producto"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_Producto" runat="server" CssClass="CampoTexto" onkeypress="return soloLetras(event);"></asp:TextBox>
                        <br />
                        
                        <asp:Label ID="Label3" runat="server" Text="Precio"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_Precio" runat="server" CssClass="CampoTexto" onkeypress="return soloNumDecimal(event);"></asp:TextBox>
                        <br />

                        <asp:Label ID="Label_Categoria" runat="server" Text="Categoria"></asp:Label>
                        <br />
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="CampoTexto" Height="27px">


                        </asp:DropDownList>
                        <br />
           
                       
                        <br />

                    </asp:PlaceHolder>

                    <asp:PlaceHolder ID="PlaceHolder_Categoria" runat="server">

                        <asp:TextBox ID="TextBox_IdCategoria" runat="server" Visible="false"></asp:TextBox>
                        <asp:Label ID="Label_Venta" runat="server" Text="Ingresar caategoria" Font-Bold="true"></asp:Label>
                    
                        <br />
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Categoria"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_Categoria" runat="server" CssClass="CampoTexto" onkeypress="return soloLetras(event);"></asp:TextBox>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br /> 
                        <br />
                        <br />
                        <br />
                        <br /> 
                        <br /> 

                    </asp:PlaceHolder>

                    <asp:Button ID="Button_Guardar" runat="server" Text="Guardar" BorderStyle="None" CssClass="Button" OnClick="Button_Guardar_Click"/>
                    <asp:Button ID="Button_Actualizar" runat="server" Text="Actualizar" BorderStyle="None" CssClass="Button" OnClick="Button_Actualizar_Click"/>

                    <asp:Button ID="Button_Cancelar" runat="server" Text="Cancelar" BorderStyle="None" CssClass="Button" OnClick="Button_Cancelar_Click"/>
                    <br />
                    <br />

                </div>

                <div class="Formularios">

                    <!--<br />-->
                  <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BackColor="White" BorderColor="Lime" BorderStyle="Solid" BorderWidth="2px" CellPadding="4"  PageSize="6" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound">
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
                    <asp:RadioButton ID="RadioButton_Producto" runat="server" Checked="True" GroupName="Tipo" Text="Producto" />
                    <asp:RadioButton ID="RadioButton_Categoria" runat="server" GroupName="Tipo" Text="Categoria" />
                    <asp:Button ID="Button_Tipo" runat="server" BorderStyle="None" CssClass="Button" Text="Tipo" OnClick="Button_Tipo_Click" />
                    <asp:Label ID="Label_Mensaje" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </div>
            </form>

        </section>

    </section>


</asp:Content>
