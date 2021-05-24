using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;
using System.CodeDom.Compiler;

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
            //POLECENIE
            var strb = new StringBuilder();
            strb.AppendLine("");
            strb.AppendLine(@$"Polecenie = ""{Polecenie}""");

            //ARGUMENTY 
            strb.AppendLine("");
            strb.AppendLine("Argumenty");
            foreach (var item in Argumenty)
            {
                strb.AppendLine($@"""{item}""");
            }

            //OPCJE I WARTOŚCI OPCJI
            strb.AppendLine("");
            strb.AppendLine("Opcja");
            foreach (KeyValuePair<string, string> item in Opcje)
            {
                //DODANE CZY SPEC
                if (Znak == "n")
                {
                    strb.AppendLine(Environment.NewLine + $@"""{item.Value}""");
                }
                else
                {
                    //PIERWOTNE
                    strb.AppendLine($@"""{item.Key}"":" + $@"""{item.Value}"""); //""\item.Value"\");
                    
                }
                
            }
            return strb.ToString();
        }
    }
}
