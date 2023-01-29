namespace MultiTreadProgressBar
{
    public class Randomizer
    {
        public static int GetRandomInt(int min, int max)
        {
            int time = Convert.ToInt32(DateTime.Now.Ticks % 100000);
            Random random = new Random(time);
            return random.Next(min, max);
        }
    }
}