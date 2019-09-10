using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Generico
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [Column(TypeName ="datetime2")]
        public DateTime FechaInsercion  { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime FechaModificacion { get; set; }
    }
}
