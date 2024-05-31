using System.Data;
using bl_Q1Calculator.Core.Abstraction;

namespace bl_Q1Calculator.Core.Implementation;

public class CalculatorRepo : ICalculatorRepo
{
    public float Multiply(float number1, float number2) => number1 * number2;

    public float Add(float number1, float number2) => number1 + number2;

    public float Subtract(float number1, float number2) => number1 - number2;


    public float Divide(float number1, float number2)
    {
        if (number1 == 0 || number2 == 0)
            throw new DivideByZeroException("Division by zero is not allowed.");

        return number1 / number2;
    }
    
    public float Evaluate(string expression)
    {
        return (float)EvaluateExpression(expression);
    }

    private double EvaluateExpression(string expression)
    {
        var table = new DataTable();
        table.Columns.Add("expression", typeof(string), expression);
        DataRow row = table.NewRow();
        table.Rows.Add(row);
        return double.Parse((string)row["expression"]);
    }
}