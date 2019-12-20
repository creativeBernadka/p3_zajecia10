using System;

namespace zajecia10
{
    class Program
    {
        private static bool _canPrint = true;
        static void Main(string[] args)
        {
            Printer printer = new Printer();
            
            printer.PaperJammed += PaperJammedEventHandler;
            printer.InkRunOut += InkRunOutEventHandler;
            
            for (int i = 0; i < 500; i++)
            {
                printer.Print(i);
                if (!_canPrint)
                {
                    break;
                }
            }
        }

        static void PaperJammedEventHandler(object sender, PaperJammedEventArgs e)
        {
            Console.WriteLine($"Main: Paper Jammed at page {e.Page}");
            _canPrint = false;
        }

        static void InkRunOutEventHandler(object sender, InkRunOutEventArgs e)
        {
            Console.WriteLine($"Main: {e.Ink} ink run out at page {e.Page}");
            _canPrint = false;
        }
    }
}