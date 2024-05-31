using bl_Q1Calculator.Calc.Abstraction;

namespace bl_Q1Calculator.Calc.Implementation;

public class CalculatorRepo : ICalculatorRepo
{
    public float Multiply(float number1, float number2) => number1 * number2;

    public float Add(float number1, float number2) => number1 + number2;

    public float Subtract(float number1, float number2) => number1 - number2;


    public float Divide(float number1, float number2)
    {
        if (number1 == 0 && number2 == 0)
            throw new DivideByZeroException("Division by zero is not allowed.");

        return number1 / number2;
    }
}