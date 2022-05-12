using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace WiTi_Algorithm
{
    internal class Problem
    {
        public int countoftasks;
        public List<Task> listoftasks;
        public int countdone;
        public int seed;
        public int sum_WiTi;
        List<int> listWiTiSum;    
        public Problem()
        {
            sum_WiTi = 0;
            countdone = 0;
            seed = 0;
            countoftasks = 0;
            listoftasks = new List<Task>();
            listWiTiSum = new List<int>();
        }
        public Problem(int s, int c)
        {
            sum_WiTi = 0;
            seed = s;
            countdone = 0;
            countoftasks = c;
            listoftasks = new List<Task>();
            listWiTiSum = new List<int>();
        }
        public void Read_From_Console()
        {
            string x = "", a = "", b = "", c = "";
            x = Console.ReadLine();
            for(int i = 0; i < int.Parse(x); i++)
            {
                a = Console.ReadLine();
                b = Console.ReadLine();
                c = Console.ReadLine();
                listoftasks.Add(new Task(i, int.Parse(a), int.Parse(b), int.Parse(c)));

            }
        }

        public void RandomElements()
        {
            Random random = new Random(seed);
            int[] rpd = new int[3];

            for (int i = 1; i <= countoftasks; i++)
            {
                rpd[0] = random.Next(countoftasks) + 1;
                rpd[1] = random.Next(countoftasks) + 1;
                rpd[2] = random.Next(countoftasks) + 1;
                listoftasks.Add(new Task(i, rpd[0], rpd[1], rpd[2]));
            }
        }
        public void Read_tasks_from_file()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data/JACK3.DAT");
            //for different set of data change JACK3.DAT to JACK2.DAT or JACK1.DAT or change data in those files
            //Console.WriteLine(filePath); 
            string line;
            if (File.Exists(filePath))
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(filePath);
                    countoftasks = int.Parse(file.ReadLine());
                    int i = 0;
                    while (i <= countoftasks && (line = file.ReadLine()) != null)
                    {
                        i++;
                        string[] bits = line.Split(' ');
                        listoftasks.Add(new Task(i, int.Parse(bits[0]), int.Parse(bits[1]), int.Parse(bits[2])));
                    }
                }
                finally
                {
                    if (file != null)
                        file.Close();
                }
            }
        }
        static void Swap(List<Task> list, int indexA, int indexB)
        {
            Task tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
        public List<List<Task>> Permute(ref List<Task> listoftasks)
        {
            var list = new List<List<Task>>();
            return DoPermute(ref listoftasks, 0, listoftasks.Count() - 1, ref list);
        }

        static List<List<Task>> DoPermute(ref List<Task> list, int start, int end, ref List<List<Task>> permutations)
        {
            if (start == end)
            {
                // We have one of our possible n! solutions,
                // add it to the list.
                permutations.Add(new List<Task>(list));
            }
            else
            {
                for (var i = start; i <= end; i++)
                {
                    Swap( list,start,i);
                    DoPermute(ref list, start + 1, end, ref permutations);
                    Swap(list, start, i);
                }
            }

            return permutations;
        }
        public void WiTi()
        {
            var permutations = Permute(ref listoftasks); // funkcja zwraca liste wszystkich możliwych permutacji
            int i = 0;
            sum_WiTi = 1000000000;
            int min_index=0;
            int tmp_WiTi = 0, time=0;
            foreach (var job in permutations)
            {
                //Console.WriteLine("permutacja "+ i);
                foreach (var task in job)
                {
                    //Console.WriteLine(task);
                    time += task.processing_time;
                    if(task.desired_ending_time < time)
                    {
                        tmp_WiTi += task.weight * (time - task.desired_ending_time);
                    }
                }
                if(tmp_WiTi < sum_WiTi)
                {
                    min_index = i;
                    sum_WiTi = tmp_WiTi;
                }
                listWiTiSum.Add(tmp_WiTi);
                //Console.WriteLine("Suma WiTi dla " + i + " permutacji = " + tmp_WiTi as string);
                //Console.WriteLine();
                time = 0;
                tmp_WiTi = 0;
                i++;
            }
            
            listoftasks = permutations[min_index];

        }

    }
}