<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VentaProducto.aspx.cs" Inherits="Sistema_Producto.Vistas.VentaProducto" %>
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

                        <h4> Venta de Productos</h4>
                        
                        <asp:TextBox ID="TextBox_Codigo" Visible="false" runat="server" ReadOnly="true" CssClass="CampoTexto" ></asp:TextBox>
             

                        <asp:Label ID="Label_Categoria" runat="server" Text="Categoria"></asp:Label>
                        
                        <br />
                        
                        <asp:TextBox ID="TextBox_Categoria" AutoPostBack=" true" runat="server" ReadOnly="true" CssClass="CampoTexto" ></asp:TextBox>
                        <br />
                  
                        <asp:Label ID="Label_Producto" runat="server" Text="Producto"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_Producto" AutoPostBack="true" runat="server" ReadOnly ="true" CssClass="CampoTexto" ></asp:TextBox>
                        <br />
                        
                        <asp:Label ID="Label_Precio" runat="server" Text="Precio"></asp:Label>
                        <br />
                        <br />
                        <asp:TextBox ID="TextBox_Precio" AutoPostBack="true" runat="server" CssClass="CampoTexto" ReadOnly="true" OnTextChanged="TextBox_Precio_TextChanged"></asp:TextBox>
                        <br />

                        <asp:Label ID="Label_Cantidad" runat="server" Text="Cantidad"></asp:Label>
                        <br />
                        <br />
                        <asp:TextBox ID="TextBox_Cantidad" AutoPostBack="true" runat="server" CssClass="CampoTexto" onkeypress="return soloNumeros(event);" OnTextChanged="TextBox_Cantidad_TextChanged"></asp:TextBox>
                        <br />
                        
                        <asp:Label ID="Label_Importe" runat="server" Text="Importe"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_Importe" runat="server" CssClass="CampoTexto" ReadOnly="true" OnTextChanged="TextBox_Importe_TextChanged" ></asp:TextBox>
                       
                        <br />
                                              
                        <asp:Label ID="Label_Fecha" runat="server" Text="Fecha"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_Fecha" runat="server" CssClass="CampoTexto" ReadOnly="true" ></asp:TextBox>
                       
                        <br />
                        <br />

                   

                    

                    <asp:Button ID="Button_Venta" runat="server" Text="Venta" BorderStyle="None" CssClass="Button" OnClick="Button_Venta_Click"/>

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
                    <asp:TextBox ID="TextBox_Buscar1" runat="server" AutoCompleteType="Search" AutoPostBack="True" CssClass="CampoTexto" Width="101px" OnTextChanged="TextBox_Buscar1_TextChanged"></asp:TextBox>
                   
                </div>


                <!----------------------------------------------------------------------->

                <div class="Formularios">

                        <h4> Clientes </h4>
                        
                        <asp:Label ID="Label_Cliente" runat="server" Text="Cliente"></asp:Label>
             
                        <br />
                        
                        <asp:TextBox ID="TextBox_Cliente" AutoPostBack=" true" runat="server" ReadOnly="true" CssClass="CampoTexto" ></asp:TextBox>
                        <br />
                  
                        <asp:Label ID="Label_Direccion" runat="server" Text="Direccion"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_Direccion" AutoPostBack="true" runat="server" ReadOnly ="true" CssClass="CampoTexto" ></asp:TextBox>
                        <br />
                        
                        <asp:Label ID="Label_Telefono" runat="server" Text="Telefono"></asp:Label>
                        <br />
                        <br />
                        <asp:TextBox ID="TextBox_Telefono" AutoPostBack="true" runat="server" ReadOnly="true" CssClass="CampoTexto" ></asp:TextBox>
                        <br />

                        <asp:Label ID="Label_Email" runat="server" Text="Email"></asp:Label>
                        <br />
                        <br />
                        <asp:TextBox ID="TextBox_Email" AutoPostBack="true" runat="server" ReadOnly="true" CssClass="CampoTexto" ></asp:TextBox>
                        <br /> 
                        
                        <asp:Label ID="Label_FechaProv" runat="server" Text="Fecha"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_ProvFecha" runat="server" CssClass="CampoTexto" ReadOnly="true" ></asp:TextBox>
                       
                        <br />
                        
                        <asp:Label ID="Label_Factura" runat="server" Text="Factura"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_Factura" runat="server" CssClass="CampoTexto" ReadOnly="true" ></asp:TextBox>
                       
                        <br />
                        <asp:Label ID="Label_Mensaje" runat="server" ForeColor="Red"></asp:Label>
                        <br />                                    

                </div>


                <div class="Formularios">

                    <!--<br />-->
                  <asp:GridView ID="GridView2" runat="server" AllowPaging="True" BackColor="White" BorderColor="Lime" BorderStyle="Solid" BorderWidth="2px" CellPadding="4"  PageSize="8" OnPageIndexChanging="GridView2_PageIndexChanging" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
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


                <div class="Formularios">

               
                  <asp:Label ID="Label2" runat="server" Text="Ventas realizadas" Font-Bold="true"></asp:Label>
                  <br />
                  <br />   
                  <asp:GridView ID="GridView3" runat="server" AllowPaging="True" BackColor="White" BorderColor="Lime" BorderStyle="Solid" BorderWidth="2px" CellPadding="4"  PageSize="8" OnPageIndexChanging="GridView3_PageIndexChanging">
                       <AlternatingRowStyle BackColor="White" ForeColor="#ff0066" />

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
                    <asp:Image ID="Image3" runat="server" Height="34px" ImageUrl="~/Images/Vista_Elements_Icons.png" Width="39px"/>
                    <asp:TextBox ID="TextBox_Buscar3" runat="server" AutoCompleteType="Search" AutoPostBack="true" CssClass="CampoTexto" Width="101px" OnTextChanged="TextBox_Buscar3_TextChanged"></asp:TextBox>
                   
                    
                </div>


                <div class="Formularios">


                  <asp:Label ID="Label1" runat="server" Text="Carrito de Ventas" Font-Bold="true"></asp:Label>
                  <br />
                  <br />
                  <asp:GridView ID="GridView4" runat="server" AllowPaging="True" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3"  PageSize="8" OnPageIndexChanging="GridView4_PageIndexChanging" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" GridLines="Vertical" OnRowDataBound="GridView4_RowDataBound" OnRowDeleting="GridView4_RowDeleting">
                       <AlternatingRowStyle BackColor="#DCDCDC" />

                        <Columns>
                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Eliminar_Icon.png" ShowDeleteButton="True" />
                       </Columns>
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
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Total importe a pagar"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox_ImporteTotal" runat="server"  CssClass="CampoTexto" Width="101px" ></asp:TextBox>
                    <asp:TextBox ID="texto" runat="server"  Visible="true" value="" ></asp:TextBox>
                    
                  
                </div>










            </form>

        </section>

    </section>





</asp:Content>
