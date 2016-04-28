using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
//using System.Timers;
using System.Threading;

namespace SocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  Timer myTimer = new Timer();
              myTimer.Elapsed += new ElapsedEventHandler(Go);
              myTimer.Interval = 2000;
              myTimer.Start();


              while (Console.Read() != 'q')
              {
                  ;
             
            User user1 = new User { user = "Margaret"};
            User user2 = new User { user = "John" };*/

            try
            {
                User user1 = new User { user = "Margaret" };
                SendMessageFromSocket(11000, user1);
                Thread.Sleep(27500);
                User user2 = new User { user = "John" };
                SendMessageFromSocket(11000, user2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }

        static void SendMessageFromSocket(int port, User Us)
        {
            // Буфер для входящих данных
            byte[] bytes = new byte[1024];

            // Соединяемся с удаленным устройством

            // Устанавливаем удаленную точку для сокета
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Соединяем сокет с удаленной точкой
            sender.Connect(ipEndPoint);


            string json = JsonConvert.SerializeObject(Us);

            Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());
            byte[] msg = Encoding.UTF8.GetBytes(json);

            // Отправляем данные через сокет
            int bytesSent = sender.Send(msg);

            // Получаем ответ от сервера
            int bytesRec = sender.Receive(bytes);
            Console.WriteLine("\nОтвет от сервера: {0}\n\n", Encoding.UTF8.GetString(bytes, 0, bytesRec));


            // Освобождаем сокет
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}