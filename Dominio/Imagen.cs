using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio

{
    public class Imagen
    {
        public int IDImagen { get; set; }
        public int IDArticulo { get; set; }
        public string ImagenUrl { get; set; }

        public Imagen()
        {
            IDArticulo = 0;
            ImagenUrl = "";
        }

    }
}
