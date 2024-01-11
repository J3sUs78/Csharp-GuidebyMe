using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;
using PatchExtension;

namespace PeticionesAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Función que realiza una petición GET a una URL específica
            await RealizarPeticionGet();

            // Función que realiza una petición POST a una URL específica
            await RealizarPeticionPost();
        }

        // Función para realizar una petición GET
        static async Task RealizarPeticionGet()
        {
            // Usando el objeto HttpClient para manejar la solicitud web
            using (var client = new HttpClient())
            {
                try
                {
                    // URL para la petición GET
                    string urlGet = "https://jsonplaceholder.typicode.com/posts/3";

                    // Limpiar los encabezados de solicitud
                    client.DefaultRequestHeaders.Clear();

                    // Enviar la solicitud GET y esperar la respuesta
                    var response = await client.GetAsync(urlGet);

                    // Verificar si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta
                        var res = await response.Content.ReadAsStringAsync();

                        // Analizar el contenido JSON de la respuesta
                        dynamic r = JObject.Parse(res);

                        // Mostrar el resultado en la consola
                        Console.WriteLine(r);
                    }
                    else
                    {
                        // Mostrar un mensaje si hay un error en la solicitud
                        Console.WriteLine($"Error en la solicitud GET: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    // Manejar cualquier error de solicitud HTTP
                    Console.WriteLine($"Error al enviar la solicitud GET: {ex.Message}");
                }
                catch (JsonException ex)
                {
                    // Manejar cualquier error al analizar la respuesta JSON
                    Console.WriteLine($"Error al parsear la respuesta GET: {ex.Message}");
                }
            }
        }

        // Función para realizar una petición POST
        static async Task RealizarPeticionPost()
        {
            // Usando el objeto HttpClient para manejar la solicitud web
            using (var client = new HttpClient())
            {
                try
                {
                    // URL para la petición POST
                    string urlPost = "https://jsonplaceholder.typicode.com/posts";

                    // Limpiar los encabezados de solicitud
                    client.DefaultRequestHeaders.Clear();

                    // Crear los parámetros del POST
                    var parameters = new
                    {
                        title = "pedro",
                        body = "hola bienvenido",
                        userId = 31
                    };

                    // Convertir los parámetros a formato JSON
                    var json = JsonConvert.SerializeObject(parameters);

                    // Crear el contenido de la solicitud POST
                    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                    // Enviar la solicitud POST y esperar la respuesta
                    var response = await client.PostAsync(urlPost, httpContent);

                    // Verificar si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta
                        var res = await response.Content.ReadAsStringAsync();

                        // Analizar el contenido JSON de la respuesta
                        dynamic r = JObject.Parse(res);

                        // Mostrar el resultado en la consola
                        Console.WriteLine(r);
                    }
                    else
                    {
                        // Mostrar un mensaje si hay un error en la solicitud
                        Console.WriteLine($"Error en la solicitudost: {response.StatusCode}");
                    }
                }
                catch(HttpRequestException ex)
                {
                    Console.WriteLine($"Error al enviar la solicitud POST: {ex.Message}");
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error al parsear la respuesta POST: {ex.Message}");
                }
            }
        }

        static async Task RealizarPeticionPut()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // URL para la petición PUT a un recurso específico (en este caso, el post 3)
                    string urlPut = "https://jsonplaceholder.typicode.com/posts/3";

                    // Limpiar los encabezados de solicitud
                    client.DefaultRequestHeaders.Clear();

                    // Crear los parámetros del PUT para actualizar el recurso
                    var parameters = new
                    {
                        title = "Nuevo título",
                        body = "Nuevo contenido del post",
                        userId = 31
                    };

                    // Convertir los parámetros a formato JSON
                    var json = JsonConvert.SerializeObject(parameters);

                    // Crear el contenido de la solicitud PUT
                    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                    // Enviar la solicitud PUT y esperar la respuesta
                    var response = await client.PutAsync(urlPut, httpContent);

                    // Verificar si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta
                        var res = await response.Content.ReadAsStringAsync();

                        // Analizar el contenido JSON de la respuesta
                        dynamic r = JObject.Parse(res);

                        // Mostrar el resultado en la consola
                        Console.WriteLine(r);
                    }
                    else
                    {
                        // Mostrar un mensaje si hay un error en la solicitud
                        Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error al enviar la solicitud PUT: {ex.Message}");
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error al parsear la respuesta PUT: {ex.Message}");
                }
            }
        }


        static async Task RealizarPeticionPatch()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // URL para la petición PATCH a un recurso específico
                    string urlPatch = "https://api.example.com/posts/1";

                    // Limpiar los encabezados de solicitud
                    client.DefaultRequestHeaders.Clear();

                    // Crear los parámetros del PATCH para actualizar parcialmente el recurso
                    var parameters = new
                    {
                        title = "Nuevo título",
                        // Otras propiedades que se desean modificar
                    };

                    // Convertir los parámetros a formato JSON
                    dynamic json = JsonConvert.SerializeObject(parameters);

                    // Crear el contenido de la solicitud PATCH
                    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                    // Enviar la solicitud PATCH y esperar la respuesta
                    var response = await client.PatchAsync(urlPatch, httpContent);

                    // Verificar si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta
                        var res = await response.Content.ReadAsStringAsync();

                        // Analizar el contenido JSON de la respuesta
                        dynamic r = JObject.Parse(res);

                        // Mostrar el resultado en la consola
                        Console.WriteLine(r);
                    }
                    else
                    {
                        // Mostrar un mensaje si hay un error en la solicitud
                        Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error al enviar la solicitud PATCH: {ex.Message}");
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error al parsear la respuesta PATCH: {ex.Message}");
                }
            }
        }

        
    }
}
