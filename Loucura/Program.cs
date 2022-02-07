using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Loucura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start();
        }
        static void Start()
        {
            Console.WriteLine("Informe o tempo para executar: ");
            int time = int.Parse(Console.ReadLine());       

            Console.WriteLine("Digite um valor: ");
            int valor = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o caminho para salvar: ");
            string path = Console.ReadLine();
            
            Calculo(valor, time, path);
        }
        static void Calculo(int valor, int time, string path)
        {
            /*
             * this method is used to show you all outputs for the program
             * You won't see the results from the Loucura yet, unless you
             * change the code
             */
            int currentTime = 0;
            List<double> values = new List<double>();
            while (currentTime < time)
            {
                currentTime++;
                double a = Loucura(currentTime, time, path);
                values.Add(a);
                Console.WriteLine($"Elapsed time {currentTime}");
                Thread.Sleep(1000);
            }

            /*
             * At the end of Loucura I send the list to storage it
             */
            Store(path, values);
        }
        static double Loucura(int currentTime, int time, string path)
        {
            /*
             * do your Loucura here but be careful to not overflow or consume 
             * too much process
             * - maybe it could be in a separeted thread  of the main
             */
            double conta = currentTime / time + Math.Pow(currentTime, 2) * currentTime / time;
            return conta;
        }
        static void Store(string path, List<double> valores)
        {
            /*
             * I send the values calculated previously to this function and them i call
             * WriteInFile to well... write it down
             */
                WriteInFile(path, valores);
        }
        static void WriteInFile(string path, List<double> stored)
        {
            /*
             *  Maybe I can validate the path, or use an better way to create directory using Directory.CreateDirectory
             *  or the archive extension' using a lambda like to force use one kind of archive, but you are free
            */
            using (var file = new StreamWriter(path))
            {
                foreach(double v in stored)
                {
                    file.WriteLine(v);
                }
            }
        }
    }
}
