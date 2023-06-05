using System.Text;
class Program
{
    static void WriteChar(char chr, int count, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        for (int i = 0; i < count; i++)
        {
            Thread.Sleep(20);
            Console.Write(chr);
        }

        Console.ForegroundColor = ConsoleColor.Gray;
    }

    // Üçüncü thread-da işləyəcək metod (ikinci threaddan çağrılacaq).
    public static void Method3()
    {
        Console.WriteLine("Üçüncü thread # {0}", Thread.CurrentThread.GetHashCode());
        WriteChar('3', 80, ConsoleColor.Yellow);
        Console.WriteLine("Üçüncü thread işini bitirdi.");
    }

    // İkinci thread-da işləyəcək metod (Birinci (əsas) thread-dan çağrılacaq).
    public static void Method2()
    {
        Console.WriteLine("İkinci thread # {0}", Thread.CurrentThread.GetHashCode());
        WriteChar('2', 80, ConsoleColor.Blue);

        // Üçüncü thread-ın yaradılması
        var thread = new Thread(Method3);
        thread.Start();
        thread.Join();

        WriteChar('2', 80, ConsoleColor.Blue);
        Console.WriteLine("İkinci thread işini bitirdi.");
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Birinic thread # {0}", Thread.CurrentThread.GetHashCode());
        WriteChar('1', 80, ConsoleColor.Green);

        // İkinci thread-ın yaradılması
        Thread thread = new Thread(Method2);
        thread.Start();
        thread.Join();

        WriteChar('1', 80, ConsoleColor.Green);

        Console.WriteLine("Birinci thread işini bitirdi.");

        // Delay
        Console.ReadKey();
    }
}