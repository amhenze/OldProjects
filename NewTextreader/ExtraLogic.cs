namespace NewTextreader
{
    internal class ExtraLogic
    {
        public static bool Remain(Line line)
        {
            return line.Numbers % 4 == 3;
        }
    }
}