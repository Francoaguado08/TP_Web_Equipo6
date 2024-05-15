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
        // Constructor que inicializa la lista de URLs de imágenes
        public Articulo()
        {
            UrlImagenes = new List<string>();
        }

        // Atributos de la clase Articulo
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public Categoria Categoria { get; set; }
        public Marca Marca { get; set; }

        // Propiedad para almacenar múltiples URLs de imágenes
        public List<string> UrlImagenes { get; set; }
    }
}
