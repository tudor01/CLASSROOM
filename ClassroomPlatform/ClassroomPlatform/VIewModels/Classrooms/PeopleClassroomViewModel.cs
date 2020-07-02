using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomPlatform.VIewModels.Classrooms
{
    public class PeopleClassroomViewModel
    {
        public Guid Id { get; set; }
        public IEnumerable<EndUser> People { get; set; }
        public Classroom Classroom { get; set; }
    }
}
