namespace Summary;

/// <summary>
///     A member of the generated document (e.g. type, field, property, method, etc.).
/// </summary>
/// <param name="Name">The name of the member (e.g. `public int Field` has name `Field`).</param>
/// <param name="Declaration">
///     The code-snippet that contains the full declaration of the member
///     (e.g. `public int Field` is a declaration of the field member `Field`).
/// </param>
/// <param name="Access">The access modifier of the member.</param>
/// <param name="Comment">The documentation comment of the member (can be empty).</param>
/// <param name="DeclaringType">The type that this member is declared in (works for nested types as well).</param>
public record DocMember(
    string FullyQualifiedName,
    string Name,
    string Declaration,
    AccessModifier Access,
    DocComment Comment,
    DocType? DeclaringType)
{
    public bool MatchesCref(string cref)
    {
        // TODO: Check whether it's enough for most of the cases.
        if (FullyQualifiedName.EndsWith(cref))
            return true;

        if (this is DocMethod method)
            return method.SignatureWithoutParams.EndsWith(cref) ||
                   method.Signature.EndsWith(cref);

        return false;
    }
}