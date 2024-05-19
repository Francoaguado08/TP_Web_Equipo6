using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
  public class ImagenesNegocio
    {

        public List<Imagen> listar()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM imagenes ORDER BY IdArticulo");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.IDImagen = (int)datos.Lector["Id"];
                    aux.IDArticulo = (int)datos.Lector["IdArticulo"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



        public List<Imagen> listarImagenesArticuloSeleccionado(int idArticulo)
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = String.Format("SELECT ImagenUrl FROM imagenes Where idArticulo = {0}", idArticulo);


                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    //aux.IDImagen = (int)datos.Lector["Id"];
                    //aux.IDArticulo = (int)datos.Lector["IdArticulo"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        //public Articulo listarArticulo(int idArticulo)
        //{

        //    AccesoDatos datos = new AccesoDatos();
        //    Articulo articulo = new Articulo();

        //    try
        //    {
        //        string consulta = String.Format("SELECT * FROM ARTICULOS Where Id = {0}", idArticulo);


        //        datos.setearConsulta(consulta);
        //        datos.ejecutarLectura();

        //        while (datos.Lector.Read())
        //        {
        //            articulo.ID = (int)datos.Lector["Id"];
        //            articulo.Nombre = (string)datos.Lector["Nombre"];
        //            articulo.Codigo = (string)datos.Lector["Codigo"];
        //            articulo.Descripcion = (string)datos.Lector["Descripcion"];
        //            articulo.Precio = (decimal)datos.Lector["Precio"];
        //            listarArticulo

        //        }

        //        return articulo;
        //    }



        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        //throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}


        //public Articulo listarArticulo(int idArticulo)
        //{
        //    AccesoDatos datos = new AccesoDatos();
        //    Articulo articulo = null;

        //    try
        //    {
        //        string consulta = "SELECT * FROM ARTICULOS WHERE Id = @IdArticulo";
        //        datos.setearConsulta(consulta);
        //        datos.setearParametro("@IdArticulo", idArticulo);
        //        datos.ejecutarLectura();

        //        while (datos.Lector.Read())
        //        {
        //            articulo = new Articulo
        //            {
        //                ID = (int)datos.Lector["Id"],
        //                Nombre = (string)datos.Lector["Nombre"],
        //                Codigo = (string)datos.Lector["Codigo"],
        //                Descripcion = (string)datos.Lector["Descripcion"],
        //                Precio = (decimal)datos.Lector["Precio"]
        //            };
        //        }

        //        return articulo;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        throw;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}

        public Articulo listarArticulo(int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            Articulo articulo = null;

            try
            {
                // Consulta SQL actualizada para incluir las tablas MARCAS y CATEGORIAS
                string consulta = @"
            SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, 
                   M.Descripcion AS Marca, C.Descripcion AS Categoria
            FROM ARTICULOS AS A 
            LEFT JOIN MARCAS AS M ON A.Id = M.Id
            LEFT JOIN CATEGORIAS AS C ON A.Id = C.Id
            WHERE A.Id = @IdArticulo";

                datos.setearConsulta(consulta);
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    // Inicializar el objeto articulo con los valores leídos
                    articulo = new Articulo
                    {
                        ID = (int)datos.Lector["Id"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Codigo = (string)datos.Lector["Codigo"],
                        Descripcion = (string)datos.Lector["Descripcion"],
                        Precio = (decimal)datos.Lector["Precio"],
                        Marca = new Marca
                        {
                            Descripcion = datos.Lector["Marca"] != DBNull.Value ? (string)datos.Lector["Marca"] : null
                        },
                        Categoria = new Categoria
                        {
                            Descripcion = datos.Lector["Categoria"] != DBNull.Value ? (string)datos.Lector["Categoria"] : null
                        }
                    };

                    // Mensaje en caso de que la categoría no esté disponible
                    if (articulo.Categoria.Descripcion == null)
                    {
                        Console.WriteLine("No disponible");
                    }
                }

                return articulo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



        public void agregarImagen(Imagen nuevaImagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Insertar en IMAGENES
                string consulta = "INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl);";
                datos.setearConsulta(consulta);

                // Establecer parámetros para la imagen
                datos.setearParametro("@IdArticulo", nuevaImagen.IDArticulo);
                datos.setearParametro("@ImagenUrl", nuevaImagen.ImagenUrl);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void actualizarImagen(Imagen nuevaImagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Actualizar IMAGENES
                string consulta = "UPDATE imagenes SET ImagenUrl=@ImagenUrl WHERE IdArticulo=@IdArticulo AND ID=@ID;";
                datos.setearConsulta(consulta);

                // Establecer parámetros para la imagen
                // Si no especificamos ID, se actualizarían TODAS las imágenes dadas de cierto artículo
                datos.setearParametro("@IdArticulo", nuevaImagen.IDArticulo);
                datos.setearParametro("@ImagenUrl", nuevaImagen.ImagenUrl);
                datos.setearParametro("@ID", nuevaImagen.IDImagen);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM Imagenes WHERE ID=@id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool TieneProductosAsociados(Imagen imagen)
        {
            AccesoDatos datos = new AccesoDatos();
            // Consulta SQL para contar los productos asociados a la imagen
            datos.setearConsulta("SELECT COUNT(*) FROM IMAGENES I INNER JOIN Articulos A ON I.IDArticulo=A.ID WHERE I.ID=@IDImagen;");
            datos.setearParametro("@IDImagen", imagen.IDImagen);
            // Verifica cuántos productos asociados a la imagen hay
            int cantidadProductos = datos.ejecutarScalar();

            return cantidadProductos > 0;
        }

        public void vincularImagenes(List<Articulo> articulos, List<Imagen> imagenes)
        {
        // Vamos artículo por artículo y recorremos todas las imágenes para agregarlas
        // a la lista de imágenes de cada artículo, cuando sea apropiado.
            foreach (Articulo miArticulo in articulos)
            {
                foreach (Imagen miImagen in imagenes)
                {
                    if (miImagen.IDArticulo.ToString() == miArticulo.ID.ToString())
                    {
                        miArticulo.UrlImagenes.Add("");
                    }
                }
            }
        }



    }
}
