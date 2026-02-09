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
            user.Name.Value.Should().Be("Juan");
            user.Email.Value.Should().Be("old@email.com");
            user.IsActivate.Should().BeTrue();
        }
    

     [Fact]
        public void Constructor_ShouldThrowException_WhenNameIsEmpty()
        {
            // Act

            var act = () => new Name("");
                
            // Assert
            act.Should()
               .Throw<DomainExceptions>()
               .WithMessage("El nombre es obligatorio");
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenEmailIsInvalid()
        {
            // Act


            var act = () => new Email("TT");
                      
            // Assert
            act.Should()
               .Throw<DomainExceptions>()
               .WithMessage("Email inválido");
        }

        [Fact]
        public void UpdateEmailUser_ShouldUpdateEmail_WhenValid()
        {
            // Arrange
            var name = new Name("Santiago");
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

            var user = new User(
        new Name("Santiago"),
        new Email("old@mail.com"),
        new PasswordHash("123456")
    );

         
            // Act
            var act = () => user.UpdateEmailUser(new Email("tt"));

            // Assert
            act.Should()
               .Throw<DomainExceptions>()
               .WithMessage("Email inválido");
        }


    }

}
