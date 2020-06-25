using ClassroomPlatform.ApplicationLogic.Abstractions;
using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.DataAccess.Repositories
{
    public class EFAssigmentRepository : EFBaseRepository<Assigment>, IAssigmentRepository
    {
        public EFAssigmentRepository(ClassroomPlatformDbContext dbContext) : base(dbContext)
        {
        }
    }
}
