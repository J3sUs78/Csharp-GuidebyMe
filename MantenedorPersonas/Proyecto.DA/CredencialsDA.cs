

using Npgsql;
using System;

namespace Proyecto.DA
{
    public class CredencialsDA
    {

        public bool InsertarCredenciales(string rut_fk, string clave, NpgsqlConnection conn)
        {

            using (var cmdInsertCredencials = new NpgsqlCommand("INSERT INTO public.credenciales_sesion (credencial_uuid, rut_fk, status_fk, clave) VALUES (uuid_generate_v4(), @rut_fk, 2, @clave)",conn)) 
            { 

                cmdInsertCredencials.Parameters.AddWithValue("rut_fk", rut_fk);
                cmdInsertCredencials.Parameters.AddWithValue("clave", clave);

                try
                {
                    cmdInsertCredencials.ExecuteNonQuery();
                    return true;

                }catch
                {
                    return false;
                }

            }



        }

        public int ObtenerEstado(string rut, NpgsqlConnection conn)
        {
            int state;
            using (var cmdBuscarEstado = new NpgsqlCommand("SELECT cs.status_fk FROM credenciales_sesion cs JOIN personas p ON p.rut = cs.rut_fk WHERE cs.rut_fk = @rut", conn))
            {

                cmdBuscarEstado.Parameters.AddWithValue("rut", rut);

                using (var lector = cmdBuscarEstado.ExecuteReader())
                {
                    if(lector.Read())
                    {
                        state = (int)lector["status_fk"];



                        switch (state)
                        {
                            case 1:
                                return 1;
                            case 2:
                                return 2;
                        }


                    }
                    else
                    {
                        return 0;
                    }
                }

            }
            return 0;


        }

        public string ClaveCifrada(string rut, NpgsqlConnection conn)
        {
            // Handle potential errors and user feedback:
            try
            {
                using (var cmdBuscarEstado = new NpgsqlCommand("SELECT clave FROM credenciales_sesion  WHERE rut_fk = @rut", conn))
                {
                    cmdBuscarEstado.Parameters.AddWithValue("@rut", rut);

                    using (var lector = cmdBuscarEstado.ExecuteReader())
                    {
                        // Check if user exists and has a clave:
                        if (lector.Read())
                        {
                            var res_clave = lector["clave"].ToString();
                            return res_clave;
                        }
                        else
                        {
                            // Inform user if their RUT is not found or has no clave:
                            return "Clave no encontrada. Verifique su RUT o contáctese con el administrador.";
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                // Handle database errors gracefully:
                return "Error al acceder a la base de datos. Inténtelo nuevamente más tarde o contáctese con el administrador."+ex.Message;
            }
        }




    }
}
