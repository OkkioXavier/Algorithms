using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Algorithms.Paths;

public static class PathCleaner
{
    public static string GetCanonicalPath(string absolutePath)
    {
        var components = absolutePath.Split("/", StringSplitOptions.RemoveEmptyEntries)
            .Where(c => c != ".");
        var builder = new StringBuilder();
        var stack = new Stack<string>(components);

        while (TryGetNextComponent(stack, out var directory))
        {
            builder.Insert(0, directory);
            builder.Insert(0, "/");
        }

        return builder.Length == 0 ? "/" : builder.ToString();
    }

    static bool TryGetNextComponent(Stack<string> stack, [NotNullWhen(returnValue: true)] out string? file)
    {
        file = null;

        if (stack.Count == 0)
        {
            return false;
        }

        var popCount = 1;
        string? nextComponent = null;

        while (popCount > 0)
        {
            if (stack.Count == 0)
            {
                return false;
            }

            nextComponent = stack.Pop();

            if (nextComponent == "..")
            {
                popCount++;
            }
            else
            {
                popCount--;
            }
        }

        if (nextComponent is null)
        {
            return false;
        }

        file = nextComponent;
        return true;
    }
}