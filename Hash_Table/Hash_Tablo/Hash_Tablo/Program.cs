using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Tablo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int s;
            Console.Write("Tablo boyutunu giriniz : ");
            s=int.Parse(Console.ReadLine());
            int numara;
            string isim;
            int secim=menu();
            Tablo tb=new Tablo(s);

            while (secim != 0)
            {
                switch (secim)
                {
                    case 1:
                        int num;
                        string ad;
                        Console.WriteLine("Numara giriniz : ");
                        num=int.Parse(Console.ReadLine());
                        Console.WriteLine("İsim giriniz : ");
                        ad=Console.ReadLine();
                        tb.Add(num,ad); 
                        break;
                    case 2:
                        int k;
                        Console.WriteLine("Silmek istediğiniz verinin numarasını giriniz : ");
                        k=int.Parse(Console.ReadLine());
                        tb.delete(k);
                        break;

                    case 3:
                        tb.print();
                        break;
                    case 4:
                        tb.dataCount();
                        break;
                    case 5:
                        Console.WriteLine("Aradığınız kişi numarasını giriniz : ");
                        int a=int.Parse(Console.ReadLine());
                        tb.dataFind(a);
                        break;

                    case 0:
                        break;
                    default: Console.WriteLine("Hatalı işlem numarası girdiniz!"); break;
                }
                secim=menu();
            }

           
        }
        //menu() Metodu (Kullanıcı işlemleri yaptırmak)
        #region
        public static int menu()
        {
            int secim;
            Console.WriteLine("1-Ekle ");
            Console.WriteLine("2-Sil ");
            Console.WriteLine("3-Yazdır ");
            Console.WriteLine("4-Veri Sayısını Bul ");
            Console.WriteLine("5-Kişi Bul ");
            Console.WriteLine("0-Çıkış ");
            Console.Write("Seçiminiz : ");
            secim=int.Parse(Console.ReadLine());
            Console.Clear();
            return secim;
        }
        #endregion
    }
    //Düğüm (Node) Sınıfı
    #region
    class Node
    {
        public int key;
        public string isim;
        public Node next;
        public Node()
        {
            this.next= null;
        }
        public Node(int key, string isim)
        {
            this.key = key;
            this.isim = isim;
            this.next = null;
        }
    }
    #endregion

    //Tablo (Hash Table) Sınıfı
    #region
    class Tablo
    {
       public int size;
       public Node [] dizi; 

        public Tablo(int size)
        {
            this.size = size;
            dizi=new Node[size];

            for(int i = 0; i < size; i++)
            {
                dizi[i] = new Node();
            }
        }

        //indexer() Metodu (key değerinin dizi boyutuna göre modunu alma)
        #region
        public int indexer(int key)
        {
            return key % size;
        }
        #endregion  

        //Add() Metodu (LinkedList Sona ekleme)
        #region
        public void Add(int key,string isim)
        {
            Node dugum = new Node(key,isim);
            int indis=indexer(key);
            Node node = dizi[indis];

            if (node == null)
            {
                node.next = dugum;

            }
            else
            {
                while (node.next != null)
                {
                    node = node.next;
                }
                node.next = dugum;
                Console.WriteLine(isim + " eklendi");

            }
        }
        #endregion

        // delete() Metodu (Silme)
        #region
        public void delete(int key)
        {
            bool lean = false;
            int indis = indexer(key);
            Node node1 = dizi[indis];
            Node node2;

            if (node1.next == null)
            {
                Console.WriteLine(key+" numarali veri kaydı bulunmamakta");
                lean= true;
            }
            else if(node1.next.next == null&& node1.next.key==key) 
            {
                node1.next = null;
                Console.WriteLine(key+" numaralı veri silindi.");
                lean= true;
            }
            else
            {
                while (node1.next != null)
                {
                    node2 = node1;
                    node1 = node1.next;
                    if (node1.key==key)
                    {
                        node2.next = node1.next;
                        Console.WriteLine(key+" numaralı veri silindi");
                        lean= true;                    
                    }
                }
            }
            if (!lean)
            {
                Console.WriteLine(key+" numaralı veri kaydı tabloda yok");
            }
        }
        #endregion

        //dataCount() Metodu (Hash Table üzerindeki veri kaydı sayısını bulmak )
        #region
        public void dataCount()
        {
            int sayac = 0;
            for(int i=0;i<size;i++)
            {
                Node node= dizi[i];
               
                while (node.next != null)
                {
                    node=node.next;
                    sayac++;
                }
                Console.WriteLine();
            }
            if (sayac == 0) Console.WriteLine("Tabloda veri kaydı yok!");
            else Console.WriteLine("Tabloda kayıtlı veri sayısı : " + sayac);

        }
        #endregion

        //dataFind() Metodu (Hash Table üzerinde aranan kişiyi bulmak)
        #region
        public void dataFind(int key)
        {
            bool lean= false;
            for(int i=0;i<size;i++)
            { 
                Node node= dizi[i];

                while (node.next != null)
                {
                    node= node.next;
                    if(key==node.key)
                    {
                        lean= true;
                        Console.WriteLine(node.key+" numaralı kişi bilgileri : "+node.isim);
                    }
                }
                Console.WriteLine();
            }
            if(!lean)
            {
                Console.WriteLine(key+" numaralı kişi bulunamadı ");
            }
        }
        #endregion

        //print() Metodu (Hash tablosunu görüntüle)
        #region
        public void print()
        {
            for(int i=0;i<size;i++)
            {
                Node dugum = dizi[i];
                Console.Write("Dizi[{0}] =>  ",i);

                while(dugum.next!=null)
                {
                    dugum = dugum.next;
                    Console.Write(dugum.key + "-" + dugum.isim+" => ");
                }
                Console.WriteLine();
            }
        }
        #endregion

    }
    #endregion
}
//H.TNG


/* 
 //headAdd() Metodu (LinkedList Başa ekleme)
public void headAdd(int key,string isim)
{
 int indis = indexuret (key) ;
 Node eleman= new Node(key, isim);
 Node temp= dizi[indis] ;
 if (temp.next == null)
 {
  temp.next eleman;
  Console.WriteLine ("sütünün ilk elemani eklendi ");
 }
 else
 {
  eleman.next dizi[indis].next; 
  dizi[indis ].next = eleman;
  Console.WriteLine (key+"eklendi ");
 }
}
 */
