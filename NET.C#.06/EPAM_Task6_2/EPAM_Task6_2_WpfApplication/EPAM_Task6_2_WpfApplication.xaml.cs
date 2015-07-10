using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using EPAM_Task6_2_Library;

namespace EPAM_Task6_2_WpfApplication
{
   /// <summary>
   /// Логика взаимодействия для MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      FileReader file;
      int pos;// текущая позиция
      string pass; // Введенный Пароль
      public MainWindow()
      {
         InitializeComponent();
      }

      private void MenuItem_Click(object sender, RoutedEventArgs e)
      {
         OpenFileDialog openFileDialog1 = new OpenFileDialog();
         openFileDialog1.InitialDirectory = "f:\\";
         openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
         openFileDialog1.FilterIndex = 1;
         openFileDialog1.RestoreDirectory = true;

         if (openFileDialog1.ShowDialog() == true)
         {
            TextBox1.Text = "";
            Label1.Content = "0% файла прочитано";
            pos = 0;
            ScrollBar1.Value = pos;
            file = new FileReader(openFileDialog1.FileName);
            ScrollBar1.Maximum = file.FileLenght;
         }
      }

      private void ScrollBar1_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
      {

         if (Mouse.LeftButton.ToString() == "Released")
         {
            if (pos > (int)ScrollBar1.Value || file == null)
            {
               ScrollBar1.Value = pos;
            }
            else
            {
               Window1 passWindow = new Window1();
               if (passWindow.ShowDialog() == true)
               {
                  passWindow.Label2.Content = "";
                  pass = passWindow.PasswordBox1.Password;
               }
               try
               {
                  TextBox1.Text += file.Read((int)ScrollBar1.Value, pass);
               }
               catch (Exception ex)
                  {
                     if (ex.Message == "Пароль введён неправильно")
                     {
                        Label2.Content = "Пароль введён неправильно!";
                        ScrollBar1.Value = pos;
                        return;
                     }
                  }
               Label2.Content = "";
               pos = (int)ScrollBar1.Value;
               if (TextBox1.Text.Length / ScrollBar1.Maximum == 1)
               {
                  Label1.Content = "100% файла прочитано";
               }
               else
               {
                  Label1.Content = Convert.ToString((TextBox1.Text.Length / ScrollBar1.Maximum) * 100).Remove(4) + "% файла прочитано";
               }
            }
         }
      } 
   }
}
