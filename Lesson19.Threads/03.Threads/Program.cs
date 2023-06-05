Console.OutputEncoding = System.Text.Encoding.UTF8;

// Cari thread-ın instance-nı alırıq.
Thread primaryThread = Thread.CurrentThread;

// Thread-a ad veririk.
primaryThread.Name = "Primary";

// Cari thread haqqında məlumatı ekranda əks elətdiririk.
Console.WriteLine("Thread Id {0}: {1}", primaryThread.Name, primaryThread.GetHashCode());


// Yeni threa-ın işləməsi.
Thread secondaryThread = new Thread(WriteSecond);
secondaryThread.Start();

for (int counter = 0; counter < 10; counter++)
{
    Console.WriteLine(primaryThread.Name + " " + counter);
    // Cari thread-ı qeyd edilən milli saniyə əsasında saxlayırıq.
    Thread.Sleep(1500);
}

// Delay.
Console.ReadKey();



void WriteSecond()
{
    // Thread.CurrentThread - cari thread-a instance qaytarır.
    Thread thread = Thread.CurrentThread;

    // Thread-a ad veririk.
    thread.Name = "Secondary";

    // Cari thread haqqında məlumatı ekranda əks elətdiririk.
    Console.WriteLine("Thread Id {0}: {1}", thread.Name, thread.GetHashCode());

    for (int counter = 0; counter < 10; counter++)
    {
        Console.WriteLine(new string(' ', 15) + thread.Name + " " + counter);
        // Cari thread-ı qeyd edilən milli saniyə əsasında saxlayırıq.
        Thread.Sleep(1000);
    }
}