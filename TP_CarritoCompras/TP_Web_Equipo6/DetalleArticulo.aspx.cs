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
                    int id = int.Parse(Request.QueryString["id"]);

                    artSeleccionado = ((List<Articulo>)Session["articulos"]).Find(x => x.ID== id);

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