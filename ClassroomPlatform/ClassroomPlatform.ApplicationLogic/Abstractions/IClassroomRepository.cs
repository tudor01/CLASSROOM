using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Abstractions
{
    public interface IClassroomRepository : IBaseRepository<Classroom>
    {
        EndUserClassroom AddEndUser(EndUserClassroom endUserClassroom);
        bool RemoveEndUser(Guid id);
        EndUserClassroom UpdateEndUser(EndUserClassroom endUserClassroom);
        IEnumerable<Classroom> GetAllForUser(Guid endUserId);
        IEnumerable<EndUserClassroom> GetAllEndUserClassrooms(Guid id);
    }
}
