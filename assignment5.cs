﻿using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = 100;
        List<int> primes = SieveOfEratosthenes(n);

        Console.WriteLine("2到100以内的素数有：");
        foreach (int prime in primes)
        {
            Console.Write(prime + " ");
        }
    }

    static List<int> SieveOfEratosthenes(int n)
    {
        bool[] isPrime = new bool[n + 1];
        for (int i = 2; i <= n; i++)
        {
            isPrime[i] = true;
        }

        for (int p = 2; p * p <= n; p++)
        {
            if (isPrime[p])
            {
                for (int i = p * p; i <= n; i += p)
                {
                    isPrime[i] = false;
                }
            }
        }
        List<int> primes = new List<int>();
        for (int i = 2; i <= n; i++)
        {
            if (isPrime[i])
            {
                primes.Add(i);
            }
        }

        return primes;
    }
}
