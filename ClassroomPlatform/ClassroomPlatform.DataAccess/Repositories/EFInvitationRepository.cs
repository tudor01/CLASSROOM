using ClassroomPlatform.ApplicationLogic.Abstractions;
using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.DataAccess.Repositories
{
    public class EFInvitationRepository : EFBaseRepository<Invitation>, IInvitationRepository
    {
        public EFInvitationRepository(ClassroomPlatformDbContext dbContext) : base(dbContext)
        {

        }
    }
}
