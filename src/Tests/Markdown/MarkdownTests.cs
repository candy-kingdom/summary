using Summary.Markdown;
using Summary.Pipes;
using Summary.Pipes.IO;
using Summary.Roslyn.CSharp;

namespace Summary.Tests.Markdown;

public class MarkdownTests
{
    [Fact]
    public void NewLinePreserved() => Parsed(
        """
        /// <summary>
        ///     A text.
        ///
        ///     Another text.
        /// </summary>
        public record Person;
        """)
        .Should().Be($"A text.{Environment.NewLine}{Environment.NewLine}Another text.");

    [Fact]
    public void LinkBeforeDot() => Parsed(
        """
        /// <summary>
        ///     A <see cref="Link"/>.
        /// </summary>
        public record Person;
        """)
        .Should().Be("A [`Link`](./Link.md).");

    [Fact]
    public void LinkBeforeSpace() => Parsed(
        """
        /// <summary>
        ///     A <see cref="Link"/> to something.
        /// </summary>
        public record Person;
        """)
        .Should().Be("A [`Link`](./Link.md) to something.");

    private static string Parsed(string src) =>
        new ParseSyntaxTreePipe()
            .Then(new ParseDocPipe())
            .RunSync(new Source(src))
            .Members
            .OfType<DocTypeDeclaration>()
            .Single()
            .Comment
            .Element("summary")!
            .Render();
}