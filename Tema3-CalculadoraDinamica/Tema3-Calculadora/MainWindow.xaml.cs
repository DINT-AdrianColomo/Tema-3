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

namespace Tema3_Calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Grid ButtonGrid { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            ButtonGrid = CreateButtonGrid();
            
        }
        public Grid CreateButtonGrid()
        {

            Grid grid = grid1;

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            Grid.SetRow(border1, 0);
            Grid.SetColumnSpan(border1, 3);

         
            for (int i = 0; i < 14; i++)
            {
                Button button = new Button();
                button.Tag = (i + 1);
                button.Content =  button.Tag;
                button.Click += Button_Click;

                Grid.SetRow(button, i / 3 + 1);
                Grid.SetColumn(button, i % 3);

                grid.Children.Add(button);

                button = new Button();
                button.Tag = 0;
                button.Content = button.Tag;
                button.Click += Button_Click;
                Grid.SetRow(button, 4);
                Grid.SetColumnSpan(button, 3);
                grid.Children.Add(button);
            }
            grid.Margin = new Thickness(2);
            return grid;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            textBlock.Text += (button.Tag).ToString();
        }
    }
}
