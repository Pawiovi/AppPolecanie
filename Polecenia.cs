using System;
using System.Collections.Generic;
using System.Text;

namespace AppPolecanie
{
    public class Polecenia
    {
        public string Polecenie { get; set; }

        public string Slowo { get; set; }

        public string Literea { get; set; }

        public List<string> Argumenty { get; set; }

        public Dictionary<string, string> Opcje { get; set; }
    }
}
