using Algorithms.Paths;
using FluentAssertions;

namespace Algorithms.Tests.Path;

public class PathTests
{
    [Theory]
    [InlineData("/home/user/Documents/../Pictures","/home/user/Pictures")]
    [InlineData("/.../a/../b/c/../d/./","/.../b/d")]
    [InlineData("/home/user/Documents/../..","/home")]
    [InlineData("/./././././","/")]
    [InlineData("/a/./b/../../c/","/c")]
    [InlineData("/home/of/foo/../../bar/../../is/./here/.","/is/here")]
    [InlineData("/a//b////c/d//././/..","/a/b/c")]
    [InlineData("/a/../../b/../c//.//","/c")]
    [InlineData("/","/")]
    [InlineData("////","/")]
    [InlineData("/home/user/Documents/image.pdf","/home/user/Documents/image.pdf")]
    public void CanonicalPathIsCorrect(string path, string canonicalPath)
    {
        PathCleaner.GetCanonicalPath(path).Should().Be(canonicalPath);
    }
}