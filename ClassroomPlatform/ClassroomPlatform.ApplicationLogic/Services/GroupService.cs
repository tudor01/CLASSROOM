using ClassroomPlatform.ApplicationLogic.Abstractions;
using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Services
{
    public class GroupService
    {
        private readonly IGroupRepository groupRepository;
        private readonly IClassroomRepository classroomRepository;

        public GroupService(IGroupRepository groupRepository,
                            IClassroomRepository classroomRepository)
        {
            this.classroomRepository = classroomRepository;
            this.groupRepository = groupRepository;
        }

        public Group GetById(Guid id)
        {
            return this.groupRepository.GetById(id);
        }

        public Group Add(string name)
        {
            var groupToAdd = Group.Create(name);
            return this.groupRepository.Add(groupToAdd);
        }

        public Classroom AddClassroom(Guid groupId, Guid classroomId)
        {
            var groupDb = GetById(groupId);
            var classroomDb = this.classroomRepository.GetById(classroomId);

            groupDb.AddClassroom(classroomDb);
            return this.classroomRepository.Add(classroomDb);
        }
    }
}
