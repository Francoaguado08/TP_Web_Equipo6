<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Web_Equipo6._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>BIENVENIDOS A DIGITAL PLANET</h1>




    <br />
    <div class="container text-center">
        <h1 class="display-3">STOCK DISPONIBLE</h1>
    </div>
    <br />




    <div class="row row-cols-1 row-cols-md-3 g-4">
    <% foreach (Dominio.Articulo arti in listaArticulo) { %>
    <div class="col">
        <div class="card">
            <% 
                string defaultUrl = "https://nayemdevs.com/wp-content/uploads/2020/03/default-product-image.png";
                string imagenIndex = defaultUrl; // Inicializar con la imagen predeterminada

                if (arti.UrlImagenes != null && arti.UrlImagenes.Any())
                {
                    imagenIndex = arti.UrlImagenes[0]; // Usar la primera imagen disponible
                }
            %>
            <img src="<%= imagenIndex %>" style="width: auto" class="card-img-top" alt="Imagen del Articulo <%= arti.Nombre %>" onerror="this.src='<%= defaultUrl %>'">
            <div class="card-body">
                <h1><%= arti.Nombre %></h1>
                <h5><%= arti.Descripcion %></h5>
                <p>ARS <%= Math.Round(arti.Precio, 2) %></p>
                <a href="DetalleArticulo.aspx?id=<%= arti.ID %>" class="btn btn-primary">Ver más</a>
            </div>
        </div>
    </div>
    <% } %>
</div>





    <div>
        <!-- Etiqueta ASP.NET para mostrar el total, si es necesario -->
        <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
    </div>



</asp:Content>












