# [Summary.DocPropertyAccessor](../src/Core/DocPropertyAccessor.cs#L6)
```cs
public record DocPropertyAccessor
```

One of the [`DocProperty`](./Summary.DocProperty.md) accessors (e.g., `get`, `set`, `init`).

## Fields
### [Access](../src/Core/DocPropertyAccessor.cs#L29)
```cs
public AccessModifier? Access
```

The access modifier of the accessor.
If the value is `null`, then the access modifier is inherited from the property declaration.

### [Kind](../src/Core/DocPropertyAccessor.cs#L34)
```cs
public AccessorKind Kind
```

The kind of the accessor.

## Methods
### [Defaults()](../src/Core/DocPropertyAccessor.cs#L11)
```cs
public static DocPropertyAccessor[] Defaults()
```

The sequence that consists only of a default `public get` property accessor.

### [Default()](../src/Core/DocPropertyAccessor.cs#L19)
```cs
public static DocPropertyAccessor Default()
```

The default `public get` property accessor.

