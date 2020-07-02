using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Models
{
    public class Announcement : DataEntity
    {
        public EndUser Creator { get; private set; }
        public DateTime Date { get; private set; }
        public string Content { get; private set; }

        public static Announcement Create(EndUser creator, string content)
        {
            return new Announcement
            {
                Id = Guid.NewGuid(),
                Creator = creator,
                Date = DateTime.UtcNow,
                Content = content
            };
        }
    }
}
