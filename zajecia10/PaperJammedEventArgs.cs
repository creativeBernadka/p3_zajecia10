using System;

namespace zajecia10
{
    public class PaperJammedEventArgs: PrinterEventArgs
    {

        public PaperJammedEventArgs(int page) : base(page)
        {
        }
    }
}