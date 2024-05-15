using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio

{
    public class Categoria
    {
        //Agrego los constructores, uno sin parametros que se carga vacio 
        //y otro con los parametros que se le carguen.
       public Categoria()
        {
            ID = 0;
            Descripcion = "";
        }
        public Categoria(int id, string descripcion)
        {
            ID = id;
            Descripcion = descripcion;
        }
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }

    }
}
