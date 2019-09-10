using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.mapeo;

namespace Core.Generico
{
    public class AxDbContext:DbContext
    {
        public AxDbContext():base("name=AxDbContext")
        {

        }
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EstudianteMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
