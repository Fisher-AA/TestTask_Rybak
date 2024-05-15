using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_Rybak
{
    public class InputParametres :InputData
    {
        public InputParametres(CommandLineOptions opts)
        {
            base.SetPathFileLog( opts.PathFileLog);
            base.SetPathFileOut(opts.PathFileOut);
            base.SetStartIPAddress(opts.StartIPAddress);
            base.SetAddressMask(opts.AddressMask);
        }
    }
}
