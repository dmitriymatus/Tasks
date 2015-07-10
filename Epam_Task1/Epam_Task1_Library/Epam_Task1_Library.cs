using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Epam_Task1
{
   /// <summary>
   /// Класс содержит метод для преобразования строки
   /// </summary>
   public class MyConvert
   {
      /// <summary>
      /// Функция преобразования
      /// </summary>
      /// <param name="inputString">Строка которую нужно преобразовать</param>
      /// <returns>Возвращает преобразованную строку</returns>
      public static string ConvertFunc(string inputString)
      {
         StringBuilder result = new StringBuilder();
         MatchCollection templateStrings = Regex.Matches(inputString, @"\d+.\d+,\d+.\d+");
         foreach (Match templateString in templateStrings)
         {
            Match templateLine = Regex.Match(templateString.Value, @"\d+.\d+");
            Regex.Replace(templateLine.Value, ".", ",");
            result.Append("x=");
            result.AppendLine(templateLine.Value);
            templateLine = templateLine.NextMatch();
            Regex.Replace(templateLine.Value, ".", ",");
            result.Append("y=");
            result.AppendLine(templateLine.Value);
         }
         return result.ToString();
      }
      /// <summary>
      /// Функция преобразования
      /// </summary>
      /// <param name="inputFile">Файл который нужно преобразовать</param>
      /// <returns>Возвращает строку</returns>
      public static string ConvertFunc(FileStream inputFile)
      {
         StreamReader c = new StreamReader(inputFile);
         string x = c.ReadToEnd();
         return ConvertFunc(x);
      }
   }
}