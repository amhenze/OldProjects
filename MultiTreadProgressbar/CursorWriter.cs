namespace MultiTreadProgressBar
{
    public class CursorWriter
    {
        public static object Lock = new object();
        public static void WriteAt(string s, int x, int y)
        {
            try
            {
                lock (Lock)
                {
                    Console.SetCursorPosition(Program.originalColumn + x, Program.originalRow + y);
                    Console.Write(s);
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
    }
}