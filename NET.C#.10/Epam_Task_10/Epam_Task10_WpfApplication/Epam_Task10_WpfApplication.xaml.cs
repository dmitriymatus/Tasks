using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Win32;
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
using System.ComponentModel;
using Epam_Task_10_Library;

namespace Epam_Task10_WpfApplication
{
   /// <summary>
   /// Логика взаимодействия для MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      BackgroundWorker backgroundWorker1 = new BackgroundWorker();
      Epam_Task_10_Library.Timer timer = new Epam_Task_10_Library.Timer();

      public MainWindow()
      {
         InitializeComponent();
         timer.EndOfSecond += (a, ex) => { backgroundWorker1.ReportProgress(Convert.ToInt32(ex.msg)); };
         timer.EndOfTime += (a, ex) => { backgroundWorker1.ReportProgress(0); };
         backgroundWorker1.DoWork += backgroundWorker1_DoWork;
         backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
      }

      private void Button_Click(object sender, RoutedEventArgs e)
      {
         
         if (TextBox1.Text == "" || Convert.ToUInt32(TextBox1.Text)==0)
         {
            return;
         }
            Label1.Content = "";
            if (backgroundWorker1.IsBusy != true)
            {
               // Start the asynchronous operation.              
               Button.IsEnabled = false;
               backgroundWorker1.RunWorkerAsync(TextBox1.Text);              
            }
      }

      void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
      {
         Label1.Content =  Convert.ToString(e.ProgressPercentage);
         if (e.ProgressPercentage == 0)
         {
            Button.IsEnabled = true;
            backgroundWorker1.CancelAsync();
         }
      }

      private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
      {
            int time = Convert.ToInt32(e.Argument);
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.WorkerReportsProgress = true;
            timer.Start(time);
      }

   }
}
