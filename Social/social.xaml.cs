using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для social.xaml
    /// </summary>
    public partial class social : Window
    {
        private Socket socket;
        private Client s;
        public social(string login, string ip)
        {
            InitializeComponent();
            s = new Client(login, List, ip);

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            s.SendMessage(box.Text);
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
