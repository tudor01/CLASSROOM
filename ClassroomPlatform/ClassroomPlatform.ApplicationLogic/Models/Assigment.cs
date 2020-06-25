using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Models
{
    public class Assigment : DataEntity
    {
        public ICollection<EndUserGrade> EndUserGrades { get; private set; }
        public EndUser Creator { get; private set; }
        public DateTime Deadline { get; private set; }
        public DateTime Date { get; private set; }
        public string Content { get; private set; }
        public string Title { get; private set; }

        public static Assigment Create(EndUser creator,
                                       DateTime deadline,
                                       DateTime date,
                                       string content,
                                       string title)
        {
            return new Assigment
            {
                Id = Guid.NewGuid(),
                Creator = creator,
                Deadline = deadline,
                Date = date,
                Content = content,
                Title = title,
                EndUserGrades = new List<EndUserGrade>()
            };
        }

        public Assigment Update(DateTime deadline, string content)
        {
            this.Deadline = deadline;
            this.Content = content;
            return this;
        }
    }
}
