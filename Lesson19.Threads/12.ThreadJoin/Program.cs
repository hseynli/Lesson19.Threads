using System.Text;

class Program
{
    // Ümumi iterasiya dəyişəni
    //[ThreadStatic] //TODO şərhdən çıxarmaq
    public static int counter;

    // Thread-ların rekursiv çağrılması
    public static void Method()
    {
        if (counter < 100)
        {
            counter++; // Çağrılan metodlar tərəfindən iterasiya dəyişənin bir vahid artırılması
            Console.WriteLine(counter + " - START --- " + Thread.CurrentThread.GetHashCode());

            Thread thread = new Thread(Method);
            thread.Start();
            thread.Join(); // şərhə salmaq             
        }

        Console.WriteLine("Thread {0} işini bitirdi.", Thread.CurrentThread.GetHashCode());
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread thread = new Thread(Method);
        thread.Start();
        thread.Join();

        Console.WriteLine("Əsas thread işini bitirdi.");

        // Delay
        Console.ReadKey();
    }
}