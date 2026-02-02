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
            var user = new User(
                "Juan",
                "juan@mail.com",
                "123456"
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
            var act = () => new User(
                "",
                "mail@mail.com",
                "123"
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
            var act = () => new User(
                "Pedro",
                "correo-invalido",
                "123"
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
            var user = new User(
                "Ana",
                "old@mail.com",
                "123"
            );

            // Act
            user.UpdateEmailUser("new@mail.com");

            // Assert
            user.Email.Should().Be("new@mail.com");
        }

        [Fact]
        public void UpdateEmailUser_ShouldThrowException_WhenEmailIsInvalid()
        {
            // Arrange
            var user = new User(
                "Ana",
                "old@mail.com",
                "123"
            );

            // Act
            var act = () => user.UpdateEmailUser("invalid");

            // Assert
            act.Should()
               .Throw<DomainExceptions>()
               .WithMessage("Email inválido");
        }


    }

}
