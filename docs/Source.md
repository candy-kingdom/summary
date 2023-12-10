# [Summary.Pipes.IO.Source](../src/Core/Pipes/IO/Source.cs#L7)
```cs
public record Source(string Text, string? Path = null)
```

A text file with source code.

## Properties
### Text
```cs
public string Text { get; }
```

The text file content.

### Path
```cs
public string? Path { get; }
```

The path to the file.

## Methods
### Read(string, CancellationToken)
```cs
public static async Task<Source> Read(string path, CancellationToken token = default)
```

Reads source code from the specified file.

