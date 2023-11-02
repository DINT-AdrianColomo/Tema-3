using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UT3_PixelArt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SolidColorBrush color;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void CrearCuadricula(int size)
        {
            cuadricula.Children.Clear();
            borde.BorderBrush = Brushes.Black;
            borde.BorderThickness = new Thickness(1);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Border border = new Border();
                    border.BorderThickness = new Thickness(0.5);
                    border.BorderBrush = Brushes.LightGray;
                    TextBlock textBlock = new TextBlock();
                    border.Child = textBlock;
                    textBlock.Background = Brushes.White;
                    textBlock.MouseLeftButtonDown += TextBlock_MouseLeftButtonDown;
                    textBlock.MouseEnter += TextBlock_MouseEnter;
                    cuadricula.Children.Add(border);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button? btn = sender as Button;
            int size = int.Parse(btn.Tag.ToString());
            CrearCuadricula(size);
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border? border = sender as Border;
            border.Background = Brushes.Blue;
        }
        private void TextBlock_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            TextBlock border = (TextBlock)sender;
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                border.Background = color;
            }
        }
        private void TextBlock_MouseEnter(object sender, RoutedEventArgs e)
        {
            TextBlock border = (TextBlock)sender;
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                border.Background = color;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton? radio = sender as RadioButton;
            if (radio.Tag.ToString() != "personalizado")
            {

                color = (SolidColorBrush)new BrushConverter().ConvertFrom(radio.Tag.ToString());
                if (colorPersonalizado != null)
                {
                    colorPersonalizado.IsEnabled = false;
                    }
            }
            else
            {
                colorPersonalizado.IsEnabled = true;
                try
                {
                    if (colorPersonalizado.Text.StartsWith('#'))
                    {
                        color = (SolidColorBrush)new BrushConverter().ConvertFrom(colorPersonalizado.Text);
                    }
                }
                catch (Exception ex)
                {
                    color = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFFFF");
                }
            }
        }
        private void Rellenar_Click(object sender, RoutedEventArgs e)
        {
            foreach (Border border in cuadricula.Children)
            {
                if (border.Child is TextBlock textBlock)
                {
                    textBlock.Background = color;
                }
            }
        }
    }
}
