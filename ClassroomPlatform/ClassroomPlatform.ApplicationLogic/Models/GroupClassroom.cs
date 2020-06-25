using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Models
{
    public class GroupClassroom : DataEntity
    {
        public ICollection<Classroom> Classrooms { get; private set; }
    }
}
