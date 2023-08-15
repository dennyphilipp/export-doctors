using webscrapingdoctor;

namespace ParallelExample
{
    class Program
    {
        static void Main()
        {
            var scraping = new Scraping();

            scraping.Execute();

            Console.WriteLine("Scraping finalizado...");
            Console.ReadLine();
        }
    }
}