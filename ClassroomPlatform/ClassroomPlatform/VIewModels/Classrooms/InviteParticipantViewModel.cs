using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomPlatform.VIewModels.Classrooms
{
    public class InviteParticipantViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool DoesEmailExists { get; set; }
    }
}
