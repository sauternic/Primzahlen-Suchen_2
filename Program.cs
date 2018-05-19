using System;
using System.Diagnostics;

//Program_UInt64_Vorselektion.cs
namespace Primzahlen
{
    class CPrimzahlen
    {

        //16 Stellen:   1000000000000000
        //17 Stellen:   10000000000000000
        //20 Stellen:   10000000000000000000
        //21 Stellen :  100000000000000000000
        //Max ulong =   18446744073709551615;
        //Max decimal = 79228162514264337593543950335M;

        //Field
        static int P_Nr = 0;

        static void Main()
        {
            ulong anfang = 0;
            ulong ende = 0;

            Console.Write("\n   Program_UInt64_Vorselektion\n\n");
            Console.Write("\n\n   Primzahlenauflisten!\n\n");
            Console.Write("\n   Untere Grenze Eingeben? ");
            anfang = Convert.ToUInt64(Console.ReadLine());

            Console.Write("   Obere  Grenze Eingeben? ");
            ende = Convert.ToUInt64(Console.ReadLine());
            Console.WriteLine();//Leerzeile

            SuchePrimzahlen(anfang, ende);
        }

        //Noch ohne Parallel.For!
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        static void SuchePrimzahlen(ulong anfang, ulong ende)
        {
            Stopwatch s = new Stopwatch();

            label1:
            s.Start();
            //Aeussere Schleife Ersetzt Hand Eingabe.
            for (; anfang <= ende; anfang++)
            {
                //Geht bis 20 Stellen!! :O
                ulong Wurzel_anfang = (ulong)Math.Pow(anfang, 0.5);

                //Primzahlen Engine! :)
                for (ulong teiler = 2; teiler <= Wurzel_anfang; teiler++)
                {

                    //2 Einzig Gerade Primzahl darum (... || teiler == 2) gibt true bei 2!!!!
                    //Das ist am Schnellsten nur gerade Zahlen weglassen
                    if (teiler % 2 != 0 || teiler == 2)
                    {
                        //Wenn mod == 0 ist keine Primzahl
                        if (anfang % teiler == 0)
                        {
                            //Schleife erhöht über label1 anfang nicht:
                            ++anfang;
                            goto label1;
                        }
                    }
                }

                //1 und 0 rausputzen! ;)
                if (anfang == 1 || anfang == 0)
                    continue;

                s.Stop();
                TimeSpan timeSpan = s.Elapsed;

                ++P_Nr;
                //Ausgabe
                string ausgString = String.Format("\nPrimzahl {0} :)  {1:#,#}\n", P_Nr, anfang);
                ausgString += String.Format("TimeN: {0}h {1}m {2}s {3}ms\n", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);

                Console.WriteLine(ausgString);
                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
            }
            Console.WriteLine("Fertig! :)");
            Console.WriteLine("\n\tCopyright © Nicolas Sauter");
            Console.ReadLine();
        }
    }
}