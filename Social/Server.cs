using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Controls;

namespace Social
{
    internal class Server
    {
        private Socket soket;
        private List<Socket> clients = new List<Socket>();
        private server myWIndow;
        private List<string> usernames = new List<string>();
        public Server( server server, ListBox listBox)

        {
            myWIndow = server;
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 8888);
            soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            soket.Bind(ipPoint);
            soket.Listen(1000);
            ListenToClients();
        }

        private async Task ListenToClients()
        {
            while (true)
            {
                var client = await soket.AcceptAsync();
                clients.Add(client);
                RecievieMessage(client);

                //через форыч пробегаться по всем юзерам и отправлять юзернеймы
            }
        }
        private async Task RecievieMessage(Socket client)
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await client.ReceiveAsync(new ArraySegment<byte>( bytes), SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);

                if (message.StartsWith("/username "))
                {
                    string[] a = message.Split(' ');  
                    myWIndow.list2.Items.Add("Пользователь: " + a[1]);
                    //добавить этот юзернейм в лист с юзерами
                                                        }
               // myWIndow.List.Items.Add($"[Собщение {DateTime.UtcNow}]: {message}");

                foreach (var item in clients)
                {
                    SendMessage(item, message);
                }
            }

        }
        private async Task SendMessage(Socket client, string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            client.Send(bytes, SocketFlags.None);

        }
    }
}