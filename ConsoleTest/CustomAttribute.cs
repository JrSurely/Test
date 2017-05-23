using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple=false,Inherited=false)]
    public class CustomAttribute : Attribute
    {
        public CustomAttribute(string name)
        {
            m_name = name;
            version = "1.0";
            other = "";
        }
        /// <summary>
        /// 名称（定位参数）
        /// </summary>
        private string m_name;
        /// <summary>
        /// 获取名称（定位参数）
        /// </summary>
        public string GetName
        {
            get { return m_name; }
        }
        /// <summary>
        /// 版本号（命名参数）
        /// </summary>
        public string version;
        /// <summary>
        /// 其它（命名参数）
        /// </summary>
        public string other { set; get; }
    }
}
