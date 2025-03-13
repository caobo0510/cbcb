using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("请输入一个整数: ");
        if (int.TryParse(Console.ReadLine(), out int number) && number > 1)
        {
            List<int> primeFactors = GET(number);
            Console.WriteLine($"{number} 的素数因子为: {string.Join(", ", primeFactors)}");
        }
        else
        {
            Console.WriteLine("请输入一个有效的正整数。");
        }
    }
    static List<int> GET(int num)
    {
        List<int> factors = new List<int>();
        while (num % 2 == 0)
        {
            factors.Add(2);
            num /= 2;
        }
        for (int i = 3; i <= Math.Sqrt(num); i += 2)
        {
            while (num % i == 0)
            {
                factors.Add(i);
                num /= i;
            }
        }
        if (num > 2)
        {
            factors.Add(num);
        }

        return factors;
    }
}
