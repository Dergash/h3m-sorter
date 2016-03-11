using System;

namespace com.github.dergash.h3msorter
{
    public class SafeDeleteCommand : IConsoleCommand
    {
        String InnerKey = "-d";
        String MapsDirectoryPath;

        public SafeDeleteCommand(String MapsDirectoryPath)
        {
            this.MapsDirectoryPath = MapsDirectoryPath;
        }

        public void Exec(String Key, String[] Args)
        {
            if (CheckKey(Key) == false)
            {
                throw new ArgumentException("Key " + Key + " is not valid for SafeDeleteCommand which exptects " + this.InnerKey);
            }
            UInt32[] Sizes;
            try
            {
                Sizes = Array.ConvertAll(Args, s => UInt32.Parse(s));
            }
            catch(Exception e)
            {
                String Msg = e.GetType().ToString() + ": Specified sizes is not in correct format.";
                Msg += "\n Should be unsigned integer, i.e. 36, 72, 108, 144";
                Console.WriteLine(Msg);
                return;
            }
            var Cleaner = new SafeCleaner();
            Cleaner.Clean(this.MapsDirectoryPath, Sizes);
        }

        public void Exec()
        {
            throw new NotSupportedException();
        }

        private Boolean CheckKey(String Key)
        {
            return (Key == this.InnerKey);
        }
    }
}