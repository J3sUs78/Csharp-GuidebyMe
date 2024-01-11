using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestingAPis : ControllerBase
    {
        [HttpGet("Getpapi")]
        public string Get() //metodo get generico que no recibe parametros
        {
            return "Hola mundo";
        }

        [HttpGet("GetSaludo/{nombre}")] //ruta para solicitar endpoint de esta api 
        public string Get(string nombre)
        {
            return $"Hola {nombre}";
        }


        private struct User
        {
            public string nombre;
            public string edad;
            public int id;

        }

        //devolver respuesta en formato json
        [HttpGet("GetUsuario/{id}/{nombre}/{edad}")]
        public string Get(int id, string nombre, string edad)
        {
            User user = new User();
            user.nombre = nombre;
            user.edad = edad;
            user.id = id;

            string res = JsonConvert.SerializeObject(user);
            return res;
        }

        public class UsuarioP
        {
            public int id { get; set;}
            public string nombre { get; set;}
        }

        [HttpPost("PostUser")]
        public string Post(UsuarioP user)
        {
            return JsonConvert.SerializeObject(user);
        }


        [HttpPatch("UpdateUser")]
        public string Patch(UsuarioP user)
        {
            return "Actualizado correctamente...";
        }

        [HttpDelete("DelUser")]
        public string Delete(int id_user)
        {
            return "Se elimino correctamente...";
        }
    }
}
