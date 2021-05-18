using System;
using System.Collections.Generic;
using System.Text;

namespace AppPolecanie
{
    public class Polecenia
    {
        public string Polecenie { get; set; }

        public string Slowo { get; set; }

        public string Znak { get; set; }

        public List<string> Argumenty { get; set; } = new List<string>();

        public Dictionary<string, string> Opcje { get; set; } = new Dictionary<string, string>();

        public override string ToString()
        {
            var strb = new StringBuilder();
            strb.AppendLine(@$"Polecenie = ""{Polecenie}""");
            
            strb.AppendLine("Argumenty");
            foreach (var item in Argumenty)
            {
                strb.AppendLine($@"""{item}""");
            }

            strb.AppendLine("Opcja");
            foreach (KeyValuePair<string, string> item in Opcje)
            {
                strb.AppendLine($@"""{item.Key}"":" + $@"""{item.Value}"""); //""\item.Value"\");
            }
            return strb.ToString();
        }
    }
}
