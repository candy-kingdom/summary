# [Summary.Caching.CrefCache](../src/Core/Caching/CrefCache.cs#L9)
```cs
public static partial class CrefCache
```

A cache of different `cref` conversions.

## Methods
### [AsCref(string)](../src/Core/Caching/CrefCache.cs#L30)
```cs
public static string AsCref(this string self)
```

Converts the given string into the format of `cref` attribute value.

#### Example
In the following example, the `"Some&lt;T1, T2&gt;"` string
(which represents the name of some type)
is converted into `"Some{T1,T2}"` as if it was a value of a link
(e.g., &lt;see cref="Some{T1,T2}"&gt;):
```cs
var a = "Some&lt;T1, T2&gt;";
var b = a.AsCref();
&lt;br/&gt;
b.Should().Be("Some{T1,T2}");
```

### [AsRawCref(string)](../src/Core/Caching/CrefCache.cs#L51)
```cs
public static string AsRawCref(this string self)
```

Converts the given string into the format of `cref` attribute value
but also removes all generic parameter names.

#### Example
In the following example, the `"Some&lt;T1, T2&gt;"` string
(which represents the name of some type)
is converted into `"Some{,}"`, the raw form of `cref` that can be used for comparisons
without involving generic type parameter names.
```cs
var a = "Some&lt;T1, T2&gt;";
var b = a.AsCref();
&lt;br/&gt;
b.Should().Be("Some{,}");
```

### [FromCref(string)](../src/Core/Caching/CrefCache.cs#L73)
```cs
public static string FromCref(this string self)
```

Converts the given string from the format of `cref` attribute value.

#### Example
In the following example, the `"Some{T1,T2}"` string
(which represents the name of some type in the `cref` format)
is converted into `"Some&lt;T1, T2&gt;` so that it can be displayed somewhere.
```cs
var a = "Some{T1,T2}";
var b = a.AsCref();
&lt;br/&gt;
b.Should().Be("Some&lt;T1, T2&gt;");
```

