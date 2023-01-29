using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace MultiTreadProgressBar
{
    public class Program
    {
        public static int originalRow;
        public static int originalColumn;
        public static int tasksCountMax = 24;



        public static async Task Main()
        {
            List<Thread> threadList = new List<Thread>();
            originalRow = Console.CursorTop;
            originalColumn = Console.CursorLeft;
            WaitHandle[] waitHandles = new WaitHandle[tasksCountMax];

            for (int taskCount = 0; taskCount < tasksCountMax; taskCount++)
            {
                var handle = new EventWaitHandle(false, EventResetMode.ManualReset);
                Thread thread = new Thread(() =>
                {
                    ThreadProgress threadProgress = new ThreadProgress();
                    threadProgress.ConsoleWriteProgress();
                    handle.Set();
                });
                thread.Name = $"{taskCount}";
                threadList.Add(thread);
                waitHandles[taskCount] = handle;
            }
            foreach (var thread in threadList)
            {
                thread.Start();
            }
            WaitHandle.WaitAll(waitHandles);
            CursorWriter.WriteAt("done", 2, tasksCountMax + 1);
        }
    }
}
