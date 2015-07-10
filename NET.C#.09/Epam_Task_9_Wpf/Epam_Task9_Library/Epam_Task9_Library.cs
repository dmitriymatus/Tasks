using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Epam_Task9_Library
{
   /// <summary>
   /// Класс для чтения из файла
   /// </summary>
   public class FileReader : FileStream
   {
      long fileLength; //длинна файла
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
      }
      /// <summary>
      /// Метод для чтения из файла
      /// </summary>
      /// <returns>Возвращает прочитанные байты перекодированные в текст</returns>
      public string Read()
      {
         StringBuilder answer = new StringBuilder();
         byte[] array = new byte[FileLenght];
         base.Read(array, 0, (int)FileLenght);
         answer.Append(Encoding.Default.GetString(array));
         return answer.ToString();
      }

   }


   public class FileWriter : FileStream
   {
      long fileLength; //длинна файла
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
      public FileWriter(String path,FileMode fileMode)
         : base(path, fileMode)
      {
         fileLength = this.Length;
      }
      /// <summary>
      /// Метод для записи текста в файл
      /// </summary>
      /// <param name="info">Текст который нужно записать в файл</param>
      /// <param name="start">Позиция с которой нужно записать текст</param>
      /// <param name="newFileLenght">Новая длинна файла</param>
      public void Write(string info, int start)
      {
         int newFileLenght = start + info.Length;
         if (start == newFileLenght)
         {
            base.SetLength(newFileLenght);
         }
         else
         {
            StringBuilder answer = new StringBuilder();
            byte[] array = Encoding.Default.GetBytes(info);
            base.Seek(start, SeekOrigin.Current);
            base.Write(array, 0, array.Length);
            if (base.CanSeek && base.CanWrite)
            {
               base.SetLength(newFileLenght);
            }
         }
         
      }
   }

   public class UsedFile
   {
      public string fileName;
      public bool changed = false;
      int minChange = 0;
      public UsedFile(String path)
      {
         if (path == null)
         {
            throw new ArgumentNullException();
         }
         if (path == "")
         {
            throw new ArgumentException();
         }
         this.fileName = path;
      }
      /// <summary>
      /// Метод для считывания из файла
      /// </summary>
      /// <returns>Возвращает текст из файла</returns>
      public string Read()
      {
         FileReader file = new FileReader(fileName);
         string answer = file.Read();
         minChange = answer.Length;
         file.Close();
         file = null;
         this.changed = false;
         return answer;
      }

      /// <summary>
      /// Метод записывает изменённое содержимое файла
      /// </summary>
      /// <param name="text">Текст</param>
      public void Save(string text)
      {
         FileWriter file;
         try
         {
         file = new FileWriter(fileName, FileMode.Open);
         }
         catch (FileNotFoundException)
         {
         file = new FileWriter(fileName, FileMode.Create);
         }
         if (minChange == text.Length)
         {
            file.Write("", minChange);
         }
         else
         {
            file.Write(text, minChange);
         }
         this.changed = false;
      }
      /// <summary>
      /// Метод отслеживает минимальную позицию
      /// </summary>
      /// <param name="Offset">Место где произошло изменение</param>
      public void Change(int Offset)
      {
         if (minChange > Offset)
         {
            minChange = Offset;
            changed = true;
         }
      }

   }


}
