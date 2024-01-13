using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tek_Yonlu_Dairesel_Liste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Liste list= new Liste();
            list.HeadAdd(10);
            list.LastAdd(20);
            list.LastAdd(30);
            list.LastAdd(40);
            list.Print();
            Console.WriteLine();
            list.BetweenAdd(3, 50);
            list.Print();
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
        public Dugum(int data)
        {
            this.data = data;
            this.next = null; 
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
            head=null; 
            tail=null;
        }

        //Yazdır Metodu
        #region
        public void Print()
        {
            if(head==null)
            {
                Console.WriteLine("Lİste Boş");
            }
            else
            {
                Dugum node= head;
                Console.Write("Baş ");

                while(node!=tail)
                {
                    Console.Write(node.data+" -> ");
                    node=node.next;
                }
                Console.Write(node.data + " son");
            }
        }
        #endregion

        //Başa Düğüm Ekleme
        #region
        public void HeadAdd(int data)
        {
            Dugum dugum = new Dugum(data);

            if (head == null)
            {
                head=tail=dugum;
                tail.next= head;
                Console.WriteLine("Liste oluşturuldu ve ilk düğüm eklendi "+dugum.data);
            }
            else
            {
                dugum.next= head;
                head = dugum;
                tail.next = head;
                Console.WriteLine("Başa düğüm eklendi "+dugum.data);

            }
        }
        #endregion

        //Araya Düğüm Ekleme
        #region
        public void BetweenAdd(int indis,int data)
        {
            Dugum dugum = new Dugum(data);
            if (head == null && indis == 0)
            {
                head = tail = dugum;
                tail.next= head;
                Console.WriteLine("Lİste oluşturuldu ve ilk düğüm eklendi");
            }
            else if (head != null && indis == 0)
            {
                HeadAdd(data);
            }
            else
            {
                int i = 0;
                Dugum node1 = head;
                Dugum node2 = node1;
                while (node1 != tail)
                {
                    if (i==indis)
                    {
                        node2.next = dugum;
                        dugum.next = node1;
                        Console.WriteLine("Araya düğüm eklendi");
                        i++;
                        break;
                    }
                    node2= node1;
                    node1=node1.next;
                    i++;
                }
                if (i == indis)
                {
                    node2.next = dugum;
                    dugum.next = node1;
                    Console.WriteLine("Araya düğüm eklendi");
                    
                }
            }
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
                tail.next = head;
                Console.WriteLine("Liste oluşturuldu ve ilk düğüm eklendi " + dugum.data);
            }
            else
            {
                tail.next=dugum;
                tail=dugum;
                tail.next = head;
                Console.WriteLine("Sona düğüm eklendi " + dugum.data);

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
            else if(head.next==head)
            {
                head = tail = null;
                
                Console.WriteLine("Listedeki son düğüm silindi");
            }
            else
            {
                head=head.next;
                tail.next=head;
                Console.WriteLine("İlk düğüm silindi");
            }
        }
        #endregion

        //Aradan Düğüm Silme
        #region
        //public void BetweenDelete(int indis)
        //{
        //    bool lean = false;
        //    if (head == null)
        //    {
        //        lean = true;
        //        Console.WriteLine("Liste Boş");
        //    }
        //    else if (head.next == null && indis == 0)
        //    {
        //        lean = true;
        //        head = null;
        //        Console.WriteLine("Listede kalan son düğümü sildiniz");
        //    }
        //    else if (head != null && indis == 0)
        //    {
        //        lean = true;
        //        HeadDelete();
        //        Console.WriteLine("Düğüm silindi");
        //    }
        //    else
        //    {
        //        int i = 0;
        //        Dugum node1 = head;
        //        Dugum node2 = node1;
        //        while (node1.next != null)
        //        {
        //            if (i == indis)
        //            {
        //                lean = true;
        //                node2.next = node1.next;
        //                Console.WriteLine("Aradan eleman silindi");
        //                i++;
        //                break;
        //            }
        //            node2 = node1;
        //            tail.next = head;
        //            node1 = node1.next;
        //            i++;
        //        }
        //            if (i == indis)
        //            {
        //                lean = true;
        //                node2.next = node1.next;
        //                Console.WriteLine("Aradan eleman silindi");
        //                i++;
        //                break;
        //            }
        //    }
        //    if (lean == false)
        //    {
        //        Console.WriteLine("Hatalı indis girişi yaptınız");
        //    }
        //}
        #endregion

        //Sondan Düğüm Silme
        #region
        public void LastDelete()
        {         
            if (head == null)
            {
                Console.WriteLine("Liste Boş!");
            }
            else if (head == tail)
            {
                head = tail = null;
                Console.WriteLine("Listedeki son düğüm silindi");
            }
            else
            {
                Dugum node = head;
                while(node.next != tail)
                {
                    node = node.next;
                }
                node.next = null;
                tail= node;
                node.next = head;
                Console.WriteLine("Son düğüm silindi");
            }
        }
        #endregion
    }
}
//H.TNG