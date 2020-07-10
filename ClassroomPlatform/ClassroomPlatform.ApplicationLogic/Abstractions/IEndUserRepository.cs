using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Abstractions
{
    public interface IEndUserRepository : IBaseRepository<EndUser>    
    {
        EndUser GetByUserId(string userId);
        void AddMultipleEndUserGrades(List<EndUserGrade> endUserGrades);
        EndUserGrade GetEndUserGrade(Guid assigmentId, string userId);
        void UpdateEndUserGrade(EndUserGrade endUserGradeDb);
        IEnumerable<EndUserGrade> GetStudents(Guid assigmentId);
    }
}
