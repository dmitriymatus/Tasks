using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
using Epam_Task9_Library;

namespace Epam_Task_9
{
   /// <summary>
   /// Логика взаимодействия для MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      UsedFile file = null;
      public MainWindow()
      {
         InitializeComponent();
      }

      private void NewItem_Click(object sender, RoutedEventArgs e)
      {
         if ((file == null && TextBox1.Text != "") || (file != null && file.changed == true))
         {
            string messageBoxText = "Сохранить изменения в файле?";
            string caption = "Word Processor";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            // Process message box results
            switch (result)
            {
               case MessageBoxResult.Yes:
                  SaveItem_Click(this, new RoutedEventArgs());
                  TextBox1.Text = "";
                  file = null;
                  break;
               case MessageBoxResult.No:
                  TextBox1.Text = "";
                  file = null;
                  break;
               case MessageBoxResult.Cancel:
                  break;
            }
         }
         else
         {
            TextBox1.Text = "";
         }
      }

      private void OpenItem_Click(object sender, RoutedEventArgs e)
      {
         OpenFileDialog openFileDialog1 = new OpenFileDialog();
         openFileDialog1.InitialDirectory = "f:\\";
         openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
         openFileDialog1.FilterIndex = 1;
         if (openFileDialog1.ShowDialog() == true)
         {
               SaveItem_Click(this,new RoutedEventArgs());
               file = null;
               file = new UsedFile(openFileDialog1.FileName);
               TextBox1.Text = file.Read();
               file.changed = false;
         }
      }

      private void SaveItem_Click(object sender, RoutedEventArgs e)
      {
         if (file != null && file.changed == true)
         {
            file.Save(TextBox1.Text);
         }
         if (file == null && TextBox1.Text != "")
         {
            SaveAsItem_Click(this,new RoutedEventArgs());
         }
      }

      private void SaveAsItem_Click(object sender, RoutedEventArgs e)
      {
         if (TextBox1.Visibility == System.Windows.Visibility.Visible)
         {
            SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".text"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            if (dlg.ShowDialog() == true)
            {
               file = new UsedFile(dlg.FileName);
               file.Save(TextBox1.Text);
            }
         }
      }
      private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
      {
         if (file != null)
         {
            ICollection<TextChange> a = e.Changes;
            foreach (var t in a)
            {
               if (t.AddedLength != t.RemovedLength || t.Offset != 1)
               {
                  file.Change(t.Offset);
               }
            }          
         }
      }
   }
}
