﻿using System;
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
using Epam_Task2_2_Library;

namespace Epam_Task2_2_WpfApplication
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

      private void Button1_Click(object sender, RoutedEventArgs e)
      {
         TextBox2.Text = ConvertToBinnary.MyConvert(Convert.ToInt16(TextBox1.Text));
      }
   }
}
