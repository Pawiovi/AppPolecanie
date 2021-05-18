using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AppPolecanie
{
    class Program
    {
        static void Main(string[] args)
        {
            //string TrescPolecenia = " Def string tryb ";
            //string TrescPolecenia = " Def -domyslny debug ";
            //string TrescPolecenia = " Def string tryb -domyslny debug ";
            string TrescPolecenia = "Def string tryb -domyslny debug -elementy 1,2,3,4 -resetuj -separator ,";

            TrescPolecenia = TrescPolecenia.Trim();//TRIM usuwa wszytskie białe znaki
            int i = 0;
            
            var polecenie = new Polecenia();
            
            var strb = new StringBuilder();
            var typ = TypDanych.Polecenie;
            bool bylaOpcja = false;

            while (i < TrescPolecenia.Length)
            {

                var ch = TrescPolecenia[i++];
                if (char.IsWhiteSpace(ch))
                {
                    switch (typ)
                    {
                        case TypDanych.Polecenie:
                            polecenie.Polecenie = strb.ToString();
                            
                            break;
                        case TypDanych.Argument:
                            polecenie.Argumenty.Add(strb.ToString());
                            
                            break;
                        case TypDanych.Opcje:
                            
                            polecenie.Opcje[strb.ToString()] = null;
                            bylaOpcja = true;
                            
                            break;
                        case TypDanych.OpcjaWartosc:
                            //polecenie.Opcje[polecenie.Opcje.Keys.Last()] = strb.ToString();
                            polecenie.Opcje[polecenie.Opcje.Keys.Last()] = strb.ToString();
                            bylaOpcja = false;
                            
                            break;
                        default:
                            break;
                    }
                    typ = TypDanych.Brak;
                    strb.Clear();
                   
                }
                else
                {
                    if (typ == TypDanych.Brak)
                    {
                        if (ch == '-')
                        {
                            typ = TypDanych.Opcje;
                            bylaOpcja = false;
                            
                            continue;
                        }
                        else
                        {
                            if (bylaOpcja == true)
                            {
                                typ = TypDanych.OpcjaWartosc;
                            }
                            else
                            {
                                typ = TypDanych.Argument;
                            }
                        }
                    }
                    strb.Append(ch);

                    //polecenie.Polecenie += ch;
                    //polecenie.Slowo += ch;
                    //polecenie.Znak = ch.ToString();
                    //poczatek = i;



                }


                //Console.WriteLine("ID = " + i + " wartość = " + ch);


                //DZIAŁA 
                //if (polecenie.Polecenie == null)
                //{
                //    //polecenie.Polecenie = TrescPolecenia.Substring(poczatek, i - poczatek - 1);
                //    //polecenie.Polecenie = TrescPolecenia.Substring(poczatek, koniec);
                //    //Console.WriteLine("Polecenie = " + polecenie.Polecenie);
                //    polecenie.Polecenie = TrescPolecenia.Substring(poczatek - i, i + poczatek + 1);
                //    //Console.WriteLine("test = " + polecenie.Polecenie);
                //    Console.WriteLine("Polecenie = " + polecenie.Polecenie);


                //}
                //else
                //{
                //    //polecenie.Polecenie = TrescPolecenia.Substring(0, 4);
                //    //Console.WriteLine("test = " + polecenie.Polecenie);
                //    //Console.WriteLine("Polecenie 2= " + polecenie.Polecenie);
                //    //Console.WriteLine(ch);
                //}


                // DLA OPCJI
                //if (polecenie.Znak == "-")
                //{
                //    polecenie.Slowo = TrescPolecenia.Substring(poczatek - i, i + poczatek + 1);
                //    //Console.WriteLine("Test = " + polecenie.Slowo);

                //    //polecenie.Argumenty.Add(polecenie.Slowo.ToString());

                //    Console.WriteLine("Test = " + polecenie.Argumenty);
                //}
                //else
                //{
                //    //Console.WriteLine("NOPE");
                //}

                //if (ch == ' ')
                //{
                //    //polecenie.Slowo = TrescPolecenia.Substring(poczatek - i, i + poczatek + 1);

                //    Console.WriteLine("Argumenty = " + polecenie.Slowo);
                //    polecenie.Slowo = "";
                //}
                //i++;
                //Console.WriteLine(polecenie.Literea);
                //if (polecenie.Literea == " ")
                //{
                //    //polecenie.Slowo = TrescPolecenia.Substring(poczatek - i, i + poczatek + 1);
                //    Console.WriteLine("Argumenty = " + polecenie.Slowo);

                //}

            }

            switch (typ)
            {
                case TypDanych.Polecenie:
                    polecenie.Polecenie = strb.ToString();
                    typ = TypDanych.Brak;
                    break;
                case TypDanych.Argument:
                    polecenie.Argumenty.Add(strb.ToString());
                    break;
                case TypDanych.Opcje:
                    polecenie.Opcje[strb.ToString()] = null;
                    break;
                case TypDanych.OpcjaWartosc:
                    polecenie.Opcje[polecenie.Opcje.Keys.Last()] = strb.ToString();
                    break;
                default:
                    break;
            }
            Console.WriteLine(polecenie);
            //Console.WriteLine("test = " + polecenie.Polecenie);

            //Console.WriteLine("koniec = " + koniec);
            //Console.WriteLine("poczatek = " + poczatek);
            //Console.WriteLine("i = " + i);

            //Console.WriteLine("Polecenie = " + polecenie.Polecenie);
            //Console.WriteLine("Argumenty = ");
            //Console.WriteLine("Opcje = ");

        }
    }
}

