using Core.Estructura;
using Core.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
  public interface IUnitOfwork:IDisposable
    {
        void save();
        Repository<T> Repository<T>() where T : BaseEntity;


    }
}
