#region Version Info
/* ======================================================================== 
    * 【Description】 
    *  
    * Author:yoolo        Time：2013/8/8 19:10:11
    * FileName：SingleMutilInstance
    * Version:V1.0.0 
    *
	
    * Update History:       
    * 
    * ======================================================================== 
  */
#endregion

namespace YooloSoft.LPComponent.ConsoleApp.SingleTemplate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using YooloSoft.LPComponent.Common;
    using YooloSoft.LPComponent.Common.Model;

    public class SingleMutilInstance
    {
        public static void ObjectEqualMutiThreadTest()
        {
            int Length = 20;

            Student[] stus = new Student[Length];


            Action<object> createObjA = (i) =>
            {
                int index = Convert.ToInt32(i);
                stus[index] = SingleTemplate<Student>.Instance;  //Student.Instance;
                Thread.Sleep(1000 * 2);
                Console.WriteLine("#创建对象 " + index);
            };

            Thread[] tds = new Thread[Length];
            for (int i = 0; i < tds.Count(); i++)
            {
                tds[i] = new Thread(new ParameterizedThreadStart(createObjA));
                tds[i].Name = "#Thread " + i;
                tds[i].IsBackground = true;
            }

            for (int i = 0; i < Length; i++)
            {
                tds[i].Start(i);
                tds[i].Join();
            }

            for (int i = 0; i < Length - 1; i++)
            {
                bool isEqual = stus[i].Equals(stus[i + 1]) && stus[i].Age.Equals(stus[i + 1].Age);
                if (!isEqual)
                    Console.WriteLine("单例构造失败");
            }

            Console.WriteLine("主线程执行完毕");
        }
    }
}
