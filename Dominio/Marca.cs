using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Marca
    {
        //Agrego los constructores, uno sin parametros que se carga vacio 
        //y otro con los parametros que se le carguen.
        // (en la BD a lo que nosotros le llamamos "Nombre", figura como "Descripcion")
        public Marca()
        {
            ID = 0;
            Descripcion = "";
        }
        public Marca(int id, string nombre)
        {
            ID = id;
            Descripcion = nombre;
        }
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
