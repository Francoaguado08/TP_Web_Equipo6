using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio

{
    public class Articulo
    {
        //Agrego los constructores, uno sin parametros que se carga vacio 
        //y otro con los parametros que se le carguen.
        public Articulo()
        {
            ID = 0;
            Codigo = "0";
            Nombre = "";
            Descripcion = "";
            Precio = 0;
            Categoria = new Categoria();
            Marca = new Marca();
            UrlImagen = "";
        }
        public Articulo(string codigo, string nombre, string descripcion, decimal precio, Categoria categoria, Marca marca, string urlImagen)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Categoria = categoria;
            Marca = marca;
            UrlImagen = urlImagen;
        }

        //ATRIBUTOS DE MI CLASE ARTICULO GENERICA.
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string  Descripcion  { get; set; }
        public decimal Precio { get; set; }
        public Categoria Categoria { get; set; }
        public Marca Marca { get; set; }
        public string UrlImagen { get; set; }    

        /*Recordemos que el comboBox (el desplegable que nos pide) ya tiene que tener cargado sus ITEMS 
        en el LOAD.? */
    }
}
