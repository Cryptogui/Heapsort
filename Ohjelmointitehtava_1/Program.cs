using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ohjelmointitehtava_1
{
    class Program
    {

        /// <summary>
        /// Pääohjelma
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] taulukko = new int[10];
            taulukko = taytaTaulukko(taulukko);
            //int[] taulukko = { 0,70,33,26,88,88,14,26,61,95};
            System.Diagnostics.Debug.WriteLine("alkuperäinen: " + string.Join(",", taulukko));
            int[] lajiteltu = kekolajittelu(taulukko);
            System.Diagnostics.Debug.WriteLine("lopputulos:   " + string.Join(",", lajiteltu));
        }

        /// <summary>
        /// Täyttää taulukon satunnaisilla Int arvoilla
        /// </summary>
        /// <param name="taulu"></param>
        /// <returns></returns>
        static int[] taytaTaulukko(int[] taulu)
        {
            Random numero = new Random();
            taulu[0] = 0;
            for (int i = 1; i < taulu.Length; i++)
            {
                taulu[i] = numero.Next(100);
            }
            return taulu;
        }

        /// <summary>
        /// Aliohjelma joka suorittaa kekorakenteen luomisen ja kekolajittelun
        /// </summary>
        /// <param name="taulukko"></param>
        /// <returns></returns>
        static int[] kekolajittelu(int[] taulukko)
        {
            int koko = taulukko.Length - 1;
            taulukko = rakennaKeko(taulukko, koko);
            while (koko > 1) {
                taulukko = swappaa(taulukko, koko);
                koko--;
                if (koko > 1) taulukko = rakennaKeko(taulukko, koko);
            }
            return taulukko;
        }
        
        /// <summary>
        /// muuntaa taulukon ns. MaxHeap muotoon
        /// </summary>
        /// <param name="taulukko"></param>
        /// <param name="koko"></param> taulukon koko eli viimeisen alkion indeksi
        /// <returns></returns>
        static int[] rakennaKeko(int[] taulukko, int koko)
        {
            while (true) {
                for (int i = ((koko) / 2); i > 0; i--)
                {
                    taulukko = korjaaPuu(taulukko, i, koko);
                }
                bool ehja = tarkistaPuu(taulukko, koko);
                if (ehja == true) break;
            }
            return taulukko;
        }

        /// <summary>
        /// Korjaa MaxHeap rakenteen solmussa i
        /// </summary>
        /// <param name="taulukko"></param>
        /// <param name="i"></param> korjattavan solmun indeksi taulukossa
        /// <returns></returns>
        static int[] korjaaPuu(int[] taulukko, int i, int koko)
        {
            int vasemman_indeksi = 2 * i;
            int oikean_indeksi = 2 * i + 1;

            if (taulukko[i] < taulukko[vasemman_indeksi] || taulukko[i] < taulukko[oikean_indeksi])
            {
                int muisti = taulukko[i];
                if (oikean_indeksi <= koko)
                {
                    if (taulukko[vasemman_indeksi] > taulukko[oikean_indeksi])
                    {
                        taulukko[i] = taulukko[vasemman_indeksi];
                        taulukko[vasemman_indeksi] = muisti;
                    }
                    else if (taulukko[oikean_indeksi] > taulukko[vasemman_indeksi])
                    {
                        taulukko[i] = taulukko[oikean_indeksi];
                        taulukko[oikean_indeksi] = muisti;
                    }

                    else if (taulukko[oikean_indeksi] == taulukko[vasemman_indeksi])
                    {
                        taulukko[i] = taulukko[oikean_indeksi];
                        taulukko[oikean_indeksi] = muisti;
                    }
                }
                else if (oikean_indeksi > koko)
                {
                    taulukko[i] = taulukko[vasemman_indeksi];
                    taulukko[vasemman_indeksi] = muisti;
                }
            }
            return taulukko;
        }

        /// <summary>
        /// Tarkistaa että puun MaxHeap rakenne on ehjä (jos on, palauttaa True)
        /// </summary>
        /// <param name="taulukko"></param>
        /// <param name="koko"></param>
        /// <returns></returns>
        static bool tarkistaPuu(int[] taulukko, int koko)
        {
            bool ehja = true; 
            for (int i = 1; i <= koko / 2; i++)
            {
                if (taulukko[i] < taulukko[2 * i + 1] && 2 * i + 1 <= koko)
                {
                    ehja = false;
                    break;
                }
                if (taulukko[i] < taulukko[2 * i] && 2 * i <= koko)
                {
                    ehja = false;
                    break;
                }
            }
            return ehja;
        }

        /// <summary>
        /// Vaihtaa keon ensimmäisen ja viimeisen solmun keskenään
        /// </summary>
        /// <param name="taulukko"></param>
        /// <param name="koko"></param> Viimeisen solmun indeksi
        /// <returns></returns>
        static int[] swappaa(int[] taulukko, int koko)
        {
            if (koko > 1)
            {
                int muisti;
                muisti = taulukko[koko];
                taulukko[koko] = taulukko[1];
                taulukko[1] = muisti;
                
            }
            return taulukko;
        }
    }
}
