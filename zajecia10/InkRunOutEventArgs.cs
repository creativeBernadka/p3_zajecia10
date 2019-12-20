using System;

namespace zajecia10
{
    public class InkRunOutEventArgs : EventArgs
    {
        public int Page { get; set; }
        public string Ink { get; set; }

        public InkRunOutEventArgs(int page, string ink)
        {
            Page = page;
            Ink = ink;
        }
    }
}