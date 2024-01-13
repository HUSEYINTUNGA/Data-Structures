using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splay_Tree
{
    internal class Splay_Tree
    {
        
    }
    class Splay
    {

        public class node
        {

            public int key;
            public node left, right;
        }

       
        static node newNode(int key)
        {
            node Node = new node();
            Node.key = key;
            Node.left = Node.right = null;
            return (Node);
        }

        //rightRotate() ve leftRotate() Metotları Ağacı döndürerek düzenleme
        #region
        static node rightRotate(node x)
        {
            node y = x.left;
            x.left = y.right;
            y.right = x;
            return y;
        }

        
        static node leftRotate(node x)
        {
            node y = x.right;
            x.right = y.left;
            y.left = x;
            return y;
        }
        #endregion

        //splay() Metodu rotasyon işlemlerini gerçekleştirme
        #region
        static node splay(node root, int key)
        {
           
            if (root == null || root.key == key)
                return root;

            
            if (root.key > key)
            {
                
                if (root.left == null) return root;

                // Zig-Zig (Left Left)
                if (root.left.key > key)
                {
                    
                    root.left.left = splay(root.left.left, key);

                    
                    root = rightRotate(root);
                }

                // Zig-Zag (Left Right)
                else if (root.left.key < key) 
                {
                    
                    root.left.right = splay(root.left.right, key);

                   
                    if (root.left.right != null)
                        root.left = leftRotate(root.left);
                }

                
                return (root.left == null) ?
                root : rightRotate(root);
            }
            else 
            {
                
                if (root.right == null) return root;

                // Zag-Zig (Right Left)
                if (root.right.key > key)
                {
                    
                    root.right.left = splay(root.right.left, key);

                   
                    if (root.right.left != null)
                        root.right = rightRotate(root.right);
                }

                // Zag-Zag (Right Right)
                else if (root.right.key < key)
                {
                    
                    root.right.right = splay(root.right.right, key);
                    root = leftRotate(root);
                }

                
                return (root.right == null) ?
                root : leftRotate(root);
            }
        }
        #endregion

        //search() Metodu Ağaç üzerinde arama yapma
        #region
        static node search(node root, int key)
        {
            return splay(root, key);
        }
        #endregion

        static void preOrder(node root)
        {
            if (root != null)
            {
                Console.Write(root.key + " ");
                preOrder(root.left);
                preOrder(root.right);
            }
        }

        
        public static void Main(String[] args)
        {
            node root = newNode(10);
            root.right = newNode(16);
            root.right.right= newNode(20);
            root.right.left = newNode(45);
            root.right.right.right = newNode(30);
            root.left.left.left = newNode(30);
            root.left.left.left.left = newNode(20);
            root.left.left.left.right = newNode(120);
            preOrder(root);
            root = search(root, 120);
            Console.Write("\n Ağaç üzerinde arama yapıldıktan sonraki hali \n");
            preOrder(root);
            Console.ReadKey();
        }
    }
}
