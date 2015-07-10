using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Task_11_1_Library
{
   /// <summary>
   /// Класс для хранения потомков узла дерева
   /// </summary>
   /// <typeparam name="T"></typeparam>
   public class NodeList<T> : List<BinaryTreeNode<T>>
   {
      public NodeList() : base() 
      {
         base.Add(default(BinaryTreeNode<T>));
         base.Add(default(BinaryTreeNode<T>));
      }

   }
}
