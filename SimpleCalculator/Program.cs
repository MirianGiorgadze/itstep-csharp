using SimpleCalculator;

namespace projects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Simple Calculator!");
            Console.WriteLine("Enter a mathematical expression or '0' to exit.");

            string input;
            do
            {
                Console.Write("Operation: ");
                input = Console.ReadLine();

                if (input == "0")
                {
                    Console.WriteLine("Exiting calculator...");
                    break;
                }

                double result;
                try
                {
                    string trimmedOp = Calculator.TrimOperation(input);
                    result = Calculator.EvaluateExpression(trimmedOp);
                    Console.WriteLine("Result: " + result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                Console.WriteLine("Press any key to calculate more, or '0' to exit.");
            } while (input != "0");
        }
    }
    
}
