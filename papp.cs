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
            string[] sorok = File.ReadAllLines("Eredmenyek.txt", Encoding.Default);
            string[,] eredmenyek = new string[sorok.Length, 10];
            for (int i = 0; i < sorok.Length; i++)
            {
                string[] egysor = sorok[i].Split(';');
                for (int j = 0; j < 10; j++)
                {
                    eredmenyek[i, j] = egysor[j];
                }
            }
            Console.WriteLine("2. feladat: A versenyt {0} versernyző fejezte be.", sorok.Length);
            int el = 0;
            double ossz = 0;
            for (int i = 0; i < sorok.Length; i++)
            {
                if (eredmenyek[i, 4] == "elit junior")
                    el++;
                ossz +=(2014- Convert.ToInt32(eredmenyek[i, 1]));
            }
            
            Console.WriteLine("3. feladat? Versenyzők száma az elit junior kategóriában: {0} fő", el);
            Console.WriteLine("4. feladat: Átlagéletkor: {0}",Math.Round( ossz / sorok.Length,2));
            Console.Write("\n5. feladat: Kérek egy kategóriát: ");
            string kateg = Console.ReadLine();
            List<string> sorsz = new List<string>();
            for (int i = 1; i < sorok.Length; i++)
            {
                if (eredmenyek[i, 4] == kateg)
                    sorsz.Add(eredmenyek[i, 2]);
            }
            Console.Write("\n\tRajtszám(ok): ");
            if (sorsz.Count == 0)
                Console.Write("Nincs ilyen kategória!");
            else
            {
                foreach (string item in sorsz)
                    Console.Write(item + " ");
            }
            TimeSpan minido = TimeSpan.MaxValue;
            string min = "";
            for (int i = 0; i < sorok.Length; i++)
            {
                if (eredmenyek[i, 3] == "n" && TimeSpan.Parse(eredmenyek[i, 5]) + TimeSpan.Parse(eredmenyek[i, 6]) + TimeSpan.Parse(eredmenyek[i, 7]) + TimeSpan.Parse(eredmenyek[i, 8]) + TimeSpan.Parse(eredmenyek[i, 9]) < minido)
                {
                    minido = TimeSpan.Parse(eredmenyek[i, 5]) + TimeSpan.Parse(eredmenyek[i, 6]) + TimeSpan.Parse(eredmenyek[i, 7]) + TimeSpan.Parse(eredmenyek[i, 8]) + TimeSpan.Parse(eredmenyek[i, 9]);
                    min = eredmenyek[i, 0];
                }
            }
            Console.WriteLine("\n6. feladat: A legjobb időt {0} érte el", min);
            Console.ReadKey();
        }
    }
}
