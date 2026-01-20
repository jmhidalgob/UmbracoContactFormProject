using System.ComponentModel.DataAnnotations;

namespace UmbracoContactFormProject.Models;

public class ContactFormViewModel 
{   
    [Required(ErrorMessage = "Por favor, introduce tu nombre")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Por favor, introduce tu correo electrónico")]
    [EmailAddress(ErrorMessage = "Introduce un email válido")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Por favor, introduce tu mensaje")]
    [StringLength(200, ErrorMessage = "El mensaje es demasiado largo")]
    public string Message { get; set; }
}