using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Genetic_Algorithm
{
    class Logger
    {
        private static int generation = 0;
        public static void LoggPopulation(Population population)
        {
            //Best
            WriteLine("Best.txt", population.GetEntitys()[0].GetFittingLevel().ToString());

            //Baddest            
            WriteLine("Worst.txt", population.GetEntitys()[population.GetAmount()-1].GetFittingLevel().ToString());

            //Median
            WriteLine("Median.txt", population.GetEntitys()[population.GetAmount()/2].GetFittingLevel().ToString());

            //Avrage
            float sum = 0;
            foreach (AIEntity e in population.GetEntitys())
                sum += e.GetFittingLevel();

            float avrage = sum / population.GetAmount();
            WriteLine("Avrage.txt", avrage.ToString());

            //Standard deviation
            float sumStandard = 0;
            foreach (AIEntity e in population.GetEntitys())
                sumStandard += (float)Math.Pow((e.GetFittingLevel() - avrage), 2);

            float standardDeviation = (float)Math.Sqrt(sumStandard / population.GetAmount());
            WriteLine("StandardDeviation.txt", standardDeviation.ToString());

            //CONSOLE INFO
            generation++;
            Console.WriteLine("Generation: " + generation + " Best: " + population.GetEntitys()[0].GetFittingLevel().ToString());

        }
        public static void ResetAll()
        {
            Reset("Best.txt");
            Reset("Worst.txt");
            Reset("Median.txt");
            Reset("Avrage.txt");
            Reset("StandardDeviation.txt");
        }
        private static void Reset(string file)
        {
            using (System.IO.StreamWriter tw = new System.IO.StreamWriter(Path.GetFullPath(@"..\Logger\") + file, false))
            {
            }
        }

        private static void WriteLine(string file, string text)
        {
            using (System.IO.StreamWriter tw = new System.IO.StreamWriter(Path.GetFullPath(@"..\Logger\") + file, true))
            {
                tw.WriteLine(text);
            }
        }
    }
}
