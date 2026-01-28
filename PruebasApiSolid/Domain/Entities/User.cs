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
            Validate(name, email, password);

            Name = name;
            Email = email;
            Password = password;
            IsActivate = true;
        }

        public void NoIsActivated() => IsActivate = false;

        public void UpdateEmailUser(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new DomainExceptions("Email inválido");
           
            Email = email;
            
        }

        private static void Validate(string name, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainExceptions("Nombre inválido");

            if (string.IsNullOrWhiteSpace(email))
                throw new DomainExceptions("Email inválido");

            if (string.IsNullOrWhiteSpace(password))
                throw new DomainExceptions("Password inválido");
        }
    }
}
