using FluentAssertions;
using Moq;
using PruebasApiSolid.Application.Interfaces;
using PruebasApiSolid.Application.Users.Commands.UpdateUser;
using PruebasApiSolid.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasApiSolid.Application.Tests.Users.Commands.UpdateUser
{
    public class UpdateUserHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UpdateUserHandler _handler;

        public UpdateUserHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();

            _handler = new UpdateUserHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenUserDoesNotExist()
        {
            // Arrange
            var command = new UpdateUserCommand(
                Guid.NewGuid(),
                "nuevo@email.com"
            );

            _userRepositoryMock
                .Setup(x => x.GetId(command.Id))
                .ReturnsAsync((User?)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("Usuario no existe");

            _userRepositoryMock.Verify(
                x => x.UpdateUser(It.IsAny<User>()),
                Times.Never
            );
        }

        [Fact]
        public async Task Handle_ShouldUpdateEmail_WhenUserExists()
        {
            // Arrange
            var user = new User("Juan", "old@email.com", "123456");

            var command = new UpdateUserCommand(
                Guid.NewGuid(),
                "new@email.com"
            );

            _userRepositoryMock
                .Setup(x => x.GetId(command.Id))
                .ReturnsAsync(user);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeNull();
            result.Value!.Email.Should().Be(command.Email);

            _userRepositoryMock.Verify(
                x => x.UpdateUser(user),
                Times.Once
            );
        }
    }
}
