using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter postfix expression:");
            string postfixExpression = Console.ReadLine();

            int result = RemoveWhiteSpace(postfixExpression);
            Console.WriteLine($"Result: {result}");
        }

        static int RemoveWhiteSpace(string expression)
        {
            Stack<int> stack = new Stack<int>();

            foreach (char c in expression)
            {
                if (char.IsDigit(c))
                {
                    // Convert char digit to integer
                    stack.Push(c - '0');
                }
                else if (IsOperator(c))
                {
                    int operand2 = stack.Pop();
                    int operand1 = stack.Pop();
                    int res = OperationCall(operand1, operand2, c);
                    stack.Push(res);
                }
                // Ignore whitespace
            }

            return stack.Pop();
        }

        static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        static int OperationCall(int operand1, int operand2, char op)
        {
            switch (op)
            {
                case '+':
                    return operand1 + operand2;
                case '-':
                    return operand1 - operand2;
                case '*':
                    return operand1 * operand2;
                case '/':
                    if (operand2 == 0)
                        throw new DivideByZeroException("Cannot divide by zero");
                    return operand1 / operand2;
                default:
                    throw new ArgumentException("Invalid operator");
            }
        }
    }
}
