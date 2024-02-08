using Proyecto.DA;
using System;
using System.Data;


namespace Proyecto.BL
{
    public class PersonaBL
    {
        private static PersonaBL _instance;

        public static PersonaBL Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new PersonaBL();
                }
                return _instance;
            }
        }

        private PersonaDA dataAccess;

        public PersonaBL()
        {
            dataAccess = new PersonaDA();
        }

        public string InsertarDataConexionBL(string server, string port, string user_id, string password, string database)
        {
            try
            {
                var errores = ValidacionesBL.Val_Param_DB(server, port,user_id,password,database);
                if( errores.Count > 0)
                {
                    //Mostrar mensaje error
                    return string.Format("<script>alert('Los siguientes campos faltan: {0}');</script>", string.Join(" , ", errores));
                }

                return dataAccess.InicializarConexionDA(server, port, user_id, password, database);
            }
            catch (Exception ex)
            {
                return $"Error con los datos de entrada al conectar a la base de datos: {ex.Message}";
            }
        }

        public string TestConnect()
        {
            var response = dataAccess.TestConnect();
            
            return response;
        }


        //crud
        public string RegistrarPersonaBL(string rut, string nombre1, string nombre2, string nombre3, string apaterno, string amaterno, string fecha_nacimiento, int g_id_fk, string clave)
        {
            PersonaBE persona;

            var errores = ValidacionesBL.ValidarCamposPersona(rut,nombre1,nombre2,nombre3,apaterno,amaterno,fecha_nacimiento,g_id_fk,clave);
            if (errores.Count > 0)
            {
                //Mostrar mensaje error
                return string.Format("<script>alert('Los siguientes campos faltan: {0}');</script>", string.Join(" , ", errores));

            }
            else
            {
                //Sino entonces guardas data como entidad y mandas la info a la db
                persona = new PersonaBE
                {
                    Rut = rut,
                    PrimerNombre = nombre1,
                    SegundoNombre = nombre2,
                    TercerNombre = nombre3,                        
                    ApMaterno = amaterno,
                    ApPaterno = apaterno,
                    FechaNacimiento = fecha_nacimiento,
                    Genero = g_id_fk,
                    Contrasena = clave
                };
            }

            string response = dataAccess.InsertarPersonaDA(persona.Rut, persona.PrimerNombre, persona.SegundoNombre, persona.TercerNombre, persona.ApPaterno, persona.ApMaterno, persona.FechaNacimiento, persona.Genero, persona.Contrasena);

            return $"<script>alert('{response}');</script>";
        }

        public string EditarPersonaBL(string rut, string nombre1, string nombre2, string nombre3, string apaterno, string amaterno, string fecha_nacimiento, int g_id_fk)
        {
            try
            {
                var persona = new PersonaBE
                {
                    Rut = rut,
                    PrimerNombre = nombre1,
                    SegundoNombre = nombre2,
                    TercerNombre = nombre3,
                    ApMaterno = amaterno,
                    ApPaterno = apaterno,
                    FechaNacimiento = fecha_nacimiento,
                    Genero = g_id_fk,
                };

                return dataAccess.EditarPersonaDA(persona.Rut,persona.PrimerNombre,persona.SegundoNombre,persona.TercerNombre,persona.ApPaterno,persona.ApMaterno,persona.FechaNacimiento,persona.Genero);

 

            }
            catch (Exception ex)
            {
                return $"Error: {ex}";
            }
        }


        public string EliminarPersonaBL(string rut)
        {

                bool val_rut = ValidacionesBL.ValidarRut(rut);
                // Validar el formato del RUT
                if (!val_rut)
                {
                    return "Formato de RUT incorrecto";
                }
                else
                {//Si el formato del rut es correcto entonces ahora verificamos si existe alguien con ese rut en la bd
                var rut_formateado = ValidacionesBL.FormatearRut(rut);
                    return dataAccess.EliminarPersonaDA(rut);             
                   
                }                 
        }


        public PersonaBE BuscarPorRut(string rut)
        {
            
            bool val_rut = ValidacionesBL.ValidarRut(rut);
            // Validar el formato del RUT
            if (!val_rut)
            {
                throw new Exception("Formato de RUT incorrecto");
            }
            else
            {// Llamar a la capa de acceso a datos para buscar la persona
                var respuesta = dataAccess.ObtenerPersonaPorRut(rut);
                return respuesta;
            }

        }


        public DataTable SendDataPersonas(DataTable table)
        {
            // Use a disposable pattern for proper reader management
            var response = dataAccess.GetAllPersonasDA(table);
            if (response != null)
            {
                return response;
            }
            else
            {
                return null;
            }


        }



        public PersonaBE IngresarUsuario(string rut, string clave)
        {
            int res_estado = dataAccess.EstadoPersona(rut);
            string clave_usuario = dataAccess.DesencadenarClave(rut);
            var usuario = BuscarPorRut(rut);

            if(usuario == null)
            {
                return null;
            }
            else
            {
                
                usuario.Estado = res_estado;
                usuario.Contrasena = clave_usuario;
                int edad_user = usuario.Edad;
                if (clave == usuario.Contrasena)
                {   

                    return usuario;
                }
                else
                {
                    return null;
                }
            }

          

        }

    }







}
