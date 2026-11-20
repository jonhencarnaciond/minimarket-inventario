using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace MinimarketInventario.Data
{
    public static class Database
    {
        private static readonly string RutaDb =
            Path.Combine(AppContext.BaseDirectory, "minimarket.db");

        public static SqliteConnection ObtenerConexion()
        {
            return new SqliteConnection($"Data Source={RutaDb}");
        }

        public static void Inicializar()
        {
            using var conexion = ObtenerConexion();
            conexion.Open();

            string sql = @"
                CREATE TABLE IF NOT EXISTS Productos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Codigo TEXT NOT NULL UNIQUE,
                    Nombre TEXT NOT NULL,
                    Categoria TEXT,
                    Precio REAL NOT NULL,
                    Stock INTEGER NOT NULL DEFAULT 0
                );";

            using var comando = new SqliteCommand(sql, conexion);
            comando.ExecuteNonQuery();
        }
    }
}
