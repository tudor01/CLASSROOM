using ClassroomPlatform.ApplicationLogic.Abstractions;
using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomPlatform.DataAccess.Repositories
{
    public class EFBaseRepository<T> : IBaseRepository<T> where T : DataEntity
    {
        protected readonly ClassroomPlatformDbContext dbContext;
        
        public EFBaseRepository(ClassroomPlatformDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T Add(T entity)
        {
            this.dbContext.Add<T>(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.dbContext.Set<T>().AsEnumerable();
        }

        public virtual T GetById(Guid id)
        {
            return this.dbContext.Set<T>()
                                 .Where(entity => entity.Id == id)
                                 .SingleOrDefault();
        }

        public bool Remove(Guid id)
        {
            var entityToRemove = GetById(id);

            if (entityToRemove != null)
            {
                this.dbContext.Remove<T>(entityToRemove);
                this.dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public T Update(T entity)
        {
            this.dbContext.Update<T>(entity);
            this.dbContext.SaveChanges();
            return entity;
        }
    }
}
