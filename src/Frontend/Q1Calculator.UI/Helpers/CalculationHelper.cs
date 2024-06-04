namespace Q1Calculator.UI.Helpers;

public static class CalculationHelper
{
        public static bool IsValidExpression(string expression)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(expression, @"^[0-9+\-*/(). ]+$");
        }


}
