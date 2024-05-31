    using bl_Q1Calculator.Calc.Abstraction;
    using bl_Q1Calculator.Calc.Implementation;
    using NUnit.Framework;
using FluentAssertions;

    namespace bl_Q1Calculator.tests;

[TestFixture]
public class EvaluateTests
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
    public void Evaluate_ShouldReturnCorrectResult_ForSimpleExpression()
    {
        // Arrange
        string expression = "3 + 5";

        // Act
        float result = _calculatorRepo.Evaluate(expression);

        // Assert
        result.Should().Be(8);
    }

    [Test]
    public void Evaluate_ShouldReturnCorrectResult_ForComplexExpression()
    {
        // Arrange
        string expression = "2 + 3 * 4";

        // Act
        float result = _calculatorRepo.Evaluate(expression);

        // Assert
        result.Should().Be(14);
    }

    [Test]
    public void Evaluate_ShouldReturnCorrectResult_ForExpressionWithParentheses()
    {
        // Arrange
        string expression = "(2 + 3) * 4";

        // Act
        float result = _calculatorRepo.Evaluate(expression);

        // Assert
        result.Should().Be(20);
    }

    [Test]
    public void Evaluate_ShouldReturnCorrectResult_ForExpressionWithDivision()
    {
        // Arrange
        string expression = "20 / 4";

        // Act
        float result = _calculatorRepo.Evaluate(expression);

        // Assert
        result.Should().Be(5);
    }
}