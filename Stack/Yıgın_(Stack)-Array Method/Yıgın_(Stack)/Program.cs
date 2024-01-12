using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yıgın__Stack_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int s,a;
            Console.Write("Yığıt boyutunu giriniz : ");
            s = int.Parse(Console.ReadLine());            
            string isim;
            int secim = menu();
            Yıgın<string> yıgın = new Yıgın<string>(s);

            while (secim != 0)
            {
                switch (secim)
                {
                    case 1:                       
                        string ad;                        
                        Console.WriteLine("İsim giriniz : ");
                        ad = Console.ReadLine();
                        yıgın.push(ad);
                        break;
                    case 2:                       
                        isim= yıgın.pop();
                        Console.WriteLine(isim+" verisi yığıttan silindi");
                        break;

                    case 3:
                        isim=yıgın.peak();
                        Console.WriteLine("Yığıtın en üstteki verisi "+isim);
                        break;
                    case 4:
                       a= yıgın.Size();
                        Console.WriteLine("Yığıtın içerisindeki veri sayısı : "+a);
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
            Console.WriteLine("1-Push()");
            Console.WriteLine("2-Pop() ");
            Console.WriteLine("3-Peak() ");
            Console.WriteLine("4-Size() ");            
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
