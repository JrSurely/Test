using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public interface ITestBase
    {
        string UserName();
    }

    //同样也是为了测试方便，定义了派生公共接口的基类
    //供测试的类型继承，这样测试时候就直接使用多态特性调用类方法就OK了！
    public class TestBase : ITestBase
    {
        public TestBase(string userName)
        {
            m_userName = userName;
        }
        private string m_userName = "";
        public string UserName()
        {
            return m_userName;
        }
    }
}
