<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Sistema_Producto.Vistas.Reportes" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
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
                    <li runat="server" id="Reporte"><a href="Reportes.aspx" id="enlaces">Repportes/a></li>
                    <li><a href="Bodega.aspx" id="enlaces">Bodega/productos</a></li>
                    <li><a href="ClienteProveedor.aspx" id="enlaces">Cliente/Proveedor</a></li>

                </ul>
            </nav>

        </section>

        <section id="Contenido">

            <form id="form1" runat="server">

                <div class="Formularios">

                     <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BackColor="White" BorderColor="Lime" BorderStyle="Solid" BorderWidth="2px" CellPadding="4"  PageSize="8" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                       <AlternatingRowStyle BackColor="White" ForeColor="#ff0066" />

                        <Columns>
                            <asp:CommandField ButtonType="Image" HeaderText="Select" SelectImageUrl="~/Images/Sign_up_Icon_256.png" ShowSelectButton="True" />
                
                            
                       </Columns>
               
                        <EditRowStyle BackColor="#33cc33" />
                        <FooterStyle BackColor="#FFFFCC" Font-Bold="True" ForeColor="#330099" />
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

                     <br />
                    <asp:Image ID="Image1" runat="server" Height="34px" ImageUrl="~/Images/Vista_Elements_Icons.png" Width="39px" />
                    <asp:TextBox ID="TextBox_Buscar" runat="server" AutoCompleteType="Search" AutoPostBack="true" CssClass="CampoTexto" Width="101px" OnTextChanged="TextBox_Buscar_TextChanged"></asp:TextBox>
                    <asp:RadioButton ID="RadioButton_Compras" runat="server" AutoPostBack="True" Checked="True" GroupName="Tipo" Text="Compras" />
                     <asp:RadioButton ID="RadioButton_Ventas" runat="server" AutoPostBack="True" GroupName="Tipo" Text="Ventas" />

                    </div>

                
                <div class="Formularios">
                   
                    <asp:Chart ID="Chart1" runat="server"  Width ="500px" Height="350px">
                        <Series>
                            <asp:Series Name="Series1"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <Area3DStyle Enable3D="True" />
                                <AxisX Title ="Cantidad de Productos" />
                                <AxisY Title ="Porcentaje" />


                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>

                
                </div>


                <div class="Formularios" id="Imprimir">


                    <center>

                        <h2>Reportes del producto</h2>

                        <a href =" "javascript:;" onclick="PrintThisDiv('Imprimir')">Factura</a>
                    </center>

                    <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>


                </div>
                                
            </form>
            
        </section>




</asp:Content>

