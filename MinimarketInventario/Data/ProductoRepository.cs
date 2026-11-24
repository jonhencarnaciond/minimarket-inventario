using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using MinimarketInventario.Models;

namespace MinimarketInventario.Data
{
    public class ProductoRepository
    {
        public void Insertar(Producto producto)
        {
            using var conexion = Database.ObtenerConexion();
            conexion.Open();

            string sql = @"INSERT INTO Productos (Codigo, Nombre, Categoria, Precio, Stock)
                           VALUES ($codigo, $nombre, $categoria, $precio, $stock);";

            using var comando = new SqliteCommand(sql, conexion);
            comando.Parameters.AddWithValue("$codigo", producto.Codigo);
            comando.Parameters.AddWithValue("$nombre", producto.Nombre);
            comando.Parameters.AddWithValue("$categoria", producto.Categoria);
            comando.Parameters.AddWithValue("$precio", (double)producto.Precio);
            comando.Parameters.AddWithValue("$stock", producto.Stock);
            comando.ExecuteNonQuery();
        }

        public List<Producto> ObtenerTodos()
        {
            var lista = new List<Producto>();

            using var conexion = Database.ObtenerConexion();
            conexion.Open();

            string sql = "SELECT Id, Codigo, Nombre, Categoria, Precio, Stock FROM Productos ORDER BY Nombre;";

            using var comando = new SqliteCommand(sql, conexion);
            using var lector = comando.ExecuteReader();

            while (lector.Read())
            {
                lista.Add(new Producto
                {
                    Id = lector.GetInt32(0),
                    Codigo = lector.GetString(1),
                    Nombre = lector.GetString(2),
                    Categoria = lector.IsDBNull(3) ? "" : lector.GetString(3),
                    Precio = (decimal)lector.GetDouble(4),
                    Stock = lector.GetInt32(5)
                });
            }

            return lista;
        }
    }
}
