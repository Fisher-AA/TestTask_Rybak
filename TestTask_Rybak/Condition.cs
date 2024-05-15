using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestTask_Rybak.Interfases;

namespace TestTask_Rybak
{
    public class Condition : ICondition
    {
       private Dictionary<string, int> result = new Dictionary<string, int>();

       private string error=string.Empty;
        IPAddressRange? iPAddressRange;

        private string delimiter;
        public string GetError()
        {
            return error;
        }

        public bool IsError()
        {
            return !string.IsNullOrWhiteSpace(error);
        }
        public Dictionary<string, int> GetResult()
        {
            return result;
        }

       public Condition(string delimiter= "\t", IPAddress? lowerInclusive =null, IPAddress? addressMask = null)
        {
            this.delimiter = delimiter;
            if (lowerInclusive != null)
            {
                IPAddress upperIP = addressMask == null ? IPAddress.Parse("255.255.255.255") : IpAddressWorker.GetBroadcastAddress(lowerInclusive, addressMask) ;
                iPAddressRange = new IPAddressRange(lowerInclusive, upperIP);  
            }
        }
        public void UseConditon(string s)
        {
            if (string.IsNullOrEmpty(s)) 
                return;

            string[] arData = s.Split(delimiter);
            IPAddress? ipAddress;
            DateTime date;
            string err = $"Сторока ({s}) из лог файла не валидна.";
            if (arData.Length >= 2)
            {
                if (!IPAddress.TryParse(arData[0], out ipAddress) )
                {
                    error = $"{err} Значение ({arData[0]}) не валидный IPAddress.";
                }
                else
                {
                    if (ipAddress.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        error = $"{err} Значение ({arData[0]}) не валидный IPv4-адрес";
                    }
                    else
                    {
                        if (!DateTime.TryParse(arData[1], out date))
                        {
                            error = $"{err} Значение ({arData[1]}) не валидный DateTime.";
                        }
                        else
                        {
                            if (iPAddressRange == null || iPAddressRange.IsInRange(ipAddress))
                            {
                                string key = ipAddress.ToString();
                                if (result.ContainsKey(key))
                                {
                                    result[key]++;
                                }
                                else
                                {
                                    result.Add(key, 1);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                error = $"{err} Возможна проблема в разделителе. Использоан разделитель ({delimiter})";
            }
        }
    }
}
