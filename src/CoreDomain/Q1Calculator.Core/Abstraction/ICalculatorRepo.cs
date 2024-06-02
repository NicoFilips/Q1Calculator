namespace Q1Calculator.Core.Abstraction;

public interface ICalculatorRepo
{
        public float Multiply(float number1, float number2);
        public float Add(float number1, float number2);
        public float Subtract(float number1, float number2);
        public float Divide(float number1, float number2);
        public float Evaluate(string expression);
        public double EvaluateExpressionProgrammatically(string expression);
}
