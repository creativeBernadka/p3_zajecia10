using System;

namespace zajecia10
{
    public abstract class PrinterEventArgs: EventArgs
    {
        public int Page;

        public PrinterEventArgs(int page)
        {
            Page = page;
        }
    }
}