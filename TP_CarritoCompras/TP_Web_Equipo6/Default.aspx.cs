using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.ComponentModel;

namespace TP_Web_Equipo6
{
    public partial class _Default : Page
    {
        public List<Articulo> listaArticulo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                obtenerProductos();

                ddlFiltrarPor.Items.Add("Precio");
                ddlFiltrarPor.Items.Add("Categoría");
                ddlFiltrarPor.Items.Add("Marca");
                ddlFiltrarPor.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                ddlFiltrarPor.SelectedIndex = 0;

                ddlCriterio.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                ddlCriterio.SelectedIndex = 0;
            }
            else
            {
                listaArticulo = (List<Articulo>)Session["articulos"];
            }
        }

        private void obtenerProductos()
        {
            ArticuloNegocio articulos = new ArticuloNegocio();
            ImagenesNegocio imagenes = new ImagenesNegocio();
            List<Imagen> misImagenes = new List<Imagen>();
            misImagenes = imagenes.listar();
            listaArticulo = new List<Articulo>();
            listaArticulo = articulos.listar();
            imagenes.vincularImagenes(listaArticulo, misImagenes);
            if (Session["articulos"] == null)
            {
                Session.Add("articulos", listaArticulo);
            }
            else
            {
                Session["articulos"] = listaArticulo;
            }
        }

       

        

        protected void ddlCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["criterio"] = ddlCriterio.SelectedItem.ToString();
        }

        protected void ddlFiltrarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Add("campo", ddlFiltrarPor.SelectedItem.ToString());

            if (ddlFiltrarPor.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Clear();
                ddlCriterio.Items.Add("Ascendente");
                ddlCriterio.Items.Add("Descendente");
                Session.Add("criterio", ddlCriterio.SelectedItem.ToString());
            }
            else if (ddlFiltrarPor.SelectedItem.ToString() == "Marca")
            {
                ddlCriterio.Items.Clear();
                //llamar a base de datos, listar marcas
                MarcasNegocio marcasNegocios = new MarcasNegocio();
                List<Marca> misMarcas = marcasNegocios.listar();
                foreach (Marca item in misMarcas)
                {
                    ddlCriterio.Items.Add(item.Descripcion);
                }
                Session.Add("criterio", ddlCriterio.SelectedItem.ToString());

            }
            else if (ddlFiltrarPor.SelectedItem.ToString() == "Categoría")
            {
                ddlCriterio.Items.Clear();
                // llamar a base de datos, listar categorías
                CategoriaNegocio categoriasNegocios = new CategoriaNegocio();
                List<Categoria> misCategorias = categoriasNegocios.listar();
                foreach (Categoria item in misCategorias)
                {
                    ddlCriterio.Items.Add(item.Descripcion);
                }
                Session.Add("criterio", ddlCriterio.SelectedItem.ToString());
            }
            else
            {
                ddlCriterio.Items.Clear();
                obtenerProductos();
            }
        }

        protected void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articulos = new ArticuloNegocio();
            ImagenesNegocio imagenes = new ImagenesNegocio();
            List<Imagen> misImagenes = imagenes.listar();
            listaArticulo = new List<Articulo>();
            string campo = (string)Session["campo"];
            string criterio = (string)Session["criterio"];
            listaArticulo = articulos.listarFiltrados(campo, criterio);
            imagenes.vincularImagenes(listaArticulo, misImagenes);
            Session["articulos"] = listaArticulo;
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            ddlFiltrarPor.SelectedIndex = 0;
            ddlCriterio.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlCriterio.SelectedIndex = 0;

            ArticuloNegocio articulos = new ArticuloNegocio();
            ImagenesNegocio imagenes = new ImagenesNegocio();
            List<Imagen> misImagenes = new List<Imagen>();
            misImagenes = imagenes.listar();
            listaArticulo = new List<Articulo>();
            listaArticulo = articulos.listar();
            imagenes.vincularImagenes(listaArticulo, misImagenes);
            if (Session["articulos"] == null)
            {
                Session.Add("articulos", listaArticulo);
            }
            else
            {
                Session["articulos"] = listaArticulo;
            }
            Session["articulos"] = listaArticulo;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articulos = new ArticuloNegocio();
            string textoEnTextbox;
            textoEnTextbox = tbxBuscar.Text;

            if (textoEnTextbox.Length >= 2)
            {
                listaArticulo = ((List<Articulo>)Session["articulos"]).FindAll(x => x.Nombre.ToUpper().Contains(textoEnTextbox.ToUpper()));
            }
            else
            {
                listaArticulo = (List<Articulo>)Session["articulos"];
            }
        }
    }
}