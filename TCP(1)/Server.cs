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
        int port = 55554;

        // Создаем объекты IPEndPoint и Socket
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Привязываем сокет к IP адресу и запускаем прослушивание
        serverSocket.Bind(ipEndPoint);
        serverSocket.Listen(10);


        // Принимаем подключение от клиента
        Socket clientSocket = serverSocket.Accept();

   

        // Получаем сообщение от клиента
        byte[] buffer = new byte[1024];
        int bytesRead = clientSocket.Receive(buffer);
        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        

        // Отправляем ответ клиенту
        string replyMessage = ;
        byte[] replyBuffer = Encoding.UTF8.GetBytes(replyMessage);
        clientSocket.Send(replyBuffer);

        // Закрываем соединение
        clientSocket.Shutdown(SocketShutdown.Both);
        clientSocket.Close();
    }
}