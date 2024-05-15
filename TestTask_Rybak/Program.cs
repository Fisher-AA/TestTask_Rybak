
using CommandLine;
using Microsoft.Extensions.Configuration;
using System.Net;
using TestTask_Rybak;
using static System.Runtime.InteropServices.JavaScript.JSType;


if (args == null || args.Length==0) {   
    DoProcess( new InputConfiguration("config.json"));    
}
else
{
    Parser.Default.ParseArguments<CommandLineOptions>(args)
                    .WithParsed(Run)
                    .WithNotParsed(HandleParseError);
}

void DoProcess(InputData data)
{
    if (data != null)
    {
        if (data.IsError())
        {
            Console.WriteLine(data.Error);
        }
        else
        {
            Condition condition = new Condition(data.Delimetr, data.StartIPAddress, data.AddressMask);
            FileReader reader = new FileReader(data.PathFileLog, condition);
            reader.Read();

            if (condition.IsError())
                Console.WriteLine(condition.GetError());
            else
            {
                if (reader.IsError())
                    Console.WriteLine(reader.GetError());
                else
                {
                    FileWriter writer = new FileWriter(data.PathFileOut, condition.GetResult(), data.Delimetr);
                    writer.Write();
                    Console.WriteLine(writer.IsError() ? writer.GetError() : "Файл создан");
                }
            }
        }
    }
}
void HandleParseError(IEnumerable<CommandLine.Error> errs)
{
    if (errs.IsVersion())
    {
        Console.WriteLine("Version Request not implement");
        return;
    }

    if (errs.IsHelp())
    {
        Console.WriteLine("Help Request not implement");
        return;
    }
    Console.WriteLine("Command line parse fail");
}

 void Run(CommandLineOptions opts)
{
    DoProcess(new InputParametres(opts));
}

