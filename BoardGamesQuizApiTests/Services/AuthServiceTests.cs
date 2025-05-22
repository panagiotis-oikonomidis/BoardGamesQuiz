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

        [Theory]
        [InlineData("", "")]
        [InlineData("panos", "wrongpass")]
        [InlineData("PANOS", "199")]
        [InlineData("panagiotisoikonomidis", "199")]
        [InlineData("panos", "99")]
        [InlineData("panos", "150")]
        [InlineData("panss", "149")]
        public void Login_ThrowsOnInvalid(string username, string password)
        {
            var dto = new LoginRequest
            {
                Username = username,
                Password = password
            };

            Action act = () => _svc.Login(dto);
            act.Should().Throw<UnauthorizedAccessException>();
        }

        [Fact]
        public void Login_ReturnsSuccessOnValid()
        {
            var goodDto = new LoginRequest
            {
                Username = "panos",
                Password = "149"
            };

            var res = _svc.Login(goodDto);
            res.IsSuccess.Should().BeTrue();
        }
    }
}