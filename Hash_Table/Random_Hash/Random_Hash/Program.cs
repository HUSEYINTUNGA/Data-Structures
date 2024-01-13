using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Random_Hash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tablo tbl = new Tablo(100);
            Random rnd = new Random();
            for (int i = 0; i < 101; i++)
            {
                //tbl.headAdd(rnd.Next(0, 10000));
                //tbl.ChainingAdd(rnd.Next(0, 10000));
                //tbl.LinearProbingAdd(rnd.Next(0, 10000));
                //tbl.QuadraticProbingAdd(rnd.Next(0, 10000));
            }
            tbl.print();
            Console.ReadKey();           
        }
    }
    //Düğüm (Node) Sınıfı
    #region
    class Node
    {
        public int key;        
        public Node next;
        public Node()
        {
            this.next = null;
        }
        public Node(int key)
        {
            this.key = key;            
            this.next = null;
        }
    }
    #endregion

    //Tablo (Hash Table) Sınıfı
    #region
    class Tablo
    {
        public int size;
        public Node[] dizi;

        public Tablo(int size)
        {
            this.size = size;
            dizi = new Node[size];

            for (int i = 0; i < size; i++)
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
       
        //headAdd() Metodu (LinkedList Başa ekleme)
        #region
        public void headAdd(int key)
        {
            int indis = indexer(key);
            Node eleman = new Node(key);
            Node temp = dizi[indis];
            if (temp.next == null)
            {
                temp.next= eleman;
                Console.WriteLine("sütünün ilk elemani eklendi ");
            }
            else
            {
                eleman.next =dizi[indis].next;
                dizi[indis].next = eleman;
                Console.WriteLine(key + "eklendi ");
            }
        }
        #endregion

        //ChainingAdd() Metodu 
        #region
        public void ChainingAdd(int key)
        {
            Node dugum = new Node(key);
            int indis = indexer(key);
            Node node = dizi[indis];

            if (node == null)
            {
                node.next = dugum;
                // buraya yöntemler gelecek;

            }
            else
            {
                while (node.next != null)
                {
                    node = node.next;
                }
                node.next = dugum;


            }
        }
        #endregion

        //LinearProbingAdd() Metodu
        #region
        public void LinearProbingAdd(int key)
        {
            Node dugum = new Node(key);
            int indis = indexer(key);
            Node node = dizi[indis];

            if(node.next != null)
            {
                for(int i = indis+1; i < dizi.Length; i++)
                {
                    if (dizi[i].next == null)
                    {
                        dizi[i].next = dugum;
                        break;
                    }
                    
                }
            }
            else
            {
                node.next = dugum;
            }
        }
        #endregion

        //QuadraticProbingAdd() Metodu
        #region
        public void QuadraticProbingAdd(int key)
        {
            Node dugum = new Node(key);
            int indis = indexer(key);
            Node node = dizi[indis];

            if (node.next != null)
            {
                for (int i =1; i < dizi.Length; i++)
                {
                    if (dizi[indexer(indis + i * i)].next == null)
                    {
                        dizi[indexer(indis + i * i)].next = dugum;
                        break;
                    }

                }
            }
            else
            {
                node.next= dugum;
            }
        }
        #endregion

        //print() Metodu (Hash tablosunu görüntüle)
        #region
        public void print()
        {
            for (int i = 0; i < size; i++)
            {
                Node dugum = dizi[i];
                Console.Write("Dizi[{0,-2}] =>  ", i);

                while (dugum.next != null)
                {
                    dugum = dugum.next;
                    Console.Write("{0,-3}",dugum.key);
                    Console.Write(" => ");
                }
                Console.WriteLine();
            }
        }
        #endregion

    }
    #endregion
}
//Hüseyin TUNGA 215542006




