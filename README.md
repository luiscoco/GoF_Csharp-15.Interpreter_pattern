# GoF_Csharp-15.Interpreter_pattern

The Interpreter Pattern is a behavioral design pattern that allows you to define a language or grammar for interpreting and evaluating expressions. It enables you to build an interpreter that can understand and execute expressions written in that language. This pattern is often used in domain-specific languages (DSLs) or when you need to evaluate complex expressions.

Key components of the Interpreter Pattern:

1. Context: Represents the context or input for the expressions that need to be evaluated.

2. Abstract Expression: An abstract class or interface that defines the interpret method. All concrete expression classes will implement this interface.

3. Terminal Expression: Represents the basic elements of the language and does not have any sub-expressions.

4. Non-terminal Expression: Represents complex expressions composed of multiple sub-expressions.

```csharp
﻿using System;
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
```

## How to setup Github actions

![Csharp Github actions](https://github.com/luiscoco/GoF_Csharp-15.Interpreter_pattern/assets/32194879/ee21a9eb-b930-40da-905e-574d9e06f8e8)













