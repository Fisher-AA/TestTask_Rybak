using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask_Rybak;

namespace TestProject.DataForTest
{
    public static class TestData
    {
        public const string FileResultPath = "result.txt";

        public static CommandLineOptions optionsEmpty = new CommandLineOptions();
        public static CommandLineOptions optionsPathIn = new CommandLineOptions() { PathFileLog= "TestFiles/Normal.txt" };
        public static CommandLineOptions optionsPathInPathOut = new CommandLineOptions() { PathFileLog = "TestFiles/Normal.txt", PathFileOut= "ResultFiles/result.txt" };
        public static CommandLineOptions optionsFull = new CommandLineOptions() { PathFileLog = "TestFiles/Normal.txt", PathFileOut = "ResultFiles/result.txt",
         StartIPAddress= "10.1.1.15", AddressMask= "255.255.0.0"};


        public static Dictionary<string, int> dictInput = new Dictionary<string, int>() {  {"1.1.1.1",1} };
        public const string fileResult = "1.1.1.1{0}1\r\n";
    }
}
