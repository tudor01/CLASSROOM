using ClassroomPlatform.ApplicationLogic.Abstractions;
using ClassroomPlatform.ApplicationLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomPlatform.DataAccess.Repositories
{
    public class EFInvitationRepository : EFBaseRepository<Invitation>, IInvitationRepository
    {
        public EFInvitationRepository(ClassroomPlatformDbContext dbContext) : base(dbContext)
        {

        }

        public override Invitation GetById(Guid id)
        {
            return dbContext.Invitations.Include(invitation => invitation.Classroom)
                .Include(invitation => invitation.EndUser)
                .Where(invitation => invitation.Id == id)
                .SingleOrDefault();
        }

        public IEnumerable<Invitation> GetAllForUser(string userId)
        {
            return dbContext.Invitations
                .Include(invitation => invitation.EndUser)
                .Include(invitation => invitation.Classroom)
                .ThenInclude(invitation => invitation.Creator)
                .Where(invitation => invitation.EndUser.UserId == userId);
        }
    }
}
