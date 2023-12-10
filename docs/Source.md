# [Summary.Pipes.IO.Source](../src/Core/Pipes/IO/Source.cs#L7)
```cs
public record Source(string Text, string? Path = null)
```

A text file with source code.

## Properties
### [Text](../src/Core/Pipes/IO/Source.cs#L7)
```cs
public string Text { get; }
```

The text file content.

### [Path](../src/Core/Pipes/IO/Source.cs#L7)
```cs
public string? Path { get; }
```

The path to the file.

## Methods
### [Read(string, CancellationToken)](../src/Core/Pipes/IO/Source.cs#L12)
```cs
public static async Task<Source> Read(string path, CancellationToken token = default)
```

Reads source code from the specified file.

