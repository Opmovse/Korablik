using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void Main()
    {
        // Устанавливаем IP адрес и порт для сервера
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        int port = 12345;

        // Создаем объекты IPEndPoint и Socket
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Привязываем сокет к IP адресу и запускаем прослушивание
        serverSocket.Bind(ipEndPoint);
        serverSocket.Listen(10);

        Console.WriteLine("Сервер запущен и ожидает подключения...");

        // Принимаем подключение от клиента
        Socket clientSocket = serverSocket.Accept();

        Console.WriteLine("Клиент подключен");

        // Получаем сообщение от клиента
        byte[] buffer = new byte[1024];
        int bytesRead = clientSocket.Receive(buffer);
        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        Console.WriteLine("Клиент: " + message);

        // Отправляем ответ клиенту
        string replyMessage = "Привет, я сервер!";
        byte[] replyBuffer = Encoding.UTF8.GetBytes(replyMessage);
        clientSocket.Send(replyBuffer);

        // Закрываем соединение
        clientSocket.Shutdown(SocketShutdown.Both);
        clientSocket.Close();
    }
}