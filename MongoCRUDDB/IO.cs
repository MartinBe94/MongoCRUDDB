using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoCRUDDB
{
    internal class IO: IUI
    {
        //public void Clear()
        //{
        //    Clear();
        //}

        public void Exit()
        {
            System.Environment.Exit(0);
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
