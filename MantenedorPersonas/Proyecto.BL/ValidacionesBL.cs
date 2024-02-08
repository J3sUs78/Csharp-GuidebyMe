

using System.Collections.Generic;
using System;

namespace Proyecto.BL
{
    internal class ValidacionesBL
    {


        //VALIDACIONES
        public static List<string> ValidarCamposPersona(string rut, string nombre1, string nombre2, string nombre3, string apaterno, string amaterno, string fecha_nacimiento, int g_id_fk, string clave)
        {
            List<string> errores = new List<string>();


            // Validar RUT
            if (!ValidarRut(rut))
            {
                errores.Add("formato del RUT incorrecto");
            }
            else if (string.IsNullOrEmpty(rut))
            {
                errores.Add("RUT");
            }


            // Validar primer nombre
            if (string.IsNullOrEmpty(nombre1))
            {
                errores.Add("Primer nombre");
            }


            // Validar segundo nombre
            if (string.IsNullOrEmpty(nombre2))
            {
                errores.Add("Segundo nombre");
            }

            // Validar apellido paterno
            if (string.IsNullOrEmpty(apaterno))
            {
                errores.Add("Apellido paterno");
            }

            // Validar apellido materno
            if (string.IsNullOrEmpty(amaterno))
            {
                errores.Add("Apellido materno");
            }

            // Validar fecha de nacimiento (opcional)
            if (string.IsNullOrEmpty(fecha_nacimiento))
            {
                errores.Add("Fecha de nacimiento");

            }

            if (string.IsNullOrEmpty(clave))
            {
                errores.Add("Clave");
            }

            return errores;
        }

        public static List<string> Val_Param_DB(string server, string port, string user_id, string password, string database)
        {
            List<string> errores = new List<string>();

            // Validar servidor
            if (string.IsNullOrEmpty(server))
            {
                errores.Add("Servidor");
            }

            // Validar puerto
            if (string.IsNullOrEmpty(port))
            {
                errores.Add("Puerto");
            }
            else
            {
                try
                {
                    int.Parse(port);
                }
                catch (Exception)
                {
                    errores.Add("Puerto debe ser entero");
                }
            }

            // Validar usuario
            if (string.IsNullOrEmpty(user_id))
            {
                errores.Add("Usuario");
            }

            // Validar contraseña
            if (string.IsNullOrEmpty(password))
            {
                errores.Add("Contraseña");
            }
            else if (password.Length < 3)
            {
                errores.Add("Contraseña debe tener al menos 3 caracteres");
            }

            // Validar base de datos
            if (string.IsNullOrEmpty(database))
            {
                errores.Add("Base de datos");
            }

            return errores;
        }



        public static string FormatearRut(string rut)
        {
            // Validar el RUT antes de formatearlo
            if (!ValidarRut(rut))
            {
                return string.Empty; // O retornar un mensaje de error
            }

            // Eliminar puntos y guiones antes de formatear
            rut = rut.ToUpper().Replace(".", "").Replace("-", "");

            // Si el RUT tiene 8 dígitos, no se necesita formateo
            if (rut.Length == 8)
            {
                return rut;
            }

            // Insertar puntos y guion en las posiciones correctas
            if (rut.Length == 9)
            {
                return $"{rut.Substring(0, 2)}.{rut.Substring(2, 3)}.{rut.Substring(5, 3)}-{rut.Substring(8)}";
            }

            // Si el RUT tiene más de 9 dígitos, se considera inválido
            return string.Empty; // O retornar un mensaje de error
        }




        public static bool ValidarRut(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }

        public static string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
        }

    }
}
