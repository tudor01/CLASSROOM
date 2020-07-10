using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomPlatform.VIewModels.Assigments
{
    public class AddWorkAssigmentViewModel
    {
        public Guid AssigmentId { get; set; }
        public Guid ClassroomId { get; set; }
        public string Work { get; set; }
    }
}
