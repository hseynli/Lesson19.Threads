// Работа вторичного потока.
Thread thread = new Thread(WriteSecond);
thread.Start();

// Работа первичного потока.
WriteSecond();

void WriteSecond()
{
    // CLR hər bir thread üçün öz stack-nı yaradır. Ona görə hər bir metodun öz lokal dəyişəni vardır.
    // counter dəyişənin instance-ı hər bir thread üçün ayrıca yaranacaqdır.
    // Ona görə dəyərlər bu şəkildə olacaqdır - 0,1,2.
    int counter = 0;

    while (counter < 10)
    {
        Console.WriteLine("Thread Id {0}, counter = {1}", Thread.CurrentThread.GetHashCode(), counter);
        counter++;
    }
}