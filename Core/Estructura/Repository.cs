using Core.Generico;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Estructura
{
    public class Repository<T> where T: BaseEntity
    {

        private readonly AxDbContext context;
        private IDbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(AxDbContext context)
        {
            this.context = context;

        }
        private IDbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = context.Set<T>();
                }
                return entities;
            }
        }

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Add(entity);
                this.context.SaveChanges();



            }
            catch (DbEntityValidationException ex)
            {
                foreach(var errVal in ex.EntityValidationErrors)
                {

                    foreach(var errVal2 in errVal.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} error: {1}", errVal2.PropertyName, errVal2.PropertyName) + Environment.NewLine;
                            
                    }

                }

                throw new Exception(errorMessage, ex);


            }
           
              }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.context.SaveChanges();

            }catch(DbEntityValidationException ex)
            {
                foreach (var errVal in ex.EntityValidationErrors)
                {

                    foreach (var errVal2 in errVal.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} error: {1}", errVal2.PropertyName, errVal2.PropertyName) + Environment.NewLine;

                    }

                }

                throw new Exception(errorMessage, ex);

            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Remove(entity);
                this.context.SaveChanges();

            }catch (DbEntityValidationException ex)
            {
                foreach (var errVal in ex.EntityValidationErrors)
                {

                    foreach (var errVal2 in errVal.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} error: {1}", errVal2.PropertyName, errVal2.PropertyName) + Environment.NewLine;

                    }

                }

                throw new Exception(errorMessage, ex);

            }

        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }


        




    }
}
