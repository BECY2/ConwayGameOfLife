using System.Diagnostics.Metrics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CurrencyConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int size = 100;
        int[,] matrix;
        public MainWindow()
        {
            InitializeComponent();
            matrix = new int[size, size];
            Generalas();
        }
      

        private void Generalas() {
            //buttonMatrix = new Button[size, size];
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();
            grid.Children.Clear();
            for (int i = 0; i < size; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //Label uj = new();
                    Button uj = new();
                    uj.VerticalAlignment = VerticalAlignment.Stretch;
                    uj.HorizontalAlignment = HorizontalAlignment.Stretch;
                    uj.BorderBrush = new SolidColorBrush(Colors.White);
                    uj.BorderThickness = new Thickness(0.5,0.5,0.5,0.5);
                    if (matrix[i, j] == 0)
                    {
                        uj.Background = new SolidColorBrush(Colors.Black);
                    }
                    else {
                        uj.Background = new SolidColorBrush(Colors.White);
                    }
                    Grid.SetRow(uj, i);
                    Grid.SetColumn(uj, j);
                    
                    uj.Click += matrixgomb_Click;
                    grid.Children.Add(uj);  
                }
            }
        }
        private void matrixgomb_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            //MessageBox.Show(b.Content.ToString());
            b.Background = new SolidColorBrush(Colors.White);
            matrix[Grid.GetRow(b), Grid.GetColumn(b)] = 1;
            //MessageBox.Show(matrix[Grid.GetRow(b), Grid.GetColumn(b)].ToString());
        }

        public void OneNight()
        {

            for (int i = 0; i < size; i++)
            {
                for (int f = 0; f < size; f++)
                {
                    int db = Check(i, f);
                    if (matrix[i,f] ==1 && db < 2) {
                        matrix[i, f] = 0;
                    }
                    else if (matrix[i, f] == 0 && db == 3)
                    {
                        matrix[i, f] = 1;
                    }
                    else if (matrix[i, f] == 1 && db > 3)
                    {
                        matrix[i, f] = 0;
                    }
                }
            }

            Generalas();
        }

        public async void Gen(object sender, RoutedEventArgs s) { 
        
            for (int i = 0;i < 20; i++)
            {
                OneNight();
                await Task.Delay(1);
            }
        }

        public int Check(int r, int c) {


            
            int db = 0;
            if (r > 0)
            {
                if (c>0)
                {
                    if (matrix[r - 1, c - 1] == 1)
                    {
                        db++;
                    }
                }
             
                if (matrix[r - 1, c] == 1)
                {
                    db++;
                }
                if (c<size-1) {
                    if (matrix[r - 1, c + 1] == 1)
                    {
                        db++;
                    }
                }
            }

            if (r < size-1)
            {
                if (c > 0)
                {
                    if (matrix[r + 1, c - 1] == 1)
                    {
                        db++;
                    }
                }
                if (matrix[r + 1, c] == 1)
                {
                    db++;
                }
                if (c < size-1)
                {
                    if (matrix[r + 1, c + 1] == 1)
                    {
                        db++;
                    }
                }
            }

            if (c > 0)
            {
                if (matrix[r, c - 1] == 1)
                {
                    db++;
                }
            }
            if (c < size - 1) {
                if (matrix[r, c + 1] == 1) {
                    db++;
                }
            }
            
            
           
            return db;
        }
    }
    
}