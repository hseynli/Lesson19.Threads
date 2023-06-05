// Interlocked - bir neçə thread-ın istifadə etdiyi dəyişənləe üzərində əməliyyatların edilməsi üçün yaradılmış klasdır.

using System.Text;

class Program
{
    // Yaradılmış thread üçün iterasiya dəyişəni
    static long counter;
    //static object block = new object();

    static void Procedure()
    {
        // İterasiya dəyişənin artırılması
        for (int i = 0; i < 1000000; i++)
        {
            Interlocked.Increment(ref counter);

            //lock (block)
            //{
            //  counter++;
            //}
        }
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("İterasiya dəyişəninin gözlənilən dəyəri = 10000000");

        Thread[] threads = new Thread[10];

        for (int i = 0; i < 10; ++i)
            (threads[i] = new Thread(Procedure)).Start();

        for (int i = 0; i < 10; ++i)
            threads[i].Join();

        Console.WriteLine("İterasiya dəyişəninin real dəyəri  = {0}", counter);

        // Delay
        Console.ReadKey();
    }
}