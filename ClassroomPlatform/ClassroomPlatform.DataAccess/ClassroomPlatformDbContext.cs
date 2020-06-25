using ClassroomPlatform.ApplicationLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClassroomPlatform.DataAccess
{
    public class ClassroomPlatformDbContext : DbContext
    {
        public ClassroomPlatformDbContext(DbContextOptions<ClassroomPlatformDbContext> options)
            : base(options)
        {
        }

        public DbSet<Announcement> Announcements {get; private set;}
        public DbSet<Assigment> Assigments {get; private set;}
        public DbSet<Classroom> Classrooms {get; private set;}
        public DbSet<EndUser> EndUsers {get; private set;}
        public DbSet<EndUserClassroom> EndUserClassrooms {get; private set;}
        public DbSet<EndUserGrade> EndUserGrades {get; private set;}
        public DbSet<Grade> Grades {get; private set;}
        public DbSet<Group> Groups {get; private set;}
        public DbSet<GroupClassroom> GroupClassrooms {get; private set;}
        public DbSet<Invitation> Invitations {get; private set;}
    }
}
