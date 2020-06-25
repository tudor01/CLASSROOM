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

        public EndUserService(IEndUserRepository endUserRepository)
        {
            this.endUserRepository = endUserRepository;
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

        public EndUser Update(Guid id, string firstName, string lastName, string email)
        {
            var endUserToUpdate = GetById(id);
            endUserToUpdate.Update(firstName, lastName, email);
            return this.endUserRepository.Update(endUserToUpdate);
        }
    }
}
