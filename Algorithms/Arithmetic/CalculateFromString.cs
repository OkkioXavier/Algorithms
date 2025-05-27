namespace Algorithms.Arithmetic;

public static class CalculateFromString
{
    public static int Calculate(string s)
    {
        // Consider - as a unary operator
        // Find the most nested bracket and substitute the value
        // When no brackets remain evaluate the expression

        // Locate the first closing bracket
        // Work back to the nearest opening bracket
        // Evaluate each operator and then replace the element on the stack
        // var expression = new Expression();
        var stack = new Stack<Expression>();

        for (int i = 0; i < s.Length; i++)
        {
            switch (s[i])
            {
                case '(':
                    stack.Push(new Parenthesis());
                    break;
                case ')':
                    var innerExpression = stack.Pop();

                    if (stack.Count == 0)
                    {
                        stack.Push(innerExpression);
                    }
                    else
                    {
                        var parenthesis = stack.Pop();
                        if (parenthesis is Parenthesis paren)
                        {
                            paren.Expression = innerExpression;

                            if (stack.Count == 0)
                            {
                                stack.Push(paren);
                            }
                            else
                            {
                                UpdateOperator(stack, paren);
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException("Unbalanced parentheses");
                        }   
                    }

                    break;
                case ' ':
                    continue;
                case '+':
                    var add = new Add(stack.Pop());
                    stack.Push(add);
                    break;
                case '*':
                    var multiply = new Multiply(stack.Pop());
                    stack.Push(multiply);
                    break;
                case '-':
                    if (stack.Count == 0
                        || stack.Peek() is BinaryExpression {Right: null}
                        || stack.Peek() is Parenthesis {Expression: null})
                    {
                        stack.Push(new UnaryMinus());
                    }
                    else
                    {
                        stack.Push(new Subtract(stack.Pop()));
                    }
                    break;
                default:
                    var start = i;
                    while (i < s.Length && char.IsNumber(s[i]))
                    {
                        i++;
                    }
                    var number = new Number(int.Parse(s[start..i]));
                    i--; // Because we're going to add one at the start of the loop

                    if (stack.Count > 0)
                    {
                        UpdateOperator(stack, number);
                    }
                    else
                    {
                        stack.Push(number);
                    }

                    break;
            }
        }


        return stack.Pop().Solve();
    }

    private static void UpdateOperator(Stack<Expression> stack, Expression expression)
    {
        switch (stack.Peek())
        {
            case Parenthesis:
                stack.Push(expression);
                break;
            case BinaryExpression binary:
                binary.Right = expression;
                break;
            case UnaryMinus unary:
                unary.RightExpression = expression;
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    private abstract record Expression
    {
        public abstract int Solve();
    }

    private record Number(int Value) : Expression
    {
        public override int Solve()
        {
            return Value;
        }
    }

    private abstract record BinaryExpression(Expression Left) : Expression
    {
        public Expression? Right { get; set; }
    }

    private record Add(Expression Left) : BinaryExpression(Left)
    {
        public override int Solve()
        {
            return Left.Solve() + Right.Solve();
        }
    }

    private record Subtract(Expression Left) : BinaryExpression(Left)
    {
        public override int Solve()
        {
            return Left.Solve() - Right.Solve();
        }
    }

    private record Multiply(Expression Left) : BinaryExpression(Left)
    {
        public override int Solve()
        {
            return Left.Solve() * Right.Solve();
        }
    }

    private record UnaryMinus() : Expression
    {
        public override int Solve()
        {
            return -RightExpression.Solve();
        }

        public Expression RightExpression { get; set; }
    }

    private record Parenthesis : Expression
    {
        public override int Solve()
        { 
            return Expression?.Solve() ?? 0;
        }

        public Expression Expression { get; set; }
    }
}