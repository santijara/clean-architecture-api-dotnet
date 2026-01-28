using PruebasApiSolid.Domain.Exceptions;

namespace PruebasApiSolid.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsActivate { get; private set; }

        private User() { }

        public User(string name, string email, string password)
        {
            if(string.IsNullOrEmpty(name)) throw new DomainExceptions("Nombre Invalido");
            if (string.IsNullOrEmpty(email)) throw new DomainExceptions("Email Invalido");
            if (string.IsNullOrEmpty(password)) throw new DomainExceptions("Password Invalido");

            Name = name;
            Email = email;
            Password = password;
            IsActivate = true;
        }

        public void NoIsActivated() => IsActivate = false;
    }
}
