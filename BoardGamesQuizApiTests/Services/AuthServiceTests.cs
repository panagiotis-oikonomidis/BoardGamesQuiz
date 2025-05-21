using System;
using Xunit;
using FluentAssertions;
using BoardGamesQuizApi.Models;
using BoardGamesQuizApi.Services;

namespace BoardGamesQuizApiTests.Services
{
    public class AuthServiceTests
    {
        private readonly AuthService _svc = new();

        [Fact]
        public void Login_ThrowsOnInvalid()
        {
            var badDto = new LoginRequest
            {
                Username = "bcdfg",
                Password = "100"
            };

            Action act = () => _svc.Login(badDto);
            act.Should().Throw<UnauthorizedAccessException>();
        }

        [Fact]
        public void Login_ReturnsSuccessOnValid()
        {
            var goodDto = new LoginRequest
            {
                Username = "johnas",
                Password = "199"
            };

            var res = _svc.Login(goodDto);
            res.IsSuccess.Should().BeTrue();
        }
    }
}
