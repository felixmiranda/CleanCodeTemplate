using System.ComponentModel.DataAnnotations;
using CleanCodeTemplate.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanCodeTemplate.Test;

[TestClass]
public class LoginCommandTest
{
    private static WebApplicationFactory<Program> _factory = null!;
    private static IServiceScopeFactory _scopeFactory = null!;

    [ClassInitialize]
    public static void ClassInitialize(TestContext _)
    {
        _factory = new CustomWebApplicationFactory();
        _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
    }

    [TestMethod]
    public async Task ShouldNotGenerateToken()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        //Arrange
        var command = new LoginCommand()
        {
            Email = "notfound@gmail.com",
            Password = "empty"
        };

        var expected = false;
        //Act

        var response = await mediator.Send(command);

        //Assert
        Assert.AreEqual(expected, response.IsSuccess);


    }


    [TestMethod]
    public async Task ShouldGenerateToken()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        //Arrange
        var command = new LoginCommand()
        {
            Email = "felixmiranda@gmail.com",
            Password = "rodrigo16"
        };

        var expected = true;
        //Act

        var response = await mediator.Send(command);

        //Assert
        Assert.AreEqual(expected, response.IsSuccess);


    }
}