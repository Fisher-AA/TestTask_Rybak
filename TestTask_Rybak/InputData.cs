using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_Rybak
{
    public abstract class InputData
    {
        private StringBuilder sb = new StringBuilder();
        public string PathFileLog { get; private set; }=string.Empty;
        public string PathFileOut { get; private set; } =string.Empty;
        public IPAddress? StartIPAddress { get; private set; }
        public IPAddress? AddressMask { get; private set; }
        public string Delimetr { get; private set; } = "\t";

        public string Error
        {
            get { return sb.ToString(); }
            set { if(!string.IsNullOrWhiteSpace(value)) sb.AppendLine(value); }
        }

        public bool IsError() { return !string.IsNullOrWhiteSpace(Error); }

        protected void SetPathFileLog(string path)
        {
            if (string.IsNullOrWhiteSpace(path))  
                Error = "Путь к лог файлу не задан"; 
            else
            {
                var fInfo = new FileInfo(path);
                if (!fInfo.Exists)
                {
                    Error = "Входящий лог файл не найден";
                }
                else
                {
                    if (fInfo.Length == 0)
                    {
                        Error = "Входящий лог файл не имеет данных";
                    }
                    else  PathFileLog = path; 
                }    
            }
        }
        protected void SetPathFileOut(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                Error = "Не задан путь для файла результатов";
            else
                if (File.Exists(path))
                Error = "Файл результатов по заданному пути уже существует";
            else PathFileOut = path;
        }
        protected void SetStartIPAddress(string ip)
        {
            if (!string.IsNullOrWhiteSpace(ip))
            {
                IPAddress? address;
                if(IPAddress.TryParse(ip, out address) && address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    StartIPAddress = address;
                }
                else
                {
                    Error = "Start Ip Address not valid";
                }
            }
        }
        protected void SetAddressMask(string mask) 
        {  
            if ( StartIPAddress is not null && !string.IsNullOrWhiteSpace(mask)) 
            {
                IPAddress? address;
                if (IPAddress.TryParse(mask, out address) && address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    AddressMask = address;
                }
                else
                {
                    Error = "Mask not valid";
                }
            }
        }

        protected void SetDelimetr(string d)
        {
            if (!string.IsNullOrEmpty(d))
            {
                Delimetr = d;
            }
        }
    }
}
