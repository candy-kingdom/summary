# Summary.Samples.Sample
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

```cs
public class Sample<T0, T1>
```

## Type Parameters
- `T0`: A first type parameter.
- `T1`: A second type parameter.

## Delegates
### Delegate1(int, int)
A sample delegate.

```cs
public void Delegate1(int x, int y)
```

## Events
### Event1
A sample field event.

```cs
public event Action Event1
```

### Event2
A sample property event.

```cs
public Action Event2 { add; remove; }
```

## Fields
### Field1
A sample field.

```cs
public int Field1
```

### Field2
A pair of fields.

```cs
public int Field2
```

### Field3
A pair of fields.

```cs
public int Field3
```

## Properties
### Property1
A sample property.

```cs
public int Property1 { get; set; }
```

### Property2
A sample property with custom visibility.

```cs
public int Property2 { private get; set; }
```

### Property3
A sample property with custom visibility (2).

```cs
public int Property3 { get; protected set; }
```

### Property4
A sample property with custom accessors.

```cs
public int Property4 { get; set; }
```

## Indexers
### this[int]
A sample indexer.

```cs
public int this[int i] { get; }
```

#### Parameters
- `i`: The parameter for indexer.

#### Returns
What indexer returns.

## Methods
### Method<M0, M1, M2>(int, string)
A simple method.
It contains two parameters:
- `x` means `x`
- `y` means `y`
It contains three type parameters:
- `M0` is the first one
- `M1` is the second one
- `M2` is the third one

```cs
public TimeSpan Method<M0, M1, M2>(int x, string y)
```

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
The overloaded [`Method{M0,M1,M2}(int,string)`](./Method{M0,M1,M2}(int,string).md).

```cs
public TimeSpan Method<M0, M1, M2>(short x, string y)
```

#### Type Parameters
- `M0`: The first type parameter of the method.
- `M1`: The second type parameter of the method.
- `M2`: The third type parameter of the method.

#### Parameters
- `x`: The `x` of the method.
- `y`: The `y` of the method.

#### Returns
The `TimeSpan` instance.

