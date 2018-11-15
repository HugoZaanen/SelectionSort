using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new Random();
            var data = new int[10];

            //fill array with random int in range 10-99
            for(var i = 0; i < data.Length;++i)
            {
                data[i] = generator.Next(10, 100);
            }

            Console.WriteLine("Unsorted array:");
            Console.WriteLine(string.Join(" ", data) + " \n");//display array

            SelectionSort(data);//sort array

            Console.WriteLine("Sorted array:");
            Console.WriteLine(string.Join(" ", data) + "\n");
            Console.Read();
        }

        //sort array using selection sort
        public static void SelectionSort(int[] values)
        {
            //loop over data.Length - 1 elements
            for(var i = 0; i < values.Length - 1;++i)
            {
                var smallest = i;//first index of remaining array

                //loop to find index of smallest element
                for(var index = i + 1;index < values.Length;++index)
                {
                    if(values[index] < values[smallest])
                    {
                        smallest = index;
                    }
                }

                Swap(ref values[i], ref values[smallest]);//swap elements
                PrintPass(values, i + 1, smallest);//ouput pass of algorithm
            }
        }

        //helper method to swap values in two elements
        public static void Swap(ref int first, ref int second)
        {
            var temporary = first;//stre first in temporary
            first = second;// replace first with second
            second = temporary;//put temporary in second
        }

        //display a pass of the algorithm
        public static void PrintPass(int[] values, int pass, int index)
        {
            Console.Write($"after pass {pass}\n");

            //output elements through the selected item
            for(var i = 0; i < index;++i)
            {
                Console.Write($"{values[i]} ");
            }

            Console.Write($"{values[index]}* ");//indicate swap

            //finish outputting array
            for(var i = index + 1;i < values.Length;++i)
            {
                Console.Write($"{values[i]} ");
            }

            Console.Write("\n       ");//for alignment

            //indicate amount of array that is sorted
            for(var j = 0; j < pass; ++j)
            {
                Console.Write("-- ");
            }

            Console.WriteLine("\n");//skip a line in output
        }
    }
}