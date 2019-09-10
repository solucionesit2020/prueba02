using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface  IEstudianteRep
    {
        IEnumerable<EstudianteModelo> GetallEstudiante();
        EstudianteModelo GetById(int id);
        void AddEdditEstudiante(bool id, EstudianteModelo estudiante);
        void DeleteEstudiante(int id);


    }
}
