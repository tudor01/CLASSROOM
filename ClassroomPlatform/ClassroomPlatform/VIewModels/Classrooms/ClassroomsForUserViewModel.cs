using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomPlatform.VIewModels.Classrooms
{
    public class ClassroomsForUserViewModel
    {
        public EndUser EndUser { get; set; }
        public IEnumerable<Classroom> Classrooms { get; set; }
        public IEnumerable<Invitation> Invitations { get; set; }
    }
}
