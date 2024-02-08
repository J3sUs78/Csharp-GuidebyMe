
using System.ComponentModel.DataAnnotations;


namespace Proyecto.BE
{
    public class DatabaseConfigBE
    {
        [Required]
        public string Server { get; set; }

        [Required]
        public string Port { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
     
        public string Password { get; set; }

        [Required]
      
        public string Database { get; set; }

        
    }
}
