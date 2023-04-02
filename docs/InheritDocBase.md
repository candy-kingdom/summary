# InheritDocBase
Summary.

_Remarks section._

```cs
public class InheritDocBase
```

## Events
### Event1
An event.

```cs
public virtual event Action Event1
```

## Fields
### Field1
A field.

```cs
public int Field1
```

### Field2
A field.

```cs
public int Field2
```

## Properties
### Property1
A property.

_Property remarks._

```cs
public virtual int Property1 { get; set; }
```

### Property2
A property.

_Property remarks._

```cs
public virtual int Property2 { get; set; }
```

### Property3
A property.

_Property remarks._

```cs
public int Property3 { get; set; }
```

## Indexers
### this[int]
An indexer.

```cs
public virtual int this[int i] { get; }
```

#### Parameters
- `i`: A parameter to the indexer.

## Methods
### Sum(int, int)
Calculates the sum.

```cs
public virtual int Sum(int x, int y)
```

#### Parameters
- `x`: The first parameter.
- `y`: The second parameter.

#### Returns
Returns the sum of two values.

### Sum<T>(byte, byte)
Calculates the byte sum.

```cs
public byte Sum<T>(byte x, byte y)
```

#### Parameters
- `x`: The first byte parameter.
- `y`: The second byte parameter.

#### Type Parameters
- `T`: The type parameter.

#### Returns
Returns the sum of two values.

### Sum(short, short)
```cs
public short Sum(short x, short y)
```

### Sum2(short, short)
```cs
public short Sum2(short x, short y)
```

### Sum3(short, short)
```cs
public short Sum3(short x, short y)
```

### Sum4(short, short)
```cs
public short Sum4(short x, short y)
```

