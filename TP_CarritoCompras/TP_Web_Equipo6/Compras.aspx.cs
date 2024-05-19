using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

/*namespace TP_Web_Equipo6
{
    public partial class Compras : System.Web.UI.Page
    {
        public Articulo artAgregado;
        public List<Articulo> compras;
        public CarritoCompras miCarrito;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener o inicializar el carrito de compras
                if (Session["compras"] == null)
                {
                    miCarrito = new CarritoCompras();
                    Session.Add("compras", miCarrito);
                }
                else
                {
                    miCarrito = (CarritoCompras)Session["compras"];
                }

                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    List<Articulo> articulos = (List<Articulo>)Session["articulos"];
                    if (articulos != null)
                    {
                        artAgregado = articulos.Find(x => x.ID == id);
                        if (artAgregado != null)
                        {
                            miCarrito.AgregarProducto(artAgregado);
                        }
                    }
                }

                // Enlazar el GridView con los productos del carrito
                BindGridView();

                // Calcular y mostrar el total general
                ActualizarTotalGeneral();
            }
        }

        protected void dgvCompras_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvCompras.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void dgvCompras_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Obtener el carrito de la sesión
            miCarrito = (CarritoCompras)Session["compras"];

            // Obtener la fila que se está editando
            GridViewRow row = dgvCompras.Rows[e.RowIndex];
            int id = Convert.ToInt32(dgvCompras.DataKeys[e.RowIndex].Value);

            // Obtener la nueva cantidad del TextBox
            TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");
            int nuevaCantidad = int.Parse(txtCantidad.Text);

            // Actualizar la cantidad del producto en el carrito
            Articulo producto = miCarrito.ObtenerProductos().Find(p => p.ID == id);
            if (producto != null)
            {
                producto.Cantidad = nuevaCantidad;
            }

            // Guardar el carrito actualizado en la sesión
            Session["compras"] = miCarrito;

            // Salir del modo de edición y volver a enlazar el GridView
            dgvCompras.EditIndex = -1;
            BindGridView();

            // Actualizar el total general
            ActualizarTotalGeneral();
        }

        protected void dgvCompras_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvCompras.EditIndex = -1;
            BindGridView();
        }

        private void BindGridView()
        {
            miCarrito = (CarritoCompras)Session["compras"];
            dgvCompras.DataSource = miCarrito.ObtenerProductos();
            dgvCompras.DataBind();
        }

        private void ActualizarTotalGeneral()
        {
            miCarrito = (CarritoCompras)Session["compras"];
            decimal totalGeneral = miCarrito.ObtenerProductos().Sum(a => a.Precio * a.Cantidad);
            lblTotalGeneral.Text = "Total: " + totalGeneral.ToString("C");
        }
    }
}*/


namespace TP_Web_Equipo6
{
    public partial class Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarritoCompras miCarrito = Session["compras"] as CarritoCompras ?? new CarritoCompras();
                Session["compras"] = miCarrito;

                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    List<Articulo> articulos = (List<Articulo>)Session["articulos"];
                    if (articulos != null)
                    {
                        Articulo artAgregado = articulos.Find(x => x.ID == id);
                        if (artAgregado != null)
                        {
                            miCarrito.AgregarProducto(artAgregado);
                        }
                    }
                }

                BindGridView();
                ActualizarTotalGeneral();
            }
        }

        protected void dgvCompras_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvCompras.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void dgvCompras_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            CarritoCompras miCarrito = (CarritoCompras)Session["compras"];
            GridViewRow row = dgvCompras.Rows[e.RowIndex];
            int id = Convert.ToInt32(dgvCompras.DataKeys[e.RowIndex].Value);
            TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");
            int nuevaCantidad = int.Parse(txtCantidad.Text);

            Articulo producto = miCarrito.ObtenerProductos().Find(p => p.ID == id);
            if (producto != null)
            {
                producto.Cantidad = nuevaCantidad;
            }

            Session["compras"] = miCarrito;
            dgvCompras.EditIndex = -1;
            BindGridView();
            ActualizarTotalGeneral();
        }

        protected void dgvCompras_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvCompras.EditIndex = -1;
            BindGridView();
        }

        private void BindGridView()
        {
            CarritoCompras miCarrito = (CarritoCompras)Session["compras"];
            dgvCompras.DataSource = miCarrito.ObtenerProductos();
            dgvCompras.DataBind();
        }

        private void ActualizarTotalGeneral()
        {
            CarritoCompras miCarrito = (CarritoCompras)Session["compras"];
            decimal totalGeneral = miCarrito.ObtenerTotal();
            lblTotalGeneral.Text = "Total: " + totalGeneral.ToString("C");
        }
    }
} 