class PriorityTest
{
    public bool stop = false;

    public void Method()
    {
        Console.WriteLine("{1,11} prioriteti ilə olan Thread {0,3} işə başladı",
            Thread.CurrentThread.ManagedThreadId,
            Thread.CurrentThread.Priority);

        long count = 0;

        while (!stop)
            count++;

        Console.WriteLine("{1,11} prioriteti ilə olan Thread {0,3} işə başladı. Count = {2,13}",
            Thread.CurrentThread.ManagedThreadId,
            Thread.CurrentThread.Priority,
            count.ToString("N0"));
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Press any key...");
        Console.ReadKey();

        Console.WriteLine("Əsas thread-ın default prioriteti: {0}",
            Thread.CurrentThread.Priority);

        PriorityTest priorityTest = new PriorityTest();

        Thread[] threads = new Thread[9];

        for (int i = 0; i < 9; i++)
            threads[i] = new Thread(priorityTest.Method);

        // Thread-lara prioritetin təyin edilməsi
        threads[0].Priority = ThreadPriority.Lowest;

        for (int i = 1; i < 9; i++)
            threads[i].Priority = ThreadPriority.Highest;

        // Ən aşağı prioritet ilə olan thread-ın yaradılması
        threads[0].Start();

        // Yüksək prioritet ilə olan thread-ların işə düşməsinin qarşısını 2 saniyə almaq
        //Thread.Sleep(2000);

        // Digər yüksək prioriteti olan 8 thread işə salınması
        for (int i = 1; i < 9; i++)
            threads[i].Start();

        // Thread-ların işləyə bilməsi üçün 10 saniyə vaxt vermək
        Thread.Sleep(10000);

        Console.WriteLine("Əsas thread işini bitirdi.");

        // Bütün thread-ların işini dayandırmaq
        priorityTest.stop = true;

        // Delay
        Console.ReadKey();
    }
}