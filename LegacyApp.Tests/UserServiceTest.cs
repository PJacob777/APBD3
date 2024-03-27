using System;
using JetBrains.Annotations;
using LegacyApp;
using Xunit;

namespace LegacyApp.Tests;

[TestSubject(typeof(UserService))]
public class UserServiceTest
{

    [Fact]
    public void Returns_False_When_FirstName_Is_Missing()
    {
       // Arrange
       var userService = new UserService();
       // Act
       var addResult = userService.AddUser("", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
       // Assert
       Assert.False(addResult);
    }
    [Fact]
    public void Returns_False_When_Email_Is_Wrong()
    {
        // Arrange
        var userService = new UserService();
        // Act
        var addResult = userService.AddUser("John", "Doe", "johndoegmailcom", DateTime.Parse("1982-03-21"), 1);
        // Assert
        Assert.False(addResult);
    }
    [Fact]
    public void Returns_False_When_Person_Is_Not_Major()
    {
        // Arrange
        var userService = new UserService();
        // Act
        var addResult = userService.AddUser("John", "Doe", "johndoegmailcom", DateTime.Parse("2010-03-21"), 1);
        // Assert
        Assert.False(addResult);
    }    [Fact]
    public void Returns_False_When_Credit_Person_Is_Too_Long()
    {
        // Arrange
        var userService = new UserService();
        // Act
        var addResult = userService.AddUser("Johnjhgkukuyyguyguyglghhjllkjhlkjhhhuyoijrerfqofsal;dkfaslkfjslkfjasl;kfjsaldkjfsaldkjfslakjfsldkjfas;lkjfas;ldkjflaskjfslkdjfask;ljdfsa;lkjfsalkjfsaljdkfsalkjdfsalkjfsa;lkjfsalkjfsakjdfsakjfsakljfhsalkjdhfsakljdhfsaljkdhflaksjdhfaslkjhfsakldjhfsakjhfalskdjhfaskjhfskadjhfsakljdhfsakljdhfsakjhfskdjhfaskjhfalsdhjfalsjkfahsjkfjaklsdhdalskhjf", "Doehhkjbjhbjhbljhbbbhjhbjhbjbkhjvhgvhvkhvhjvjhvjkhvjkvjkhvjhvkjhvkjhvjhvkjhvkjhvjhvkjvjkhvjvjbjkhbyvyukjhbvjhbhvyugkjhbhjgvkhvhgvkuygkhvbygkuhvhgvyukvhbvuygkjhbvjhvuygjhvuygkjhvygvjhbugvuyguygjhbjhbjhvyuougyouyguuohjhjlbjhbbjhk", "johndoegmailcom", DateTime.Parse("2010-03-21"), 1);
        // Assert
        Assert.False(addResult);
    }

    [Fact]
    public void Decrement_Value_If_Month_Is_Same()
    {
        // Arrange
        var userService = new UserService();
        // Act
        var addResult = userService.AddUser("Joff", "Doe", "johndoegmailcom", DateTime.Parse("2010-03-21"), 1);
        // Assert
        Assert.
    }
}