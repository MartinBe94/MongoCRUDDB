using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoCRUDDB
{
    internal interface IUI
    {
        public string GetInput();
        public void Print(string text);

        //public void Clear();
        public void Exit();
    }
}
