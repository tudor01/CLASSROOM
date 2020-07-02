using ClassroomPlatform.ApplicationLogic.Abstractions;
using ClassroomPlatform.ApplicationLogic.Models;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Classroom> GetAllForUser(Guid endUserId)
        {
            var endUserClassrooms = this.dbContext.EndUserClassrooms
                                                  .Include(endUserClassroom => endUserClassroom.EndUser)
                                                  .Include(endUserClassroom => endUserClassroom.Classroom)
                                                  .ThenInclude(classroom => classroom.Creator)
                                                  .Where(endUserClassroom => endUserClassroom.EndUser.Id == endUserId);
            var myClassrooms = new List<Classroom>();
            foreach (var item in endUserClassrooms)
            {
                myClassrooms.Add(item.Classroom);
            }

            myClassrooms.AddRange(this.dbContext.Classrooms
                                                .Include(classroom => classroom.Creator)
                                                .Where(classroom => classroom.Creator.Id == endUserId));
            return myClassrooms;
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

        public override Classroom GetById(Guid id)
        {
            return this.dbContext.Classrooms
                                 .Where(classroom => classroom.Id == id)
                                 .Include(classroom => classroom.Assigments)
                                 .Include(classroom => classroom.Announcements)
                                 .Include(classroom => classroom.Creator)
                                 .SingleOrDefault();
        }

        public IEnumerable<EndUserClassroom> GetAllEndUserClassrooms(Guid id)
        {
            return this.dbContext.EndUserClassrooms
                .Include(endUserClassroom => endUserClassroom.Classroom)
                .Include(endUserClassroom => endUserClassroom.EndUser)
                .Where(endUserClassroom => endUserClassroom.Classroom.Id == id);
        }
    }
}
