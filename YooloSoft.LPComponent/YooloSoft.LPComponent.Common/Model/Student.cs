#region Version Info
/* ======================================================================== 
    * 【Description】 
    *  
    * Author:yoolo        Time：2013/8/8 19:11:54
    * FileName：Student
    * Version:V1.0.0 
    *
	
    * Update History:       
    * 
    * ======================================================================== 
  */
#endregion

namespace YooloSoft.LPComponent.Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Student
    {
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }

        public Student()
        {
            this.UserName = string.Empty;
            this.Email = string.Empty;
            this.PassWord = string.Empty;
            this.Age = new Random().Next(1, Int32.MaxValue);
        }
    }
}
