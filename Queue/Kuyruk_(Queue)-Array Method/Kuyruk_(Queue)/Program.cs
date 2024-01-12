using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuyruk__Queue_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int s, a;
            Console.Write("Kuyruk boyutunu giriniz : ");
            s = int.Parse(Console.ReadLine());
            string isim;
            int secim = menu();
            Kuyruk<string> kuyruk = new Kuyruk<string>(s);

            while (secim != 0)
            {
                switch (secim)
                {
                    case 1:
                        string ad;
                        Console.WriteLine("İsim giriniz : ");
                        ad = Console.ReadLine();
                        kuyruk.enQueue(ad);
                        break;
                    case 2:
                        isim = kuyruk.deQueue();
                        Console.WriteLine(isim + " verisi kuyruktan silindi");
                        break;

                    case 3:
                        Console.WriteLine("Aradığınız veriniyi giriniz ");
                        isim=Console.ReadLine();
                        Console.WriteLine(kuyruk.contains(isim));
                        
                        break;
                    case 4:
                        a = kuyruk.Size();
                        Console.WriteLine("Yığıtın içerisindeki veri sayısı : " + a);
                        break;
                    case 5:
                        Console.WriteLine("İndex numarasını giriniz");
                        a=int.Parse(Console.ReadLine());
                        Console.WriteLine(kuyruk.access(a));
                        break;
                    case 0:
                        break;
                    default: Console.WriteLine("Hatalı işlem numarası girdiniz!"); break;
                }
                secim = menu();
            }
        }
        //menu() Metodu (Kullanıcı işlemleri yaptırmak)
        #region
        public static int menu()
        {
            int secim;
            Console.WriteLine("1-enQueue()");
            Console.WriteLine("2-deQueue()");
            Console.WriteLine("3-contains()");
            Console.WriteLine("4-Size()");
            Console.WriteLine("5-access()");
            Console.WriteLine("0-Çıkış ");
            Console.Write("Seçiminiz : ");
            secim = int.Parse(Console.ReadLine());
            Console.Clear();
            return secim;
        }
        #endregion
    }
}
//H.TNG

