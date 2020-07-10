using ClassroomPlatform.ApplicationLogic.Abstractions;
using ClassroomPlatform.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Services
{
    public class EndUserService
    {
        private readonly IEndUserRepository endUserRepository;
        private readonly IClassroomRepository classroomRepository;
        private readonly IInvitationRepository invitationRepository;

        public EndUserService(IEndUserRepository endUserRepository,
                              IClassroomRepository classroomRepository,
                              IInvitationRepository invitationRepository)
        {
            this.endUserRepository = endUserRepository;
            this.classroomRepository = classroomRepository;
            this.invitationRepository = invitationRepository;
        }

        public EndUser GetById(Guid id)
        {
            return this.endUserRepository.GetById(id);
        }

        public EndUser GetByUserId(string userId)
        {
            return this.endUserRepository.GetByUserId(userId);
        }

        public EndUser Add(string userId, string firstName, string lastName, string email)
        {
            var endUserToAdd = EndUser.Create(userId, firstName, lastName, email);
            return this.endUserRepository.Add(endUserToAdd);
        }

        public IEnumerable<Invitation> GetAllInvitations(string userId)
        {
            return this.invitationRepository.GetAllForUser(userId);
        }

        public EndUser Update(Guid id, string firstName, string lastName, string email)
        {
            var endUserToUpdate = GetById(id);
            endUserToUpdate.Update(firstName, lastName, email);
            return this.endUserRepository.Update(endUserToUpdate);
        }

        public Invitation ReceiveInvitation(Guid endUserId, Guid classroomId)
        {
            var endUserDb = endUserRepository.GetById(endUserId);
            var classroomDb = classroomRepository.GetById(classroomId);
            var invitationToAdd = Invitation.Create(endUserDb, classroomDb);
            return this.invitationRepository.Add(invitationToAdd);
        }

        public EndUserGrade GetEndUserGrade(Guid assigmentId, string userId)
        {
            return endUserRepository.GetEndUserGrade(assigmentId, userId);
        }

        public void AcceptInvitation(Guid id)
        {
            var invitationDb = invitationRepository.GetById(id);
            var endUserClassroomToAdd = EndUserClassroom.Create(invitationDb.EndUser, invitationDb.Classroom);
            this.invitationRepository.Remove(id);
            this.classroomRepository.AddEndUser(endUserClassroomToAdd);
        }

        public void DeclineInvitation(Guid id)
        {
            this.invitationRepository.Remove(id);
        }

        public IEnumerable<EndUserGrade> GetStudents(Guid assigmentId)
        {
            return endUserRepository.GetStudents(assigmentId);
        }
    }
}
