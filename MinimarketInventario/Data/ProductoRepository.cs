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
    }
}
