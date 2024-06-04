using Q1Calculator.Core.Abstraction;
using Q1Calculator.Core.Implementation;
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
        string expression = "3+5";

        // Act
        float result = _calculatorRepo.Evaluate(expression);

        // Assert
        result.Should().Be(8);
    }

    [Test]
    public void Evaluate_ShouldReturnCorrectResult_ForComplexExpression()
    {
        // Arrange
        string expression = "2+3*4";

        // Act
        float result = _calculatorRepo.Evaluate(expression);

        // Assert
        result.Should().Be(14);
    }

    [Test]
    public void Evaluate_ShouldReturnCorrectResult_ForExpressionWithParentheses()
    {
        // Arrange
        string expression = "(2+3)*4";

        // Act
        float result = _calculatorRepo.Evaluate(expression);

        // Assert
        result.Should().Be(20);
    }

    [Test]
    public void Evaluate_ShouldReturnCorrectResult_ForExpressionWithDivision()
    {
        // Arrange
        string expression = "20/4";

        // Act
        float result = _calculatorRepo.Evaluate(expression);

        // Assert
        result.Should().Be(5);
    }

    [Test]
    [TestCase("3+5", 8)]
    [TestCase("(1+2)*3", 9)]
    [TestCase("5/(2-1)", 5)]
    [TestCase("4*(3+2)-7", 13)]
    [TestCase("10/2+3*(2-1)", 8)]
    public void EvaluateExpressionProgrammatically_ValidExpressions_ReturnsExpectedResults(string expression, double expected)
    {
        double result = _calculatorRepo.EvaluateExpressionProgrammatically(expression);
        result.Should().BeApproximately(expected, 1e-5);
    }

    [Test]
    [TestCase("3++5")]
    [TestCase("3 ** 5")]
    [TestCase("3 // 5")]
    [TestCase("(3 + 5")]
    [TestCase("3 + 5)")]
    public void EvaluateExpressionProgrammatically_InvalidExpressions_ThrowsException(string expression)
    {
        Action act = () => _calculatorRepo.EvaluateExpressionProgrammatically(expression);
        act.Should().Throw<ArgumentException>();
    }
}
