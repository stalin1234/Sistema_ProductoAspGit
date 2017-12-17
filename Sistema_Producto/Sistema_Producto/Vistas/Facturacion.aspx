<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Facturacion.aspx.cs" Inherits="Sistema_Producto.Vistas.Facturacion" %>
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
                    <asp:TextBox ID="TextBox_Buscar1" runat="server" AutoCompleteType="Search" AutoPostBack="True" CssClass="CampoTexto" Width="101px" OnTextChanged="TextBox_Buscar1_TextChanged"></asp:TextBox>
                   
                    <asp:RadioButton ID="RadioButton_Cliente" runat="server" AutoPostBack="True" Checked="True" GroupName="Tipo" Text="Cliente" OnCheckedChanged="RadioButton_Cliente_CheckedChanged" />
                    <asp:RadioButton ID="RadioButton_Proveedor" runat="server" AutoPostBack="True" GroupName="Tipo" Text="Proveedor" OnCheckedChanged="RadioButton_Proveedor_CheckedChanged" />
                    <asp:Button ID="Button_Cancelar" runat="server" BorderStyle="None" CssClass="Button" Text="Cancelar" OnClick="Button_Cancelar_Click" />
                   
                </div>


                <!----------------------------------------------------------------------->

                <div class="Formularios" id="Imprimir">

                    
                    <table style="width: 30%;">
                        
                        <tr>
                            <td><a href="javascript:;" onclick="PrintThisDiv('Imprimir')">Factura</a></td>

                        </tr>
                                                                        
                        <tr>
                            <td><asp:Label ID="Label_CliProv" runat="server" Text="Cliente"></asp:Label>
                            </td>
                            <td>Fecha</td>
                            
                        </tr>
                        <tr>
                            <td><asp:TextBox ID="TextBox_CliProv" runat="server" CssClass="CampoTexto" ReadOnly="true" Width="112px"></asp:TextBox></td>
                            <td><asp:TextBox ID="TextBox_Fecha" runat="server" CssClass="CampoTexto" ReadOnly="true" Width="112px"></asp:TextBox></td>
                           
                        </tr>
                        
                    </table>   
                                                        

                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3"  PageSize="8" OnPageIndexChanging="GridView2_PageIndexChanging" GridLines="Vertical">
                       <AlternatingRowStyle BackColor="#DCDCDC" />

                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                    </asp:GridView>


                        <table style="width: 30%;">
                        <tr>
                            <td>N° Factura</td>
                            <td>Importe Total</td>
                            
                        </tr>
                        <tr>
                            <td><asp:TextBox ID="TextBox_Factura" runat="server" CssClass="CampoTexto" ReadOnly="true" Width="112px"></asp:TextBox></td>
                            <td><asp:TextBox ID="TextBox_Importe" runat="server" CssClass="CampoTexto" ReadOnly="true" Width="112px"></asp:TextBox></td>
                           
                        </tr>
                        
                    </table>   
                


                    <br />
                    <asp:Label ID="Label_Mensaje" runat="server"></asp:Label>
                


                </div>


                <div class="Formularios">

                    <!--<br />-->
                  <asp:GridView ID="GridView3" runat="server" AllowPaging="True" BackColor="White" BorderColor="Lime" BorderStyle="Solid" BorderWidth="2px" CellPadding="4"  PageSize="8" OnPageIndexChanging="GridView3_PageIndexChanging" OnSelectedIndexChanged="GridView3_SelectedIndexChanged">
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
                   
                    
                    <asp:Image ID="Image2" runat="server" Height="34px" ImageUrl="~/Images/Vista_Elements_Icons.png" Width="39px"/>
                    <asp:TextBox ID="TextBox_Buscar2" runat="server" AutoCompleteType="Search" AutoPostBack="True" CssClass="CampoTexto" Width="101px" OnTextChanged="TextBox_Buscar2_TextChanged"></asp:TextBox>
                    
                  
                </div>



                <!------------------------------------------------------------------------------------------->


                
                                               
            </form>

        </section>

    </section>







</asp:Content>



