using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TP_Web_Equipo6
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        //Por que no me toma ??
        public Articulo artSeleccionado; 

       public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Inicializar la lista de artículos en la sesión si no existe
                List<Articulo> articulos = Session["articulos"] != null ? (List<Articulo>)Session["articulos"] : new List<Articulo>();

                // Obtener el ID del artículo desde la URL
                int id = int.Parse(Request.QueryString["id"]);

                // Obtener la lista original de artículos desde la sesión
                List<Articulo> listaOriginal = (List<Articulo>)Session["listaArticulo"];
                if (listaOriginal == null)
                {
                    listaOriginal = new List<Articulo>(); // Esto debería ser llenado con datos reales
                    Session["listaArticulo"] = listaOriginal;
                }

                // Encontrar el artículo seleccionado en la lista original
                artSeleccionado = listaOriginal.Find(x => x.ID == id);
                if (artSeleccionado != null)
                {
                    // Agregar el artículo seleccionado a la lista de artículos
                    articulos.Add(artSeleccionado);

                    // Actualizar la sesión con la nueva lista de artículos
                    Session["articulos"] = articulos;

                    // Asignar la lista de artículos al GridView y enlazar los datos
                    dgvArticulos.DataSource = articulos;
                    dgvArticulos.DataBind();



                    





                    // Mostrar los detalles del artículo seleccionado
                    txtNombre.Text = string.Format("<h1>{0}</h1>", artSeleccionado.Nombre);
                    txtCodigo.Text = string.Format("<h5>Código: {0}</h5>", artSeleccionado.Codigo);
                    txtPrecio.Text = string.Format("<h3>ARS {0}</h3>", Math.Round(artSeleccionado.Precio, 2));
                    txtDescripcion.Text = string.Format("<p>{0}</p>", artSeleccionado.Descripcion);
                    txtMarca.Text = string.Format("<h6>Marca: {0}</h6>", artSeleccionado.Marca != null ? artSeleccionado.Marca.Descripcion : "No disponible");
                    txtCategoria.Text = string.Format("<h6>Categoria: {0}</h6>", artSeleccionado.Categoria != null ? artSeleccionado.Categoria.Descripcion : "No disponible");
                }
            }
        }





        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            List<Articulo> articulos = Session["articulos"] != null ? (List<Articulo>)Session["articulos"] : new List<Articulo>();
            CarritoCompras miCarrito = Session["compras"] != null ? (CarritoCompras)Session["compras"] : new CarritoCompras();

            int id = int.Parse(Request.QueryString["id"]);
            List<Articulo> listaOriginal = (List<Articulo>)Session["listaArticulo"];
            artSeleccionado = listaOriginal.Find(x => x.ID == id);

            if (artSeleccionado != null)
            {
                miCarrito.AgregarProducto(artSeleccionado);
                Session["compras"] = miCarrito;

                Response.Redirect("Compras.aspx");
            }
        }



    }
}