using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Task_11_2_Library
{
   /// <summary>
   /// Класс клиента
   /// </summary>
   public class Client
   {
      IProductA a;
      IProductB b;
      /// <summary>
      /// Конструктор класса
      /// </summary>
      /// <param name="factory">Объект который реализует интерфейс IFactory</param>
      public Client(IFactory factory)
      {
         if (factory == null)
         {
            throw new ArgumentNullException();
         }
         a = factory.GetProductA();
         b = factory.GetProductB();
      }
      /// <summary>
      /// Метод возвращает имена продуктов
      /// </summary>
      /// <returns>Имена продуктов</returns>
      public string ProductsName()
      {
         return a.GetProductName() + "\n" + b.GetProductName();
      }

   }
   /// <summary>
   /// Интерфейс для завода
   /// </summary>
   public interface IFactory
   {
     IProductA GetProductA();
     IProductB GetProductB();
   }
   /// <summary>
   /// Интерфейс для продуктов A
   /// </summary>
   public interface IProductA
   {
      string GetProductName();
   }
   /// <summary>
   /// Интерфейс для продуктов B
   /// </summary>
   public interface IProductB
   {
      string GetProductName();
   }
   /// <summary>
   /// Класс создаёт продукт 1
   /// </summary>
   public class Factory1:IFactory
   {

      public IProductA GetProductA()
      {
         return new ProductA1();
      }

      public IProductB GetProductB()
      {
         return new ProductB1();
      }
   }
   /// <summary>
   /// Класс создаёт продукт 2
   /// </summary>
   public class Factory2:IFactory
   {

      public IProductA GetProductA()
      {
         return new ProductA2();
      }

      public IProductB GetProductB()
      {
         return new ProductB2();
      }
   }
   /// <summary>
   /// Класс продукта
   /// </summary>
   public class ProductA1:IProductA
   {

      public string GetProductName()
      {
         return "Product A1";
      }
   }
   /// <summary>
   /// Класс продукта
   /// </summary>
   public class ProductA2:IProductA
   {

      public string GetProductName()
      {
         return "Product A2";
      }
   }
   /// <summary>
   /// Класс продукта
   /// </summary>
   public class ProductB1:IProductB
   {

      public string GetProductName()
      {
         return "Product B1";
      }
   }
   /// <summary>
   /// Класс продукта
   /// </summary>
   public class ProductB2:IProductB
   {

      public string GetProductName()
      {
         return "Product B2";
      }
   }
}
