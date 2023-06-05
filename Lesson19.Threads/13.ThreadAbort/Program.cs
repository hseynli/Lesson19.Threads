// Thread-lar iki növdə işləyə bilir Foreground и Background
// Foreground - Əsas thread işini bitirəndən sonra da işinə davam edəcək.
// Background - Əsas thread ilə işini bitirəcəkdir
using System.Text;

class Program
{
    static void Procedure()
    {
        for (int i = 0; i < 1000; i++)
        {
            Thread.Sleep(10);
            Console.Write(".");
        }
        Console.WriteLine("\nİkinci thread işini bitirdi.");
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        var thread = new Thread(Procedure);

        // IsBackground - thread-ı fonda işlətmək üçündür. Bu halda ikinci thread-ın işini bitirməsini gözləmirik.
        // Default olaraq - thread.IsBackground = false; 

        //thread.IsBackground = true; // Şərhə salmaq.
        thread.Start();

        Thread.Sleep(500);

        Console.WriteLine("\nƏsas thread işini bitirdi.");
    }
}