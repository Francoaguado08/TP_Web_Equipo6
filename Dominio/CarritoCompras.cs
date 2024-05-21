using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    
    public class CarritoCompras
    {
        private List<Articulo> productos;

        public CarritoCompras()
        {
            productos = new List<Articulo>();
        }

        public void AgregarProducto(Articulo producto)
        {
            var productoExistente = productos.FirstOrDefault(p => p.ID == producto.ID);
            if (productoExistente != null)
            {
                productoExistente.Cantidad++;
            }
            else
            {
                producto.Cantidad = 1;
                productos.Add(producto);
            }
        }

        public List<Articulo> ObtenerProductos()
        {
            return productos;
        }

        public decimal ObtenerTotal()
        {
            return productos.Sum(p => p.Precio * p.Cantidad);
        }
    }





}