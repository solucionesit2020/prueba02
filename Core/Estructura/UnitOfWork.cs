using Core.Generico;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Estructura
{
    public class UnitOfWork : IUnitOfwork
    {
        private readonly AxDbContext context;
        private bool disposed;
        private Dictionary<string, object> repositorios;

        public UnitOfWork(AxDbContext context)
        {
            this.context = context;
        }

        public UnitOfWork()
        {
            context = new AxDbContext();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
        public Repository<T> Repository<T>() where T : BaseEntity
        {
          
            if (repositorios == null)
            {
                repositorios = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!repositorios.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
                repositorios.Add(type, repositoryInstance);

            }

            return (Repository<T>) repositorios[type];

        }

        public void save()
        {
            this.context.SaveChanges();
        }
    }
}
