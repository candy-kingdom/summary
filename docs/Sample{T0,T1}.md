# Summary.Samples.Sample<T0, T1>
```cs
public class Sample<T0, T1>
```

A sample class that is documented.
This a second paragraph.
It is indented.
This is the third paragraph.
Here is a _italic_, _italic2_ fragment.
Here is a **bold**, **bold2** fragment.
Here is a `code` fragment.
Here is a ~~strikethrough~~ fragment.

_Remarks section._
_Second line._
_Another paragraph._
_Btw, this type has a child: [`Sample{T0,T1}.Child`](./Sample{T0,T1}.Child.md)._

## Type Parameters
- `T0`: A first type parameter.
- `T1`: A second type parameter.

## Delegates
### Delegate1(int, int)
```cs
public void Delegate1(int x, int y)
```

A sample delegate.

## Events
### Event1
```cs
public event Action Event1
```

A sample field event.

### Event2
```cs
public Action Event2 { add; remove; }
```

A sample property event.

## Fields
### Field
```cs
public int Field
```

A field of the child class.

### ~~Field1~~
> [!WARNING]
> "The field is deprecated."

```cs
[Obsolete("The field is deprecated.")]
public int Field1
```

A sample field.

### Field2
```cs
public int Field2
```

A pair of fields.

### Field3
```cs
public int Field3
```

A pair of fields.

## Properties
### Property1
```cs
public int Property1 { get; set; }
```

A sample property.

### Property2
```cs
public int Property2 { private get; set; }
```

A sample property with custom visibility.

### Property3
```cs
public int Property3 { get; protected set; }
```

A sample property with custom visibility (2).

### Property4
```cs
public int Property4 { get; set; }
```

A sample property with custom accessors.

## Indexers
### this[int]
```cs
public int this[int i] { get; }
```

A sample indexer.

#### Parameters
- `i`: The parameter for indexer.

#### Returns
What indexer returns.

## Methods
### Method<M0, M1, M2>(int, string)
```cs
public TimeSpan Method<M0, M1, M2>(int x, string y)
```

A simple method.
It contains two parameters:
- `x` means `x`
- `y` means `y`
It contains three type parameters:
- `M0` is the first one
- `M1` is the second one
- `M2` is the third one

#### Type Parameters
- `M0`: The first type parameter of the method.
- `M1`: The second type parameter of the method.
- `M2`: The third type parameter of the method.

#### Parameters
- `x`: The `x` of the method.
- `y`: The `y` of the method.

#### Returns
The `TimeSpan` instance.

### Method<M0, M1, M2>(short, string)
```cs
public TimeSpan Method<M0, M1, M2>(short x, string y)
```

The overloaded [`Method{M0,M1,M2}(int,string)`](./Method{M0,M1,M2}(int,string).md).

#### Type Parameters
- `M0`: The first type parameter of the method.
- `M1`: The second type parameter of the method.
- `M2`: The third type parameter of the method.

#### Parameters
- `x`: The `x` of the method.
- `y`: The `y` of the method.

#### Returns
The `TimeSpan` instance.

