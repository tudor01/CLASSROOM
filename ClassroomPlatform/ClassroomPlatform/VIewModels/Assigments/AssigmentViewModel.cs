using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomPlatform.VIewModels.Assigments
{
    public class AssigmentViewModel
    {
        public Guid ClassroomId { get; set; }
        public Assigment Assigment { get; set; }
        public EndUserGrade EndUserGrade { get; set; }
        public IEnumerable<EndUserGrade> Students { get; set; }
    }
}
