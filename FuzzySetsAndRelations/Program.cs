using System;
using System.IO;

namespace FuzzySetsAndRelations
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(new string('-', 10) + "Task1" + new string('-', 10));
            Task1.WriteToConsole();
            Console.WriteLine(new string('-', 10) + "Task2" + new string('-', 10));
            Task2.WriteToConsole();
            Console.WriteLine(new string('-', 10) + "Task3" + new string('-', 10));
            Task3.WriteToConsole();
            Console.WriteLine(new string('-', 10) + "Task6" + new string('-', 10));
            Task6.WriteToConsole();
            Console.WriteLine(new string('-', 10) + "Task7" + new string('-', 10));
            Task7.WriteToConsole();
            Console.WriteLine(new string('-', 10) + "Task8" + new string('-', 10));
            Task8.WriteToConsole();
            Console.WriteLine(new string('-', 10) + "Task9" + new string('-', 10));
            Task9.WriteToConsole();
            Console.WriteLine(new string('-', 10) + "Task10" + new string('-', 10));
            Task10.WriteToConsole();

            //using (StreamWriter sr = new StreamWriter("Log.txt", false))
            //{
            //    sr.WriteLine(new string('-', 10) + "Task1" + new string('-', 10));
            //    Task1.WriteToStream(sr);
            //    sr.WriteLine(new string('-', 10) + "Task2" + new string('-', 10));
            //    Task2.WriteToStream(sr);
            //    sr.WriteLine(new string('-', 10) + "Task3" + new string('-', 10));
            //    Task3.WriteToStream(sr);
            //    sr.WriteLine(new string('-', 10) + "Task6" + new string('-', 10));
            //    Task6.WriteToStream(sr);
            //    sr.WriteLine(new string('-', 10) + "Task7" + new string('-', 10));
            //    Task7.WriteToStream(sr);
            //    sr.WriteLine(new string('-', 10) + "Task8" + new string('-', 10));
            //    Task8.WriteToStream(sr);
            //    sr.WriteLine(new string('-', 10) + "Task9" + new string('-', 10));
            //    Task9.WriteToStream(sr);
            //    sr.WriteLine(new string('-', 10) + "Task10" + new string('-', 10));
            //    Task10.WriteToStream(sr);
            //Console.WriteLine("Done");
            //}

           


            Console.ReadKey();
        }
    }
}