using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_Rybak
{
    public class CommandLineOptions
    {
        [Option(longName: "file-log", Required = true, HelpText = "Путь к файлу с логами.")]
        public string PathFileLog { get; set; } = string.Empty;

        [Option(longName: "file-output", Required = true, HelpText = "Путь к файлу с результатом.")]
        public string PathFileOut { get; set; } = string.Empty;

        [Option(longName: "address-start", Required = false, HelpText = "Нижняя граница диапазона адресов.")]
        public string StartIPAddress { get; set; } = string.Empty;

        [Option(longName: "address-mask", Required = false, HelpText = "маска подсети, задающая верхнюю границу диапазона.")]
        public string AddressMask { get; set; } = string.Empty;
    }
}
