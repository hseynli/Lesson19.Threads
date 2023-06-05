using System.Text;

class Program
{
    static void Function()
    {
        Console.WriteLine("İkinci thread-ın ID-si: {0}", Thread.CurrentThread.ManagedThreadId);
        Console.ForegroundColor = ConsoleColor.Yellow;

        for (int i = 0; i < 160; i++)
        {
            Thread.Sleep(20);
            Console.Write(".");
        }

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("İkinci thread işini bitirdi.");
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Əsas thread-ın ID-si: {0}", Thread.CurrentThread.GetHashCode());

        // Yeni thread-ın yaradılması
        Thread thread = new Thread(new ThreadStart(Function));
        thread.Start();

        // Əsas thread yeni yaradılmış thread-ın işini bitirməsini gözləyəcək.
        thread.Join(); //TODO şərhdən çıxarmaq.

        Console.ForegroundColor = ConsoleColor.Green;

        for (int i = 0; i < 160; i++)
        {
            Thread.Sleep(20);
            Console.Write("-");
        }

        Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine("\nƏsas thread işini bitirdi.");

        // Delay
        Console.ReadKey();
    }
}