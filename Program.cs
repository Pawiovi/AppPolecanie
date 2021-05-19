﻿using System;
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
            //string TrescPolecenia = "Def string tryb -domyslny debug -elementy 1,2,3,4 -resetuj -separator ,";
            //string TrescPolecenia = "Def string tryb -domyslny debug -elementy 1,2,3,4 xxx -resetuj -separator ,";
            //string TrescPolecenia = "Def string tryb -domyslny debug -elementy \"1, 2, 3, 4\" -resetuj -separator ,";
            string TrescPolecenia = "Def string tryb -domyslny debug -elementy \"\\n1, \"2\", \n3, \\4\" -resetuj -separator ,";

            TrescPolecenia = TrescPolecenia.Trim();//TRIM usuwa wszytskie białe znaki
            int i = 0;

            var polecenie = new Polecenia();

            var strb = new StringBuilder();
            var typ = TypDanych.Polecenie;
            bool bylaOpcja = false;
            bool jestCudzyslow = false;
            while (i < TrescPolecenia.Length)
            {

                var ch = TrescPolecenia[i++];
                if (char.IsWhiteSpace(ch) && !jestCudzyslow)
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
                    if (typ == TypDanych.Brak && !jestCudzyslow)
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
                                //i--;

                                //while (ch == '"')
                                //{
                                //    //i++;
                                //    polecenie.Slowo += ch;
                                //    Console.WriteLine(polecenie.Slowo);

                                //    //continue;
                                //}

                                //TU SKOŃCZYŁEM
                                //if (ch == '"')
                                //{

                                //while (ch.ToString() != ", " || ch == '"')
                                //{
                                //    i++;
                                //    polecenie.Slowo += ch;
                                //    typ = TypDanych.OpcjaWartosc;
                                //}

                                //}
                                typ = TypDanych.OpcjaWartosc;
                                if (ch == '"')
                                {
                                    jestCudzyslow = true;
                                    continue;
                                }
                              
                            }
                            else
                            {
                                typ = TypDanych.Argument;
                                if (ch == '"')
                                {
                                    jestCudzyslow = true;
                                    continue;
                                }
                            }
                        }
                    }
                    else if (jestCudzyslow && ch == '"')
                    {
                        jestCudzyslow = false;
                        continue;
                    }


                    strb.Append(ch);
                }

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

            Console.WriteLine("=================================================================================================");
            Console.WriteLine("Treść polecenia = " + TrescPolecenia);
            Console.WriteLine("=================================================================================================");

            Console.WriteLine(polecenie);

        }
    }
}

