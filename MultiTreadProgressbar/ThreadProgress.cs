namespace MultiTreadProgressBar
{
    public class ThreadProgress
    {
        static Semaphore sem = new Semaphore(5, 5);
        public void ConsoleWriteProgress()
        {
            sem.WaitOne();
            for (int n = 1; n <= 100; n++)
            {
                Thread.Sleep(Randomizer.GetRandomInt(1, 2));
                string progress = $"[{new String('#', n / 10)}{new String(' ', 10 - n / 10)}]";
                string treadLine = $"Task{Thread.CurrentThread.Name}{new String(' ',3 -  Thread.CurrentThread.Name.Length)}{progress} {n.ToString()}%   TreadID={Thread.CurrentThread.ManagedThreadId}";
                CursorWriter.WriteAt(treadLine, 0, Convert.ToInt32(Thread.CurrentThread.Name));
            }
            sem.Release();
        }
    }
}