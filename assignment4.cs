using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] a = new int[] { 7, 11, 23, 56, 87, 99, 55 };
        int max = Findmax(a);
        int min = Findmin(a);
        double average = Findaverage(a);
        int sum = calculate(a);
        Console.WriteLine(max);
        Console.WriteLine(min);
        Console.WriteLine(average);
        Console.WriteLine(sum);

        static int Findmax(int[] array)
        {
            int max = array[0];
            for(int i = 1; i < array.Length; i++) {
                if (array[i] > max)
                    max = array[i]; }
                return max;
        }
        static int Findmin(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
            }
            return min;
        }
        static double Findaverage(int[] array)
        {
            int sum = calculate(array);
            return (double)sum / (double)array.Length;
        }
        static int calculate(int[] array)
        {
            int sum = 0;
            foreach (int item in array)
            {
                sum += item;
            }
            return sum;
        }
    }
}