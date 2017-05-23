using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            //加载程序集信息
            System.Reflection.Assembly asm =
             System.Reflection.Assembly.Load("ConsoleTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");

            //Type[] allTypes = asm.GetTypes();    //这个得到的类型有点儿多
            Type[] types = asm.GetExportedTypes(); //还是用这个比较好，得到的都是自定义的类型

            // 验证指定自定义属性（使用的是 4.0 的新语法，匿名方法实现的，不知道的同学查查资料吧！）
            Func<System.Attribute[], bool> IsAtt1 = o =>
             {
                 foreach (System.Attribute aa in o)
                 {
                     if (aa is CustomAttribute)
                         return true;
                 }
                 return false;
             };

            //查找具有 Attribute.Atts.Att1 特性的类型（使用的是 linq 语法）
            Type[] CosType = types.Where(o =>
            {
                return IsAtt1(System.Attribute.GetCustomAttributes(o, true));
            }).ToArray();

            //遍历具有指定特性的类型
            object obj;
            foreach (Type t in CosType)
            {
                //实例化了一个当前类型的实例
                obj = t.Assembly.CreateInstance(t.FullName);

                if (obj != null)
                {
                    //这里封装了一个方法叫 ShowMsg 接收的是一个 string 参数，就是将 string 打印到出来
                    Console.WriteLine(
                        //这里就用到了多态特性了，调用了 UserName 方法（用接口是方便哈！）
                      ((ITestBase)obj).UserName()
                    );
                }
            }


            string Password = "";

            if (string.IsNullOrEmpty(Password))
            {

                Console.WriteLine("密码不能都为空<br/>");

            }

            object a;

            a = 1;//为变量a赋值

            Console.WriteLine(a);

            Console.WriteLine(a.GetType());

            Console.WriteLine(a.ToString());

            Console.WriteLine();

            a = new ObjectClass();//重新实例化变量a

            ObjectClass classRef;

            classRef = (ObjectClass)a;//引用调用

            Console.WriteLine(classRef.i);

            Console.Read();


            string str = "[[1,'张三',1],[2,'李四',10],[1,'哈哈']]";
            JArray jja = (JArray)JsonConvert.DeserializeObject(str);
            string rre = jja[0][0].ToString();
            //for (int i = 0; i < ja.Count; i++)
            //{
            //    Console.WriteLine(ja[i].ToString());
            //    Console.ReadKey();
            //}@
            string teststr = @"[
	[
		[26,'苏州',0],[27,'吴江',1],[28,'昆山',2],[29,'张家港',3],[30,'常熟',4],
		[31,'太仓',5],[32,'盛泽',6],[33,'常州',7],[34,'无锡',8],[35,'江阴',9],[36,'宜兴',10],[38,'南京',11],[39,'南通',12],[41,'靖江',13],[48,'苏州工业园区',14]
	],
	[
		[9,'上海浦东机场',0],[10,'上海虹桥机场',1],[11,'无锡硕放机场',2],[12,'常州奔牛机场',3],[14,'杭州萧山机场',4],
		[15,'宁波机场',5],[16,'南京禄口机场',6],[17,'南通兴东机场',7],[18,'苏州北站（高铁站）',8],[19,'苏州火车站（北）',9],[20,'嘉兴火车站',10],
		[21,'虹桥火车站',11],[22,'上海南站',12],[23,'吴淞口码头',13],[24,'小洋山港码头',14],[25,'上海吴淞口码头',15],[27,'上海国际客运码头（东大名路）',16],
		[28,'上海火车站',17],[30,'台州玉环县大麦屿码头',18],[31,'无锡火车站',19],[32,'无锡火车东站',20]
	],

	['766c35e2-58b2-4bf6-84d5-692ebee94519','8f0eb5a9-acd8-428c-af06-1513998cdc7c']
]";
            JArray ja = (JArray)JsonConvert.DeserializeObject(teststr);
            string re = ja[0][0].ToString();
            JArray jb = (JArray)JsonConvert.DeserializeObject(re);
            Console.Write(jb[0] + "__" + jb[1] + "__" + jb[2]);
            Console.ReadKey();
        }
    }
    class ObjectClass
    {

        public int i = 60;

    }

}
