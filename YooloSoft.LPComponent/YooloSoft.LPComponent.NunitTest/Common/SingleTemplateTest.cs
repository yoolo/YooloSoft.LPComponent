#region Version Info
/* ======================================================================== 
    * 【Description】 
    *  
    * Author:yoolo        Time：2013/8/8 9:53:19
    * FileName：SingleTemplateTest
    * Version:V1.0.0 
    *
	
    * Update History:       
    * 
    * ======================================================================== 
  */
#endregion

namespace YooloSoft.LPComponent.NunitTest.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using System.Threading;
    using YooloSoft.LPComponent.Common;
    using YooloSoft.LPComponent.Common.Model;

    [TestFixture]
    public class SingleTemplateTest
    {
        /// <summary>
        /// 非单例构造
        /// </summary>
        [Test]
        public void ObjectNotEqualTest()
        {
            Student studentA = new Student();
            Student studentB = new Student();

            bool isEqual = studentA.Equals(studentB);

            Assert.IsFalse(isEqual, "普通对象构造对象不相等!");
        }

        /// <summary>
        /// 单例构造
        /// </summary>
        [Test]
        public void ObjectEqualTest()
        {
            Student studentA = SingleTemplate<Student>.Instance;
            Student studentB = SingleTemplate<Student>.Instance;

            bool isEqual = studentA.Equals(studentB) && studentA.Age.Equals(studentB.Age);

            Assert.IsTrue(isEqual, "单例模拟失败!");
        }

        /// <summary>
        /// 多线程单例测试
        /// </summary>
        [Test]
        public void ObjectEqualMutiThreadTest()
        {
            int Length = 20;

            Student[] stus = new Student[Length];


            Action<object> createObjA = (i) =>
            {
                int index = Convert.ToInt32(i);
                stus[index] = SingleTemplate<Student>.Instance;
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
                    Assert.IsTrue(isEqual, "单例构造失败！");
            }

            Assert.Pass("单例构造成功!");
        }

    }
}
