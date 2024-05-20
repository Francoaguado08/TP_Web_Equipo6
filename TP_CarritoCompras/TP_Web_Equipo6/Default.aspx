<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Web_Equipo6._Default" %>


        <%--PRESENTACION!--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="text-center mb-4">
            <h1 class="display-4">BIENVENIDOS A DIGITAL PLANET</h1>
            <h2 class="display-5">STOCK DISPONIBLE</h2>
        </div>


         <%--FILTRO NUMERO (1)--%>
        <div class="bg-dark text-white p-3 mb-4 d-flex justify-content-center align-items-center">
            <asp:Label ID="lblFiltrarPor" runat="server" Text="Filtrar por:" CssClass="me-3" />
                 <asp:DropDownList ID="ddlFiltrarPor" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="ddlFiltrarPor_SelectedIndexChanged" CssClass ="form-select me-3"></asp:DropDownList>



            <%--FILTRO NUMERO (2)--%>
            <asp:Label ID="lblCriterio" runat="server" Text="Criterio:" CssClass="me-3" />
            <asp:DropDownList ID="ddlCriterio" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCriterio_SelectedIndexChanged" CssClass="form-select me-3" />
            

            <%--BOTON PARA APLICAR filtro y limpiar filtro--%>
            <asp:Button ID="btnAplicarFiltro" runat="server" Text="Aplicar filtro" CssClass="btn btn-primary me-3" Onclick="btnAplicarFiltro_Click" />
            <asp:Button ID="btnLimpiarFiltro" runat="server" Text="Limpiar filtros" CssClass="btn btn-secondary me-3" Onclick="btnLimpiarFiltro_Click" />
            
            <%--BOTON PARA BUSCAR AL HACER CLICK.--%>
             <div class="input-group ms-3">
                <asp:TextBox ID="tbxBuscar" CssClass="form-control" runat="server" />
                <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn btn-secondary" Onclick="btnBuscar_Click" runat="server" />
             </div>
            

                
        </div>


         <%--MOSTRAR IMAGEN EN CARTA CON CIERTA PROPIEDAD--%>
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <% foreach (Dominio.Articulo arti in listaArticulo) { %>
            <div class="col">
                <div class="card h-100">
                    <%
                        string defaultUrl = "https://nayemdevs.com/wp-content/uploads/2020/03/default-product-image.png";
                        string imagenIndex = defaultUrl;

                        if (arti.UrlImagenes != null && arti.UrlImagenes.Any())
                        {
                            imagenIndex = arti.UrlImagenes[0];
                        }
                    %>
                    <img src="<%= imagenIndex %>" class="card-img-top" alt="Imagen del Articulo <%= arti.Nombre %>" onerror="this.src='<%= defaultUrl %>'">
                    <div class="card-body">
                        <h5 class="card-title"><%= arti.Nombre %></h5>
                        <p class="card-text"><%= arti.Descripcion %></p>
                        <p class="card-text"><strong>ARS <%= arti.Precio %></strong></p>
                        <a href="DetalleArticulo.aspx?id=<%= arti.ID %>" class="btn btn-primary">Ver más</a>
                    </div>
                </div>
            </div>
            <% } %>
        </div>
    </div>
</asp:Content>








