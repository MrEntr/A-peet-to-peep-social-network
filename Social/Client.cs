using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using System.Net;
using System.Windows.Controls;

namespace Social
{
    internal class Client
    {
        private Socket socket;
        private List<Socket> clients = new List<Socket>();

        private ListBox ListBox;
        private List<string> usernames = new List<string>();

        public Client(string login, ListBox listBox, string ip)
        {
            ListBox = listBox;
            /*new server().Show();*/
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ip, 8888);
            //RecieveMessage();
            SendMessage("/username " + login);
            RecieveMessage();
        }
        public async void SendMessage(string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await socket.SendAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
        }
        private async void RecieveMessage()
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await socket.ReceiveAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                ListBox.Items.Add($"[Собщение {DateTime.UtcNow}]: {message}");
              
            }
        }
    }
}

