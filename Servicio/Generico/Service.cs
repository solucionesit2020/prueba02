using Core.Interfaces;
using Modelo;
using Repositorio.Clases;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Generico
{
    public abstract class Service
    {
        protected IEstudianteRep _estService;
        protected IUnitOfwork _uow;

        public Service(IUnitOfwork uow)
        {
            _uow = uow;

        }

        protected IEstudianteRep _IEstud => _estService ?? (_estService = new EstudianteRep(_uow));
    }
}
