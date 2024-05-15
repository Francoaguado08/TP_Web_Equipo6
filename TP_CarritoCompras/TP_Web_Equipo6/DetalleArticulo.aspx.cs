using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Web_Equipo6
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
             //Inicializar la lista de artículos en la sesión si no existe
            List<Articulo> articulos;
            articulos = Session["articulos"] != null ? (List <Articulo>) Session["articulos"]: new List<Articulo>();

            // Obtener el ID del artículo desde la URL
            int id = int.Parse(Request.QueryString["id"]);
            
            // Obtener la lista original de artículos desde la sesión
            List<Articulo> listaOriginal = (List <Articulo>) Session["listaArticulo"];

            // Encontrar el artículo seleccionado en la lista original
            Articulo seleccionado = listaOriginal.Find(x => x.ID == id);
            // Agregar el artículo seleccionado a la lista de artículos
            articulos.Add(seleccionado);

            // Asignar la lista de artículos al DataGridView y enlazar los datos
            dgvArticulos.DataSource = articulos;    
            dgvArticulos.DataBind();    




        }

    
        
    
    
    
    
    }
    
    
  }
