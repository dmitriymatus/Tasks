using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Task_11_1_Library
{
   /// <summary>
   /// Класс для работы с бинарным деревом
   /// </summary>
   /// <typeparam name="T">Параметр типа</typeparam>
    public class BinaryTree<T>:ICollection<T> where T:IComparable
    {
       private BinaryTreeNode<T> root;
       private int count = 0;
       List<T> values = new List<T>();
       public BinaryTreeNode<T> Root
       {
          get
          {
             return root;
          }
          set
          {
             root = value;
          }
       }

       public BinaryTree()
       {
          root = null;
       }
       /// <summary>
       /// Метод для добавления элементов
       /// </summary>
       /// <param name="item">Элемент который нужно добавить</param>
       public void Add(T item)
       {
          if (item == null)
          {
             throw new ArgumentNullException();
          }
          BinaryTreeNode<T> temp = new BinaryTreeNode<T>(item);
          int result;
          BinaryTreeNode<T> current = root, parent = null;
          while (current != null)
          {
             result = current.Value.CompareTo(item);
             if (result == 0)
             {
                return;
             }
             else if(result > 0)
             {
                // добавляем temp  в левое поддерево
                parent = current;
                current = current.Left;
             }
             else if (result < 0)
             {
                // добавляем temp  в правое поддерево
                parent = current;
                current = current.Right;
             }
          }//end of while

          count++;
          if (parent == null)
          {
             //дерево было пустым
             root = temp;
          }
          else
          {
             result = parent.Value.CompareTo(temp.Value);
             if (result > 0)
             {
                parent.Left = temp;
             }
             else
             {
                parent.Right = temp;
             }
          }
       } // end of add
       /// <summary>
       /// Метод для очистки дерева
       /// </summary>
       public void Clear()
       {
          root = null;
       }
       /// <summary>
       /// Метод для проверки нахождения элемента
       /// </summary>
       /// <param name="item">Элемент который нужно найти</param>
       /// <returns>True если элемент найден, false если не найден</returns>
       public bool Contains(T item)
       {
          if (item == null)
          {
             throw new ArgumentNullException();
          }
          BinaryTreeNode<T> current = root;
          int result;
          while (current != null)
          {
             result = current.Value.CompareTo(item);
             if (result == 0)
             {
                return true;
             }
             else if (result > 0)
             {
                current = current.Left;
             }
             else if (result < 0)
             {
                current = current.Right;
             }
          }//end of while
          return false;
       }
       /// <summary>
       /// Метод для копирования дерева в массив
       /// </summary>
       /// <param name="array">Массив в который нужно скопировать элементы дерева</param>
       /// <param name="arrayIndex">Индекс с которого записывать в массив</param>
       public void CopyTo(T[] array, int arrayIndex)
       {
          if (array == null)
          {
             throw new ArgumentNullException();
          }
          if (arrayIndex < 0)
          {
             throw new ArgumentOutOfRangeException();
          }
          if (arrayIndex + Count > array.Length)
          {
             throw new ArgumentException();
          }
          values.Clear();
          Traversal(Root);
          for (int i = 0; arrayIndex < Count; arrayIndex++,i++)
          {
             array[arrayIndex] = values[i];
          }
       }
       /// <summary>
       /// Свойство для получения количества элементов в дереве
       /// </summary>
       public int Count
       {
          get { return count; }
       }
       /// <summary>
       /// Метод для проверки является ли дерево доступным только для чтения
       /// </summary>
       public bool IsReadOnly
       {
          get { return false; }
       }
       /// <summary>
       /// Метод для удаления элемента из дерева
       /// </summary>
       /// <param name="item">Элемент который нужно удалить</param>
       /// <returns>True если элемент удалён</returns>
       public bool Remove(T item)
       {
          if (root == null)
          {
             return false;
          }
          if (item == null)
          {
             throw new ArgumentNullException();
          }
          BinaryTreeNode<T> current = root, parent = null;
          int result = current.Value.CompareTo(item);
          while (result != 0)
          {
             if (result > 0)
             {
                parent = current;
                current = current.Left;
             }
             else if (result < 0)
             {
                parent = current;
                current = current.Right;
             }
             if (current == null)
             {
                return false;
             }
             else
             {
                result = current.Value.CompareTo(item);
             }
          }//end of while
          count--;
          // СЛУЧАЙ1: Если текущий узел не имеет правого потомка, то левый
          // потомок текущего узла становится узлом на который ссылается
          // родитель
          if (current.Right == null)
          {
             if (parent == null)
             {
                root = current.Left;
             }
             else
             {
                result = parent.Value.CompareTo(current.Value);
                if (result > 0)
                {
                   // parent.Value > current.Value, поэтому сделать левого
                   // потомка текущего узла левым потомком родителя
                   parent.Left = current.Left;
                }
                else if (result < 0)
                {
                   // parent.Value < current.Value, поэтому сделать левого
                   // потомка текущего узла правым потомком родителя
                   parent.Right = current.Right;
                }
             }
          }
          // СЛУЧАЙ2: Если правый потомок текущего узла не имеет левого потомка, 
          // то правый потомок текущего узла замещает текущий узел в дереве
          else if (current.Right.Left == null)
          {
             current.Right.Left = current.Left;
             if (parent == null)
             {
                root = current.Right;
             }
             else
             {
                result = parent.Value.CompareTo(current.Value);
                if (result > 0)
                {
                   // parent.Value > current.Value, поэтому сделать правого
                   // потомка текущего узла левым потомком родителя
                   parent.Left = current.Right;
                }
                else if (result < 0)
                {
                   // parent.Value < current.Value, поэтому сделать правого
                   // потомка текущего узла правым потомком родителя
                   parent.Right = current.Right;
                }
             }
          }
          // СЛУЧАЙ3: Если правый потомок текущего узла имеет левого потомка, 
          // то заменить текущий узел самым левым наследником правого потомка
          // текущего узла
          else
          {
             // Сперва мы должны найти самого левого потомка правого узла
             BinaryTreeNode<T> leftmost = current.Right.Left, lmParent = current.Right;
             while (leftmost.Left != null)
             {
                lmParent = leftmost;
                leftmost = leftmost.Left;
             }
             // левое поддерево родителя становится правым поддеревом самого
             // левого
             lmParent.Left = leftmost.Right;
             leftmost.Left = current.Left;
             leftmost.Right = current.Right;
             if (parent == null)
             {
                root = leftmost;
             }
             else
             {
                result = parent.Value.CompareTo(current.Value);
                if (result > 0)
                {
                   // parent.Value > current.Value, поэтому сделать самый левый
                   // узел левым потомком родителя
                   parent.Left = leftmost;
                }
                else if (result < 0)
                {
                   // parent.Value < current.Value, поэтому сделать самый левый
                   // узел правым потомком родителя
                   parent.Right = leftmost;
                }
             }
          }
          return true;
       }//end of Remove

       public IEnumerator<T>  GetEnumerator()
       {
          values.Clear();
          Traversal(Root);
          foreach(var value in values)
          {
             yield return value;
          }
       }

       IEnumerator IEnumerable.GetEnumerator()
       {
          values.Clear();
          Traversal(Root);
          foreach (var value in values)
          {
             yield return value;
          }
       }
       /// <summary>
       /// Метод производит обход по дереву и копирует его элементы в коллекцию
       /// </summary>
       /// <param name="current">Элемент с которого нужно начать обход</param>
       void Traversal(BinaryTreeNode<T> current)
       {
          if (current != null)
          {
             Traversal(current.Left);
             values.Add(current.Value);
             Traversal(current.Right);
          }
       }
    }
}
