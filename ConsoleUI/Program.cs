using System;
using System.Threading;

class Program
{
    static Semaphore signal0 = new Semaphore(1, 1);
    public static int cntr = 5;
    public static int bufsize = 5;

    static void Main()
    {
        Thread thread1 = new Thread(Thread1);
        Thread thread2 = new Thread(Thread2);

        thread1.Start();
        thread2.Start();

        Console.WriteLine("Threads started.");

        thread1.Join();
        thread2.Join();

        Console.WriteLine("Final value: " + cntr);
    }

    static void Thread1()
    {
        int i = 0;
        while (i < 5)
        {
            Console.WriteLine("Producer waiting for semaphore");
            signal0.WaitOne();
            Console.WriteLine("Producer checking the while loop condition");
            while (cntr == bufsize) { };
            cntr--;
            Console.WriteLine("Producer decreases cntr by 1");
            signal0.Release();
            i++;
        }
    }

    static void Thread2()
    {
        int i = 0;
        while (i < 5)
        {
            Console.WriteLine("Producer waiting for semaphore");
            signal0.WaitOne();
            Console.WriteLine("Producer checking the while loop condition");
            while (cntr == bufsize) { };
            cntr++;
            Console.WriteLine("Producer increments cntr by 1");
            signal0.Release();
            i++;
        }
    }
}