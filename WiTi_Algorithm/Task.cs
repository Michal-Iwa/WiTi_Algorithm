using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WiTi_Algorithm
{
    public class Task
    {
        public int id;
        public int processing_time;
        public int weight;
        public int desired_ending_time;
        public bool done;
        public Task()
        {
            id = 0;
            processing_time = 0;
            weight = 0;
            desired_ending_time = 0;
            done = false;
        }
        public Task(int i, int p, int w, int d)
        {
            id = i;
            processing_time = p;
            weight = w;
            desired_ending_time = d;
            done = false;
        }
        public override string ToString()
        {
            return "Id : " + id + " Czas trwania: " + processing_time + ", Waga: " + weight + ", Porządany termin zakończenia: " + desired_ending_time + "\n";
        }
    }
}