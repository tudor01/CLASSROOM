using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Models
{
    public class EndUserGrade : DataEntity
    {
        public EndUser EndUser { get; private set; }
        public Grade Grade { get; private set; }
        public string Work { get; private set; }

        public static EndUserGrade Create(EndUser endUser, Grade grade)
        {
            return new EndUserGrade
            {
                Id = Guid.NewGuid(),
                EndUser = endUser,
                Grade = grade
            };
        }

        internal void UpdateWork(string work)
        {
            this.Work = work;
        }
    }
}
