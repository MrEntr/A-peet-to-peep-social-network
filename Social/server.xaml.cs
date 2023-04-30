using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace Social
{
    /// <summary>
    /// Логика взаимодействия для server.xaml
    /// </summary>
    public partial class server : Window
    {
        private Server s;
        private Client client;

        public server(string login)
        {
            InitializeComponent();
            s = new Server(this, list2);
            client = new Client(login, List, "127.0.0.1");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            client.SendMessage(box.Text);
            box.Text = null;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MainWindow s = new MainWindow();
            s.Show();
            Close();
        }

        private void box_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (box.Text == "/disconect")
            {
                MainWindow s = new MainWindow();
                s.Show();
                Close();
            }
        }
    }
}
