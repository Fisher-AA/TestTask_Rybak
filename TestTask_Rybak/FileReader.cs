using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask_Rybak.Interfases;

namespace TestTask_Rybak
{
    public class FileReader
    {
        private string path;
        private ICondition condition;
        private string error = string.Empty;
        public FileReader(string path, ICondition condition) 
        { 
            this.path = path;
            this.condition = condition;
        }
        public void Read()
        {
            try
            {
                using (var sReader = new StreamReader(path, Encoding.UTF8))
                {
                    string? s;
                    while((s = sReader.ReadLine())!= null)
                    {
                        condition.UseConditon(s);
                        if (condition.IsError())
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                error =ex.Message;
            }
        }

        public string GetError()
        {
            return error;
        }
        public bool IsError()
        {
            return !string.IsNullOrWhiteSpace(error);
        }
    }
}
