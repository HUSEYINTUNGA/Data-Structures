﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Agac_Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 10-20-2-1-9-15-24 için;
             
                    inOrder() -> 1-2-9-10-15-20-24
                   preOrder() -> 10-2-1-9-20-15-24
                  postOrder() -> 1-9-2-15-24-20-10
                                                    çıktısı beklenir.  */

            Tree tre = new Tree();

            tre.root = tre.insert(tre.root, 10);
            tre.root = tre.insert(tre.root, 20);
            tre.root = tre.insert(tre.root, 2);
            tre.root = tre.insert(tre.root, 1);
            tre.root = tre.insert(tre.root, 9);
            tre.root = tre.insert(tre.root, 15);
            tre.root = tre.insert(tre.root, 24);
            tre.root = tre.insert(tre.root, 30);

            //tre.printLevelOrder();//Ağaç veri yapısının aynı düzeyde bulunan düğümlerini yazdırmak için "//" i kaldırın!
            //
            /*Console.Write("inOrder() : ");
            tre.inOrder(tre.root);
            Console.WriteLine();*/

            /*Console.Write("preOrder() : ");
            tre.preOrder(tre.root);
            Console.WriteLine();*/

            /*Console.Write("postOrder() : ");
            tre.postOrder(tre.root);*/

            //Console.WriteLine("\nAğaç yapısında bulunan eleman sayısı = "+tre.size(tre.root));

            //Console.WriteLine("Ağaç yapısının yüksekliği = "+tre.height(tre.root));

            //tre.maxData();//En büyük değeri, atasını ve kardeşini bulmak için "//" i kaldırın!
            //tre.minData();//En küçük değeri, atasını ve kardeşini bulmak için "//" i kaldırın!

            //tre.DengeFarkı();
            
            Console.ReadKey();
        }
    }
    //Düğüm Sınıfı (Node)
    #region
    class Node
    {
        public int data;
        public Node right;
        public Node left;
        public Node(int data)
        {
            this.data = data;
            left = null;
            right=null;
        }
    }
    #endregion

    //Ağaç Sınıfı (Tree)
    #region
    class Tree
    {
        public Node root;
        public Tree()
        {
            root = null;
        }

        public Node Dugum(int data)
        {
            root = new Node(data);
            return root;
        }

        // insert() Metodu (Ağaca veri ekleme)
        #region
        public Node insert(Node root, int data)
        {
            Node node1 = new Node(data);
            if (root != null)
            {
                if(data<root.data)
                {
                    root.left = insert(root.left,data);
                }
                else
                {
                    root.right=insert(root.right,data);
                }

            }
            else
            {
                root =  Dugum(data);
                
                
            }
            return root;

        }
        #endregion

        // preOrder() Metodu    (" kök - kök.sol - kök.sağ " şeklinde yazdırma)
        #region
        public void preOrder(Node root)
        {
            if(root != null)
            {
                Console.Write(root.data + " - ");
                preOrder(root.left);
                preOrder(root.right);
            }
        }
        #endregion

        // inOrder() Metodu    (" kök.sol - kök - kök.sağ " şeklinde yazdırma)
        #region
        public void inOrder(Node root)
        {
            if (root != null)
            {
                inOrder(root.left);
                Console.Write(root.data + " - ");
                inOrder(root.right);
            }
        }
        #endregion

        // postOrder() Metodu    (" kök.sol - kök.sağ - kök " şeklinde yazdırma)
        #region
        public void postOrder(Node root)
        {
            if(root!=null)
            {
                postOrder(root.left);
                postOrder(root.right);
                Console.Write(root.data+" - ");
            }
        }
        #endregion

        // size() Metodu (Ağacın düğüm sayısını bulma)
        #region
        public int size(Node root)
        {
            if(root==null)return 0;
            else return size(root.left)+size(root.right)+1 ;           
        }
        #endregion

        // height() Metodu (Ağacın yüksekliğini bulma)
        #region
        public int height(Node root)
        {
            if(root==null)return -1;
            else
            {
                 int lft,rght;
                lft=height(root.left);
                rght=height(root.right);
                if (lft > rght)
                    return lft + 1;
                else return rght + 1;

            }
        }
        #endregion

        // maxData() Metodu (Ağacın en büyük değere sahip verisini, verinin atasını ve kardeşlerini bulma)
        #region
        public void maxData()
        {

            if (root != null)
            {
                int enBuyuk = root.data;
                int ata = 0;
                string kardes = "0";
                while (root.right != null)
                {
                    ata = root.data;
                    if (root.left == null) kardes = null;
                    else kardes=root.left.data.ToString();
                    root = root.right;
                }
                enBuyuk = root.data;
                Console.WriteLine("En büyük değer "+enBuyuk);
                Console.WriteLine("En büyük değerin atası "+ata);
                Console.WriteLine("En büyük değerin kardeşi "+kardes);
            }
        }
        #endregion

        // minData() Metodu (Ağacın en küçük değere sahip verisini, verinin atasını ve kardeşlerini bulma)
        #region
        public void minData()
        {

            if (root != null)
            {
                int enBuyuk = root.data;
                int ata = 0;
                string kardes = "0";
                while (root.left != null)
                {
                    ata = root.data;
                    if (root.left == null) kardes = null;
                    else kardes = root.right.data.ToString();
                    root = root.left;
                }
                enBuyuk = root.data;
                Console.WriteLine("En küçük değer " + enBuyuk);
                Console.WriteLine("En küçük değerin atası " + ata);
                Console.WriteLine("En küçük değerin kardeşi " + kardes);
            }
        }
        #endregion

        //DengeFarkı() Metodu (İkili ağacın sağ ve sol dalları arasındaki yükseklik farkını bulma)
        #region
        public void DengeFarkı()
        {            
            int fark = Math.Abs(height(root.right) - height(root.left));
            Console.WriteLine("Ağacın dalları arasındaki denge farkı = "+fark);
            if (height(root.right) <= height(root.left)) { Console.WriteLine("Uzun dal, sol dal"); }
            else if (height(root.right) == height(root.left)) { Console.WriteLine("Dallar aynı uzunlukta"); }
            else { Console.WriteLine("Uzun dal, sağ dal"); }
        }
        #endregion

        //levelOrder() Metodu (Ağacın bir katmanını dolaşma, daha sonra üst veya alt katmanları dolaşma)
        #region
        public virtual void levelOrder(Node root,int level)
        {
            if (root == null)
            {
                return;
            }
            if (level == 1)
            {
                Console.Write(root.data + "-> ");
            }
            else if (level > 1)
            {
                levelOrder(root.left, level - 1);
                levelOrder(root.right, level - 1);
            }
        }

        public virtual void printLevelOrder()
        {
            int h = height(root);
            int i;
            for (i = 1; i <= h; i++)
            {
                levelOrder(root, i);
            }
            levelOrder(root, i);
        }
        #endregion
    }
    #endregion
}
//H.TNG 
