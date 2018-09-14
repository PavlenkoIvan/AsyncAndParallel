using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let start!");
            var folderPath = @"C:\Music\MegMayers";
            var fileList = Directory.EnumerateFiles(folderPath).ToList();
            //new Launcher().AsyncFilesRead(fileList).Wait();
            new Launcher().ParallelFilesRead(fileList);
            Console.ReadLine();
        }
    }
    public class Launcher
    {
        public async Task AsyncFilesRead(List<string> filesPaths)
        {
            var timer = Stopwatch.StartNew();
            var asy = new AsyncExample();
            var tasks = new List<Task<TheResponse>>();
            foreach (var path in filesPaths)
            {
                tasks.Add(asy.ReedThisFile(path));
            }

            foreach (var t in tasks)
            {
                var r = await t.ConfigureAwait(false);
                Console.WriteLine(r.ThreadId);
                Console.WriteLine(r.ActionMessage);
                Console.WriteLine("__________________________");
            }
            timer.Stop();
            Console.WriteLine($"Finished, Time: {timer.Elapsed}");
        }
        public void ParallelFilesRead(List<string> filesPaths)
        {
            var timer = Stopwatch.StartNew();
            var sy = new SyncExample();
            var tasks = new List<Task<TheResponse>>();
            Parallel.ForEach(filesPaths, p =>
            {
                var r = sy.ReedThisFile(p);
                Console.WriteLine(r.ThreadId);
                Console.WriteLine(r.ActionMessage);
                Console.WriteLine("__________________________");
            });
          
            timer.Stop();
            Console.WriteLine($"Finished, Time: {timer.Elapsed}");
        }
    }
    
}
