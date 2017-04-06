using System;
using System.Linq;
using System.Collections.Generic;

namespace Innovation
{
    public static class Helper
    {
        private static bool win = false;
        public static void log(string message)
        {
            Console.WriteLine(message);
        }

        public static void triggerWin()
        {
            win = true;
        }
        public static bool getWin()
        {
            return win;
        }
    }
}
