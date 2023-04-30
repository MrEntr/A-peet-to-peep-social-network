using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Social
{
   
    public partial class MainWindow : Window
        
    {
        private string login;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void log_GotFocus(object sender, RoutedEventArgs e)
        {
            log.Text = "";

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (log.Text == null && log.Text == string.Empty)
            {
                MessageBox.Show("Вы не ввели дааные");
            }
            else
            {
                
                server sr = new server(log.Text);
                sr.Show();
                Close();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(IP.Text, "^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$") && log.Text != null && log.Text != string.Empty)
            {               
                social sr = new social(log.Text, IP.Text);
                sr.Show();
                Close();

            }
            else
            {
                MessageBox.Show("Вы не ввели дааные");
            }
        }

        private void ip_GotFocus(object sender, RoutedEventArgs e)
        {
            IP.Text = "";
        }

        private void IP_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }

        private void log_TextChanged(object sender, TextChangedEventArgs e)
        {
        
        }
    }

}
