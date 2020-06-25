using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Models
{
    public enum InvitationStatus { Accepted, Declined, None};
    public class Invitation : DataEntity
    {
        public EndUser EndUser { get; private set; }
        public Classroom Classroom { get; private set; }
        public InvitationStatus Status { get; private set; }
    }
}
