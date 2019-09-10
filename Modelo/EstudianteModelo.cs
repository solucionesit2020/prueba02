using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class EstudianteModelo
    {
        public int Id { get; set; }
        [Display(Name="Primer Nombre")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string PrimerNombre { get; set; }
        [Display(Name = "Primer Apellido")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string PrimerApellido { get; set; }
        [Display(Name = "Nombre Completo")]
        public string NombreCompleto { get; set; }
        [Display(Name = "Correo")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Email { get; set; }
        [Display(Name = "Identififación")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string NoIdentifacion { get; set; }
    }
}
