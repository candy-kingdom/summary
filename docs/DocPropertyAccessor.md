# Summary.DocPropertyAccessor
```cs
public record DocPropertyAccessor
```

One of the [`DocProperty`](./DocProperty.md) accessors (e.g., `get`, `set`, `init`).

## Fields
### Access
```cs
public AccessModifier Access
```

The access modifier of the accessor.

### Kind
```cs
public AccessorKind Kind
```

The kind of the accessor.

## Methods
### Defaults()
```cs
public static DocPropertyAccessor[] Defaults()
```

The sequence that consists only of a default `public get` property accessor.

### Default()
```cs
public static DocPropertyAccessor Default()
```

The default `public get` property accessor.

