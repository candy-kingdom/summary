using Summary.Pipes;
using Summary.Pipes.IO;
using Summary.Roslyn.CSharp;

namespace Summary.Tests.Roslyn;

public class RoslynParserTests
{
    [Fact]
    public void Class()
    {
        const string src = "public class Person<T> : Parent, IParent { }";

        Declaration(src).Should().Be("public class Person<T> : Parent, IParent");
    }

    [Fact]
    public void Record()
    {
        const string src = "public record Person<T>(string FirstName, string LastName) : Parent(FirstName) { }";

        Declaration(src).Should().Be("public record Person<T>(string FirstName, string LastName) : Parent(FirstName)");
    }

    [Fact]
    public void RecordStruct()
    {
        const string src = "public record struct Person<T>(string FirstName, string LastName) : Parent(FirstName);";

        Declaration(src).Should().Be("public record struct Person<T>(string FirstName, string LastName) : Parent(FirstName)");
    }

    private static string Declaration(string src) =>
        new ParseSyntaxTreePipe()
            .Then(new ParseDocPipe())
            .RunSync(new Source(src))
            .Members
            .OfType<DocTypeDeclaration>()
            .Single()
            .Declaration;
}