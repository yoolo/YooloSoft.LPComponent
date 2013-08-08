#region Version Info
/* ======================================================================== 
    * 【Description】 
    *  
    * Author:yoolo        Time：2013/8/7 18:47:34
    * FileName：SingleTemplate
    * Version:V1.0.0 
    *
	
    * Update History:       
    * 
    * ======================================================================== 
  */
#endregion

namespace YooloSoft.LPComponent.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SingleTemplate<T> where T : new()
    {
        private static readonly T instance = new T();

        protected SingleTemplate()
        {
        }

        static SingleTemplate()
        {
        }

        public static T Instance
        {
            get
            {
                return instance;
            }
        }

    }
}
