using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Contact
    {
        [Required (ErrorMessage = "Ingrese un Nombre, por favor.")]
        [Display(Name = "Nombre Completo")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Ingrese un Telefono, por favor.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Required (ErrorMessage = "Ingrese un Correo Electronico, por favor.")]
        [DataType(DataType.EmailAddress), EmailAddress(ErrorMessage = "El {0} no es un e-mail valido.")]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [Required (ErrorMessage = "Ingrese un Mensaje de Consulta, por favor.")]
        [DataType(DataType.Text)]
        [Display(Name = "Mensaje")]
        [StringLength(100, ErrorMessage = "El {0} debe contener al menos {2} caracteres.", MinimumLength = 6)]
        public string Message { get; set; }
    }
}