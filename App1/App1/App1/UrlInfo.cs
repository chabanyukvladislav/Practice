using System.Collections.Generic;

namespace App1
{
    public class UrlInfo
    {
        public string Protocol { get; set; }
        public string Address { get; set; }
        public Dictionary<string, string> Arguments { get; set; }
    }
}