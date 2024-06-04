using System.Data;
using System.Globalization;
using Q1Calculator.Core.Abstraction;

namespace Q1Calculator.Core.Implementation;

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
        expression = expression.Replace(" ", "+");
        var table = new DataTable();
        table.Columns.Add("expression", typeof(string), expression);
        DataRow row = table.NewRow();
        table.Rows.Add(row);
        return double.Parse((string)row["expression"]);
    }


 public double EvaluateExpressionProgrammatically(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
        {
            throw new ArgumentException("Expression cannot be null or whitespace.");
        }

        expression = RemoveSpaces(expression);

        var rpn = ConvertToRPN(expression);
        return EvaluateRPN(rpn);
    }

    private string RemoveSpaces(string expression)
    {
        return expression.Replace(" ", string.Empty);
    }

    private Queue<string> ConvertToRPN(string expression)
    {
        var outputQueue = new Queue<string>();
        var operatorStack = new Stack<string>();
        var numberBuffer = string.Empty;

        for (int i = 0; i < expression.Length; i++)
        {
            char token = expression[i];

            if (char.IsDigit(token) || token == '.')
            {
                numberBuffer += token;
            }
            else
            {
                if (!string.IsNullOrEmpty(numberBuffer))
                {
                    outputQueue.Enqueue(numberBuffer);
                    numberBuffer = string.Empty;
                }

                if (IsOperator(token))
                {
                    while (operatorStack.Count > 0 && IsOperator(operatorStack.Peek()[0]) &&
                           GetPrecedence(token) <= GetPrecedence(operatorStack.Peek()[0]))
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Push(token.ToString());
                }
                else if (token == '(')
                {
                    operatorStack.Push(token.ToString());
                }
                else if (token == ')')
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    if (operatorStack.Count == 0 || operatorStack.Peek() != "(")
                    {
                        throw new ArgumentException("Mismatched parentheses in expression.");
                    }
                    operatorStack.Pop(); // Pop the '('
                }
                else
                {
                    throw new ArgumentException($"Invalid character '{token}' in expression.");
                }
            }
        }

        if (!string.IsNullOrEmpty(numberBuffer))
        {
            outputQueue.Enqueue(numberBuffer);
        }

        while (operatorStack.Count > 0)
        {
            if (operatorStack.Peek() == "(" || operatorStack.Peek() == ")")
            {
                throw new ArgumentException("Mismatched parentheses in expression.");
            }
            outputQueue.Enqueue(operatorStack.Pop());
        }

        return outputQueue;
    }

    private double EvaluateRPN(Queue<string> rpnQueue)
    {
        var evaluationStack = new Stack<double>();

        while (rpnQueue.Count > 0)
        {
            string token = rpnQueue.Dequeue();

            if (double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out double number))
            {
                evaluationStack.Push(number);
            }
            else if (IsOperator(token[0]))
            {
                if (evaluationStack.Count < 2)
                {
                    throw new ArgumentException("Insufficient operands for the operator.");
                }
                double rightOperand = evaluationStack.Pop();
                double leftOperand = evaluationStack.Pop();
                double result = ApplyOperator(token[0], leftOperand, rightOperand);
                evaluationStack.Push(result);
            }
            else
            {
                throw new ArgumentException($"Invalid token '{token}' in RPN expression.");
            }
        }

        if (evaluationStack.Count != 1)
        {
            throw new ArgumentException("The user input has too many numbers.");
        }

        return evaluationStack.Pop();
    }

    private bool IsOperator(char c)
    {
        return c == '+' || c == '-' || c == '*' || c == '/';
    }

    private int GetPrecedence(char c)
    {
        switch (c)
        {
            case '+':
            case '-':
                return 1;
            case '*':
            case '/':
                return 2;
            default:
                return 0;
        }
    }

    private double ApplyOperator(char op, double left, double right)
    {
        switch (op)
        {
            case '+':
                return left + right;
            case '-':
                return left - right;
            case '*':
                return left * right;
            case '/':
                if (right == 0)
                {
                    throw new DivideByZeroException("Division by zero.");
                }
                return left / right;
            default:
                throw new ArgumentException($"Invalid operator '{op}'");
        }
    }
}
