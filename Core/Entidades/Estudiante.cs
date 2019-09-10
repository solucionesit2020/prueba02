using Core.Generico;

namespace Core.Entidades
{
    public class Estudiante:BaseEntity
    {
      
        public string PrimerNombre { get; set; }      
        public string PrimerApellido { get; set; }          
        public string email { get; set; }    
        public string NoIdentificacion { get; set; }
    }
}
