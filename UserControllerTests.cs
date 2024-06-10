using Xunit;
using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using System.Web.Mvc;

public class UserControllerTests
{
    [Fact]
    public void Index_ReturnsViewWithCorrectModel()
    {
        // Arrange
        var userController = new UserController();

        // Act
        var result = userController.Index() as ViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<System.Collections.Generic.List<User>>(result.Model);
    }

    [Fact]
    public void Details_ReturnsViewWithCorrectModel()
    {
        // Arrange
        var userController = new UserController();
        var user = new User { Id = 1, Name = "Test", Email = "test@test.com" };
        UserController.userlist.Add(user);

        // Act
        var result = userController.Details(1) as ViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<User>(result.Model);
        Assert.Equal(user, result.Model);
    }

    [Fact]
    public void Create_Post_RedirectsToIndex()
    {
        // Arrange
        var userController = new UserController();
        var user = new User { Id = 1, Name = "Test", Email = "test@test.com" };

        // Act
        var result = userController.Create(user) as RedirectToRouteResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Index", result.RouteValues["action"]);
    }

    [Fact]
    public void Edit_Post_RedirectsToIndex()
    {
        // Arrange
        var userController = new UserController();
        var user = new User { Id = 1, Name = "Test", Email = "test@test.com" };
        UserController.userlist.Add(user);

        // Act
        var result = userController.Edit(1, user) as RedirectToRouteResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Index", result.RouteValues["action"]);
    }

    [Fact]
    public void Delete_Post_RedirectsToIndex()
    {
        // Arrange
        var userController = new UserController();
        var user = new User { Id = 1, Name = "Test", Email = "test@test.com" };
        UserController.userlist.Add(user);

        // Act
        var result = userController.Delete(1) as RedirectToRouteResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Index", result.RouteValues["action"]);
    }
}
