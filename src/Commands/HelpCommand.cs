using System;

namespace com.github.dergash.h3msorter
{
    public class HelpCommand : IConsoleCommand
    {
        public void Exec()
        {
            String Msg = "Usage: h3msorter.exe <MapsFolder> -d <Size1> <Size2> <SizeN>";
            Msg += "\nExample: h3msorter.exe ./Maps -d 36 72 108 ";
            Msg += "\nThis will move all maps with S, M and L sizes to ./Maps/Trash folder";
            Console.WriteLine(Msg);
        }
        public void Exec(String Key, String[] Args)
        {
            Exec();
        }
    }
}