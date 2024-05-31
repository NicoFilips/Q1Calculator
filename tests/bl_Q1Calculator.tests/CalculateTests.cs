using bl_Q1Calculator.Calc.Abstraction;
using bl_Q1Calculator.Calc.Implementation;
using FluentAssertions;
using NUnit.Framework;
using Moq;

namespace bl_Q1Calculator.tests;

[TestFixture]
public class CalculatorRepoTests
{
    private ICalculatorRepo _calculatorRepo;

    [SetUp]
    public void SetUp()
    {
        _calculatorRepo = new CalculatorRepo();
    }

    [Test]
    public void Multiply_ShouldReturnCorrectResult()
    {
        // Arrange
        float number1 = 5;
        float number2 = 2;

        // Act
        float result = _calculatorRepo.Multiply(number1, number2);

        // Assert
        result.Should().Be(10);
    }

    [Test]
    public void Add_ShouldReturnCorrectResult()
    {
        // Arrange
        float number1 = 5;
        float number2 = 2;

        // Act
        float result = _calculatorRepo.Add(number1, number2);

        // Assert
        result.Should().Be(7);
    }

    [Test]
    public void Subtract_ShouldReturnCorrectResult()
    {
        // Arrange
        float number1 = 5;
        float number2 = 2;

        // Act
        float result = _calculatorRepo.Subtract(number1, number2);

        // Assert
        result.Should().Be(3);
    }

    [Test]
    public void Divide_ShouldReturnCorrectResult()
    {
        // Arrange
        float number1 = 10;
        float number2 = 2;

        // Act
        float result = _calculatorRepo.Divide(number1, number2);

        // Assert
        result.Should().Be(5);
    }

    [Test]
    public void Divide_ByZero_ShouldThrowDivideByZeroException()
    {
        // Arrange
        float number1 = 10;
        float number2 = 0;

        // Act
        Action action = () => _calculatorRepo.Divide(number1, number2);

        // Assert
        action.Should().Throw<DivideByZeroException>()
            .WithMessage("Division by zero is not allowed.");
    }
}