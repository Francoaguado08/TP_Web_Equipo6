using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio

{
    public class Imagen
    {
        public int IDArticulo { get; set; } 
        public string URLImagen { get; set; }
        public Imagen()
        {
            IDArticulo = 0;
            URLImagen = "";
        }

    }
}
