using Microsoft.AspNetCore.Identity;
using PruebasApiSolid.Domain.Exceptions;

namespace PruebasApiSolid.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public  Name Name { get; private set; }     
        public Email Email { get; private set; }
        public PasswordHash Password { get; private set; }
        public bool IsActivate { get; private set; }

        private User() { }

        public User(Name name, Email email, PasswordHash password)
        {

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            IsActivate = true;
        }

        public static User Create(Name name, Email email, PasswordHash password)
        {
            return new User(name, email, password);
        }

        public void NoIsActivated()
        {
            if (!IsActivate)
                return;

            IsActivate = false;
        }
        

        public void UpdateEmailUser(Email newEmail)
        {
            Email = newEmail;

        }

    }

    public sealed class Email
    {
        public string Value { get; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainExceptions("El email es obligatorio");

            if (!value.Contains("@"))
                throw new DomainExceptions("Email inválido");

            Value = value;
        }

        public override string ToString() => Value;
    }


    public sealed class PasswordHash
    {
        public string Value { get; }

        public PasswordHash(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainExceptions("Password inválido");

            Value = value;
        }
    }

    public sealed class Name
    {
        public string Value { get; }

        public Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainExceptions("El nombre es obligatorio");

            if (value.Length < 1)
                throw new DomainExceptions("El nombre debe tener al menos 3 caracteres");

            Value = value.Trim();
        }

        public override string ToString() => Value;
    }
}
