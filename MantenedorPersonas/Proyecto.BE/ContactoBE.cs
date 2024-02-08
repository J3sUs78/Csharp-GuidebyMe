using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.BE
{
    public class ContactoBE
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdPersona { get; set; }

        [ForeignKey("IdPersona")]
        public PersonaBE Persona { get; set; }

        [Required]
        [MaxLength(255)]
        public string Direccion { get; set; }

        [MaxLength(15)]
        public string Telefono { get; set; }

        [MaxLength(255)]
        public string CorreoElectronico { get; set; }
    }
}
