<%@ Page Title="" Language="C#" MasterPageFile="~/App/Layout.Master" AutoEventWireup="true" CodeBehind="ListarEmpleados.aspx.cs" Inherits="AppEmpleadosCloud.App.ListarEmpleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h1 class="textoH1">crud basico a una tabla html  </h1>
    <main class="estiloMain">
        <div class="contendeorApp">
            <div class="menuApp">
                <div class="contenedorBtnApp">
                    <div class="contenedorBtnApp">
                        <div>
                            <asp:Button ID="btnListartodo" runat="server" OnClick="btnListartodo_Click" Text="Listar Empleados" class="btnApp" Visible="False" />
                        </div>

                        <div>
                            <div class="contenedorText">
                                <asp:TextBox ID="InCodigoBuscar" runat="server"></asp:TextBox></div>
                        </div>

                        <div>
                            <asp:Button ID="btnBuscarCodigo" runat="server" Text="Buscar Empleados" class="btnApp" OnClick="btnBuscarCodigo_Click" />
                        </div>

                        <div>
                            <asp:Label ID="LabelBuscar" runat="server" Font-Bold="True"></asp:Label>
                        </div>

                    </div>

                </div>
            </div>
            <div class="contenedorDatos">

                <div class="contenedorGrid">
                    <asp:GridView CssClass="formatoGrid" ID="gvEmpleados" runat="server" AllowPaging="True" DataKeyNames="Codigo" OnPageIndexChanging="gvEmpleados_PageIndexChanging" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnRowCommand="gvEmpleados_RowCommand">
                        <Columns>
                            <asp:ButtonField CommandName="Select" Text="Seleccionar" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>

                </div>


            </div>
        </div>
    </main>
</asp:Content>
