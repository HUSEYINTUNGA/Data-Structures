using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parantez_Kontrol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Yıgın y = new Yıgın();
            Kuyruk k = new Kuyruk();
            string dize;
            Console.WriteLine("Parantez kontrolü yapmak istediğiniz ifadeyi yazınız:");
            dize = Console.ReadLine();
            for (int i = 0; i < dize.Length; i++)
            {
                if (dize[i] == '{' || dize[i] == '[' || dize[i] == '(')
                {
                    y.push(dize[i]);
                }
                else if (dize[i] == '}' || dize[i] == ']' || dize[i] == ')')
                {
                    k.enQueue(dize[i]);
                }
            }
            bool lean = true;

            while (!k.isEmpty())
            {
                char a = Convert.ToChar(y.pop());
                char b =Convert.ToChar(k.deQueue());
                if ((Convert.ToInt32(b)) == (Convert.ToInt32(a)+1))
                {
                    lean = true;
                }
                else if ((Convert.ToInt32(b)) == (Convert.ToInt32(a)+2))
                {
                    lean = true;
                }
                else
                {
                    lean = false; break;
                }
            }
            if (lean)
            {
                Console.WriteLine(dize + " ifadesinde doğru parantez kullanımı mevcut");
            }
            else
            {
                Console.WriteLine(dize + " ifadesinde yanlış parantez kullanımı mevcut");
            }

            //char c;
            //Console.Write("Karakter Girin: ");
            //c = Convert.ToChar(Console.ReadLine());
            //Console.WriteLine(c + " karakteri ASCII Kaşılığı >> " + Convert.ToInt32(c));

            Console.ReadKey();

        }
    }
    //Düğüm Sınıfı
    #region
    class Dugum
    {
        public char data;
        public Dugum next;
        public Dugum(char data)
        {
            this.data = data;
            next = null;
        }
    }
    #endregion


    //Yığın Sınıfı (Stack)
    #region
    class Yıgın
    {
        public Dugum top;
        public Yıgın()
        {
            top = null;
        }
        public bool isEmpty()
        {
            return top == null;
        }
        public void push(char data)
        {
            Dugum dugum = new Dugum(data);
            if (isEmpty())
            {
                top = dugum;
            }
            else
            {
                dugum.next = top;
                top = dugum;
            }
        }
        public char pop()
        {
            char ch;
            if (isEmpty())
            {
                ch = '0';
            }
            else
            {
                ch = top.data;
                top = top.next;
            }
            return ch;
        }
    }
    #endregion

    //Kuyruk Sınıfı (Queue)
    #region
    class Kuyruk
    {
        public Dugum front;
        public Dugum rear;
        public Kuyruk()
        {
            this.front = null;
            this.rear = null;
        }

        public bool isEmpty()
        {
            return front == null;
        }

        public void enQueue(char data)
        {
            Dugum dugum = new Dugum(data);

            if (isEmpty())
            {
                front = rear = dugum;
            }
            else
            {
                rear.next = dugum;
                rear = dugum;
            }
        }
        public char deQueue()
        {
            char ch;
            if (isEmpty())
            {
                ch = '0';
            }
            else
            {
                ch = front.data;
                front = front.next;
            }
            return ch;
        }
    }
    #endregion

}
//H.TNG

