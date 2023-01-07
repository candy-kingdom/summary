using Doc.Net.Core.Pipes;

var output = await new FuncPipe<Unit, string>(_ => Console.ReadLine()!)
    .Tee(x => Console.WriteLine($"Read something from console..."))
    .Select(int.Parse)
    .Run();

Console.WriteLine($"Parsed an integer: {output}");