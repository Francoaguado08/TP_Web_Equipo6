<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="TP_Web_Equipo6.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Detalle del Articulo   </h1>



    <asp:GridView ID="dgvArticulos" CssClass="table" runat="server"></asp:GridView>

    <%--CARROUSEL DE IMAGENES--%>
    <div id="carouselExample" class="carousel slide">
        <div class="carousel-inner">
            <%  string defaultUrl = "https://nayemdevs.com/wp-content/uploads/2020/03/default-product-image.png";

                Negocio.ImagenesNegocio negocioObj = new Negocio.ImagenesNegocio();
                List<Dominio.Imagen> listaImagenes = new List<Dominio.Imagen>();
                int idArticulo = int.Parse(Request.QueryString["id"]);
                listaImagenes = negocioObj.listarImagenesArticuloSeleccionado(idArticulo);
            %>


            <% for (int i = 0; i < listaImagenes.Count; i++)
                { %>
            <div class="carousel-item <%= (i == 0) ? "active" : "" %>">
                <img src="<%= listaImagenes[i].ImagenUrl %>" id="artImagen" class="img-fluid rounded-start" alt="Imagen del producto" onerror="this.src='<%= defaultUrl %>'" style="height: auto; width: 100%;">
            </div>
            <% } %>
        </div>

        <%--BOTONES DEL CARRROUSEL--%>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>
    <%--FIN DEL CARROUSEL--%>



    <div class="col-md-8">
        <div class="card-body">

            <asp:Label ID="txtNombre" runat="server" />
            <asp:Label ID="txtCodigo" runat="server" />
            <asp:Label ID="txtPrecio" runat="server" />
            <asp:Label ID="txtDescripcion" runat="server" />
            <asp:Label ID="txtMarca" runat="server" />
            <asp:Label ID="txtCategoria" runat="server" />
        </div>
    </div>
    <br />



    <div>
        <a href="Default.aspx" class="btn btn-primary">Volver al Inicio</a>

    </div>


    <br />


    <br />
    <br />



    <% 
        // Obtener el ID del artículo de la cadena de consulta
        int id = int.Parse(Request.QueryString["id"]);

        // Usar el ID para crear el enlace "Ver más"
        string agregarAlCarrito = string.Format("Compras.aspx?id={0}", idArticulo);
    %>
    <a href="<%= agregarAlCarrito %>" class="btn btn-primary">Agregar al Carrito</a>















</asp:Content>
