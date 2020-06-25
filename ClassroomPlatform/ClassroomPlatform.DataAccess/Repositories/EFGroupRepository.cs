using ClassroomPlatform.ApplicationLogic.Abstractions;
using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.DataAccess.Repositories
{
    public class EFGroupRepository : EFBaseRepository<Group>, IGroupRepository
    {
        public EFGroupRepository(ClassroomPlatformDbContext dbContext) : base(dbContext)
        {
        }
    }
}
