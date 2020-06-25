using ClassroomPlatform.ApplicationLogic.Abstractions;
using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.DataAccess.Repositories
{
    public class EFAnnouncementRepository : EFBaseRepository<Announcement>, IAnnouncementRepository
    {
        public EFAnnouncementRepository(ClassroomPlatformDbContext dbContext) : base(dbContext)
        {
        }
    }
}
