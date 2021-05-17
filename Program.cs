using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AppPolecanie
{
    class Program
    {
        static void Main(string[] args)
        {
            string TrescPolecenia = "Def string tryb";
            // Def -domyslny debug
            // Def string tryb -domyslny debug
            //string TrescPolecenia = "Def string tryb -domyslny debug -elementy 1,2,3,4 -resetuj -separator ,";

            TrescPolecenia = TrescPolecenia.Trim();//TRIM usuwa wszytskie białe znaki
            int i = 0;
            int x = 0;
            int poczatek = 0;
            int koniec = 0;
            var polecenie = new Polecenia();
            //var slowo [] = new Slowa();
            //char[] slowo;

            //var arg = new ();


            while (i < TrescPolecenia.Length)
            {

                var ch = TrescPolecenia[i];
                if (char.IsWhiteSpace(ch))
                {

                    //slowo = TrescPolecenia.ToCharArray(poczatek, koniec);

                    i++;
                    //Console.WriteLine("test = " + polecenie.Polecenie);
                    //polecenie.Slowo = polecenie.Polecenie;
                    //polecenie.Polecenie = "";
                    //rConsole.WriteLine("znak = " + ch);
                    polecenie.Slowo = " ";

                    polecenie.Literea = null;
                    continue;
                }
                else
                {
                    i++;
                
                    //polecenie.Polecenie += ch;
                    polecenie.Slowo += ch;
                    polecenie.Literea = ch.ToString();
                    poczatek = i;

                }

                //Console.WriteLine("ID = " + i + " wartość = " + ch);


                //DZIAŁA 
                if (polecenie.Polecenie == null)
                {
                    //polecenie.Polecenie = TrescPolecenia.Substring(poczatek, i - poczatek - 1);
                    //polecenie.Polecenie = TrescPolecenia.Substring(poczatek, koniec);
                    //Console.WriteLine("Polecenie = " + polecenie.Polecenie);
                    polecenie.Polecenie = TrescPolecenia.Substring(poczatek - i, i + poczatek + 1);
                    //Console.WriteLine("test = " + polecenie.Polecenie);
                    Console.WriteLine("Polecenie = " + polecenie.Polecenie);
                }
                else
                {
                    //polecenie.Polecenie = TrescPolecenia.Substring(0, 4);
                    //Console.WriteLine("test = " + polecenie.Polecenie);
                    //Console.WriteLine("Polecenie 2= " + polecenie.Polecenie);
                    //Console.WriteLine(ch);
                }

                //TEST
                //Console.WriteLine(polecenie.Literea);
                if (polecenie.Literea == " ")
                {
                    polecenie.Slowo = TrescPolecenia.Substring(poczatek - i, i + poczatek + 1);
                    Console.WriteLine("Argumenty = " + polecenie.Slowo);

                }

            }


            Console.WriteLine("koniec = " + koniec);
            Console.WriteLine("poczatek = " + poczatek);
            //Console.WriteLine("i = " + i);

            //Console.WriteLine("Polecenie = " + polecenie.Polecenie);
            //Console.WriteLine("Argumenty = ");
            //Console.WriteLine("Opcje = ");

        }
    }
}

