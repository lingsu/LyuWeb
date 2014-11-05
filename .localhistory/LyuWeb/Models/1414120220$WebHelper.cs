using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace LyuWeb.Models
{
    public class WebHelperA:IWeb
    {
        public void Send()
        {
            Debug.WriteLine("send");
        }
    }
    public class WebHelperB : IWeb
    {
        public void Send()
        {
            Debug.WriteLine("send");
        }
    }
}