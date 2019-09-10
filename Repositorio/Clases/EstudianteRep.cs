using Core.Entidades;
using Core.Estructura;
using Core.Interfaces;
using Modelo;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Clases
{
    public class EstudianteRep : IEstudianteRep
    {
        private IUnitOfwork _uow;
        private Repository<Estudiante> _estudianteRep;

        public EstudianteRep(IUnitOfwork uow)
        {
            _uow = uow;
            _estudianteRep = _uow.Repository<Estudiante>();
        }


        public void AddEdditEstudiante(bool isNew, EstudianteModelo estudiante)
        {

            var modelEst = new Estudiante
            {
                PrimerNombre = estudiante.PrimerNombre,
                PrimerApellido = estudiante.PrimerApellido,
                email = estudiante.Email,
                NoIdentificacion = estudiante.NoIdentifacion
            };

            if (isNew)
            {
                modelEst.FechaInsercion = DateTime.UtcNow;
                modelEst.FechaModificacion = DateTime.UtcNow;
                _estudianteRep.Insert(modelEst);
            }
            else
            {
                var updateEst = _estudianteRep.GetById((int)estudiante.Id);

                updateEst.FechaInsercion = DateTime.UtcNow;
                updateEst.FechaModificacion = DateTime.UtcNow;
                updateEst.PrimerNombre = estudiante.PrimerNombre;
                updateEst.PrimerApellido = estudiante.PrimerApellido;
                updateEst.email = estudiante.Email;
                updateEst.NoIdentificacion = estudiante.NoIdentifacion;
                _estudianteRep.Update(updateEst);

            }
           


        }

        public void DeleteEstudiante(int id)
        {
            var estudiante = _estudianteRep.GetById(id);
            _estudianteRep.Delete(estudiante);
        }

        public IEnumerable<EstudianteModelo> GetallEstudiante()
        {
            var estudiantes = _estudianteRep.Table.AsEnumerable().Select(c => new EstudianteModelo
            {
                Id = c.Id,
                NombreCompleto = $"{ c.PrimerNombre} {c.PrimerApellido}",
                Email = c.email,
                NoIdentifacion = c.NoIdentificacion

            });

            return estudiantes;
           
        }

        public EstudianteModelo GetById(int id)
        {

            var est = _estudianteRep.GetById(id);

            var model = new EstudianteModelo
            {
                PrimerNombre = est.PrimerNombre,
                PrimerApellido = est.PrimerApellido,
                Email = est.email,
                NoIdentifacion = est.NoIdentificacion
            };

            return model;

        }
    }
}
