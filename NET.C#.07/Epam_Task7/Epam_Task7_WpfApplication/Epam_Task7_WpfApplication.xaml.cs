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
using Epam_Task7_Library;

namespace Epam_Task7_WpfApplication
{
   /// <summary>
   /// Логика взаимодействия для MainWindow.xaml
   /// </summary>
   /// 

   public class TestRow
   {
      private double[] _values;
      public double[] Values
      {
         get { return _values; }
         set { _values = value; }
      }

      public TestRow(double[] seed)
      {
         _values = new double[seed.Length];
         seed.CopyTo(Values,0);
      }
   }

   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
         DataGrid1.Height = Double.NaN;
         DataGrid1.Width = Double.NaN;
         DataGrid2.Height = Double.NaN;
         DataGrid2.Width = Double.NaN;
         DataGrid3.Height = Double.NaN;
         DataGrid3.Width = Double.NaN;

         List<int> a = new List<int>(){2,3,4,5,6,7,8,9,10};
         ComboBox1.ItemsSource = a;
         ComboBox2.ItemsSource = a;
         ComboBox3.ItemsSource = a;
         ComboBox4.ItemsSource = a;
         int i = (int)ComboBox1.SelectedValue;
         int j = (int)ComboBox2.SelectedValue;
         double[,] mas = new double[i, j];
         DataGrid1.ItemsSource = null;
         AddRows(mas, DataGrid1);
         int k = (int)ComboBox3.SelectedValue;
         int o = (int)ComboBox4.SelectedValue;
         double[,] mas1 = new double[k, o];
         DataGrid2.ItemsSource = null;
         AddRows(mas1, DataGrid2);
      }

      private void Button_Click(object sender, RoutedEventArgs e)
      {
         int i = (int)ComboBox1.SelectedValue;
         int j = (int)ComboBox2.SelectedValue;
         double[,] mas = new double[i, j];
         DataGrid1.ItemsSource = null;
         AddRows(mas,DataGrid1);
      }

      private void AddRows(double[,] mas,DataGrid grid)
      {
         grid.Columns.Clear();
         var data = new TestRow[mas.GetLength(0)];
         for (int i = 0; i < mas.GetLength(0); i++)
         {
            double[] mas1 = new double[mas.GetLength(1)];
            for (int j = 0; j < mas.GetLength(1); j++)
            {
               mas1[j] = mas[i, j];
            }
            data[i] = new TestRow(mas1);
         }
         grid.AutoGenerateColumns = false;
         for (int i = 0; i < data[0].Values.Length; i++)
         {
            var col = new DataGridTextColumn();
            var binding = new Binding("Values[" + i + "]");
            col.Binding = binding;
            grid.Columns.Add(col);
         }
         grid.ItemsSource = data;
      }

      private void Button2_Click(object sender, RoutedEventArgs e)
      {
         int i = (int)ComboBox3.SelectedValue;
         int j = (int)ComboBox4.SelectedValue;
         double[,] mas = new double[i, j];
         DataGrid2.ItemsSource = null;
         AddRows(mas, DataGrid2);
      }


      private double[,] GetMassive(DataGrid grid)
      {
         var data = (TestRow[])grid.ItemsSource;
         double[,] mas1 = new double[data.Length, data[1].Values.Length];
         for (int i = 0; i < data.Length; i++)
         {
            for (int j = 0; j < data[i].Values.Length; j++)
            {
               mas1[i, j] = data[i].Values[j];
            }
         }
         return mas1;
      }

      private void Button_Click_1(object sender, RoutedEventArgs e)
      {
         try
         {
            MatrixClass c = new MatrixClass(GetMassive(DataGrid1)) + new MatrixClass(GetMassive(DataGrid2));
            AddRows(c.Matrix, DataGrid3);
         }
         catch (MatrixException ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void Button_Click_2(object sender, RoutedEventArgs e)
      {
         try
         {
            MatrixClass c = new MatrixClass(GetMassive(DataGrid1)) - new MatrixClass(GetMassive(DataGrid2));
            AddRows(c.Matrix, DataGrid3);
         }
         catch (MatrixException ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void Button_Click_3(object sender, RoutedEventArgs e)
      {
         try
         {
            MatrixClass c = new MatrixClass(GetMassive(DataGrid1)) * new MatrixClass(GetMassive(DataGrid2));
            AddRows(c.Matrix, DataGrid3);
         }
         catch (MatrixException ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void Button4_Click(object sender, RoutedEventArgs e)
      {
         try
         {
            MatrixClass c = MatrixClass.InverseMatrix(new MatrixClass(GetMassive(DataGrid1)));
            AddRows(c.Matrix, DataGrid3);
         }
         catch (MatrixException ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void Button5_Click(object sender, RoutedEventArgs e)
      {
         try
         {
            MatrixClass c = MatrixClass.InverseMatrix(new MatrixClass(GetMassive(DataGrid2)));
            AddRows(c.Matrix, DataGrid3);
         }
         catch (MatrixException ex)
         {
            MessageBox.Show(ex.Message);
         }
      }



   }
}
