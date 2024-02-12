using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure4
{
    public static class Util
    {

        public static void Shuffle<T>(List<T> list)
        {
            Random random = new Random();

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void Write(ConsoleOutput text)
        {
            Console.ForegroundColor = text.Color;
            Console.Write(text.Message);
        }

        public static void Write(List<ConsoleOutput> texts)
        {
            texts.ForEach(x => Util.Write(x));
        }
        public static void WriteLine(string line)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
        }

        public static void WriteLine(ConsoleOutput line)
        {
            Console.ForegroundColor = line.Color;
            Console.WriteLine(line.Message);
        }

        public static void WriteLines(List<ConsoleOutput> lines)
        {
            lines.ForEach(x => Util.WriteLine(x));
        }

        public static string ReadLine()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return Console.ReadLine().ToLower();
        }

        public static string Readfile(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                return r.ReadToEnd();
            }
        }
    }
}
