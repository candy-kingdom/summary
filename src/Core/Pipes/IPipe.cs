namespace Summary.Pipes;

/// <summary>
///     An asynchronous pipe that can transform an input to the output.
/// </summary>
/// <typeparam name="I">The type of the input of the pipe.</typeparam>
/// <typeparam name="O">The type of the output of the pipe.</typeparam>
public interface IPipe<in I, O>
{
    /// <summary>
    ///     Asynchronously processes the specified input and returns the output.
    /// </summary>
    Task<O> Run(I input);
}