using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.Domain
{
    public class User : Entity
    {
        public string Name { get; protected set; }
        public UserRole Role { get; protected set; }
        public string Email { get; protected set; }
        private string _password;
        public DateTime CreatedAt { get; protected set; }

        #region Constructors
        protected User() : base()
        {

        }
        public User(Guid id, string name, UserRole role, string email, string password) : base(id)
        {
            Name = name;
            Role = role;
            Email = email;
            _password = password;
            CreatedAt = DateTime.UtcNow;
        }
        #endregion
    }
}
