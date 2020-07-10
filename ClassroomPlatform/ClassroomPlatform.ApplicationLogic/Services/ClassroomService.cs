using ClassroomPlatform.ApplicationLogic.Abstractions;
using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Services
{
    public class ClassroomService
    {
        private readonly IClassroomRepository classroomRepository;
        private readonly IAnnouncementRepository announcementRepository;
        private readonly IAssigmentRepository assigmentRepository;
        private readonly IEndUserRepository endUserRepository;
        private readonly IGradeRepository gradeRepository;

        public ClassroomService(IClassroomRepository classroomRepository,
                                IAnnouncementRepository announcementRepository,
                                IAssigmentRepository assigmentRepository,
                                IEndUserRepository endUserRepository,
                                IGradeRepository gradeRepository)
        {
            this.classroomRepository = classroomRepository;
            this.announcementRepository = announcementRepository;
            this.assigmentRepository = assigmentRepository;
            this.endUserRepository = endUserRepository;
            this.gradeRepository = gradeRepository;
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

        public Assigment GetAssigment(Guid classroomId, Guid assigmentId)
        {
            var classroomDb = classroomRepository.GetById(classroomId);
            return classroomDb.Assigments.Where(assigment => assigment.Id == assigmentId).SingleOrDefault();
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

            var assigmentToAdd = Assigment.Create(teacherDb, deadline, date, content, title, CreateEndUserGradeList(classroomId));
            classroomDb.AddAssigment(assigmentToAdd);
            return this.assigmentRepository.Add(assigmentToAdd);
        }

        public void AddWorkForAssigment(string work, Guid assigmentId, string userId)
        {
            var endUserGradeDb = endUserRepository.GetEndUserGrade(assigmentId, userId);
            endUserGradeDb.UpdateWork(work);
            endUserRepository.UpdateEndUserGrade(endUserGradeDb);
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

        private List<EndUserGrade> CreateEndUserGradeList(Guid classroomId)
        {
            var endUserGradeList = new List<EndUserGrade>();
            var gradeList = new List<Grade>();
            foreach (var endUser in classroomRepository.GetAllEndUserClassrooms(classroomId))
            {
                var grade = Grade.Create();
                gradeList.Add(grade);
                var endUserGrade = EndUserGrade.Create(endUser.EndUser, grade);
                endUserGradeList.Add(endUserGrade);
            }
            gradeRepository.AddMultipleGrades(gradeList);
            endUserRepository.AddMultipleEndUserGrades(endUserGradeList);
            return endUserGradeList;
        }
    }
}
