using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Models
{
    public class Group : DataEntity
    {
        public string Name { get; private set; }
        public ICollection<Classroom> Classrooms { get; private set; }

        public static Group Create(string name)
        {
            return new Group
            {
                Id = Guid.NewGuid(),
                Name = name
            };
        }

        public Classroom AddClassroom(Classroom classroom)
        {
            if (this.Classrooms == null) this.Classrooms = new List<Classroom>();
            this.Classrooms.Add(classroom);
            return classroom;
        }
    }
}
