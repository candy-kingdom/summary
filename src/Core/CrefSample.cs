using Summary2;

namespace Summary
{
    public class Base
    {
        public void Method() { }
    }

    public class Base2
    {
        public void Method() { }
    }

    public class CrefSample<T0> : Base
    {
        public class Child : Base2
        {
            /// <summary>
            ///     <see cref="ClassX.Method2"/>
            /// </summary>
            public void Test()
            {

            }
        }

        public void Method()
        {
        }
    }
}

namespace Summary2
{
    public class ClassX
    {
        public void Method2()
        {

        }
    }
}

