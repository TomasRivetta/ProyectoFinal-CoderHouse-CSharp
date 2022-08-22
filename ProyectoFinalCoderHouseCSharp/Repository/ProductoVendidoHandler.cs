using ProyectoFinalCoderHouseCSharp.Model;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinalCoderHouseCSharp.Repository
{
    public class ProductoVendidoHandler
    {
        public const string ConnectionString = "Server=PCCESAR;DataBase=SistemaGestion;Trusted_Connection=True";

        //Traer todos los Productos Vendidos
        public static List<ProductoVendido> GetProductosVendidos()
        {

            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ProductoVendido", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {

                                ProductoVendido productoVendido = new ProductoVendido();

                                productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);

                                productosVendidos.Add(productoVendido);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }

            return productosVendidos;

        }

        //Traer Productos Vendidos de Cierto Usuario
        public static List<ProductoVendido> ProductosVendidos(int idVenta)
        {

            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
            List<Producto> listaProductos = ProductoHandler.TraerProductos(idVenta);

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ProductoVendido WHERE IdVenta = @idVenta", sqlConnection))
                {

                    sqlCommand.Parameters.AddWithValue("@idVenta", idVenta);

                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {

                                ProductoVendido productoVendido = new ProductoVendido();
                                
                                productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);

                                productosVendidos.Add(productoVendido);

                            }
                        }
                    }
                    sqlConnection.Close();
                }

                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario = @idVenta", sqlConnection))
                {

                    sqlCommand.Parameters.AddWithValue("@idVenta", idVenta);

                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {

                                Producto producto = new Producto();

                                producto.Id = Convert.ToInt32(dataReader["Id"]);
                                producto.Descripciones = dataReader["Descripciones"].ToString();
                                producto.Costo = Convert.ToInt32(dataReader["Costo"]);
                                producto.PrecioVenta = Convert.ToInt32(dataReader["PrecioVenta"]);
                                producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);

                                listaProductos.Add(producto);

                            }
                        }
                    }
                    sqlConnection.Close();
                }

            }

            return productosVendidos;

        }
    }
}
