<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Bodega.aspx.cs" Inherits="Sistema_Producto.Vistas.Bodega" %>
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

                        <h4> Bodega</h4>
                        
                        <asp:TextBox ID="TextBox_Codigo" Visible="false" runat="server" ReadOnly="true" CssClass="CampoTexto" ></asp:TextBox>
             
                                                             
                        <asp:Label ID="Label_Producto" runat="server" Text="Producto"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_Producto" runat="server" ReadOnly ="true" CssClass="CampoTexto" ></asp:TextBox>
                        <br />
                        
                        <asp:Label ID="Label_Precio" runat="server" Text="Precio"></asp:Label>
                        <br />
                        <br />
                        <asp:TextBox ID="TextBox_Precio"  runat="server" CssClass="CampoTexto" ReadOnly="true" ></asp:TextBox>
                        <br />

                        <asp:Label ID="Label_Actual" runat="server" Text="Actual"></asp:Label>
                        <br />
                        <br />
                        <asp:TextBox ID="TextBox_Actual" AutoPostBack="true" runat="server" CssClass="CampoTexto" onkeypress="return soloNumeros(event);" OnTextChanged="TextBox_Actual_TextChanged"></asp:TextBox>
                        <br />
                        
                        <asp:Label ID="Label_Importe" runat="server" Text="Importe"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_Importe" runat="server" CssClass="CampoTexto" ReadOnly="true" ></asp:TextBox>
                       
                        <br />
                        <br />
                        <br />                      
                        <br />                
                        <br />
                        <br />
                        <br />


                    <asp:Button ID="Button_Guardar" runat="server" Text="Guardar" BorderStyle="None" CssClass="Button" OnClick="Button_Guardar_Click"/>

                    <asp:Button ID="Button_Cancelar" runat="server" Text="Cancelar" BorderStyle="None" CssClass="Button" OnClick="Button_Cancelar_Click"/>
                    <br />
                    <br />

                </div>

                 <div class="Formularios">

                    <!--<br />-->
                  <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BackColor="White" BorderColor="Lime" BorderStyle="Solid" BorderWidth="2px" CellPadding="4"  PageSize="8" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                       <AlternatingRowStyle BackColor="White" ForeColor="#ff0066" />

                        <Columns>
                            <asp:CommandField ButtonType="Image" HeaderText="Select" SelectImageUrl="~/Images/Sign_up_Icon_256.png" ShowSelectButton="True" />
                        
                        
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
                   
                     <asp:Label ID="Label1_Mensaje" runat="server" ForeColor="Red"></asp:Label>
                   
                </div>



            </form>

        </section>

    </section>


</asp:Content>
