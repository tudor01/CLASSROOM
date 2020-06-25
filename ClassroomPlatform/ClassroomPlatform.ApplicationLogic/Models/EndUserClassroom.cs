using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Models
{
    public enum EndUserClassroomRole { Student, Teacher};
    public class EndUserClassroom : DataEntity 
    {
        public Classroom Classroom { get; private set; }
        public EndUser EndUser { get; private set; }
        public EndUserClassroomRole Role { get; private set; }
    }
}
