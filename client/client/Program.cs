using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ConsoleClient
{
    class Program
    {
        const int port = 8888;
        const string address = "127.0.0.1";
        static void Main(string[] args)
        {
            Console.Write("Enter your`s name:");
            string userName = Console.ReadLine();

            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);
                while (true)
                {
                    Console.Write(userName + ": ");
                    // ввод сообщения
                    string message1 = Console.ReadLine();
                    string message = userName + ": " + message1;
                    byte[] data = Encoding.Unicode.GetBytes(message);

                    socket.Send(data);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
