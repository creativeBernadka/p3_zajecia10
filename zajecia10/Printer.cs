using System;

namespace zajecia10
{
    public class Printer
    {
        private Random _random;

        private double _blackInk = 1;
        private double _cyjanInk = 1;
        private double _magentaInk = 1;
        private double _yellowInk = 1;
        
        public event EventHandler<PaperJammedEventArgs> PaperJammed;

        public event EventHandler<InkRunOutEventArgs> InkRunOut;

        public void OnPaperJammed(EventArgs args)
        {
            Console.WriteLine("Printer: Paper Jammed!");
        }
        public void Print(int pageNumber)
        {
            _blackInk -= _random.NextDouble() * (0.1 - 0.01) + 0.01;
            _magentaInk -= _random.NextDouble() * 0.1;
            _cyjanInk -= _random.NextDouble() * 0.1;
            _yellowInk -= _random.NextDouble() * 0.1;
            
            if (_random.NextDouble() < 0.001)
            {
                PaperJammed.Invoke(this, new PaperJammedEventArgs(pageNumber));
            }
            else if (_blackInk <= 0)
            {
                InkRunOut.Invoke(this, new InkRunOutEventArgs(pageNumber, "black"));
            }
            else if (_cyjanInk <= 0)
            {
                InkRunOut.Invoke(this, new InkRunOutEventArgs(pageNumber, "cyjan"));
            }
            else if (_magentaInk <= 0)
            {
                InkRunOut.Invoke(this, new InkRunOutEventArgs(pageNumber, "magenta"));
            } 
            else if (_yellowInk <= 0)
            {
                InkRunOut.Invoke(this, new InkRunOutEventArgs(pageNumber, "yellow"));
            }
            else
            {
                Console.WriteLine("etykieta");
            }
        }

        private void InternalEventHandler(object sender, PaperJammedEventArgs args)
        {
            Console.WriteLine(
                $"[Printer log] Jammed at page {args.Page} " +
                $"at {DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}"
                );
        }

        private void InkRunOutEventHandler(object sender, InkRunOutEventArgs args)
        {
            Console.WriteLine(
                $"[Printer log]: {args.Ink} ink run out at page {args.Page} " +
                $"at {DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}"
                );
        }

        public Printer()
        {
            _random = new Random();
            PaperJammed += InternalEventHandler;
            InkRunOut += InkRunOutEventHandler;
        }
    }
}