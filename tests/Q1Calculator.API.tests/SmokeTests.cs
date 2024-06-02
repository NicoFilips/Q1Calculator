using Q1Calculator.API;
using NUnit.Framework;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Q1Calculator.API.tests;

[TestFixture]
public class SmokeTests
{
    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;

    [SetUp]
    public void SetUp()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();
    }

    [Test]
    public async Task Application_WhenStartup_EndpointsAreReachable()
    {
        // Arrange
        var url = "/add?number1=1&number2=2";

        // Act
        var response = await _client.GetAsync(url);

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
    }



    [Test]
    public void Application_WhenStartUp_DoesntThrowException()
    {
        // Act
        Exception exception = null;
        try
        {
            var client = _factory.CreateClient();
        }
        catch (Exception ex)
        {
            exception = ex;
        }

        // Assert
        exception.Should().BeNull();
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
        _factory.Dispose();
    }
}

