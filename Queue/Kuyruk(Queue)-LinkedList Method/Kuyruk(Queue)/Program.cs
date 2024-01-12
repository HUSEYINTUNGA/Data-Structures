using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuyruk_Queue_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kuyruk ky=new Kuyruk();
            ky.enQueue(1);
            ky.enQueue(2);
            ky.enQueue(3);
            ky.enQueue(4);
            ky.Print();
            int sayi2= ky.deQueue();
            ky.Print();

            Console.ReadLine();


        }
    }

    //Düğüm (Node) Sınıfı
    #region
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
    #endregion

    //Kuyruk (Queue) Sınıfı
    #region
    class Kuyruk
    {
        Dugum front;
        Dugum rear;

        public Kuyruk()
        {
            this.front = null;
            this.rear=null;
        }

        //Kaydet (EnQueue) Metodu
        #region
        public void enQueue(int data)
        {
            Dugum node =new Dugum(data);
            if(front==null)
            {
                front=rear= node;
                Console.WriteLine("Kuyruk oluşturuldu ve ilk düğüm (front) eklendi "+node.data);
            }
            else
            {
                rear.next= node;
                rear = node;
                Console.WriteLine("Düğüm kuyruğa eklendi "+node.data);
            }
        }
        #endregion

        //Sil (DeQueue) Metodu
        #region
        public int deQueue()
        {
            if (front == null)
            {
                Console.WriteLine("Kuyruk Boş!");
                return -1;
            }
            else
            {
                int sayi=front.data;
                front= front.next;
                Console.WriteLine("\nDüğüm kuyruktan silindi "+sayi);
                return sayi;
            }

        }
        #endregion

        //Yazdır (Print) Metodu
        #region
        public void Print()
        { 
            if (front == null)
            {
                Console.WriteLine("Kuyruk Boş!");
            }
            else
            {
                Dugum node = front;
                while (node!=null)
                {
                    Console.Write(node.data+"  ");
                    node= node.next;
                }
            }
        }
        #endregion
    }
    #endregion
}
//H.TNG
