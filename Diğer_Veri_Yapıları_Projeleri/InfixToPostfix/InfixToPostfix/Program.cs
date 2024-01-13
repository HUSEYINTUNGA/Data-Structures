using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfixToPostfix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("İnfix ifadeyi giriniz");
            string ifade = Console.ReadLine();
            Yıgın yıgın = new Yıgın();
            Liste list = new Liste();
            for (int i = 0; i < ifade.Length; i++)
            {
                
                    if (kontrol(ifade[i]))
                    {
                        yıgın.push(ifade[i]);
                    }
                    else if (ifade[i] == ')')
                    {
                        list.HeadAdd(yıgın.pop());
                        yıgın.pop();
                    }
                    else
                    {
                        list.HeadAdd(ifade[i]);
                    }                
            }

            while (yıgın.top != null)
            {
                list.HeadAdd(yıgın.pop());
            }

            list.Print();
            Console.ReadKey();

            // Kontrol Metodu 
            #region
            Boolean kontrol(char harf)
            {
                return harf == '(' || harf == '^' || harf == '*' || harf == '/' || harf == '-' || harf == '+';
            }
            #endregion
        }
    }

    //Dugum1 Sınıfı Çift Yönlü Liste İçin (Postfix adında bir bağlı listenin düğümlerini oluşturacak)
    #region
    class Dugum1
    {
        public char data;
        public Dugum1 next;
        public Dugum1 prev;
        public Dugum1(char data)
        {
            this.data = data;
            this.next = null;
            this.prev = null;
        }
    }
    #endregion

    //Dugum2 Sınıfı Stack İçin (Yıgın adında bir stack yapısının düğümlerini oluşturacak)
    #region
    class Dugum2
    {
        public char data;
        public Dugum2 next;
        public Dugum2(char data)
        {
            this.data = data;
            next = null;
        }
    }
    #endregion

    //Liste Sınıfı (LinkedList)
    #region
    class Liste
    {
        Dugum1 head;
        Dugum1 tail;
        public Liste()
        {
            head = null;
            tail = null;
        }


        //Yazdır Metodu
        #region
        public void Print()
        {
            if (head == null)
            {
                Console.WriteLine("Liste Boş!");
            }
            else
            {
                Dugum1 node = tail;
                while (node.prev != null)
                {
                    Console.Write(node.data);
                    node = node.prev;
                }
                Console.Write(node.data);

            }
        }
        #endregion

        //Başa Düğüm Ekleme
        #region
        public void HeadAdd(char data)
        {
            Dugum1 dugum = new Dugum1(data);

            if (head == null)
            {
                head = tail = dugum;
                Console.WriteLine("Liste oluşturuldu ve ilk düğüm eklendi  " + dugum.data);
            }
            else
            {
                dugum.next = head;
                head.prev = dugum;
                head = dugum;
                Console.WriteLine("Listenin başına düğüm eklendi  " + dugum.data);
            }
        }
        #endregion
      
    }
    #endregion

    //Yığın Sınıfı (STACK)
    #region
    class Yıgın
    {
        public Dugum2 top;
        public Yıgın()
        {
            top = null;
        }

        //push() Metodu (En sona ekle "daima")
        #region
        public void push(char data)
        {
            Dugum2 node = new Dugum2(data);
            if (top == null)
            {
                top = node;
                Console.WriteLine("Yığın oluşturuldu ve ilk düğüm eklendi " + top.data);
            }
            else
            {
                node.next = top;
                top = node;
                Console.WriteLine("Düğüm yığına eklendi " + top.data);
            }
        }
        #endregion

        //pop() Metodu (sondan sil "daima")
        #region
        public char pop()
        {
            if (top == null)
            {
                Console.WriteLine("Yığın Boş!");
                return '0';
            }
            else
            {
                char sayi = top.data;
                top = top.next;
                Console.WriteLine(sayi + " Düğümü yığından çıkarıldı");
                return sayi;
            }
        }
        #endregion
    }
    #endregion
}
//H.TNG
