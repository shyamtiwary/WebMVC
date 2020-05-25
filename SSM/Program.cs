using System;

namespace SSM
{
    class Program
    {
        static String str;
        static DateTime time;
        static void Main(string[] args)
        {
            Console.WriteLine(str == null ? "str == null" : str);
            Console.WriteLine(time == null ? "time == null" : time.ToString());
            Console.ReadLine();
        }
    }
}
