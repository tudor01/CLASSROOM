using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Models
{
    public class EndUserGrade : DataEntity
    {
        public EndUser EndUser { get; private set; }
        public Grade Grade { get; private set; }
    }
}
