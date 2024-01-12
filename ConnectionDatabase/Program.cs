using System;
using System.Collections.Generic;

namespace ConnectionDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;

            UserModel user = ValidInputs();

            if (user != null)
            {
                // Crear la conexión y la consulta con los datos del usuario
                ConnectionController controllerDb = new ConnectionController();
                controllerDb.InsertarUsuario(user.Nombre, user.Comuna, user.Edad);

                Console.WriteLine("Se insertaron correctamente los datos en la Base de datos...");
                Console.WriteLine();
                Console.WriteLine("¿Deseas mostrar los datos insertados? (Y/N)");

                bool inputValido = false;
                while (!inputValido)
                {
                    string response = Console.ReadLine().Trim().ToUpper();

                    switch (response)
                    {
                        case "Y":
                            Console.WriteLine("Los datos del Usuario insertado son: ");
                            List<UserModel> usuarios = controllerDb.ObtenerTodosUsuarios();
                            foreach (var usuario in usuarios)
                            {
                                Console.WriteLine($"Nombre: {usuario.Nombre}, Edad: {usuario.Edad}, Comuna: {usuario.Comuna}");
                            }
                            inputValido = true;
                            break;

                        case "N":
                            inputValido = true;
                            break;

                        default:
                            Console.WriteLine("Entrada no válida. Por favor, ingresa 'Y' o 'N':");
                            break;
                    }
                }
            }
        }

        public static UserModel ValidInputs()
        {
            string nombre, comuna;
            int edad;

            // Solicitar nombre al usuario
            Console.WriteLine("Hola, Por favor ingresa tu nombre: ");
            nombre = Console.ReadLine();

            // Solicitar edad al usuario
            Console.WriteLine("Ingresa tu edad: ");
            while (!int.TryParse(Console.ReadLine(), out edad) || edad < 0)
            {
                Console.WriteLine("Edad inválida. Por favor ingresa un número entero no negativo.");
            }

            // Solicitar comuna al usuario
            Console.WriteLine("Ingresa tu comuna: ");
            comuna = Console.ReadLine();

            // Validar que se ingresaron todos los datos
            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(comuna))
            {
                return new UserModel(nombre, edad, comuna);
            }
            else
            {
                Console.WriteLine("Faltan datos. Por favor, ingresa todos los datos correctamente.");
                return null;
            }
        }
    }
}
