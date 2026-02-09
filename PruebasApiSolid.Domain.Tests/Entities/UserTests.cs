using FluentAssertions;
using PruebasApiSolid.Application.Users.Commands.UpdateUser;
using PruebasApiSolid.Domain.Entities;
using PruebasApiSolid.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PruebasApiSolid.Domain.Tests.Entities
{
    public class UserTests
    {
        [Fact]
        public void Constructor_ShouldCreateUser_WhenDataIsValid()
        {
            // Act
            var name = new Name("Juan");
            var correo = new Email("old@email.com");
            var password = new PasswordHash("123456");

            var user = new User(
                name,
                correo,
                password
            );

            // Assert
            user.Name.Should().Be("Juan");
            user.Email.Should().Be("juan@mail.com");
            user.IsActivate.Should().BeTrue();
        }
    

     [Fact]
        public void Constructor_ShouldThrowException_WhenNameIsEmpty()
        {
            // Act
            var name = new Name("");
            var correo = new Email("old@email.com");
            var password = new PasswordHash("123456");
            var act = () => new User(
                name,
                correo,
                password
            );

            // Assert
            act.Should()
               .Throw<DomainExceptions>()
               .WithMessage("Nombre requerido");
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenEmailIsInvalid()
        {
            // Act
            var name = new Name("");
            var correo = new Email("old@email.com");
            var password = new PasswordHash("123456");
            var act = () => new User(
                name,
                correo,
                password
            );

            // Assert
            act.Should()
               .Throw<DomainExceptions>()
               .WithMessage("Email inválido");
        }

        [Fact]
        public void UpdateEmailUser_ShouldUpdateEmail_WhenValid()
        {
            // Arrange
            var name = new Name("");
            var correo = new Email("old@email.com");
            var password = new PasswordHash("123456");
            var user = new User(
                name,
                correo,
               password
            );

            // Act
            user.UpdateEmailUser(correo);

            // Assert
            user.Email.Should().Be(correo);
        }

        [Fact]
        public void UpdateEmailUser_ShouldThrowException_WhenEmailIsInvalid()
        {
            // Arrange
            var name = new Name("");
            var correo = new Email("old@email.com");
            var password = new PasswordHash("123456");
            var user = new User(
                name,
                correo,
                password
            );

            // Act
            var act = () => user.UpdateEmailUser(correo);

            // Assert
            act.Should()
               .Throw<DomainExceptions>()
               .WithMessage("Email inválido");
        }


    }

}
