using Core.Interfaces;
using Modelo;
using Servicio.Generico;
using Servicio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Clases
{
    public class EstudianteService : Service, IEstudianteService
    {
        public EstudianteService(IUnitOfwork uow):base(uow)
        {

        }
        public void AddEdditEstudiante(bool id, EstudianteModelo estudiante)
        {
             _IEstud.AddEdditEstudiante(id, estudiante);
        }

        public void DeleteEstudiante(int id)
        {
            _IEstud.DeleteEstudiante(id);
        }

        public IEnumerable<EstudianteModelo> GetAllEstudiante()
        {
            return _IEstud.GetallEstudiante();
        }

        public EstudianteModelo GetByIdEstudiante(int id)
        {
            return _IEstud.GetById(id);
        }
    }
}
