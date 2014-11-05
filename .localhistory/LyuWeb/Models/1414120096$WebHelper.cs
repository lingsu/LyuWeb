using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace LyuWeb.Models
{
    public class WebHelper<int>:IWeb<int>
    {
        public void Send<T>()
        {
            Debug.WriteLine("send");
        }
    }
}