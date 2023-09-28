using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CA20230926
{
    class Program
    {
        static List<int> AtszamolPercre(List<ember> emberek) 
        {
            var percek = new List<int>();
            var oraAtvaltva = new List<int>();
            foreach (var p in emberek)
            {
                oraAtvaltva.Add(p.Ora * 60);
                percek.Add(p.Perc);
            }

            var emberPercei = new List<int>();

            for (int i = 0; i < percek.Count(); i++)
            {
                emberPercei.Add(oraAtvaltva[i] + percek[i]);
            }

            return emberPercei;

        }

        static void Main()
        {
            var emberek = new List<ember>();
            var sr = new StreamReader(@"..\..\..\src\cb.txt");

            _ = sr.ReadLine();

            while (!sr.EndOfStream)
            {
                emberek.Add(new ember(sr.ReadLine()));
            }

            Console.WriteLine($"3. feladat: Bejegyzések száma: {emberek.Count()} db");

            var f4 = emberek.Where(e => e.AdasDB >= 4);
            bool vane = false;

            if (f4.Count() >= 1)
                vane = true;
            else
                vane = false;

            Console.WriteLine($"4. feladat: {(vane ? "Volt négy adást indító sofőr":"Nem volt ilyen sofőr")}");

            Console.WriteLine();
            Console.Write("Add meg a sofőr nevét: ");
            string sofor = Console.ReadLine();
            //5. feladat

            int hivasok = emberek
                .Where(e => e.Nev.ToLower() == sofor.ToLower())
                .Sum(k => k.AdasDB);

            if (hivasok >= 1)
                Console.WriteLine($"{sofor} {hivasok}x használta a CB rádiót");
            else
                Console.WriteLine("Nincs ilyen nevű sofőr.");

            var sw = new StreamWriter(@"..\..\..\src\cb2.txt",false);

            var atvaltva = AtszamolPercre(emberek);

            for (int i = 0; i < emberek.Count(); i++)
            {
                emberek[i].Atvaltott = atvaltva[i];
            }

            sw.WriteLine("Kezdes;Nev;AdasDb");

            foreach (var ember in emberek)
            {
                sw.WriteLine($"{ember.Atvaltott};{ember.Nev};{ember.AdasDB}");
            }

            sw.Close();


            var f8dic = emberek
                .GroupBy(h => h.Nev)
                .ToDictionary(n => n.Key, hsz => hsz.Sum(h => h.AdasDB));

            Console.WriteLine($"8.f soforok szama: {f8dic.Count} fő");

            var f9 = f8dic
                .OrderByDescending(kvp => kvp.Value)
                .First();
            Console.WriteLine("9.f legtobb adast indito ember:");
            Console.WriteLine($"\tNeve: {f9.Key}");
            Console.WriteLine($"\tAdasok szama: {f9.Value}");


            Console.WriteLine();


            Console.ReadKey();
        }
    }
}
