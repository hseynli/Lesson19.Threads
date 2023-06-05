ThreadStart writeSecond = new ThreadStart(WriteSecond);
Thread thread = new Thread(writeSecond);
thread.Start();

while (true)
{
    Console.WriteLine("Primary");
}

void WriteSecond()
{
    while (true)
    {
        Console.WriteLine(new string(' ', 10) + "Secondary");
    }
}