using FluentAssertions;
using PruebasApiSolid.Application.Common;
using PruebasApiSolid.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasApiSolid.Integration.Tests.Common
{
    public class CreateUserEndpointTests
        : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public CreateUserEndpointTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateUser_ShouldReturnOk_WhenRequestIsValid()
        {
            // Arrange
            var request = new
            {
                name = "Santiago",
                email = "santiago@mail.com",
                password = "12345689444"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/user", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var result = await response.Content
                .ReadFromJsonAsync<ApiResponse<ResponseUser>>();

            result.Should().NotBeNull();
            result!.State.Should().BeTrue();
            result.Data.Email.Should().Be("santiago@mail.com");
            result.Data.Name.Should().Be("Santiago");
        }
    }
}
