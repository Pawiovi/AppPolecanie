using System;

namespace AppPolecanie
{
    class Program
    {
        static void Main(string[] args)
        {
            string TrescPolecenia = "Def string tryb -domyslny debug -elementy 1,2,3,4 -resetuj -separator";

            string[] subs = TrescPolecenia.Split(' ');

           //foreach (var sub in subs)
           //{
                //Console.WriteLine($"Substring: {sub}");

                var Tpol = TrescPolecenia.Substring(0, TrescPolecenia.IndexOf(" "));

                //var Targ = TrescPolecenia.Substring(3, TrescPolecenia.IndexOf(" -"));
                int T1Targ = TrescPolecenia.IndexOf(" ") + " ".Length;
                int T2Targ = TrescPolecenia.IndexOf(" -");
                var Targ = TrescPolecenia.Substring(T1Targ, T2Targ - T1Targ);
                
                int T1Topcje = TrescPolecenia.IndexOf(" -") + " ".Length;
                int T2Topcje = TrescPolecenia.LastIndexOf("");
                var Topcje = TrescPolecenia.Substring(T1Topcje, T2Topcje - T1Topcje);
                //var Tmiedzy = Tpol - Targ;
                //var Topc

                Console.WriteLine("Polecenie= " + Tpol);
                Console.WriteLine("Argumenty= " + Targ);
                Console.WriteLine("Opcje= "+ Topcje);
           // }

        }
    }
}
