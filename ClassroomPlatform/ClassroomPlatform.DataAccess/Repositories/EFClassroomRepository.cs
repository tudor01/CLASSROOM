using ClassroomPlatform.ApplicationLogic.Abstractions;
using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomPlatform.DataAccess.Repositories
{
    public class EFClassroomRepository : EFBaseRepository<Classroom>, IClassroomRepository
    {
        public EFClassroomRepository(ClassroomPlatformDbContext dbContext) : base(dbContext)
        {
        }

        public EndUserClassroom AddEndUser(EndUserClassroom endUserClassroom)
        {
            this.dbContext.Add<EndUserClassroom>(endUserClassroom);
            this.dbContext.SaveChanges();
            return endUserClassroom;
        }

        public bool RemoveEndUser(Guid id)
        {
            var endUserClassroomToRemove = this.dbContext.EndUserClassrooms
                                                         .Where(endUserClassroom => endUserClassroom.Id == id)
                                                         .SingleOrDefault();

            if (endUserClassroomToRemove == null)
            {
                this.dbContext.EndUserClassrooms.Remove(endUserClassroomToRemove);
                this.dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public EndUserClassroom UpdateEndUser(EndUserClassroom endUserClassroom)
        {
            this.dbContext.Update<EndUserClassroom>(endUserClassroom);
            this.dbContext.SaveChanges();
            return endUserClassroom;
        }
    }
}
