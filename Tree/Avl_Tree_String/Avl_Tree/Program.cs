using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avl_Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Avl tree = new Avl();
            tree.Add(Convert.ToInt32('A'));
            tree.Print();
            tree.Add(Convert.ToInt32('V'));
            tree.Print();
            tree.Add(Convert.ToInt32('L'));
            tree.Print();
            tree.Add(Convert.ToInt32('G'));
            tree.Print();
            tree.Add(Convert.ToInt32('C'));
            tree.Print();          
            tree.Add(Convert.ToInt32('I'));
            tree.Print();           
            tree.Add(Convert.ToInt32('N'));
            tree.Print();            
            tree.Add(Convert.ToInt32('E'));
            tree.Print();            
            tree.Add(Convert.ToInt32('K'));
            tree.Print();           
            tree.Add(Convert.ToInt32('M'));         
            tree.Print();           
            Console.ReadKey();
        }
    }

    public class Avl
    {
        //Node (Düğüm Sınıfı)
        #region
        public class Node
        {
            public int data;
            public Node left;
            public Node right;
            public int height = 0;

            public Node(int data)
            {
                this.data = data;

            }
        }
        #endregion

        public Node root;
        public Avl()
        {           
        }
        //Add() Methodu Ağaca düğüm ekleme
        #region
        public void Add(int data)
        {
            Node dugum = new Node(data);
            if (root == null)
            {
                root = dugum;
            }
            else
            {
                root = RecursiveInsert(root, dugum);
            }
        }
        
        private Node RecursiveInsert(Node current, Node n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.data < current.data)
            {
                current.left = RecursiveInsert(current.left, n);
                current = balance(current);
            }
            else if (n.data > current.data)
            {
                current.right = RecursiveInsert(current.right, n);
                current = balance(current);
            }
            return current;
        }
        #endregion
        //balance() Metodu Ağacın kolları arasındaki yükseklik farkını bulma
        #region
        private Node balance(Node root)
        {
            int b_factor = balance_factor(root);
            if (b_factor > 1)
            {
                if (balance_factor(root.left) > 0)
                {
                    root = RegulationLL(root);
                }
                else
                {
                    root = RotateLR(root);
                }
            }
            else if (b_factor < -1)
            {
                if (balance_factor(root.right) > 0)
                {
                    root = RotateRL(root);
                }
                else
                {
                    root = RegulationRR(root);
                }
            }
            return root;
        }
        private int balance_factor(Node current)
        {
            int l = Height(current.left);
            int r = Height(current.right);
            int b_factor = l - r;
            return b_factor;
        }
        #endregion
        //Delete() Metodu Ağaçtan düğüm silme
        #region
        public void Delete(int data)
        {
            root = Delete(root, data);
        }
        
        private Node Delete(Node root, int data)
        {
            Node parent;
            if (root == null)
            { return null; }
            else
            {
                
                if (data < root.data)
                {
                    root.left = Delete(root.left, data);
                    if (balance_factor(root) == -2)
                    {
                        if (balance_factor(root.right) <= 0)
                        {
                            root = RegulationRR(root);
                        }
                        else
                        {
                            root = RotateRL(root);
                        }
                    }
                }
                
                else if (data > root.data)
                {
                    root.right = Delete(root.right, data);
                    if (balance_factor(root) == 2)
                    {
                        if (balance_factor(root.left) >= 0)
                        {
                            root = RegulationLL(root);
                        }
                        else
                        {
                            root = RotateLR(root);
                        }
                    }
                }
                
                else
                {
                    if (root.right != null)
                    {
                       
                        parent = root.right;
                        while (parent.left != null)
                        {
                            parent = parent.left;
                        }
                        root.data = parent.data;
                        root.right = Delete(root.right, parent.data);
                        if (balance_factor(root) == 2)
                        {
                            if (balance_factor(root.left) >= 0)
                            {
                                root = RegulationLL(root);
                            }
                            else { root = RotateLR(root); }
                        }
                    }
                    else
                    {  
                        return root.left;
                    }
                }
            }
            return root;
        }
        #endregion
        //Find() Metodu Ağaçta veri arama
        #region
        public void Find(int key)
        {
            if (Find(key, root).data == key)
            {
                Console.WriteLine("{0} ağaçta bulundu", key);
            }
            else
            {
                Console.WriteLine("{0} ağaçta bulunamadı",key);
            }
        }
        private Node Find(int key, Node root)
        {

            if (key < root.data)
            {
                if (key == root.data)
                {
                    return root;
                }
                else
                    return Find(key, root.left);
            }
            else
            {
                if (key == root.data)
                {
                    return root;
                }
                else
                    return Find(key, root.right);
            }

        }
        #endregion
        //Print() Metodu Ağacın düğümlerini yazdırma
        #region
        public void Print()
        {
            if (root == null)
            {
                Console.WriteLine("Ağaç Boş!");
                return;
            }
            InOrderPrint(root);
            Console.WriteLine();
        }
        private void InOrderPrint(Node root)
        {
            if (root != null)
            {
                InOrderPrint(root.left);
                Console.Write("({0}) ",(Char) root.data);
                InOrderPrint(root.right);
            }
        }
        #endregion
        //Height() Metodu yüksekliği hesaplama
        #region
        public int Height(Node root)
        {
            int height = 0;
            if (root != null)
            {
                int l = Height(root.left);
                int r = Height(root.right);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }
        //max() Metodu 
        #region
        private int max(int l, int r)
        {
            return l > r ? l : r;
        }
        #endregion
        #endregion
        //RegulationRR() Metodu   
        #region
        private Node RegulationRR(Node parent)
        {
            Node pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
        #endregion
        //RegulationLL() Metodu
        #region
        private Node RegulationLL(Node parent)
        {
            Node pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }
        #endregion
        //RegulationLR() Metodu
        #region
        private Node RotateLR(Node parent)
        {
            Node pivot = parent.left;
            parent.left = RegulationRR(pivot);
            return RegulationLL(parent);
        }
        #endregion
        //RegulationRL() Metodu
        #region
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.right;
            parent.right = RegulationLL(pivot);
            return RegulationRR(parent);
        }
        #endregion
    }
}
//Hüseyin TUNGA 215542006 

