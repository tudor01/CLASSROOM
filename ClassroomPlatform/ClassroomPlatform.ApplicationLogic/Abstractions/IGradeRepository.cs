using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Abstractions
{
    public interface IGradeRepository : IBaseRepository<Grade>
    {
        EndUserGrade UpdateEndUserGrade(EndUserGrade endUserGrade);
        void AddMultipleGrades(List<Grade> gradeList);
    }
}
