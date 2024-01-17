using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        // Устанавливаем IP адрес и порт сервера
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        int port = 12345;

        // Создаем объект IPEndPoint и Socket для подключения к серверу
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Подключаемся к серверу
        clientSocket.Connect(ipEndPoint);
        Console.WriteLine("Подключение к серверу установлено");

        // Отправляем сообщение серверу
        string message = "Привет, я клиент!";
        byte[] buffer = Encoding.UTF8.GetBytes(message);
        clientSocket.Send(buffer);

        // Получаем ответ от сервера
        byte[] replyBuffer = new byte[1024];
        int bytesRead = clientSocket.Receive(replyBuffer);
        string replyMessage = Encoding.UTF8.GetString(replyBuffer, 0, bytesRead);
        Console.WriteLine("Сервер: " + replyMessage);

        // Закрываем соединение
        clientSocket.Shutdown(SocketShutdown.Both);
        clientSocket.Close();
    }
}