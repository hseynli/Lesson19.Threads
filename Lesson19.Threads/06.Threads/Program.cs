ThreadStart writeSecond = new ThreadStart(WriteSecond);
Thread thread = new Thread(writeSecond);
thread.Start();

// Əsas thread-ın işləməsi.
for (int i = 0; i < 10; i++)
{
    Console.WriteLine("Primary");
    Thread.Sleep(500);
}

// Əlavə yaradılan thread-ın işini bitirmək (əsas thread işini bitirdikdən sonra).
//thread.IsBackground = true;

static void WriteSecond()
{
    while (true)
    {
        Console.WriteLine(new string(' ', 15) + "Secondary");
        Thread.Sleep(500);
    }
}