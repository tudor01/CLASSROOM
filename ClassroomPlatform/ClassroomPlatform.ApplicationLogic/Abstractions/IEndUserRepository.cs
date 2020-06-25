using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Abstractions
{
    public interface IEndUserRepository : IBaseRepository<EndUser>    
    {
        EndUser GetByUserId(string userId);
    }
}
