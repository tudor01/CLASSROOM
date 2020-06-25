using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Abstractions
{
    public interface IBaseRepository<T> where T : DataEntity
    {
        T Add(T entity);
        T Update(T entity);
        bool Remove(Guid id);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
    }
}
