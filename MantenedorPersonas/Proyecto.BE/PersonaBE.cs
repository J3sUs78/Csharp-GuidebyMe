using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PersonaBE
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(12)]
    [RegularExpression(@"^[0-9]{8}-[0-9K]$")] // Enforce Chilean RUT format
    public string Rut { get; set; }

    [Required]
    [MaxLength(50)]
    public string PrimerNombre { get; set; }

    [Required]
    [MaxLength(50)]
    public string SegundoNombre { get; set; }

    [MaxLength(50)]
    public string TercerNombre { get; set; }

    [Required]
    [MaxLength(50)]
    public string ApPaterno { get; set; }

    [MaxLength(50)]
    public string ApMaterno { get; set; }

    [NotMapped] // Esto indica a Entity Framework que no debe mapear este atributo a la base de datos
    public int Edad => DateTime.Today.Year - DateTime.Parse(FechaNacimiento).Year - (DateTime.Today.Month < DateTime.Parse(FechaNacimiento).Month && DateTime.Today.Day < DateTime.Parse(FechaNacimiento).Day ? 1 : 0);


    [Required]
    [DataType(DataType.Date)] // Specify date data type for validation
    public string FechaNacimiento { get; set; }

    [Required]
    public int Genero { get; set; }

    
    public int Rol {  get; set; }


    public int Estado {  get; set; }




    [MaxLength(255)]
    [DataType(DataType.Password)] // Indicate password field for UI masking
    public string Contrasena { get; set; }

    public string NombreCompleto
    {
        get
        {
            if (string.IsNullOrEmpty(TercerNombre))
            {
                return $"{PrimerNombre} {SegundoNombre} {ApPaterno} {ApMaterno}";
            }
            else
            {
                return $"{PrimerNombre} {SegundoNombre} {TercerNombre} {ApPaterno} {ApMaterno}";
            }
        }
    }

    public string GeneroNombre()
    {
        switch (Genero)
        {
            case 1:
                return "Masculino";
            case 2:
                return "Femenino";
            default:
                return null;
        }
    }

    public string MandaData()
    {
        return $"Rut: {Rut}\n" +
               $"Nombre completo: {NombreCompleto}\n" +
               $"Edad: {Edad}\n" +
               $"Fecha de nacimiento: {FechaNacimiento}\n" +
               $"Género: {GeneroNombre()}\n" +
               $"Contraseña: {Contrasena}";
    }




}