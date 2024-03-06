namespace SimpleCalculator
{
    public class Calculator
    {
        public static double EvaluateExpression(string expression)
        {
            expression = TrimOperation(expression);

            string[] parts = expression.Split(new char[] { '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
            {
                throw new ArgumentException("Invalid expression format. Expression must contain exactly two operands and one operator.");
            }

            double operand1 = Convert.ToDouble(parts[0]);
            char op = expression[parts[0].Length];
            double operand2 = Convert.ToDouble(parts[1]);

            switch (op)
            {
                case '+':
                    return Add(operand1, operand2);
                case '-':
                    return Sub(operand1, operand2);
                case '*':
                    return Mult(operand1, operand2);
                case '/':
                    return Div(operand1, operand2);
                default:
                    throw new ArgumentException("Invalid operator: " + op);
            }
        }

        private static double Add(double a, double b)
        {
            return a + b;
        }

        private static double Sub(double a, double b)
        {
            return a - b;
        }

        private static double Mult(double a, double b)
        {
            return a * b;
        }

        private static double Div(double a, double b)
        {
            return a / b;
        }

        public static string TrimOperation(string opString)
        {
            return opString.Replace(" ", "");
        }
    }
}
