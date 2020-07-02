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

        public static Invitation Create(EndUser endUser, Classroom classroom)
        {
            return new Invitation
            {
                Id = Guid.NewGuid(),
                EndUser = endUser,
                Classroom = classroom,
                Status = InvitationStatus.None
            };
        }
    }
}
