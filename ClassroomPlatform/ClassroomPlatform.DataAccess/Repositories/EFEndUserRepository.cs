using ClassroomPlatform.ApplicationLogic.Abstractions;
using ClassroomPlatform.ApplicationLogic.Models;
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

        public EndUser GetByUserId(string userId)
        {
            return this.dbContext.EndUsers
                                 .Where(endUser => endUser.UserId == userId)
                                 .SingleOrDefault();
        }
    }
}
