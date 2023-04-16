# Summary.Samples.InheritDoc_Child
Summary.

_Remarks section._

```cs
public class InheritDoc_Child : InheritDocBase
```

## Events
### Event1
An event.

```cs
public override event Action Event1
```

## Properties
### Property1
A property.

_Property remarks._

```cs
public override int Property1 { get; set; }
```

## Indexers
### this[int]
An indexer.

```cs
public override int this[int i] { get; }
```

#### Parameters
- `i`: A parameter to the indexer.

## Methods
### Sum(int, int)
Calculates the sum.

```cs
public override int Sum(int x, int y)
```

#### Parameters
- `x`: The first parameter.
- `y`: The second parameter.

#### Returns
Returns the sum of two values.

