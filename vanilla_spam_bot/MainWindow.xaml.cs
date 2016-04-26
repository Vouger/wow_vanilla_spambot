using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using HtmlAgilityPack;


namespace VanillaSpamBot
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        public Thread thread;
        public MainWindow()
        {
            InitializeComponent();

            foreach (Process p in Process.GetProcessesByName("wow"))
            {
                try
                {
                    if (!string.IsNullOrEmpty(p.MainWindowTitle))
                    {
                        var data = new Test { Test1 = p.MainWindowTitle, Test2 = p.Id.ToString() };

                        dataGrid1.Items.Add(data);
                    }
                }
                catch { }
            }

            
        }

        private void ButtonStartClick(object sender, RoutedEventArgs e)
        {
            Test t = (Test)dataGrid1.SelectedItem;
            IntPtr hWnd_wow;
            if (t != null)
            {
                hWnd_wow = Process.GetProcessById(Int32.Parse(t.Test2)).MainWindowHandle;
            }
            else
            {
                Process[] pr = Process.GetProcessesByName("wow");
                hWnd_wow = Process.GetProcessById(pr[0].Id).MainWindowHandle;
            }

            string text = textMessage.Text;
            int pause = Int32.Parse(pauseBox.Text);
            int relog = Int32.Parse(relogBox.Text);

            string side = "Horde";
            label1.Content = "Horde nicknames";
            if (radioAlliance.IsChecked == true)
            {
                side = "Alliance";
                label1.Content = "Alliance nicknames";
            }

            string server = "NRB";
            if (radioPve.IsChecked == true)
            {
                server = "NBE";
            }

            thread = new Thread(() => Spam(hWnd_wow, text, pause, relog, side, server));
            thread.Start();

        }

        private void ButtonStopClick(object sender, RoutedEventArgs e)
        {
            thread.Abort();
        }


        private void ButtonGetNicknamesClick(object sender, RoutedEventArgs e)
        {
            GetPlayers();
        }

        private void GetPlayers() {
            dataGrid2.Items.Clear(); ;
            WebClient client = new WebClient();
            for (int j = 1; j <= 25; j++)
            {
                string side = "Horde";
                label1.Content = "Horde nicknames";
                if (radioAlliance.IsChecked == true) {
                   side = "Alliance";
                   label1.Content = "Alliance nicknames";
                }
                string playersSite = client.DownloadString("http://realmplayers.com/CharacterList.aspx?search=&realm=NRB&race="+ side + "&sort=Seen&page="+j);
               
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(playersSite);

                foreach (var row in doc.DocumentNode.SelectNodes("//table[@class = 'table']/tbody/tr"))
                {
                    var player = new Player();
                    int i = 0;
                    foreach (var cell in row.SelectNodes("td"))
                    {
                        if (i == 0)
                        {
                            player.Rank = cell.InnerText;
                        }

                        if (i == 1)
                        {
                            player.Name = cell.InnerText;
                        }

                        if (i == 2)
                        {
                            player.Guild = cell.InnerText;
                        }

                        if (i == 3)
                        {
                            player.Level = cell.InnerText;
                        }

                        i++;
                    }
                    dataGrid2.Items.Add(player);

                }
                label1.Content += " " + dataGrid2.Items.Count;
            }
        }

        private List<Player> GetPlayers2(string side, string server )
        {
            List<Player> players = new List<Player>();
            WebClient client = new WebClient();
            for (int j = 1; j <= 2; j++)
            {
                string playersSite = client.DownloadString("http://realmplayers.com/CharacterList.aspx?search=&realm="+ server + "&race=" + side + "&sort=Seen&page=" + j);

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(playersSite);

                foreach (var row in doc.DocumentNode.SelectNodes("//table[@class = 'table']/tbody/tr"))
                {
                    var player = new Player();
                    int i = 0;
                    foreach (var cell in row.SelectNodes("td"))
                    {
                        if (i == 0)
                        {
                            player.Rank = cell.InnerText;
                        }

                        if (i == 1)
                        {
                            player.Name = cell.InnerText;
                        }

                        if (i == 2)
                        {
                            player.Guild = cell.InnerText;
                        }

                        if (i == 3)
                        {
                            player.Level = cell.InnerText;
                        }

                        i++;
                    }
                    players.Add(player);
                }
            }
            return players;
        }

        public void Spam(IntPtr hWnd_wow, string text, int pause, int relog, string side, string server)
        {
            while (true) {
                int i = 0;
                List<Player> players = GetPlayers2(side, server);
                foreach (Player row in players)
                {
                    int j = 0;
                    var rnd = new Random(DateTime.Now.Millisecond);
                    int ticks = rnd.Next(1000, pause * 1000);
                    string name = row.Name;
                    WoWSlashCommand.send(hWnd_wow, "/w " + name + " " + text + "      ("+ticks.ToString()+")");
                    Thread.Sleep(ticks);
                    if (i > 20) {
                        WoWSlashCommand.send(hWnd_wow, "/logout");
                        Thread.Sleep(relog * 1000);
                        WoWSlashCommand.enter(hWnd_wow);
                        Thread.Sleep(relog * 1000);
                        i = 0;
                    }
                    i++;
                    j++;
                    if ((j > 100 && String.Compare(server, "NBE") == 0) || (j > 50 && String.Compare(server, "NRB") == 0))
                        break;
                }
           }

        }

    }

    public class Test
    {
        public string Test1 { get; set; }
        public string Test2 { get; set; }
    }

    public class Player
    {
        public string Rank { get; set; }
        public string Name { get; set; }
        public string Guild { get; set; }
        public string Level { get; set; }
    }


}
