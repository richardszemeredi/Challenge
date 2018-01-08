using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KeszthelySprint
{
    class Program
    {
        static void Main(string[] args)
        {
            int db = 0;
            string sor;
            string[] tömb = new string[94];

            string[,] adatok = new string[94, 10];
            StreamReader sr = new StreamReader("Eredmenyek.txt");
            while(!sr.EndOfStream)
            {
                tömb[db]=sr.ReadLine();
                db++;
            }
            sr.Close();
            StreamReader sr1 = new StreamReader("Eredmenyek.txt");
                for (int x = 0; x < 94; x++)
                {
                sor = sr1.ReadLine();
                for (int y = 0; y < 10; y++)
                    {
                        string[]csere= sor.Split(';');
                    adatok[x, y] = csere[y];          
                    }
                }
            sr1.Close();
            int elitjunior = 0;
            for (int i = 0; i < 94; i++)
            {
                if (adatok[i,4]=="elit junior")
                {
                    elitjunior++;
                }
            }
            double évátlag=0;
            double évek = 0;
            double hányéves=0;
            double évszám = 0;
            string segito;
            int[] születés = new int[94];
            for (int i = 0; i < 94; i++)
            {
                segito = adatok[i, 1];
                születés[i] = Convert.ToInt32(segito);
            }

            for (int i = 0; i < 94; i++)
            {
                évszám = születés[i];
                hányéves = 2014 - évszám;
                évek = évek + hányéves;
            }
            évátlag = évek / db;
            Console.WriteLine("2. Feladat: "+db + " db versenyző fejezte be a versenyt.");
            Console.WriteLine("3. Feladat: "+elitjunior+"-an/en versenyeztek az elit junior kategóriában.");
            Console.WriteLine("4. Feladat: Átlag életkor: "+ Math.Round(évátlag, 2) + " év");
            Console.WriteLine("Kérek egy kategóriát:");
            string kategória = Convert.ToString(Console.ReadLine());
            string[] rajtszám = new string[94];
            int a = 0;
            int s = 0;
            if(kategória!="16-17" && kategória != "18-19" && kategória != "20-24" && kategória != "25-29" && kategória != "30-34" && kategória != "35-39" && kategória != "40-44" && kategória != "45-49" && kategória != "50-54" && kategória != "elit" && kategória != "elit junior")
            { Console.WriteLine("Nincs ilyen kategória!"); }
            else
            {
                Console.WriteLine("Rajtszámok: ");
                for (int i = 0; i < 94; i++)
                {
                    if(adatok[i,4]==kategória)
                    {
                        rajtszám[a] = adatok[i, 2];
                        a++;
                    }                    
                }
            }          
            for (int i = 0; i < a; i++)
            {
                if(rajtszám[i]=="" && rajtszám[i] == "0")
                {                    
                }
                else
                {
                    Console.WriteLine(rajtszám[i]);
                }
            }
            int max=0;
            int jelenlegi=0;
            int sorszám=0;
            string halp;
            for (int i = 0; i < 94; i++)
            {                
                if(adatok[i,3]=="n")
                {                   
                    for (int x = 5; x < 9; x++)
                    {
                        string[] idő = adatok[i, x].Split(':');
                        int[] óra = new int[3];
                        for (int l = 0; l < 3; l++)
                        {
                            halp = idő[l];
                            óra[l] = Convert.ToInt32(halp);
                        }

                        jelenlegi = óra[0] * 60 * 60 + óra[1] * 60 + óra[2];
                    }
                }
                if(jelenlegi>max)
                {
                    max = jelenlegi;
                    sorszám = i;
                }
            }
            Console.WriteLine( );
            Console.WriteLine("6. Feladat: A legjobb (női) időt "+ adatok[sorszám, 0]+ " érte el.");
            Console.ReadKey();         
        }
    }
}
