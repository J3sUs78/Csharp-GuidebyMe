using System;
using System.Collections.Generic;
using Npgsql;

namespace ConnectionDatabase
{
    internal class ConnectionController
    {
        private NpgsqlConnection conn;

        // Constructor
        public ConnectionController()
        {
            conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id = postgres; Password=1234; Database = practica_csharp");
        }

        // Método para abrir la conexión
        public NpgsqlConnection AbrirConexion()
        {
            try
            {
                conn.Open();
                Console.WriteLine("Conexion abierta Correctamente...");
                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al abrir la conexión: {ex.Message}");
                return null;
            }
        }

        // Método para cerrar la conexión
        public void CerrarConexion()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
                conn = null;
                Console.WriteLine("Conexion a la base de datos cerrada con exito...");
            }
            else
            {
                Console.WriteLine("No existe ninguna conexión abierta para cerrar...");
            }
        }

        // Método para insertar un usuario
        public void InsertarUsuario(string nombre, string comuna, int edad)
        {
            var cmd = new NpgsqlCommand($"INSERT INTO usuarios (nombre, edad, comuna) VALUES ('{nombre}', {edad}, '{comuna}')", AbrirConexion());

            // Hacer insert de datos
            cmd.ExecuteNonQuery();
            CerrarConexion();
        }

        //Metodo para obtener todos los usuarios
        public List<UserModel> ObtenerTodosUsuarios()
        {
            List<UserModel> usuarios = new List<UserModel>();

            // Asegúrate de abrir la conexión antes de ejecutar la consulta
            using (var connection = AbrirConexion())
            {
                // Verifica si la conexión se abrió correctamente antes de continuar
                if (connection != null)
                {
                    using (var cmd = new NpgsqlCommand("SELECT * FROM public.usuarios", connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nombre = reader.GetString(reader.GetOrdinal("nombre"));
                                int edad = reader.GetInt32(reader.GetOrdinal("edad"));
                                string comuna = reader.GetString(reader.GetOrdinal("comuna"));

                                usuarios.Add(new UserModel(nombre, edad, comuna));
                            }
                        }
                    }
                }
            }

            // Asegúrate de cerrar la conexión después de ejecutar la consulta
            CerrarConexion();

            return usuarios;
        }

    }

}
