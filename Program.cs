using System;
using System.Collections.Generic;

// Client code
class Program
{
    static void Main(string[] args)
    {
        // Create a context and set variable values
        var context = new Context();
        context.Variables["a"] = 10;
        context.Variables["b"] = 5;

        // Build the expression: 10 + 5 - 2
        Expression expression = new SubtractionExpression(
            new AdditionExpression(
                new NumberExpression(context.GetVariableValue("a")),
                new NumberExpression(context.GetVariableValue("b"))
            ),
            new NumberExpression(2)
        );

        // Evaluate the expression
        int result = expression.Interpret(context);

        Console.WriteLine("Result: " + result); // Output: Result: 13
    }
}


// Context
class Context
{
    public Dictionary<string, int> Variables { get; set; }

    public Context()
    {
        Variables = new Dictionary<string, int>();
    }

    public int GetVariableValue(string variableName)
    {
        if (Variables.ContainsKey(variableName))
            return Variables[variableName];

        return 0;
    }
}

// Abstract Expression
abstract class Expression
{
    public abstract int Interpret(Context context);
}

// Terminal Expression
class NumberExpression : Expression
{
    private readonly int number;

    public NumberExpression(int number)
    {
        this.number = number;
    }

    public override int Interpret(Context context)
    {
        return number;
    }
}

// Non-terminal Expression
class AdditionExpression : Expression
{
    private readonly Expression left;
    private readonly Expression right;

    public AdditionExpression(Expression left, Expression right)
    {
        this.left = left;
        this.right = right;
    }

    public override int Interpret(Context context)
    {
        return left.Interpret(context) + right.Interpret(context);
    }
}

// Non-terminal Expression
class SubtractionExpression : Expression
{
    private readonly Expression left;
    private readonly Expression right;

    public SubtractionExpression(Expression left, Expression right)
    {
        this.left = left;
        this.right = right;
    }

    public override int Interpret(Context context)
    {
        return left.Interpret(context) - right.Interpret(context);
    }
}