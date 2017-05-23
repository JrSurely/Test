using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleThread
{
    class Program
    {
        static BackgroundWorker bw = new BackgroundWorker();
        static void Main()
        {
            bw.DoWork += bw_DoWork;
            bw.RunWorkerAsync("Message to worker");
            Console.ReadLine();
        }
        static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // 这被工作线程调用
            Console.WriteLine(e.Argument);        // 写"Message to worker"
            // 执行耗时的任务...
        }
    }
}
