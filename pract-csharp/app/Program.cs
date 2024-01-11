using System;

//con alt + z puedes activar el word wrap para que tu codigo se vea mas legible

namespace CsharpMouredev
{
    class Tutorial
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            string telf = "5696632";
            string color = "rojo";

            int entero = 100;
            float numDecimal = 1.976462F;

            bool autorizado = true;
            bool seleccionado = false;

            //lista que ocupan un espacio en memoria que no se puede cambiar
            int [] numeros = {22,11,441,51,552,2};
            Console.WriteLine(numeros[2]);

            //lista dinamica que puede cambiar de tamaño
            List<string> names = new List<string> {"yisu", "yisu2"};
            //ver todos los elementos unidos por un texto
            Console.WriteLine(string.Join(" , ",names));

            //lista de datos mixtos
            dynamic[] datosMixtos = {"hooa", 22,true, string.Join(" , ", names)};
            Console.WriteLine(string.Join(" , ",datosMixtos));

            //Diccionario , mapas y objetos
            Dictionary<int, string> players = new Dictionary<int, string>();
            players.Add(10,"Messi");
            players.Add(7, "Cristiano Ronaldo");
            Console.WriteLine(players[10]);
            //creacion del diccionario
            Dictionary<string,string> paises = new Dictionary<string, string>();
            paises.Add("CL","Chile");
            paises.Add("MX","Mexico");
            paises.Add("AR","Argentina");

            //mapear de texto a una lista
            Dictionary<string, string[]> emails = new Dictionary<string, string[]>();
            string[] emailsJuan = {"Juan@gmail.com"};
            emails.Add("Juan",emailsJuan);
            string[] emailsRicardo = {"Ricardito@gmail.com","RIcardon31@hotmail.com"};
            emails.Add("Ricardo",emailsRicardo);

            int sumar(int a, int b)
            {
                return a+b;
            }

            int result = sumar(33,5);
            Console.WriteLine(result);

            //si la funcion no retorna nada entonces, se le agrega de tipo void
            void multiplicar(int a, int b)
            {
                Console.WriteLine(a*b);
            }

            multiplicar(entero,3);

            //funcion que solo muestra el primer elemento de una lista
            void printFirstElement(dynamic[] list)
            {
                Console.WriteLine(list[0]);
            }

            printFirstElement(datosMixtos);

            //recorrer una lista y devolverla ordenada
            List<int> quicksort(List<int> lista)
            {
                if(lista.Count <= 1)
                {
                    return lista;
                }
                int pivote = lista[0];
                List<int> izquierda = new List<int>();
                List<int> derecha = new List<int>();
                for (int i = 1; i < lista.Count; i++)
                {
                    if(lista[i] < pivote)
                    {
                        izquierda.Add(lista[i]);
                    }
                    else
                    {
                        derecha.Add(lista[i]);
                    }
                }

                List<int> primero  = quicksort(izquierda);
                List<int> medio  = new List<int>{pivote};
                List<int> segundo  = quicksort(derecha);
                primero.AddRange(medio);
                primero.AddRange(segundo);
                return primero;
            }

            Lenguaje html = new Lenguaje("HTML", 1993);

            html.descripcion();
        
            dynamic myDinamic = 6;
            myDinamic = "Dato cambiado de int a String";

            //C# opuede inferri el tipo de dato pero se define con un solo tipo de dato
            var myVar = 6.2;
            //myVar = "da"; error
            //Console.WriteLine(myVar);

            Console.WriteLine($"Valor {string.Join(", ",emails["Ricardo"][1])} y valor de {players[10]}");


            //Crear constantes se debe tipear el tipo de variable
            const string myConst = "Constante";
            Console.WriteLine(myConst);


            //Estructuras de listas se debe igualmente describir el tipo de que sera esa array
            var myArray = new string[] {"a","b","c"};

            //Crear diccionario de manera asignada a una variable
            var myDict = new Dictionary<string, int>
            {
                {"a",3},
                {"b",5}
            };
            Console.WriteLine(myDict["b"]);

            //SET pueded recordar a una lista pero este, salta los valores repetidos
            
            /*
                En este ejemplo, se crea un HashSet de strings mySet con elementos "a", "b", "c" y "c". 
                Al imprimir los elementos de mySet, se eliminarán los duplicados automáticamente 
                y se mostrarán solo los elementos únicos ("a", "b" y "c").
            */
            var mySet = new HashSet<string> {"a","b","c","c"};
            Console.WriteLine(mySet);


            /*
            
            Tuple es una estructura que permite agrupar un número fijo de elementos de diferentes tipos en una sola entidad
            
            */

            //TUPLAS que guarda ciertos elementos
            var myTuple = ("Hello", 5, true);
            Console.WriteLine(myTuple.Item2);

            //BUCLES
            for(int i = 0; i <10; i++)
            {

            }

            foreach (var item in emails)
            {
                Console.WriteLine($"Clave: {item.Key}, Email(es): {string.Join(", ", item.Value)}");
            }

            MyVoidFunction();
            Console.WriteLine(MyFunctionWithReturn(30));

            var myClass = new MyClass("Jesus",20);
            Console.WriteLine(myClass);

        } //FIN MAIN


        //Funciones
        static void MyVoidFunction()
        {
            Console.WriteLine("Mi funcion esta fuera dde main y no devuelve nada.... de ningun tipo");

        }

        static int MyFunctionWithReturn(int param)
        {
            //funcion tipo entero recibe un entero y retorna un resultado....
            return 10 + param;
        }

        class MyClass
        {
            //atributo normal
            public string myName {get; set;}

            //atributo con propiedades get y set
            public int myAge {get; set;}

            public  MyClass(string MycurrentName, int MycurrentAge)
            {
                myName = MycurrentName;
                myAge = MycurrentAge;
            }

            public override string ToString()
            {
                return $"Nombre: {myName}, Edad: {myAge}";
            }
        }

    } //FIN CLASS
}