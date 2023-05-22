using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите выражение в постфиксной нотации:");
        string expression = Console.ReadLine();
        int result = PostfixEvaluation(expression);
        Console.WriteLine("Результат вычисления: " + result);
    }

    static int PostfixEvaluation(string expression)
    {
        Stack<int> stack = new Stack<int>();

        string[] tokens = expression.Split(' ');

        foreach (string token in tokens)
        {
            if (IsOperator(token))
            {
                int operand2 = stack.Pop();
                int operand1 = stack.Pop();
                int result = PerformOperation(token, operand1, operand2);
                stack.Push(result);
            }
            else
            {
                int number = int.Parse(token);
                stack.Push(number);
            }
        }

        return stack.Pop();
    }

    static bool IsOperator(string token)
    {
        return token == "+" || token == "-" || token == "*" || token == "/";
    }

    static int PerformOperation(string operatorSymbol, int operand1, int operand2)
    {
        switch (operatorSymbol)
        {
            case "+":
                return operand1 + operand2;
            case "-":
                return operand1 - operand2;
            case "*":
                return operand1 * operand2;
            case "/":
                return operand1 / operand2;
            default:
                throw new ArgumentException("Недопустимый оператор: " + operatorSymbol);
        }
    }
}
