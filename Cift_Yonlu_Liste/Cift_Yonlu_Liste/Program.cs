using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cift_Yonlu_Liste
{
    class Program
    {
        static void Main(string[] args)
        {
            Liste list= new Liste();
            list.HeadAdd(10);
            list.LastAdd(20);
            list.LastAdd(30);
            list.Print();
            Console.WriteLine();
            list.RPrint();
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
            this.prev = null;
        }
    }
    #endregion

    //Liste Sınıfı
    #region
    class Liste
    {
        Dugum head;
        Dugum tail;
        public Liste()
        {
            head = null;
            tail = null;
        }

        //Yazdır Metodu
        #region
        public void Print()
        {
            if(head==null)
            {
                Console.WriteLine("Liste Boş!");
            }
            else
            {
                Dugum node= head;
                Console.Write("Baş ");
                while(node.next!=null)
                {
                    Console.Write(node.data + " ->");
                    node= node.next;
                }
                Console.Write(node.data +" son");
            }

        }
        #endregion

        //Ters Yazdır Metodu
        #region
        public void RPrint()
        {
            if (head == null)
            {
                Console.WriteLine("Liste Boş!");
            }
            else
            {
                Dugum node= tail;
                Console.Write("Son ");
                while (node.prev!=null)
                {
                    Console.Write(node.data + " ->");
                    node = node.prev;
                }
                Console.Write(node.data + " baş");

            }
        }
        #endregion

        //Başa Düğüm Ekleme
        #region
        public void HeadAdd(int data)
        {
            Dugum dugum= new Dugum(data);

            if(head == null)
            {
                head=tail= dugum;
                Console.WriteLine("Liste oluşturuldu ve ilk düğüm eklendi  "+dugum.data);
            }
            else
            {
                dugum.next = head;
                head.prev= dugum;
                head = dugum;
                Console.WriteLine("Listenin başına düğüm eklendi  "+dugum.data);
            }
        }
        #endregion

        //Araya Düğüm Ekleme
        #region
        public void BetweenAdd(int indis,int data)
        {
            bool lean= false;
            Dugum dugum= new Dugum(data);

            if(head == null && indis == 0)
            {
                lean= true;
                head= tail= dugum;
                Console.WriteLine("Liste oluşturuldu ve ilk düğüm eklendi");
            }
            else if(head!=null && indis == 0)
            {
                lean = true;
                HeadAdd(data);
            }
            else
            {
                int i = 0;
                Dugum node1= head;
                Dugum node2 = node1;

                while (node1.next != null)
                {
                    if (i == indis)
                    {
                        lean = true;
                        node2.next=dugum;
                        dugum.prev = node2;

                        dugum.next=node1;
                        node1.prev=dugum;
                        Console.WriteLine("Araya düğüm eklendi");
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
                    dugum.prev = node2;

                    dugum.next = tail;
                    tail.prev = dugum;
                    Console.WriteLine("Araya düğüm eklendi");

                }
            }
            if (lean == false)
            {
                Console.WriteLine("Hatalı indis girişi yaptınız");
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
                Console.WriteLine("Liste oluşturuldu ve ilk düğüm eklendi  " + dugum.data);
            }
            else
            {
                tail.next= dugum;
                dugum.prev= tail;
                tail = dugum;
                Console.WriteLine("Listenin sonuna düğüm eklendi  "+dugum.data);

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
            else if(head.next==null)
            {
                Console.WriteLine("Listedeki son düğümü sildiniz");
            }
            else
            {
                head=head.next;
                head.prev = null;
                Console.WriteLine("İlk düğüm silindi");
            }
        }
        #endregion

        //Aradan Düğüm Silme
        #region
        public void BetweenDelete(int indis)
        {
            if (head == null)
            {
                Console.WriteLine("Liste Boş");
            }
            else if (head.next == null && indis == 0)
            {
                head = tail = null;
                Console.WriteLine("Listedeki son düğüm silindi");
            }
            else if (head.next != null && indis == 0)
            {
                HeadDelete();
            }
            else
            {
                int i = 0;
                Dugum node1 = head;
                Dugum node2 = node1;

                while (node1.next != null)
                {
                    if (i == indis)
                    {
                        node2.next = node1.next;
                        node1.next.prev = node2;
                        Console.WriteLine("Aradan düğüm silindi");
                        i++;
                        break;
                    }
                    node2 = node1;
                    node1 = node1.next;
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
            if(head==null)
            {
                Console.WriteLine("Liste Boş");
            }
            else if (head.next == null)
            {
                head=tail= null;
                Console.WriteLine("Listedeki son düğümü sildiniz");
            }
            else
            {               
                    tail = tail.prev;
                    tail.next=null;
                Console.WriteLine("Son düğüm silindi");
            }
        }
        #endregion
    }
    #endregion
}
// H.TNG
