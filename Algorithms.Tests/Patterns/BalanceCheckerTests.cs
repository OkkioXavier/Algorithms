using Algorithms.Patterns;
using FluentAssertions;

namespace Algorithms.Tests.Patterns;

public class BalanceCheckerTests
{
    [Theory]
    [InlineData('(', ')', "(")]
    [InlineData('(', ')', "((()())()")]
    [InlineData('{', '}', "{{}")]
    [InlineData('(', ')', "(()()()(")]
    [InlineData('(', ')', ")")]
    [InlineData('(', ')', ")()(")]
    [InlineData('(', ')', "())")]
    public void BalanceCheckerReturnsFalseForUnbalancedSequences(char open, char close, IEnumerable<char> sequence)
    {
        BalanceChecker.Check(open, close, sequence).Should().BeFalse();
    }

    [Theory]
    [InlineData('(', ')', "()")]
    [InlineData('(', ')', "")]
    [InlineData('(', ')', "(()()()())")]
    public void BalanceCheckerReturnsTrueForBalancedSequences(char open, char close, IEnumerable<char> sequence)
    {
        BalanceChecker.Check(open, close, sequence).Should().BeTrue();
    }

    [Fact]
    public void BalanceCheckerWorksForNonStringSequences()
    {
        var open = 1;
        var close = 2;
        var sequence = new[] {1,2,1,2};

        BalanceChecker.Check(open, close, sequence).Should().BeTrue();
    }

    [Fact]
    public void BalancedCheckerThrowsArgumentExceptionWhenStringContainsUnrecognisedCharacters()
    {
        var open = '(';
        var close = ')';
        var sequence = "({})";

        Action action = () => BalanceChecker.Check(open, close, sequence);

        action.Should().ThrowExactly<ArgumentException>();
    }
}