using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyuWeb.Models
{
    public interface IWeb<T>
    {
        void Send();
    }
}
