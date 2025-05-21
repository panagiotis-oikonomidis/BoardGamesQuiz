using Xunit;
using FluentAssertions;
using BoardGamesQuizApi.Domain;

namespace BoardGamesQuizApiTests.Models
{
    public class LoginValidatorTests
    {
        [Theory]
        [InlineData("johnas", "199", true)]
        [InlineData("johnas", "210", false)]
        [InlineData("alexander", "400", true)]
        [InlineData("alexander", "500", false)]
        public void IsValid_ReturnsExpected(string user, string pass, bool expected)
        {
            // Arrange & Act
            UserName.TryParse(user, out var u).Should().BeTrue();
            Password.TryParse(pass, out var p).Should().BeTrue();
            var ok = LoginValidator.IsValid(u!, p!);

            // Assert
            ok.Should().Be(expected);
        }

        [Fact]
        public void UserName_Rejects_InvalidInputs()
        {
            UserName.TryParse("bcdfg", out _).Should().BeFalse();          // no vowels
            UserName.TryParse("abcdefghijklmnop", out _).Should().BeFalse(); // too long
        }

        [Fact]
        public void LoginPassword_Rejects_InvalidInputs()
        {
            Password.TryParse("abc", out _).Should().BeFalse();
            Password.TryParse("99", out _).Should().BeFalse();
            Password.TryParse("1000", out _).Should().BeFalse();
        }
    }
}
