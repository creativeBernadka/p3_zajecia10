using System;

namespace zajecia10
{
    public class InkRunOutEventArgs : PrinterEventArgs
    {
        public string Ink { get; set; }

        public InkRunOutEventArgs(int page, string ink): base(page)
        {
            Ink = ink;
        }
    }
}