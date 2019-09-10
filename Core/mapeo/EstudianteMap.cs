using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Core.mapeo
{
    public class EstudianteMap:EntityTypeConfiguration<Estudiante>
    {

        public EstudianteMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.PrimerNombre).IsRequired();
            Property(t => t.PrimerApellido).IsRequired();
            Property(t => t.email).IsRequired();
            Property(t => t.NoIdentificacion).IsRequired();
            ToTable("Estudiante");
        }

    }
}
