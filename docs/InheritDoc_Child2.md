# Summary.Samples.InheritDoc_Child2
```cs
public class InheritDoc_Child2 : InheritDoc_Child
```

Summary.

_Remarks section._

## Events
### Event1
```cs
public new event Action Event1
```

An event.

### Event2
```cs
public event Action Event2
```

An event.

### Event3
```cs
public event Action? Event3
```

An event.

### Event4
```cs
public event Action? Event4
```

An event.

## Properties
### Property1
```cs
public override int Property1 { get; set; }
```

A property.

_Property remarks._

### Property2
```cs
public override int Property2 { get; set; }
```

A property.

_Property remarks._

### Property4
```cs
public int Property4 { get; set; }
```

A property.

_Property remarks._

### Property5
```cs
public int Property5 { get; set; }
```

A property.

_Property remarks._

## Indexers
### this[int]
```cs
public override int this[int i] { get; }
```

An indexer.

#### Parameters
- `i`: A parameter to the indexer.

## Methods
### Sum(int, int)
```cs
public override int Sum(int x, int y)
```

Calculates the sum.

_Sum remarks._

#### Parameters
- `x`: The first parameter.
- `y`: The second parameter.

#### Returns
Returns the sum of two values.

