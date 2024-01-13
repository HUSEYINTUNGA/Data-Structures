using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PostfixToInfix
{
    internal class Program
    {

        public static void Main(String[] args)
        {
            Console.WriteLine("'Postfix' ifadeyi giriniz; ");
            string post = Console.ReadLine();
            Console.WriteLine(getInfix(post));
            Console.ReadKey();



            // isOperand() ve getInfix() Metodu (karakter rakam mı? ve İnfix' e dönüşüm olayı)
            #region
            Boolean isOperand(char x)
            {
                return (x >= '0' && x <= '9') ;
            }

            String getInfix(String exp)
            {
                Yıgın s = new Yıgın();

                for (int i = 0; i < exp.Length; i++)
                {

                    if (isOperand(exp[i]))
                    {
                        s.push(int.Parse(exp[i] + ""));
                    }
                    else
                    {
                        int a = s.pop();
                        int b = s.pop();

                        char oprtr = exp[i];
                        switch (oprtr)
                        {
                            case '*': s.push(b * a); break;
                            case '/': s.push(b / a); break;
                            case '^': s.push(Convert.ToInt32(Math.Pow(b, a))); break;
                            case '+': s.push(b + a); break;
                            case '-': s.push(b - a); break;
                        }
                    }
                }
                return s.pop().ToString();
            }
            #endregion
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
        {
            Dugum node = new Dugum(data);
            if (top == null)
            {
                top = node;
                Console.WriteLine("Yığın oluşturuldu ve ilk düğüm eklendi");
            }
            else
            {
                node.next = top;
                top = node;
                Console.WriteLine("Düğüm yığına eklendi");
            }
            Print();
        }
        #endregion

        //pop() Metodu (sondan sil "daima")
        #region
        public int pop()
        {
            if (top == null)
            {
                Console.WriteLine("Yığın Boş!");
                return -1;
            }
            else
            {
                int sayi = top.data;
                top = top.next;
                Console.WriteLine(sayi + " Düğümü yığından çıkarıldı");
                return sayi;
            }
            Print();
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
                node = node.next;
            }

        }
        #endregion
    }
    #endregion
}
//H.TNG

