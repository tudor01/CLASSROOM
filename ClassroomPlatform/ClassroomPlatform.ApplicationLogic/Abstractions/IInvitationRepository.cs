using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Abstractions
{
    public interface IInvitationRepository : IBaseRepository<Invitation>
    {
        IEnumerable<Invitation> GetAllForUser(string userId);
    }
}
