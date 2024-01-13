using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tek_Yonlu_Liste
{
    internal class Program
    {
        static void Main(string[] args)
        {
          Liste liste= new Liste();
            liste.LastAdd(10);
            liste.LastAdd(20);
            liste.LastAdd(30);
            liste.HeadAdd(3);
            liste.HeadAdd(2);
            liste.HeadAdd(1);
            Console.WriteLine();
            liste.Print();
            Console.WriteLine();
            liste.BetweenAdd(3, 4);
            liste.Print();
            Console.WriteLine();
            liste.BetweenDelete(6);
            liste.Print();
            Console.WriteLine();



            Console.ReadKey();
        }
    }

    //Düğüm Sınıfı
    #region
    class Dugum
    {
        public int Data;
        public Dugum next;
        public Dugum(int Data)
        {
            this.Data = Data;
            next = null;
        }
    }
    #endregion

    //Liste Sınıfı
    #region
    class Liste
    {
        public Dugum Head;

        public Liste()
        {
            Head = null;
        }

        //Yazdır Metodu
        #region
        public void Print()
        {
            Dugum node = Head;
            if (Head == null)
            {
                Console.WriteLine("Liste Boş!!!");
            }
            else
            {
                Console.Write("Baş ");
                while (node.next != null)
                {
                    Console.Write(node.Data + " -> ");
                    node = node.next;
                }
                Console.Write(node.Data + " son.");
                Console.WriteLine();
            }
        }
        #endregion

        //Başa Düğüm Ekleme
        #region
        public void HeadAdd(int data)
        {
            Dugum dugum = new Dugum(data);
            if (Head == null)
            {
                Head = dugum;
                Console.WriteLine("Liste oluşturuldu ve ilk düğüm eklendi: " + dugum.Data);
            }
            else
            {
                dugum.next = Head;
                Head = dugum;
                Console.WriteLine("Listenin başına düğüm eklendi: " + dugum.Data);
            }
        }
        #endregion

        //Araya Düğüm Ekleme
        #region
        public void BetweenAdd(int indis, int data)
        {
            Dugum dugum = new Dugum(data);
            bool lean = false;

            if (Head == null && indis == 0)
            {
                Head = dugum;
                Console.WriteLine("Düğüm eklendi");
                lean = true;
            }
            else if (indis == 0)
            {
                HeadAdd(data);
                lean = true;
            }
            else
            {
                int i = 0;
                Dugum node1 = Head;
                Dugum node2 = node1;
                while (node1.next != null)
                {
                    if (i == indis)
                    {
                        lean = true;
                        node2.next = dugum;
                        dugum.next = node1;
                        Console.WriteLine("Araya Düğüm Eklendi");
                        i++;
                        break;
                    }
                    node2 = node1;
                    node1 = node1.next;
                    i++;
                }
                if (i == indis)
                {
                    lean = true;
                    node2.next = dugum;
                    dugum.next = node1;
                    Console.WriteLine("Araya Düğüm Eklendi");                    
                }

            }
        }
        #endregion

        //Sona Düğüm Ekleme
        #region
        public void LastAdd(int data)
        {
            Dugum dugum = new Dugum(data);

            if (Head == null)
            {
                Head = dugum;
                Console.WriteLine("Liste oluşturuldu ve ilk düğüm eklendi: " + dugum.Data);
            }
            else
            {
                Dugum node = Head;

                while (node.next != null)
                {
                    node = node.next;
                }
                node.next = dugum;
                Console.WriteLine("Sona düğüm eklendi: " + dugum.Data);
            }
        }
        #endregion

        //Baştan Düğüm Silme
        #region
        public void HeadDelete()
        {
            if (Head == null)
            {
                Console.WriteLine("Liste Boş");
            }
            else
            {
                Head = Head.next;
                Console.WriteLine("İlk düğüm silindi");
            }
        }
        #endregion

        //Aradan Düğüm Silme
        #region
        public void BetweenDelete(int indis)
        {
            bool lean = false;
            if (Head == null)
            {
                lean = true;
                Console.WriteLine("Liste Boş");
            }
            else if (Head.next == null && indis == 0)
            {
                lean = true;
                Head = null;
                Console.WriteLine("Listede kalan son düğümü sildiniz");
            }
            else if (Head.next != null && indis == 0)
            {
                lean = true;
                HeadDelete();
                Console.WriteLine("Düğüm silindi");
            }
            else
            {
                int i = 0;
                Dugum node1 = Head;
                Dugum node2 = node1;
                while (node1.next != null)
                {
                    if (i == indis)
                    {
                        lean = true;
                        node2.next = node1.next;
                        Console.WriteLine("Aradan eleman silindi");
                        i++;
                        break;
                    }
                    node2 = node1;
                    node1 = node1.next;
                    i++;
                }
                if (i == indis)
                {
                    lean = true;
                    node2.next = node1.next;
                    Console.WriteLine("Aradan eleman silindi");
                }
            }
            if (lean == false)
            {
                Console.WriteLine("Hatalı indis girişi yaptınız");
            }
        }
        #endregion

        //Sondan Düğüm Silme
        #region
        public void LastDelete()
        {
            if (Head == null)
            {
                Console.WriteLine("Liste Boş!!");
            }
            else if (Head.next == null)
            {
                Head = null;
                Console.WriteLine("Listedeki son eleman silindi");
            }
            else
            {
                Dugum node1 = Head;
                Dugum node2 = node1;
                while (node1.next != null)
                {
                    node2 = node1;
                    node1 = node1.next;

                }
                node2.next = null;
                Console.WriteLine("Son düğüm silindi");
            }
        }
        #endregion


    }
    #endregion
}
//H.TNG
