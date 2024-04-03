namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            null, 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        // Assert.Equal(false, result);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalskikowalskipl",
            DateTime.Parse("2000-01-01"),
            2
        );

        // Assert
        // Assert.Equal(false, result);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2004-01-01"),
            3
        );

        // Assert
        // Assert.Equal(false, result);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        // Arrange
        var userService = new UserService();
        var client = new Client { Type = "VeryImportantClient" };
        var user = new User();

        // Act
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            4
        );

        // Assert
        // Assert.Equal(false, result);
        Assert.True(result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        // Arrange
        var userService = new UserService();
        var client = new Client { Type = "ImportantClient" };
        var user = new User();

        // Act
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            5
        );

        // Assert
        // Assert.Equal(false, result);
        Assert.True(result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        // Arrange
        var userService = new UserService();
        var client = new Client { Type = "NormalClient" };
        var user = new User();

        // Act
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            6
        );

        // Assert
        // Assert.Equal(false, result);
        Assert.True(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        // Arrange
        var userService = new UserService();
        var client = new Client { Type = "NormalClient" };
        var user = new User();

        // Act
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            7
        );

        // Assert
        Assert.False(user.HasCreditLimit);
        Assert.False(result);
    }
    // 
    // 
    
    [Fact]
    public void AddUser_ThrowsArgumentExceptionWhenClientDoesNotExist()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            100
        );

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void AddUser_ThrowsExceptionWhenUserDoesNotExist()
    {
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Jan", 
            "Mickiewicz", 
            "j@mick.pl",
            DateTime.Parse("2000-01-01"),
            101
        );

        // Assert
        Assert.Throws<Exception>(action);
    }
      
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        // Arrange
        var userService = new UserService();
        var user = new User();

        // Act
        Action action = () => userService.AddUser(
            "Jan", 
            "Mickiewicz", 
            "j@mick.pl",
            DateTime.Parse("2000-01-01"),
            101
        );

        // Assert
        Assert.False(user.HasCreditLimit);
        Assert.Throws<Exception>(action);
    }
}