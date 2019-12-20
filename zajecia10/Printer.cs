using System;
using System.Collections.Generic;

namespace zajecia10
{
    public class Printer
    {
        private Random _random;

        private List<Ink> _inks;

        public event EventHandler<PaperJammedEventArgs> PaperJammed;

        public event EventHandler<InkRunOutEventArgs> InkRunOut;

        public void OnPaperJammed(EventArgs args)
        {
            Console.WriteLine("Printer: Paper Jammed!");
        }
        public void Print(int pageNumber)
        {
            _inks.ForEach(ink =>
            {
                if (ink.Color == "black")
                {
                    ink.Level -= _random.NextDouble() * (0.1 - 0.01) + 0.01;
                }
                else
                {
                    ink.Level -= _random.NextDouble() * 0.1;
                }

                if (ink.Level <= 0)
                {
                    InkRunOut.Invoke(this, new InkRunOutEventArgs(pageNumber, ink.Color));
                }
            });
            
            if (_random.NextDouble() < 0.001)
            {
                PaperJammed.Invoke(this, new PaperJammedEventArgs(pageNumber));
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
            
            _inks = new List<Ink>()
            {
                new Ink("black"),
                new Ink("cyan"),
                new Ink("magenta"),
                new Ink("yellow")
            };
            
            PaperJammed += InternalEventHandler;
            InkRunOut += InkRunOutEventHandler;
        }

        private class Ink
        {
            public double Level;
            public string Color;

            public Ink(double level, string color)
            {
                Level = level;
                Color = color;
            }

            public Ink(string color)
            {
                Level = 1;
                Color = color;
            }
        }
    }
}