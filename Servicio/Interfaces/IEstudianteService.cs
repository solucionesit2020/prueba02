using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Interfaces
{
    public interface  IEstudianteService
    {
        IEnumerable<EstudianteModelo> GetAllEstudiante();
        EstudianteModelo GetByIdEstudiante(int id);
        void AddEdditEstudiante(bool id, EstudianteModelo estudiante);
        void DeleteEstudiante(int id);

    }
}
