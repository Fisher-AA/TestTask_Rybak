using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_Rybak.Interfases
{
    public interface ICondition
    {
        public Dictionary<string, int> GetResult();

        public string GetError();
        public bool IsError();
        public void UseConditon(string s);

    }
}
