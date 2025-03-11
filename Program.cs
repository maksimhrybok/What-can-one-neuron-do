using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What_can_one_neuron_do
{
    internal class Program
    {
        public class Neuron
        {
            private decimal weight = 0.5m;
            public decimal LastError { get; private set; }

            public decimal Smoothing { get; set; } = 0.00001m;

            public decimal ProcessInputData(decimal input)
            {
                return input * weight;
            }

            public decimal ResctoreInputData(decimal output)
            {
                return output / weight;
            }

            public void Train(decimal input, decimal expectedResult)
            {
                var actualResult = input * weight;
                LastError = expectedResult - actualResult;
                var correction = (LastError / actualResult) * Smoothing;
                weight += correction;
            }

        }

        static void Main(string[] args)
        {
            decimal usd = 1;
            decimal uah = 41.34m;

            Neuron neuron = new Neuron();

            int i = 0;
            do
            {
                i++;
                neuron.Train(usd, uah);

                if(i % 100000 == 0)
                {
                Console.WriteLine($"Iteration: {i}\tMistake:\t{neuron.LastError}");
                }
            }
            while (neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);

            Console.WriteLine("Traning is done!");

            Console.WriteLine($"{neuron.ProcessInputData(100)} uah in {100} usd");
            Console.WriteLine($"{neuron.ProcessInputData(541)} uah in {541} usd");
            Console.WriteLine($"{neuron.ResctoreInputData(10)} usd in {10} uah");
        }
    }
}
