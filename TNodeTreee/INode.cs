using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNodeTreee
{
    public interface INode<T>
    {
        object data { get; set; }
        INode<T> Next { get; set; }
        string ToString();
    }
}
