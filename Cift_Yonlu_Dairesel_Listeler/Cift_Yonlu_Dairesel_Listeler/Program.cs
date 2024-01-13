using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cift_Yonlu_Dairesel_Listeler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Liste liste= new Liste();
            liste.HeadAdd(20);
            liste.HeadAdd(10); 
            liste.LastAdd(30);
            liste.LastAdd(40);
            liste.LastAdd(50);
            liste.Print();
            Console.WriteLine();
            liste.RPrint();
            Console.WriteLine();
            liste.BetweenAdd(4, 15);
            liste.Print();
            Console.WriteLine();


            Console.ReadKey();
        }
    }
    //Düğüm Sınıfı
    #region
    class Dugum
    {
        public int data;
        public Dugum next;
        public Dugum prev;
        public Dugum(int data)
        {
            this.data = data;
            this.next = null;
            this.prev=null;
        }
    }
    #endregion

    //Liste Sınıfı
    class Liste
    {
        Dugum head;
        Dugum tail;
        public Liste()
        {
            this.head = null;
            this.tail = null;
        }
        //Yazdır Metodu
        #region
        public void Print()
        {
            if(head== null)
            {
                Console.WriteLine("Liste Boş!");
            }
            else
            {
                Dugum node=head;

                Console.Write("Baş ");
                while (node!=tail)
                {
                    Console.Write(node.data+" -> ");
                    node = node.next;
                }
                Console.Write(node.data + " son. ");

            }
        }
        #endregion

        //Tersten Yazdır Metodu
        #region
        public void RPrint()
        {
            if (head == null)
            {
                Console.WriteLine("Liste Boş!");
            }
            else
            {
                Dugum node = tail;

                Console.Write("Son ");
                while (node != head)
                {
                    Console.Write(node.data + " -> ");
                    node = node.prev;
                }
                Console.Write(node.data + " baş. ");
            }
        }
        #endregion

        //Başa Düğüm Ekleme
        #region
        public void HeadAdd(int data)
        {
            Dugum dugum= new Dugum(data);

            if (head == null)
            {
                head=tail= dugum;
                Console.WriteLine("Liste oluşturuldu ve ilk düğüm eklendi "+dugum.data);
                tail.next= head;
                tail.prev= head;

                head.next = tail;
                head.prev = tail;
            }
            else
            {
                dugum.next= head;
                head.prev = dugum;
                head=dugum;

                head.prev = tail;
                tail.next= head;
                Console.WriteLine("Başa eleman eklendi "+dugum.data);

            }
        }
        #endregion

        //Araya Düğüm Ekleme
        #region
        public void BetweenAdd(int indis, int data)
        {
            bool lean = false;
            Dugum dugum = new Dugum(data);

            if (head == null && indis == 0)
            {
                head=tail= dugum;

                tail.next = head;
                tail.prev= head;
                head.next = tail;
                head.prev= tail;
                Console.WriteLine("Liste oluşturuldu ve ilk düğüm eklendi "+dugum.data);
                lean= true;
            }
            else if (head != null && indis == 0)
            {
                HeadAdd(data);
                lean= true;
            }
            else
            {
                int i = 0;
                Dugum node1= head;
                Dugum node2 = node1;
                while (node1 != tail)
                {
                    if (i == indis)
                    {
                        lean= true;
                        node2.next = dugum;
                        dugum.prev = node2;

                        dugum.next = node1;
                        node1.prev = dugum;
                        Console.WriteLine("Araya düğüm eklendi"+dugum.data);
                        i++;
                        break;
                    }
                    node2 = node1;
                    node1=node1.next;
                    i++;
                }
                if (i == indis)
                {
                    lean = true;
                    node2.next = dugum;
                    dugum.prev = node2;

                    dugum.next = node1;
                    node1.prev = dugum;
                    Console.WriteLine("Araya düğüm eklendi" + dugum.data);
                   
                }
            }
            if (lean == false)
            { Console.WriteLine("Hatalı indis girdiniz!"); }
        }
        #endregion

        //Sona Düğüm Ekleme
        #region
        public void LastAdd(int data)
        {
            Dugum dugum = new Dugum(data);

            if (head == null)
            {
                head = tail = dugum;
                Console.WriteLine("Liste oluşturuldu ve ilk düğüm eklendi " + dugum.data);
                tail.next = head;
                tail.prev = head;

                head.next = tail;
                head.prev = tail;
            }
            else
            {
                tail.next = dugum;
                dugum.prev = tail;
                tail = dugum;

                head.prev = tail;
                tail.next = head;
                Console.WriteLine("Sona eleman eklendi " + dugum.data);

            }
        }
        #endregion

        //Baştan Düğüm Silme
        #region 
        public void HeadDelete()
        {
            if(head==null)
            {
                Console.WriteLine("Liste Boş!");
            }
            else
            {
                head=head.next;
                head.prev = tail;
                tail.next=head;
                Console.WriteLine("İlk düğüm silindi");
            }
        }
        #endregion

        //Aradan Düğüm Silme
        #region
        public void BetweenDelete(int indis)
        {
            if (head == null) { Console.WriteLine("Liste Boş!"); }
            else if(head==null&&indis==0) 
            {
                head=tail= null;
                Console.WriteLine("Listedeki son düğüm silindi");
            }
            else if (head != null && indis == 0)
            {
                HeadDelete();
            }
            else
            {
                Dugum node1 = head;
                Dugum node2 = node1;
                int i = 0;
                while (node1 != tail)
                {
                    if (i == indis)
                    {
                        node2.next=node1.next;
                        node1.next.prev= node2;
                        Console.WriteLine("Aradan düğüm silindi");
                        i++;
                        break;
                    }
                    node2 = node1;
                    node1=node1.next;
                    i++;
                }
                if (i == indis)
                {
                   LastDelete();              
                }
            }

        }
        #endregion

        //Sondan Düğüm Silme
        #region
        public void LastDelete()
        {
            if (head == null)
            {
                Console.WriteLine("Liste Boş!");
            }
            else
            {
                tail = tail.prev;
                tail.next = head;
                head.prev=tail;
                Console.WriteLine("Son düğüm silindi");
            }
        }
        #endregion
    }
}
//H.TNG
