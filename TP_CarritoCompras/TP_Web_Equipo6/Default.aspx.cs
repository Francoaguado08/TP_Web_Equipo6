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
    public partial class _Default : Page {

        public List<Articulo> listaArticulo;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["listaArticulo"] != null) { 
            listaArticulo = (List<Articulo>)Session["listaArticulo"];
            }
            else { 
            // Si no está en la sesión, obtener la lista de artículos del negocio
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulo = negocio.listar();
            // Almacenar la lista de artículos en la sesión
            Session.Add("listaArticulo", listaArticulo);
            }
           



            
            
        }
            



            




    }


}