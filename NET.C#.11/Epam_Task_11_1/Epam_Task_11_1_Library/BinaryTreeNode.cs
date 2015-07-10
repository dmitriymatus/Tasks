using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Task_11_1_Library
{
   /// <summary>
   /// Класс для хранения узлов дерева
   /// </summary>
   /// <typeparam name="T">Параметр типа</typeparam>
   public class BinaryTreeNode<T>
   {
      private T data; // данные хранящиеся в узле дерева
      private NodeList<T> seed = null; // список потомков узла
      public BinaryTreeNode() { }
      public BinaryTreeNode(T data, NodeList<T> seed) 
      {
         this.data = data;
         this.seed = seed;
      }
      public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right) 
      {
         this.data = data;
         NodeList<T> children = new NodeList<T>();
         children[0] = left;
         children[1] = right;
         this.seed = children;
      }
      public BinaryTreeNode(T data) : this(data, null) { }
      /// <summary>
      /// Свойство для получения данных
      /// </summary>
      public T Value
      {
         get
         {
            return data;
         }
      }
      /// <summary>
      /// Свойство для получения или установки левого потомка узла
      /// </summary>
      public BinaryTreeNode<T> Left
      {
         get
         {
            if (this.seed == null)
               return null;
            else
               return (BinaryTreeNode<T>)this.seed[0];
         }
         set
         {
            if (this.seed == null)
               this.seed = new NodeList<T>();
            this.seed[0] = value;
         }
      }
      /// <summary>
      /// Свойство для получения или установки правого потомка узла
      /// </summary>
      public BinaryTreeNode<T> Right
      {
         get
         {
            if (this.seed == null)
               return null;
            else
               return (BinaryTreeNode<T>)this.seed[1];
         }
         set
         {
            if (this.seed == null)
               this.seed = new NodeList<T>();
            this.seed[1] = value;
         }
      }

   } // end of BinaryTreeNode
}
