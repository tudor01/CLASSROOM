using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Models
{
    public class Grade : DataEntity
    {
        public int Score { get; private set; }
        public int TotalScore { get; private set; }
    }
}
