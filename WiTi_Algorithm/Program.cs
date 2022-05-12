using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;


namespace WiTi_Algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Problem p = new Problem(2, 3);
            p.Read_From_Console();
            //p.RandomElements();
            //Problem p = new Problem();
            //p.Read_tasks_from_file();
            long start = Stopwatch.GetTimestamp();
            p.WiTi();
            long end = Stopwatch.GetTimestamp();
            Debug.WriteLine("Program obliczal przez " + (end - start) as string + " ticków ");
            long memory = GC.GetTotalMemory(true);
            Debug.WriteLine("Program zajal " + memory as string + " bajtow pamieci ");
            foreach (Task i in p.listoftasks)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine("Minimalna suma WiTi = " + p.sum_WiTi as string);

            Console.ReadLine();
        }
    }
}
