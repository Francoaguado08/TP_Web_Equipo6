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



        public Articulo artSeleccionado;


        protected void Page_Load(object sender, EventArgs e)
        {
            //Inicializar la lista de artículos en la sesión si no existe
            List<Articulo> articulos;
            articulos = Session["articulos"] != null ? (List<Articulo>)Session["articulos"] : new List<Articulo>();

            // Obtener el ID del artículo desde la URL
            int id = int.Parse(Request.QueryString["id"]);

            // Obtener la lista original de artículos desde la sesión
            List<Articulo> listaOriginal = (List<Articulo>)Session["listaArticulo"];

            // Encontrar el artículo seleccionado en la lista original
            Articulo seleccionado = listaOriginal.Find(x => x.ID == id);
            // Agregar el artículo seleccionado a la lista de artículos
            articulos.Add(seleccionado);

            // Asignar la lista de artículos al DataGridView y enlazar los datos
            dgvArticulos.DataSource = articulos;
            dgvArticulos.DataBind();






            //ddlCantidad.Items.Add("1");
            //ddlCantidad.Items.Add("2");
            //ddlCantidad.Items.Add("3");
            //ddlCantidad.Items.Add("4");
            //ddlCantidad.Items.Add("5");
            //ddlCantidad.Items.Add("6");
            //ddlCantidad.Items.Add("7");
            //ddlCantidad.Items.Add("8");
            //ddlCantidad.Items.Add("9");
            //ddlCantidad.Items.Add("10");

            if (!IsPostBack)
            {
                int ID = int.Parse(Request.QueryString["id"]);

               // artSeleccionado = ((List<Articulo>)Session["articulos"]).Find(x => x.ID == ID);

                Negocio.ImagenesNegocio obj = new Negocio.ImagenesNegocio();

                artSeleccionado = obj.listarArticulo(ID);

                txtNombre.Text = string.Format("<h1>{0}</h1>", artSeleccionado.Nombre);
                txtCodigo.Text = string.Format("<h5>Código: {0}</h5>", artSeleccionado.Codigo);
                txtPrecio.Text = string.Format("<h3>ARS {0}</h3>", (Math.Round(artSeleccionado.Precio, 2)).ToString());
                txtDescripcion.Text = string.Format("<p>{0}</p>", artSeleccionado.Descripcion);
                txtMarca.Text = string.Format("<h6>Marca: {0}</h6>", artSeleccionado.Marca);
                txtCategoria.Text = string.Format("<h6>Categoria: {0}</h6>", artSeleccionado.Categoria);

            }










        }







    }


}
