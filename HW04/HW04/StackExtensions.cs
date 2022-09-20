using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW04
{
    //Расширение класса Stack
    public static class StackExtensions
    {      
        public static void Merge(this Stack s1, Stack s2)
        {
            for (int i = 0; i < s2.Size() + i; i++)
            {
                s1.Add(s2.Pop());
            }
        }
    }
}
