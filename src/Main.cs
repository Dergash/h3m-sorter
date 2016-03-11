using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.github.dergash.h3msorter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    String MapsArchivePath = args[0];
                    if (Directory.Exists(MapsArchivePath) == false)
                    {
                        Console.WriteLine("Specified path to map folder is not valid");
                    }
                    else
                    {
                       // Console.WriteLine("here" + args.Length);
                        var CmdKey = (args.Length <= 1) ? "-h" : args[1];
                        var CmdArgs = args.Skip(2).TakeWhile(x => (x.StartsWith("-") == false)).ToArray<String>();
                        IConsoleCommand Command;
                        switch (CmdKey)
                        {
                            case "-d":
                                Command = new SafeDeleteCommand(MapsArchivePath);
                                break;
                            default:
                                Command = new HelpCommand();
                                break;
                        }
                        Command.Exec(CmdKey, CmdArgs);
                    }
                }
                else
                {
                    var Cmd = new HelpCommand();
                    Cmd.Exec();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }
        }
    }
}
