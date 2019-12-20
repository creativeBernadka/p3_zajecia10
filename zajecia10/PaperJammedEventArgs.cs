using System;

namespace zajecia10
{
    public class PaperJammedEventArgs: EventArgs
    {
        public int Page { get; set; }

        public PaperJammedEventArgs(int page)
        {
            Page = page;
        }
    }
}