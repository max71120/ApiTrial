using System.Data;
using System.Data.SqlClient;
using Tienda.Conexion;
using Tienda.Modelo;
namespace Tienda.Datos
{
    public class Dproductos
    {
        Conexionbd cn = new();
        public async Task<List<Mproductos>> MostrarProductos()
        {
            var lista = new List<Mproductos>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand ("mostrarProductos", sql)) 
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mproductos = new Mproductos(); 
                            mproductos.id = (int)item["id"];
                            mproductos.descripcion = (string)item["descripcion"];
                            mproductos.precio = (decimal)item["precio"];
                            lista.Add(mproductos);
                        }
                    }
                    }
                return lista;
            }
        }

        public async Task InsertarProductos(Mproductos parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand ("insertarProductos",sql))
                {
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue 
                        ("@descripcion",parametros.descripcion);
                    cmd.Parameters.AddWithValue("precio", parametros.precio);

                    await sql.OpenAsync();
                    await cmd.ExecuteReaderAsync();

                }
            }
        }
        public async Task EditarProductos(Mproductos parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", parametros.id);
                    cmd.Parameters.AddWithValue("@descripcion", parametros.descripcion);
                    cmd.Parameters.AddWithValue("@precio", parametros.precio);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task EliminarProductos(int id)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }

            }
        }
    }
    
}






