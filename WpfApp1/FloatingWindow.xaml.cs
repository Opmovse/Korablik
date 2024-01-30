using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для FloatingWindow.xaml
    /// </summary>
    public partial class FloatingWindow : Window
    {
        public FloatingWindow()
        {
            InitializeComponent();

            IPtoConnect.Visibility = Visibility.Collapsed;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e) //host
        {
            IPtoConnect.Visibility = Visibility.Collapsed;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e) //player
        {
            IPtoConnect.Visibility = Visibility.Visible;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /*if (!((bool)ImHost.IsChecked && (bool)ImPlayer.IsChecked))
            { 
                Application.Current.Shutdown();
            }*/
                
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).ChoosingHost(); 
            this.Close();
            
        }
    }
}
