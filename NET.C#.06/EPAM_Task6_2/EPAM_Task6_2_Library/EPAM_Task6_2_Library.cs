using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EPAM_Task6_2_Library
{
   /// <summary>
   /// Класс для чтения из файла
   /// </summary>
   public class FileReader : FileStream
   {
      long fileLength; //длинна файла
      long filePosition; // текущая позиция в потоке
      /// <summary>
      /// Свойство для получения значения длинны файла
      /// </summary>
      public long FileLenght
      {
         get
         {
            return fileLength;
         }
      }
      /// <summary>
      /// Конструктор класса
      /// </summary>
      /// <param name="path">Имя файла</param>
      public FileReader(String path)
         : base(path, FileMode.Open)
      {
         fileLength = this.Length;
         filePosition = 0;
      }
      /// <summary>
      /// Метод для чтения из файла
      /// </summary>
      /// <param name="count">Количество байт которое нужно прочитать</param>
      /// <param name="password">Пароль</param>
      /// <returns>Возвращает прочитанные байты перекодированные в текст</returns>
      public string Read(int count, string password)
      {
         if (count > fileLength)
         {
            throw new Exception("Заданное количество байт которое нужно прочитать не должно превышать длинны файла");
         }
         if (password != Resource1.Password)
         {
            throw new Exception("Пароль введён неправильно");
         }
         StringBuilder answer = new StringBuilder();
         byte[] array = new byte[count - filePosition];
         filePosition += base.Read(array, 0, count - (int)filePosition);
         base.Seek(filePosition, SeekOrigin.Begin);
         answer.Append(Encoding.Default.GetString(array));
         return answer.ToString();
      }

   }
}
