using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Genetic_Algorithm
{
    class Logger
    {

        private static int generation = 0;  //The current generation.

        /// <summary>
        /// Logg the population to text files.
        /// </summary>
        /// <param name="population">The population to logg.</param>
        public static void LoggPopulation(Population population)
        {
            //Best
            WriteLine("Best.txt", population.GetEntitys()[0].GetFittingValue().ToString());

            //Baddest            
            WriteLine("Worst.txt", population.GetEntitys()[population.GetAmount()-1].GetFittingValue().ToString());

            //Median
            WriteLine("Median.txt", population.GetEntitys()[population.GetAmount()/2].GetFittingValue().ToString());

            //Avrage
            float sum = 0;
            foreach (AIEntity e in population.GetEntitys())
                sum += e.GetFittingValue();

            float avrage = sum / population.GetAmount();
            WriteLine("Avrage.txt", avrage.ToString());

            //Standard deviation
            float sumStandard = 0;
            foreach (AIEntity e in population.GetEntitys())
                sumStandard += (float)Math.Pow((e.GetFittingValue() - avrage), 2);

            float standardDeviation = (float)Math.Sqrt(sumStandard / population.GetAmount());
            WriteLine("StandardDeviation.txt", standardDeviation.ToString());

            //CONSOLE INFO
            generation++;
            Console.WriteLine("Generation: " + generation + " Best: " + population.GetEntitys()[0].GetFittingValue().ToString());

        }

        /// <summary>
        /// Clear all the files. 
        /// </summary>
        public static void ResetAll()
        {
            Clear("Best.txt");
            Clear("Worst.txt");
            Clear("Median.txt");
            Clear("Avrage.txt");
            Clear("StandardDeviation.txt");
        }

        /// <summary>
        /// Removes a file from all text.
        /// </summary>
        /// <param name="file">The file to clear.</param>
        private static void Clear(string file)
        {
            using (System.IO.StreamWriter tw = new System.IO.StreamWriter(Path.GetFullPath(@"..\Logger\") + file, false)){}
        }

        /// <summary>
        /// Add a string/line to the file.
        /// </summary>
        /// <param name="file">The file to write to.</param>
        /// <param name="text">The text line to write.</param>
        private static void WriteLine(string file, string text)
        {
            using (System.IO.StreamWriter tw = new System.IO.StreamWriter(Path.GetFullPath(@"..\Logger\") + file, true))
            {
                tw.WriteLine(text);
            }
        }
    }
}
