using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yıgın_Stack_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Yıgın yıg=new Yıgın();
            yıg.push(1);
            yıg.push(2);
            yıg.push(3);
            yıg.push(4);
            yıg.Print();            
            Console.WriteLine();
            yıg.pop();
            yıg.Print();

            Console.ReadKey();
        }
    }

    //Düğüm Sınıfı (Node)
    class Dugum
    {
        public int data;
        public Dugum next;
        public Dugum(int data)
        {
            this.data = data;
            next = null;
        }
    }
    /*LIFO(Last in first out)->son giren ilk çıkar
      FILO(First in last out)->İlk giren son çıkar*/

    //Yığın Sınıfı (STACK)
    #region
    class Yıgın
    {
        Dugum top;
        public Yıgın()
        {
            top = null;
        }

        //push() Metodu (En sona ekle "daima")
        #region
        public void push(int data)
        { Dugum node=new Dugum(data);
            if (top == null)
            {
                top = node;
                Console.WriteLine("Yığın oluşturuldu ve ilk düğüm eklendi");
            }
            else
            {
                node.next=top;
                top=node;
                Console.WriteLine("Düğüm yığına eklendi");
            }
        }
        #endregion

        //pop() Metodu (sondan sil "daima")
        #region
        public int pop()
        {
            if(top==null)
            {
                Console.WriteLine("Yığın Boş!");
                return -1;
            }
            else
            {
                int sayi = top.data;
                top = top.next;
                Console.WriteLine(sayi+" Düğümü yığından çıkarıldı");
                return sayi;
            }
        }
        #endregion

        //size() Metodu (Yığının boyutunu gösterir)
        #region
        public void size()
        {
            if (top == null)
            {
                Console.WriteLine("Yığın Boş!");
            }
            else
            {
                int sayac = 0;
                Dugum node =top;

                while (node.next == null)
                {

                    sayac++;
                    node= node.next;
                }
                
                Console.WriteLine("Yığının Boyutu : " + sayac);

            }
        }
        #endregion

        //Yazdır Metodu
        #region
        public void Print()
        {
            Dugum node = top;
            
            while (node != null)
            {
                Console.WriteLine(node.data);
                node= node.next;
            }
            
        }
        #endregion
    }
    #endregion
}
//H.TNG
