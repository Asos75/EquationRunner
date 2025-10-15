using UnityEngine;

public class EquationGenerator
{
    public static (string equation, int answer) GenerateEquation(int minValue, int maxValue)
    {
        int operationCount = UnityEngine.Random.Range(1, 2);

        int currentValue = UnityEngine.Random.Range(minValue, maxValue + 1);
        string equation = currentValue.ToString();

        for (int i = 0; i < operationCount; i++)
        {
            char op = GetRandomOperator();
            int nextValue = UnityEngine.Random.Range(minValue, maxValue + 1);

            if (op == '/' && nextValue == 0)
                nextValue = 1;

            if (op == '/')
            {
                currentValue = currentValue - (currentValue % nextValue);
                if (nextValue == 0) nextValue = 1;
            }

            equation += $" {op} {nextValue}";
            currentValue = ApplyOperator(currentValue, nextValue, op);
        }

        return (equation, currentValue);
    }

    private static char GetRandomOperator()
    {
        char[] ops = { '+', '-', '*', '/' };
        return ops[UnityEngine.Random.Range(0, ops.Length)];
    }

    private static int ApplyOperator(int a, int b, char op)
    {
        return op switch
        {
            '+' => a + b,
            '-' => a - b,
            '*' => a * b,
            '/' => b != 0 ? a / b : a,
            _ => a
        };
    }
}

