using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask_Rybak.Interfases;

namespace TestProject.DataForTest
{
    internal class ConditionData : ICondition
    {
        private Dictionary<string, int> result = new Dictionary<string, int>();
        public string GetError()
        {
            return string.Empty;
        }

        public Dictionary<string, int> GetResult()
        {
            return result;
        }

        public bool IsError()
        {
            return false;
        }

        public void UseConditon(string s)
        {
            result.Add(s, result.Count()+1);
        }
    }
}
