<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Web_Equipo6._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>BIENVENIDOS A DIGITAL PLANET</h1>
    <h2>Stock disponible:</h2>
    <div class="row row-cols-1 row-cols-md-3 g-4">
       <% foreach (Dominio.Articulo arti in listaArticulo) { %>
            <div class="col">
                <div class="card">
                    <%--<img src="<%: arti.UrlImagen %>" class="card-img-top" alt="...">--%>
                    <div class="card-body">
                        <h5 class="card-title"><%: arti.Nombre %></h5>
                        <p class="card-text"><%: arti.Descripcion %></p>
                        <a href="DetalleArticulo.aspx?id=<%:arti.ID%>" class="btn btn-primary">Ver más</a>
                    </div>
                </div>
            </div>
       <% } %>
    </div>
    
</asp:Content>

      
      
       








