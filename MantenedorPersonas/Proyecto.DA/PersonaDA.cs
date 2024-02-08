using System;
using System.Data;
using Npgsql;

namespace Proyecto.DA
{
    public class PersonaDA
    {
        private string connectionString;

        CredencialsDA CredencialsAcces;
        DataBaseDA databaseAccess;


        public PersonaDA() 
        {
            CredencialsAcces = new CredencialsDA();
            databaseAccess = new DataBaseDA();
        
        }


        public string InicializarConexionDA(string server, string port, string user_id, string password, string database)
        {
            return databaseAccess.CrearEnlaceDeConexion(server, port, user_id, password,database);  
        }

        // Validación de la conexión
        private string ValidarConexion()
        {
            if (connectionString == null)
            {
                return "Debe inicializar la  datos de conexión antes de realizar operaciones con la base de datos.";
            }
            return connectionString;
        }


        public string TestConnect()
        {
            var c_String = ValidarConexion();
            try
            {
                using (var conn = new NpgsqlConnection(c_String))
                {
                    conn.Open();
                    conn.Close();
                    return "La prueba de conexion fue exitosa lista para realizar operaciones...";
                }
            }
            catch 
            {
                // Handle connection errors
                return c_String;
            }
        }

        // Métodos CRUD

        public string InsertarPersonaDA(string rut, string nombre1, string nombre2, string nombre3, string apaterno, string amaterno, string fecha_nacimiento, int g_id_fk, string clave)
        {
            var c_String = ValidarConexion();
            try
            {
               
                using (var conn = new NpgsqlConnection(c_String))
                {
                    conn.Open();

                    using (var cmdInsertPerson = new NpgsqlCommand("INSERT INTO public.personas (rut, nombre1, nombre2, nombre3, apaterno, amaterno, fecha_nacimiento, g_id_fk) VALUES (@rut, @nombre1, @nombre2, @nombre3, @apaterno, @amaterno, @fecha_nacimiento, @g_id_fk)", conn))
                    {
                        // Utilizar parámetros para prevenir inyecciones SQL
                        cmdInsertPerson.Parameters.AddWithValue("@rut", rut);
                        cmdInsertPerson.Parameters.AddWithValue("@nombre1", nombre1);
                        cmdInsertPerson.Parameters.AddWithValue("@nombre2", nombre2);
                        cmdInsertPerson.Parameters.AddWithValue("@nombre3", nombre3);
                        cmdInsertPerson.Parameters.AddWithValue("@apaterno", apaterno);
                        cmdInsertPerson.Parameters.AddWithValue("@amaterno", amaterno);
                        cmdInsertPerson.Parameters.AddWithValue("@fecha_nacimiento", DateTime.Parse(fecha_nacimiento)); // Convertir la fecha de nacimiento a tipo DateTime
                        cmdInsertPerson.Parameters.AddWithValue("@g_id_fk", g_id_fk);

                        

                        try
                        {
                            cmdInsertPerson.ExecuteNonQuery();
                            
                            CredencialsAcces.InsertarCredenciales(rut, clave,conn);

                            return $"Nueva persona Registrada con el nombre de {nombre1} {apaterno} y rut {rut} Correctamente...";
                        }
                        catch (NpgsqlException ex)
                        {


                            if (ex.ErrorCode == -2147467259) // Código de error para clave única violada
                            {
                                return $"El RUT {rut} ya se encuentra registrado.";
                            }
                            else
                            {
                                return $"Error Inesperado: {ex.Message}"; // Re-lanzar la excepción para otros errores
                            }
                        }

                    }

                }
            }
            catch
            {
                return c_String;
            }
        }





        public string EliminarPersonaDA(string rut)
        {
            PersonaBE data_persona;

            using (var conn = new NpgsqlConnection(ValidarConexion()))
            {
                conn.Open();

                using (var cmdSelect = new NpgsqlCommand("SELECT nombre1, nombre2 FROM public.personas WHERE rut = @rut", conn))
                {
                    cmdSelect.Parameters.AddWithValue("@rut", rut);
                    using (var reader = cmdSelect.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            data_persona = new PersonaBE
                            {
                                PrimerNombre = reader["nombre1"].ToString(),
                                SegundoNombre = reader["nombre2"].ToString(),
                                Rut = rut
                            };
                        }
                        else
                        {
                            return $"Usuario con rut: {rut} no encontrado en la base de datos...";
                        }
                    }
                }

                // Luego, realizamos la eliminación
                using (var cmdDelete = new NpgsqlCommand("DELETE FROM public.personas WHERE rut = @rut", conn))
                {
                    cmdDelete.Parameters.AddWithValue("@rut", rut);

                    try
                    {
                        cmdDelete.ExecuteNonQuery();
                        return $"Usuario {data_persona.PrimerNombre} con RUT: {rut} fue borrado de la base de datos...";
                    }
                    catch (Exception ex)
                    {
                        return $"Error inesperado: {ex.Message}";
                    }

                }
            }
        }



        public string EditarPersonaDA(string rut, string nombre1, string nombre2, string nombre3, string apaterno, string amaterno, string fecha_nacimiento, int g_id_fk)
        {
            //Instancia para acceder a los datos y jugar con ellos
            PersonaBE data_persona;

            using (var conn = new NpgsqlConnection(ValidarConexion())) 
            {
                conn.Open();

                //Validacion si existe ese usuario
                using (var cmdSelect = new NpgsqlCommand("SELECT * FROM public.personas WHERE rut = @rut", conn))
                {
                    cmdSelect.Parameters.AddWithValue("@rut", rut);
                    using (var reader = cmdSelect.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            data_persona = new PersonaBE
                            {
                                PrimerNombre = reader["nombre1"].ToString(),
                                SegundoNombre = reader["nombre2"].ToString(),
                                Rut = reader["rut"].ToString(),

                            };
                        }
                        else
                        {
                            return $"Usuario con rut: {rut} no encontrado en la base de datos...";
                        }
                    }
                }

                using (var cmdUpdate = new NpgsqlCommand("UPDATE public.personas SET rut = @rut, nombre1 = @nombre1, nombre2 = @nombre2, nombre3 = @nombre3, apaterno = @apaterno, amaterno = @amaterno, fecha_nacimiento = @fecha_nacimiento WHERE rut = @rut", conn))
                {
                    // Utilizar parámetros para prevenir inyecciones SQL
                    cmdUpdate.Parameters.AddWithValue("@rut", rut);
                    cmdUpdate.Parameters.AddWithValue("@nombre1", nombre1);
                    cmdUpdate.Parameters.AddWithValue("@nombre2", nombre2);
                    cmdUpdate.Parameters.AddWithValue("@nombre3", nombre3);
                    cmdUpdate.Parameters.AddWithValue("@apaterno", apaterno);
                    cmdUpdate.Parameters.AddWithValue("@amaterno", amaterno);
                    cmdUpdate.Parameters.AddWithValue("@fecha_nacimiento", DateTime.Parse(fecha_nacimiento)); // Convertir la fecha de nacimiento a tipo DateTime
                    cmdUpdate.Parameters.AddWithValue("@g_id_fk", g_id_fk);

                    try
                    {
                        cmdUpdate.ExecuteNonQuery();

                        return $"Campos del RUT: {data_persona.Rut} del usuario {data_persona.NombreCompleto} actualizados correctamente...";
                    }
                    catch (Exception ex)
                    {
                        return $"Lamentamos que haya una exepcion, descripcion: {ex.Message}";
                    }

                }

            }

        }
    





        public PersonaBE ObtenerPersonaPorRut(string rut)
        {
            try
            {
                using (var conn = new NpgsqlConnection(ValidarConexion()))
                {
                    conn.Open();

                    var cmd = new NpgsqlCommand($"SELECT  rut, nombre1, nombre2, nombre3, apaterno, amaterno, fecha_nacimiento, g_id_fk FROM public.personas WHERE rut = @rut", conn);
                    cmd.Parameters.AddWithValue("@rut", rut); // Previene SQL injection

                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            r.Read();
       

                            PersonaBE persona = new PersonaBE
                            {
                                PrimerNombre = r["nombre1"].ToString(),
                                SegundoNombre= r["nombre2"].ToString(),
                                TercerNombre = string.IsNullOrEmpty(r["nombre3"].ToString()) ? null : r["nombre3"].ToString(), // Enviar null si nombre3 está vacío
                                ApPaterno = r["apaterno"].ToString(),
                                ApMaterno = r["amaterno"].ToString(),
                                Rut = r["rut"].ToString(),
                                Genero = Int32.Parse(r["g_id_fk"].ToString()),
                                FechaNacimiento = r["fecha_nacimiento"].ToString(),
                            };

                            return persona;

                        }
                        else
                        {
                            return null; // Persona no encontrada
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar persona por RUT: " + ex.Message);
            }
        }

        public DataTable GetAllPersonasDA(DataTable table)
        {
            
            try
            {
                using (var conn = new NpgsqlConnection(ValidarConexion()))
                {
                    conn.Open();

                    var cmd = new NpgsqlCommand("select p.rut, p.nombre1, p.nombre2, p.nombre3, p.apaterno, p.amaterno, p.fecha_nacimiento, g.descripcion\r\nfrom personas p \r\njoin generos g ON g.g_id = p.g_id_fk\r\n", conn);

                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                table.Rows.Add(
                                    r[0], // rut                          
                                    r[1], // nombre1
                                    r[2], // nombre1
                                    r[3], // nombre1
                                    r[4], // apaterno
                                    r[5], // amaterno
                                    r[6], // fecha
                                    r[7] // genero
                                );
                            }
                            return table;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch 
            {
                return null;
            }
        }

        public int EstadoPersona(string rut)
        {
            try
            {
                using (var conn = new NpgsqlConnection(ValidarConexion()))
                {
                    conn.Open();
                    return CredencialsAcces.ObtenerEstado(rut, conn);
                }
            }
            catch
            {
                return 0;
            }
        }

        public string DesencadenarClave(string rut)
        {
            using (var conn = new NpgsqlConnection(ValidarConexion()))
            {
                conn.Open();
                var res_clave = CredencialsAcces.ClaveCifrada(rut,conn);

                byte[] clave_resuelta = Convert.FromBase64String(res_clave);
                string clave_final = System.Text.Encoding.Unicode.GetString(clave_resuelta);
                return clave_final;
            }
        }


    }
}
