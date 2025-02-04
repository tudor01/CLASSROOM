﻿using ClassroomPlatform.ApplicationLogic.Abstractions;
using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.DataAccess.Repositories
{
    public class EFGradeRepository : EFBaseRepository<Grade>, IGradeRepository
    {
        public EFGradeRepository(ClassroomPlatformDbContext dbContext) : base(dbContext)
        {
        }

        public void AddMultipleGrades(List<Grade> gradeList)
        {
            dbContext.Grades.AddRange(gradeList);
            dbContext.SaveChanges();
        }

        public EndUserGrade UpdateEndUserGrade(EndUserGrade endUserGrade)
        {
            this.dbContext.EndUserGrades.Update(endUserGrade);
            this.dbContext.SaveChanges();
            return endUserGrade;
        }
    }
}
