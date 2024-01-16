using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Media;

namespace WpfApp1
{
    /// <summary>   
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

           

        }

        #region Кнопка


        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            Program.Main();
            MessageBox.Show(Car.All.Select(x => x.Name).ToList()[1]);

            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.StartPoint = new Point(0, 0);
            gradientBrush.EndPoint = new Point(1, 1);

            // Add gradient stops with different colors
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Blue, 0.0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Green, 0.5));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 1.0));

            // Set the button's background to the LinearGradientBrush
            KNOPKA.Background = gradientBrush;
        }*/
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int Litri = 0;
            int current = 0;
            int amountBig = 0;
            int amountSmall = 0;
            int amount = 0;
            Griddy.Children.Clear();
            Griddy2.Children.Clear();

            Litri = int.Parse(Letres.Text);
            for (; current < Litri;)
            {
                if ((current + 4 > current + 3) && (current + 4 <= Litri))
                {
                    current += 4;
                    amountBig++;
                    Griddy.Children.Add(CreateBlueBorder());
                }
                else if (current + 3 <= Litri)
                {
                    current += 3;
                    amountSmall++;
                    Griddy2.Children.Add(CreateRedBorder());
                }
                else
                {
                    break;
                }
            }

            MessageBox.Show($"Заполнено {current} литров\n" +
                            $"Малых бочек: {amountSmall}\n" +
                            $"Больших бочек: {amountBig}\n" +
                            $"Всего бочек {amount = amountBig + amountSmall}");

            
        }

        private Border CreateBlueBorder()
        {
            return new Border()
            {
                CornerRadius = new CornerRadius(50),
                Background = new SolidColorBrush() { Color = Colors.Blue },
                BorderBrush = new SolidColorBrush() { Color = Colors.Black },
                Height = 20,
                Width = 30,
                Margin = new Thickness(10),
            };
        }

        private Border CreateRedBorder()
        {
            return new Border()
            {
                CornerRadius = new CornerRadius(50),
                Background = new SolidColorBrush() { Color = Colors.Red },
                BorderBrush = new SolidColorBrush() { Color = Colors.Black },
                Height = 30,
                Width = 40,
                Margin = new Thickness(10),
            };
        }


    }
}