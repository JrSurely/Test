using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    [Custom("Test1", other = "test1", version = "1.1")]
    public class Test : TestBase
    {
        public Test()
            : base("Test1")
        {
        }
    }
    //测试类 Test2
    public class Test2 : TestBase
    {
        public Test2()
            : base("Test2")
        {

        }
        public void FunTest()
        {
        }
    }

    //测试类 Test3
    public class Test3 : TestBase
    {
        public Test3()
            : base("Test3")
        {

        }
    }
}
