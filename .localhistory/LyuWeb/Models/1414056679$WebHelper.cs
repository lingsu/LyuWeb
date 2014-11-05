using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace LyuWeb.Models
{
    public class WebHelper:IWeb<int>
    {
        public void Send<int>()
        {
            Debug.WriteLine("send");
        }
    }
}