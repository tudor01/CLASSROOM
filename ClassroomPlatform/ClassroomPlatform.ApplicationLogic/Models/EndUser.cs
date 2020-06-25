using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomPlatform.ApplicationLogic.Models
{
    public class EndUser : DataEntity
    {
        public string UserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }

        public static EndUser Create(string userId, string firstName, string lastName, string email)
        {
            return new EndUser
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };
        }

        public EndUser Update(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            return this;
        }
    }
}
