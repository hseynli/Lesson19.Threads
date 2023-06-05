MyClass instance = new MyClass();

for (int i = 0; i < 3; i++)
{
    new Thread(instance.Method).Start();
}

Thread.Sleep(500);

// Delay.
Console.ReadKey();

class MyClass
{
    object block = new object();

    public void Method()
    {
        int hash = Thread.CurrentThread.GetHashCode();

        lock (block) // lock-u şərhə salmaq.
        {
            for (int counter = 0; counter < 10; counter++)
            {
                Console.WriteLine("Thread # {0}: iterasiya {1}", hash, counter);
                Thread.Sleep(100);
            }
            Console.WriteLine(new string('-', 20));
        }
    }
}