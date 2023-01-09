using Summary.Markdown.Extensions;
using Summary.Pipes;
using Summary.Roslyn.CSharp;

namespace Summary.Tests.Markdown;

public class MarkdownRendererTests
{
    [Fact]
    public void LinkBeforeDot() => Parsed(@"
/// <summary>
///     A <see cref=""Link""/>.
/// </summary>,,
public record Person;")
        .Should().Be("A [`Link`](./Link.md).");

    [Fact]
    public void LinkBeforeSpace() => Parsed(@"
/// <summary>
///     A <see cref=""Link""/> to something.
/// </summary>
public record Person;")
        .Should().Be("A [`Link`](./Link.md) to something.");

    private static string Parsed(string src) =>
        new ParseSyntaxTreePipe()
            .Then(new ParseDocPipe())
            .RunSync(src)
            .Members
            .OfType<DocType>()
            .Single()
            .Comment
            .Element("summary")!
            .Render();
}