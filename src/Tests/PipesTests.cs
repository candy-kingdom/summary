using Summary.Pipes;

namespace Summary.Tests;

public class PipesTests
{
    [Fact]
    public void Func()
    {
        var func = For<Func<int, int>>();
        var pipe = new FuncPipe<int, int>(func);

        pipe.Run(1);

        func.Received(1).Invoke(1);
    }

    [Fact]
    public void Then()
    {
        var a = For<IPipe<short, int>>();
        var b = For<IPipe<int, long>>();
        var c = a.Then(b);

        a.Run(Any<short>()).Returns(Task.FromResult(2));
        b.Run(Any<int>()).Returns(Task.FromResult(3L));

        c.Run(1);

        a.Received(1).Run(1);
        b.Received(1).Run(2);
    }

    [Fact]
    public void Tee()
    {
        var action = For<Action<int>>();
        var a = For<IPipe<short, int>>();
        var b = a.Tee(action);

        a.Run(1).Returns(Task.FromResult(2));

        b.Run(1);

        action.Received(1).Invoke(2);
    }

    [Fact]
    public void Select()
    {
        var pipe = new FuncPipe<short, int>(x => 2);

        pipe.Then(Map).Run(1).Result.Should().Be(4);

        int Map(int x) => x * 2;
    }
}