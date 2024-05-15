using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_Rybak
{
    public class FileWriter
    {
        private string path;
        private string delimiter;
        private Dictionary<string, int> dicLineData;
        private string error = string.Empty;
        public FileWriter(string path,  Dictionary<string, int> dicLineData, string delimiter= "\t")
        {
            this.path = path;
            this.dicLineData = dicLineData;
            this.delimiter = delimiter;
        }
        public void Write()
        {
            try
            {
                if(dicLineData is null || dicLineData.Count == 0)
                {
                    error = "Нет данных для записи в файл";
                    return;
                }
                
                using (var writer = new StreamWriter(path, true, Encoding.UTF8))
                {
                    foreach (var data in dicLineData)
                    {
                        writer.WriteLine($"{data.Key}{delimiter}{data.Value}");
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
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
