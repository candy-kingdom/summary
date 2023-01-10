namespace Summary;

/// <summary>
///     A <see cref="DocCommentNode"/> that represents a compound element (e.g. summary, remarks, and other XML elements).
/// </summary>
/// <param name="Name">The name of the element (e.g. `remarks`, `summary`, `example`).</param>
/// <param name="Nodes">The sequence of nodes this element consists of.</param>
/// <remarks>
///     Each element can contain simple text as well as other elements.
/// </remarks>
public record DocCommentElement(string Name, DocCommentElementAttribute[] Attributes, DocCommentNode[] Nodes) : DocCommentNode
{
    internal DocComment Comment() => new(Nodes);

    internal DocComment Summary() => new(new[]
        { new DocCommentElement("summary", Array.Empty<DocCommentElementAttribute>(), Nodes) });

    internal DocCommentElementAttribute? Attribute(string name) =>
        Attributes.FirstOrDefault(x => x.Name == name);
}