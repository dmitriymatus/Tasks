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
using Epam_Task1;
namespace EPAM_Task1_WpfApplication
{
   /// <summary>
   /// Логика взаимодействия для MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
      }

      private void Button_Click(object sender, RoutedEventArgs e)
      {
         TextRange inputText = new TextRange(RichTextBox1.Document.ContentStart, RichTextBox1.Document.ContentEnd);
         string inputString = inputText.Text;
         TextBox1.Text = (MyConvert.ConvertFunc(inputString));
      }
   }
}
