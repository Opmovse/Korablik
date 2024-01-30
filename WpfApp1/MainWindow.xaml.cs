using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Net.Sockets;
using System.Net;

namespace WpfApp1
{
    /// <summary>   
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Socket> clients = new List<Socket>();
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        bool UrTurn = true;
        FloatingWindow floatingWindow = new FloatingWindow();
        public MainWindow()
        {
            
            InitializeComponent();
            Application.Current.MainWindow = this;
            floatingWindow.ShowDialog();

            

            IPAddress clientAddress = IPAddress.Parse("127.0.0.1");


            // Создаем объект IPEndPoint и Socket для подключения к серверу
            IPEndPoint ClientipEndPoint = new IPEndPoint(clientAddress, 5555);

            // Подключаемся к серверу
            clientSocket.ConnectAsync("127.0.0.1", 5555);
            RecieveMessage();


            Field.PresetField();
            //Field.RandomizeField();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button newButton = new Button()
                    {
                        Background = new SolidColorBrush(Color.FromRgb(110, 110, 255)),
                        Content = "?",

                    };

                    Grid.SetRow(newButton, i);
                    Grid.SetColumn(newButton, j);


                    //bool Genered = false;
                    newButton.Click += (sender, e) =>
                    {

                        if (UrTurn)
                        {
                            Button clickedButton = (Button)sender;

                            int rowIndex = Grid.GetRow(clickedButton);
                            int columnIndex = Grid.GetColumn(clickedButton);


                            if (newButton.IsEnabled)
                            {
                                if (Field.Field10x10[rowIndex][columnIndex])
                                {
                                    newButton.Content = "X";
                                    //MessageBox.Show($"В клетке [{rowIndex + 1},{columnIndex + 1}] оказался корабль! ");   
                                }
                                else
                                {
                                    newButton.Content = "-";
                                    //MessageBox.Show($"В клетке [{rowIndex + 1},{columnIndex + 1}] не оказалось корабля! ");
                                }
                                newButton.IsEnabled = false;

                                SendMassage(clients[0], $"{rowIndex}{columnIndex}");


                            }
                        }
                        UrTurn = false;
                    };
                    Opponent.Children.Add(newButton);

                }
            }
        }
        

        public void ChoosingHost()
        {
            if ((bool)floatingWindow.ImHost.IsChecked)
            {
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                int port = 5555;

                // Создаем объекты IPEndPoint и Socket
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);

                // Привязываем сокет к IP адресу и запускаем прослушивание
                serverSocket.Bind(ipEndPoint);
                serverSocket.Listen(10);
                ListenToClients();
            }
            
            if ((bool)floatingWindow.ImPlayer.IsChecked)
            {
                if (clients.Count == 0)
                {
                    MessageBox.Show("Ты долбаеб. Сам с собой играть собрался?");
                    throw new Exception();
                }
                IPAddress clientAddress = IPAddress.Parse(floatingWindow.IPtoConnect.Text.Trim()); 


                // Создаем объект IPEndPoint и Socket для подключения к серверу
                IPEndPoint ClientipEndPoint = new IPEndPoint(clientAddress, 5555);

                // Подключаемся к серверу
                clientSocket.ConnectAsync(clientAddress, 5555);
                RecieveMessage();
                
            }
        }
        private async Task ListenToClients()
        {
            while (true)
            {
                var client = await serverSocket.AcceptAsync();
                clients.Add(client);
            }
        }
        private async Task SendMassage(Socket socket, string cords)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(cords);
            await socket.SendAsync(bytes, SocketFlags.None);
        }
        private async Task RecieveMessage(Socket client)
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await client.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                UrTurn = true;
                
            }
        }
        private async Task RecieveMessage()
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await clientSocket.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                UrTurn = true;
                MessageBox.Show($"{message[0]},{message[1]}");
            }
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

        /*private void Button_Click(object sender, RoutedEventArgs e)
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

            
        }*/

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