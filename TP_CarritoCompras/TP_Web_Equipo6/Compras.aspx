<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="TP_Web_Equipo6.Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



 <br />
    <div>
        <h1 class ="bottom-100">Compras</h1>
    </div>
    <br />
    <h2>Detalle de compra</h2>
    <h6>Puede modificar la cantidad de compra en determinado Articulo!</h6>
    <br />
    <asp:GridView ID="dgvCompras" CssClass="table" runat="server" AutoGenerateColumns="False" OnRowEditing="dgvCompras_RowEditing" OnRowUpdating="dgvCompras_RowUpdating" OnRowCancelingEdit="dgvCompras_RowCancelingEdit" DataKeyNames="ID">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" ReadOnly="True" />
            <asp:BoundField DataField="Codigo" HeaderText="Código" ReadOnly="True" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" ReadOnly="True" />
            <asp:TemplateField HeaderText="Cantidad">
                <EditItemTemplate>
                    <asp:TextBox ID="txtCantidad" runat="server" Text='<%# Bind("Cantidad") %>' />
                    <asp:RangeValidator ID="rvCantidad" runat="server" ControlToValidate="txtCantidad"
                        MinimumValue="1" MaximumValue="10" Type="Integer" ErrorMessage="Cantidad Minima por factura de compra entre 1 y 10" Display="Dynamic" ForeColor="Red" />
                    <asp:RegularExpressionValidator ID="revCantidad" runat="server" ControlToValidate="txtCantidad"
                        ValidationExpression="^\d+$" ErrorMessage="Solo se permiten números" Display="Dynamic" ForeColor="Red" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("Cantidad") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                    <%# (Convert.ToDecimal(Eval("Precio")) * Convert.ToInt32(Eval("Cantidad"))).ToString("C") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
        </Columns>
    </asp:GridView>

    <div>
        <asp:Label ID="lblTotalGeneral" runat="server" Text="Total: $0.00" CssClass="total-label" />
    </div>

    <br />
    <br />
    <div class="container">
        <div class="row">
            <div class="col">
                <a href="#" class="btn btn-primary float-end">Comprar</a>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="container">
        <div class="row">
            <div class="col">
                <a href="Default.aspx" class="btn btn-primary float-end">Volver</a>
            </div>
        </div>
    </div>
    





</asp:Content>
