using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_Rybak
{
    public class InputConfiguration : InputData
    {
        public InputConfiguration(string configPath)
        {
            if (string.IsNullOrWhiteSpace(configPath))
            {
                Error = "Конфигурационный файл не задан.";
                return;
            }

           var  configuration = new ConfigurationBuilder()
                  .AddJsonFile(configPath, optional: true, reloadOnChange: true)
                 .Build();
            var section = configuration.GetSection("InputParams");
            if (section != null && section.Exists()) 
            {
                base.SetPathFileLog(section["pathIn"] ?? string.Empty);
                base.SetPathFileOut(section["pathOut"] ?? string.Empty);
                base.SetStartIPAddress(section["ipStart"] ?? string.Empty);
                base.SetAddressMask(section["ipMask"] ?? string.Empty);
                base.SetDelimetr(section["delimeter"] ?? string.Empty);
            }
            else
            {
                Error = "Конфигурационный файл не найден или его значения не корректны.";
            }
        }

    }
}
