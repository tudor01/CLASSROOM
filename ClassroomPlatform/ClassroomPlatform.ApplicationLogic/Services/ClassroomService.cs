using ClassroomPlatform.ApplicationLogic.Abstractions;
using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Services
{
    public class ClassroomService
    {
        private readonly IClassroomRepository classroomRepository;
        private readonly IAnnouncementRepository announcementRepository;
        private readonly IAssigmentRepository assigmentRepository;
        private readonly IEndUserRepository endUserRepository;

        public ClassroomService(IClassroomRepository classroomRepository,
                                IAnnouncementRepository announcementRepository,
                                IAssigmentRepository assigmentRepository,
                                IEndUserRepository endUserRepository)
        {
            this.classroomRepository = classroomRepository;
            this.announcementRepository = announcementRepository;
            this.assigmentRepository = assigmentRepository;
            this.endUserRepository = endUserRepository;
        }

        public Classroom GetById(Guid classroomId)
        {
            return this.classroomRepository.GetById(classroomId);
        }

        public Classroom Add(string name, string creatorId)
        {
            var endUserDb = this.endUserRepository.GetByUserId(creatorId);
            var classroomToAdd = Classroom.Create(name, endUserDb);
            return this.classroomRepository.Add(classroomToAdd);
        }

        public IEnumerable<Classroom> GetAllForUser(string userId)
        {
            var endUserDb = this.endUserRepository.GetByUserId(userId);
            return this.classroomRepository.GetAllForUser(endUserDb.Id);
        }

        public Assigment AddAssigment(string teacherId,
                                      Guid classroomId,
                                      DateTime deadline,
                                      DateTime date,
                                      string content,
                                      string title)
        {
            var classroomDb = GetById(classroomId);
            var teacherDb = this.endUserRepository.GetByUserId(teacherId);

            var assigmentToAdd = Assigment.Create(teacherDb, deadline, date, content, title);
            classroomDb.AddAssigment(assigmentToAdd);
            return this.assigmentRepository.Add(assigmentToAdd);
        }

        public Announcement AddAnnouncement(string teacherId,
                                            Guid classroomId,
                                            string content)
        {
            var classroomDb = GetById(classroomId);
            var teacherDb = this.endUserRepository.GetByUserId(teacherId);

            var announcementToAdd = Announcement.Create(teacherDb, content);
            classroomDb.AddAnnoncement(announcementToAdd);
            return this.announcementRepository.Add(announcementToAdd);
        }

        public IEnumerable<EndUser> GetPeopleForClassroom(Guid id)
        {
            var people = new List<EndUser>();
            foreach (var item in this.classroomRepository.GetAllEndUserClassrooms(id))
            {
                people.Add(item.EndUser);
            }
            return people;
        }
    }
}
