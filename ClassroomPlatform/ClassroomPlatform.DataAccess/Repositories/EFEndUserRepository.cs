using ClassroomPlatform.ApplicationLogic.Abstractions;
using ClassroomPlatform.ApplicationLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomPlatform.DataAccess.Repositories
{
    public class EFEndUserRepository : EFBaseRepository<EndUser>, IEndUserRepository
    {
        public EFEndUserRepository(ClassroomPlatformDbContext dbContext) : base(dbContext)
        {
        }

        public void AddMultipleEndUserGrades(List<EndUserGrade> endUserGrades)
        {
            dbContext.EndUserGrades.AddRange(endUserGrades);
            dbContext.SaveChanges();
        }

        public EndUser GetByUserId(string userId)
        {
            return this.dbContext.EndUsers
                                 .Where(endUser => endUser.UserId == userId)
                                 .SingleOrDefault();
        }

        public EndUserGrade GetEndUserGrade(Guid assigmentId, string userId)
        {
            var assigment = dbContext.Assigments
                                .Include(a => a.EndUserGrades)
                                .Where(a => a.Id == assigmentId)
                                .SingleOrDefault();
            foreach (var endUserGrade in assigment.EndUserGrades)
            {
                var endUserGradeDb = dbContext.EndUserGrades
                                              .Include(eud => eud.EndUser)
                                              .Include(eud => eud.Grade)
                                              .Where(eud => eud.Id == endUserGrade.Id).SingleOrDefault();
                if (endUserGradeDb.EndUser.UserId == userId) return endUserGradeDb;
            }

            return null;
        }

        public IEnumerable<EndUserGrade> GetStudents(Guid assigmentId)
        {
            var assigment = dbContext.Assigments
                                .Include(a => a.EndUserGrades)
                                .Where(a => a.Id == assigmentId)
                                .SingleOrDefault();
            var students = new List<EndUserGrade>();
            foreach (var endUserGrade in assigment.EndUserGrades)
            {
                var endUserGradeDb = dbContext.EndUserGrades
                                              .Include(eud => eud.EndUser)
                                              .Include(eud => eud.Grade)
                                              .Where(eud => eud.Id == endUserGrade.Id).SingleOrDefault();
                students.Add(endUserGrade);
            }
            return students;
        }

        public void UpdateEndUserGrade(EndUserGrade endUserGradeDb)
        {
            dbContext.EndUserGrades.Update(endUserGradeDb);
            dbContext.SaveChanges();
        }
    }
}
