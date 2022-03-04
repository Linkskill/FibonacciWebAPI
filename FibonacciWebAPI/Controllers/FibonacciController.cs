using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    public class FibonacciController
    {
        public FibonacciController() { }

        [HttpGet("NaiveIterationFibonacci")]
        public ulong NaiveIterationFibonacci(int nTerm)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ulong term = 1, prevTerm = 0, aux;

            for (int i = 1; i <= nTerm; i++)
            {
                aux = term;

                term += prevTerm;
                prevTerm = aux;
            }

            sw.Stop();
            Console.WriteLine("Time Elapsed in Miliseconds: " + sw.Elapsed.TotalMilliseconds.ToString() + "ms");

            return term;
        }

        [HttpGet("NaiveRecursiveFibonacci")]
        public ulong NaiveRecursiveFibonacci(int nTerm)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ulong result = NaiveRecursiveFibonacciMethod(nTerm);
            sw.Stop();

            Console.WriteLine("Time Elapsed in Miliseconds: " + sw.Elapsed.TotalMilliseconds.ToString() + "ms");

            return result;
        }

        private ulong NaiveRecursiveFibonacciMethod(int nTerm)
        {
            if (nTerm < 2)
            {
                return 1;
            }
            else
            {
                return NaiveRecursiveFibonacciMethod(nTerm - 1) + NaiveRecursiveFibonacciMethod(nTerm - 2);
            }
        }

        [HttpGet("MemoizationFibonacci")]
        public ulong MemoizationFibonacci(int nTerm)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ulong[] fVet = new ulong[nTerm+1];
            ulong result = 0;

            for (int i = 0; i <= nTerm; i++)
            {
                if (i < 2)
                {
                    fVet[i] = 1;
                }
                else
                {
                    fVet[i] = 0;
                }
            }


            if (nTerm < 2)
            {
                return 1;
            }
            else
            {
                result = MemoizationFibonacciMethod(fVet, nTerm);
            }
            sw.Stop();

            Console.WriteLine("Time Elapsed in Miliseconds: " + sw.Elapsed.TotalMilliseconds.ToString() + "ms");

            return result;
        }

        private ulong MemoizationFibonacciMethod(ulong[] fVet, int nTerm)
        {
            if (fVet[nTerm] == 1)
            {
                return fVet[nTerm];
            }

            fVet[nTerm] = MemoizationFibonacciMethod(fVet, nTerm - 1) + fVet[nTerm - 2];

            return fVet[nTerm];
        }
    }
}