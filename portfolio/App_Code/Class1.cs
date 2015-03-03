using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace portfolio.App_Code
{
    public class Class1
    {
        ArrayList number = new ArrayList(10);

        public void Push(int num)
        {
            number.Add(num);
        }

        public void Contents()
        {
            foreach (int item in number)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void Pop()
        {
            number.RemoveAt((number.Count - 1));
        }
    }
}