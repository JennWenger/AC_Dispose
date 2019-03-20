using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispose
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var watcher = new FileSystemWatcher(@"C:\temp") { EnableRaisingEvents = true })
            {
                watcher.Created += new FileSystemEventHandler(watcher_Created);

                Console.WriteLine("Press a key to release the watcher reference.");
                Console.ReadKey(true);

                watcher = null;
            }
            Watcher.Dispose();
            Console.WriteLine("Press a key to exit the application.");
            Console.ReadKey(true);
        }

        static void watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File created");
            Console.WriteLine("Completed");
        }
    }
}