using System;
using System.Collections.Generic;
using UnityEngine;

public class EquationGenerator
{
    private static System.Random random = new System.Random();

    public static (string equation, int answer) GenerateEquation(int minValue, int maxValue, bool addSub, bool mulDiv, int opCount)
    {
        List<char> allowedOps = new List<char>();
        if (addSub)
            allowedOps.AddRange(new char[] { '+', '-' });
        if (mulDiv)
            allowedOps.AddRange(new char[] { '*', '/' });

        if (allowedOps.Count == 0)
            allowedOps.Add('+'); // fallback

        List<int> numbers = new List<int>();
        List<char> ops = new List<char>();

        // Generate initial random numbers
        for (int i = 0; i <= opCount; i++)
            numbers.Add(random.Next(minValue, maxValue + 1));

        // Generate operations
        for (int i = 0; i < opCount; i++)
            ops.Add(allowedOps[random.Next(allowedOps.Count)]);

        // Fix division/multiplication
        for (int i = 0; i < ops.Count; i++)
        {
            if (ops[i] == '/')
            {
                // Generate dividend first in a reasonable range
                int dividend = random.Next(minValue, maxValue + 1);
                int factor = random.Next(1, 11); // up to 10×
                dividend *= factor;

                // Find divisors of dividend greater than 1
                List<int> possibleDivisors = new List<int>();
                for (int d = 2; d <= Math.Min(dividend, maxValue); d++)
                {
                    if (dividend % d == 0)
                        possibleDivisors.Add(d);
                }

                // If no divisors found, fallback to 2
                int divisor = (possibleDivisors.Count > 0)
                              ? possibleDivisors[random.Next(possibleDivisors.Count)]
                              : 2;

                numbers[i] = dividend;
                numbers[i + 1] = divisor;
            }

            else if (ops[i] == '*')
            {
                int multiplier = numbers[i + 1];
                // Skip 1
                while (multiplier == 1)
                    multiplier = random.Next(minValue, maxValue + 1);
                numbers[i + 1] = multiplier;
            }
        }

        // Build equation string
        string equation = numbers[0].ToString();
        for (int i = 0; i < ops.Count; i++)
        {
            equation += $" {ops[i]} {numbers[i + 1]}";
        }

        // Evaluate result
        int answer = EvaluateEquation(numbers, ops);

        return (equation, answer);
    }

    private static int EvaluateEquation(List<int> numbers, List<char> ops)
    {
        List<int> tempNumbers = new List<int>(numbers);
        List<char> tempOps = new List<char>(ops);

        // Handle * and /
        for (int i = 0; i < tempOps.Count;)
        {
            if (tempOps[i] == '*' || tempOps[i] == '/')
            {
                int a = tempNumbers[i];
                int b = tempNumbers[i + 1];
                if (b == 0) b = 1;

                tempNumbers[i] = (tempOps[i] == '*') ? a * b : a / b;

                tempNumbers.RemoveAt(i + 1);
                tempOps.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }

        // Handle + and -
        int result = tempNumbers[0];
        for (int i = 0; i < tempOps.Count; i++)
        {
            int b = tempNumbers[i + 1];
            if (tempOps[i] == '+')
                result += b;
            else if (tempOps[i] == '-')
                result -= b;
        }

        return result;
    }
}
