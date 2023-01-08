using Doc.Net.Core.Pipes;

namespace Doc.Net.Tests;

[TestFixture]
public class PipesTests
{
    [Test]
    public void Func()
    {
        var func = new Mock<Func<int, int>>();
        var pipe = new FuncPipe<int, int>(func.Object);

        pipe.Run(1);

        func.Verify(x => x.Invoke(1), Times.AtMostOnce);
    }

    [Test]
    public void Then()
    {
        var a = new Mock<IPipe<short, int>>();
        var b = new Mock<IPipe<int, long>>();
        var c = a.Object.Then(b.Object);

        c.Run(1);

        a.Verify(x => x.Run(1), Times.AtMostOnce);
        b.Verify(x => x.Run(1), Times.AtMostOnce);
    }

    [Test]
    public void Tee()
    {
        var action = new Mock<Action<int>>();
        var a = new Mock<IPipe<short, int>>();
        var b = a.Object.Tee(action.Object);

        b.Run(1);

        action.Verify(x => x.Invoke(1), Times.AtMostOnce);
    }

    [Test]
    public void Select()
    {
        var pipe = new FuncPipe<short, int>(x => 2);

        pipe.Then(Map).Run(1).Result.Should().Be(4);

        int Map(int x) => x * 2;
    }
}