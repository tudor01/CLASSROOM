using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Models
{
    public class Classroom : DataEntity
    {
        public string Name { get; private set; }
        public EndUser Creator { get; private set; }
        public ICollection<Assigment> Assigments { get; private set; }
        public ICollection<Announcement> Announcements { get; private set; }

        public static Classroom Create(string name, EndUser creator)
        {
            return new Classroom
            {
                Id = Guid.NewGuid(),
                Name = name,
                Creator = creator,
                Assigments = new List<Assigment>(),
                Announcements = new List<Announcement>()
            };
        }

        public Assigment AddAssigment(Assigment assigment)
        {
            if (this.Assigments == null) this.Assigments = new List<Assigment>();
            this.Assigments.Add(assigment);
            return assigment;
        }

        public Announcement AddAnnoncement(Announcement announcement)
        {
            if (this.Announcements == null) this.Announcements = new List<Announcement>();
            this.Announcements.Add(announcement);
            return announcement;
        }

        internal Assigment Where()
        {
            throw new NotImplementedException();
        }
    }
}
