using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //(0) Agrego esto para la conexion.
using Dominio;
using Negocio;
using System.Runtime.ConstrainedExecution;

namespace Negocio
{   

    ///(1) Clase para crear los metodos de acceso a datos para los Articulos...
    /// (2) Los metodos tienen que ser Public para yo poder accederlos desde el exterior.
    public class ArticuloNegocio
    {


        // Modifico el metodo listar para manejar multiples imagenes si es que lo contiene el articulo....
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion AS Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio, I.ImagenUrl FROM ARTICULOS A LEFT JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id LEFT JOIN IMAGENES I ON A.Id = I.IdArticulo");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    int idActual = (int)datos.Lector["Id"];
                    Articulo aux = lista.FirstOrDefault(a => a.ID == idActual);

                    if (aux == null)
                    {
                        aux = new Articulo
                        {
                            ID = (int)datos.Lector["Id"],
                            Codigo = (string)datos.Lector["Codigo"],
                            Nombre = (string)datos.Lector["Nombre"],
                            Descripcion = (string)datos.Lector["Descripcion"],
                            Precio = (decimal)datos.Lector["Precio"],
                            Marca = new Marca
                            {
                                Descripcion = datos.Lector["Marca"] != DBNull.Value ? (string)datos.Lector["Marca"] : ""
                            },
                            Categoria = new Categoria
                            {
                                Descripcion = datos.Lector["Categoria"] != DBNull.Value ? (string)datos.Lector["Categoria"] : ""
                            }
                        };
                        lista.Add(aux);
                    }

                    if (!Convert.IsDBNull(datos.Lector["ImagenUrl"]))
                    {
                        aux.UrlImagenes.Add((string)datos.Lector["ImagenUrl"]);
                    }
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


        public void agregar(Articulo nuevo)
        {
            AccesoDatos acceso = new AccesoDatos();
            try
            {

                acceso.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria ) VALUES (@Codigo, @Nombre, @Descripcion,@Precio, @IdMarca, @IdCategoria)");
               
                acceso.setearParametro("@Codigo", nuevo.Codigo);
                acceso.setearParametro("@Nombre", nuevo.Nombre);
                acceso.setearParametro("@Descripcion", nuevo.Descripcion);
            
                acceso.setearParametro("@Precio", nuevo.Precio);

                acceso.setearParametro("@IdMarca", nuevo.Marca.ID);
                acceso.setearParametro("@IdCategoria", nuevo.Categoria.ID);
                
                acceso.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Cerrar la conexión
                acceso.cerrarConexion();
            }
        }

        public void agregarImagen(Articulo nuevoArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            Articulo articulo = new Articulo();
            articulo = listar().Last();

            try
            {
                int idArticulo = articulo.ID;
                datos.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.setearParametro("@ImagenUrl", nuevoArticulo.UrlImagenes);
                datos.cerrarConexion();
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

        public void eliminarArticulo(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM Articulos WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        // --- MODIFICAR (arranca acá) ---
        public void modificar(Articulo modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Precio = @Precio, Descripcion = @Descripcion WHERE Id = @Id");
                datos.setearParametro("@Id", modificar.ID);
                datos.setearParametro("@Codigo", modificar.Codigo);
                datos.setearParametro("@Nombre", modificar.Nombre);
                datos.setearParametro("@Descripcion", modificar.Descripcion);
                datos.setearParametro("@Precio", modificar.Precio);
                datos.cerrarConexion();
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void modificarCategoriaArticulo(Articulo modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET IdCategoria = @IdCategoria WHERE Id = @IdArticulo");
                datos.setearParametro("@IdArticulo", modificar.ID);
                datos.setearParametro("@IdCategoria", modificar.Categoria.ID);
                datos.cerrarConexion();
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificarMarcaArticulo(Articulo modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET IdMarca = @IdMarca WHERE Id = @IdArticulo");
                datos.setearParametro("@IdArticulo", modificar.ID);
                datos.setearParametro("@IdMarca", modificar.Marca.ID);
                datos.cerrarConexion();
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificarImagenArticulo(Articulo modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE IMAGENES SET ImagenUrl = @ImagenUrl WHERE Id = (SELECT TOP 1 Id FROM IMAGENES WHERE IdArticulo = @IdA)");
                datos.setearParametro("@IdA", modificar.ID);
                datos.setearParametro("@ImagenUrl", modificar.UrlImagenes);
                datos.cerrarConexion();
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // --- TERMINA ACÁ ---

    }
}
