using System;

namespace ConnectionDatabase
{
    internal class UserModel
    {
        // Propiedades privadas con convención CamelCase
        private string nombre;
        private int edad;
        private string comuna;

        // Propiedad pública para el nombre con validación básica
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nombre = value;
                }
                else
                {
                    Console.WriteLine("Nombre no válido. Debe tener un valor.");
                }
            }
        }

        // Propiedad pública para la edad con validación básica
        public int Edad
        {
            get { return edad; }
            set
            {
                if (value >= 0)
                {
                    edad = value;
                }
                else
                {
                    Console.WriteLine("Edad no válida. Debe ser un número entero no negativo.");
                }
            }
        }

        // Propiedad pública para la comuna con validación básica
        public string Comuna
        {
            get { return comuna; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    comuna = value;
                }
                else
                {
                    Console.WriteLine("Comuna no válida. Debe tener un valor.");
                }
            }
        }

        // Constructor para inicializar el modelo con valores predeterminados
        public UserModel(string nombre, int edad, string comuna)
        {
            // Se pueden agregar más validaciones según sea necesario
            Nombre = nombre;
            Edad = edad;
            Comuna = comuna;
        }
    }
}
