using Npgsql;
using Proyecto.BE;
using System;
using System.Data;

namespace Proyecto.DA
{
    public class DataBaseDA
    {
        private NpgsqlConnection conn;
        private DatabaseConfigBE databaseConfig;


        public string CrearEnlaceDeConexion(string server, string port, string user_id, string password, string database)
        {
            try
            {
                conn.ConnectionString = $"Server={server}; Port={port}; User Id={user_id}; Password={password}; Database={database}";
                databaseConfig = new DatabaseConfigBE
                {
                    Server = server,
                    Port = port,
                    UserId = user_id,
                    Password = password,
                    Database = database
                };
                return "Data de conexión fue enviada correctamente...ya puede probar la conexion";
            }
            catch (Exception ex)
            {
                return "ERROR INESPERADO: " + ex.Message;
            }
        }

        private string ValidarConexion()
        {
            if (conn.ConnectionString == null)
            {
                return "Debe inicializar la  datos de conexión antes de realizar operaciones con la base de datos.";
            }
            var conn_string = conn.ConnectionString;
            return conn_string;
        }



        public NpgsqlConnection AbrirConexion()
        {

            if (conn.State == ConnectionState.Open)
            {
                return conn;
            }

            conn.Open();
            return conn;

        }


        public string CerrarConexion()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                try
                {
                    conn.Close();
                    return "Conexión a la base de datos cerrada con éxito...";
                }
                catch (Exception ex)
                {
                    return "Error al cerrar la conexión a la base de datos: " + ex.Message;
                }
            }
            else
            {
                return "No existe ninguna conexión abierta para cerrar";
            }
        }


        public void SetDatabaseConfig(DatabaseConfigBE newConfig)
        {
            databaseConfig = newConfig;

            // Update the connection string with the new configuration
            conn.ConnectionString = $"Server={newConfig.Server}; Port={newConfig.Port}; User Id={newConfig.UserId}; Password={newConfig.Password}; Database={newConfig.Database}";
        }

        public DatabaseConfigBE GetDatabaseConfig()
        {
            return databaseConfig;
        }
    }
}
