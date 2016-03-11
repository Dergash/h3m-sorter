using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using com.github.dergash.h3msharp;

namespace com.github.dergash.h3msorter
{
    class SafeCleaner
    {
        public void Clean(String MapsDirectory, UInt32 [] Sizes)
        {
            String[] Paths = Directory.GetFiles(MapsDirectory);

            UInt32 Counter = 0;
            foreach (String MapPath in Paths)
            {
                
                String FileName = Path.GetFileName(MapPath);
                try
                {
                    if (Path.GetExtension(FileName) != ".h3m") continue;
                    Map Map;
                    Map = new Map(File.ReadAllBytes(MapPath));
                     if (Sizes.Contains((UInt32)Map.Size.X))
                     {
                         if(Directory.Exists(MapsDirectory + "/Trash") == false)
                         {
                             Directory.CreateDirectory(MapsDirectory + "/Trash");
                         }
                         File.Move(MapsDirectory + "/" + FileName, MapsDirectory + "/Trash/" + FileName);
                         Console.WriteLine("Moving " + FileName + ", size: " + Map.Size);
                         Counter++;
                     }
                }
                catch(Exception e)
                {
                    Console.WriteLine("Error occured while processing " + FileName);
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace); 
                    continue;
                }
            }
            Console.WriteLine("Moved " + Counter + " maps");
        }
    }
}
