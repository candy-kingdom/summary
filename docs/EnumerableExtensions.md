# EnumerableExtensions
Extension methods for [`IEnumerable{T}`](./IEnumerable{T}.md).

```cs
public static EnumerableExtensions 
```

## Methods
### Separated
Constructs a new string by placing the specified separator between each item in the specified sequence.

```cs
public static string Separated<T>(this IEnumerable<T> self, string with)
```

#### Example
```cs
var ss = new[] { "A", "B", "C" };
var s = ss.Separated(with: ", ");

s.Should().Be("A, B, C");
```

### NonNulls
Filters out all `null` values from the specified sequence.

```cs
public static IEnumerable<T> NonNulls<T>(this IEnumerable<T?> self)
```

