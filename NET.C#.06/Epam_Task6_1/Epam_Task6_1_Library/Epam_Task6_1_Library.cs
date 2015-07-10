using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Task6_1_Library
{
   /// <summary>
   /// Интерфейс содержит методы конвертирования кода из одного языка в другой
   /// </summary>
   interface IConvertible
   {
      string ConvertToCSharp(string input);
      string ConvertToVB(string input);
   }

   /// <summary>
   /// Интерфейс содержит метод для проверки кода
   /// </summary>
   interface ICodeChecker
   {
      bool CodeCheckSyntax(string input, string lang);
   }

   /// <summary>
   /// Класс реализует методы для конвертирования кода
   /// </summary>
   public class ProgramConverter: IConvertible
   {
      /// <summary>
      /// Метод конвертирует код в код CSharp
      /// </summary>
      /// <param name="input">Строка которую нужно преобразовать в код CSharp</param>
      /// <returns>Строку содержащую код CSharp</returns>
      public string ConvertToCSharp(string input)
      {
         return "Код CSharp";
      }
      /// <summary>
      /// Метод конвертирует код в код VB
      /// </summary>
      /// <param name="input">Строка которую нужно преобразовать в код VB</param>
      /// <returns>Строку содержащую код VB</returns>
      public string ConvertToVB(string input)
      {
         return "Код VB";
      }
   }
   /// <summary>
   ///  Класс реализует метод сравнения CodeCheckSyntax
   /// </summary>
   public class ProgramHelper : ProgramConverter, ICodeChecker
   {
      /// <summary>
      /// Метод для проверки кода
      /// </summary>
      /// <param name="input">Строка которую нужно проверить</param>
      /// <param name="lang">Язык программирования</param>
      /// <returns>true если входная строка input является кодом, написанном на языке заданном в строке lang</returns>
      public bool CodeCheckSyntax(string input, string lang)
      {
         if (lang == "VB" || lang == "CSharp")
         {
            if (lang == "VB" && input == "Код VB") return true;
            if (lang == "CSharp" && input == "Код CSharp") return true;
            return false;
         }
         else
         {
            throw new Exception("Язык введён не правильно!");
         }
      }
   }



}
