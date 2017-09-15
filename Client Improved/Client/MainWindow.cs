using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using Client.Common;

namespace Client
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            try
            {
                //блокировка полей
                ShowMessages.Enabled = false;
                SendButtom.Enabled = false;
                InputMessages.Enabled = false;

                //наличие файла натроек
                if (!File.Exists(@"Settings.inf"))
                {
                    SettingsForm setingsOpen = new SettingsForm();

                    setingsOpen.ShowDialog();
                }

                //показ текущей информации о подключении
                ShowCurrentInfo();


            }
            catch (Exception ex)
            {
                Error_Info errBox = new Error_Info(ex.Message);
                errBox.ShowDialog();
            }
        }

        static private Socket _client;
        private IPAddress _ip;
        private int _port;

        //показ данных о подключении
        void ShowCurrentInfo()
        {
            try
            {
                ShowMessages.Text = "";
                if (!File.Exists(@"Settings.inf"))
                {
                    throw (new Exception("Файл настроек отсутствует!"));
                }
                //считывание файла настроек
                StreamReader settings = new StreamReader(@"Settings.inf");

                string buffer = settings.ReadToEnd();

                settings.Close();

                //парсинг настроек
                string[] ipAndPort = buffer.Split(':');

                if (ipAndPort.Count() != 2)
                {
                    throw (new Exception("Не правильный файл настроек"));
                }

                IPAddress[] DNSToIP = Dns.GetHostAddresses(ipAndPort[0]);

                for (int i = 0; i < DNSToIP.Length; i++)
                {
                    if (DNSToIP[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        _ip = DNSToIP[i];

                    }
                }

                if (_ip == null)
                    throw (new Exception("IP Адрес не работает по нужному протоколу!"));

                _port = int.Parse(ipAndPort[1]);

                ShowMessages.Text += "Настройки загружены" + '\n' +
                                     "Сервер IP: " + ipAndPort[0] + "\nПорт: " + ipAndPort[1] + '\n';
            }
            catch (Exception ex)
            {
                ShowMessages.Text += "Настройки подключения не загружены!" + '\n';
                throw (ex);
            }
        }

        private void SendButtom_Click(object sender, EventArgs e)
        {
            try
            {
                string sendMessage = InputMessages.Text;
                byte[] sendBytes = Encoding.UTF8.GetBytes(sendMessage);
                if (sendBytes.Length < CommonConstants.MessageLength)
                    _client.Send(sendBytes);
                else
                {
                    Array.Resize(ref sendBytes, CommonConstants.MessageLength);
                    _client.Send(sendBytes);
                }
                InputMessages.Text = "";

            }
            catch (Exception ex)
            {
                Error_Info errBox = new Error_Info(ex.Message);
                errBox.ShowDialog();
                //критическая ошибка
                Application.Restart();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Settings_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsForm setingsOpen = new SettingsForm();

                setingsOpen.ShowDialog();

                ShowCurrentInfo();
            }
            catch (Exception ex)
            {

                Error_Info errBox = new Error_Info(ex.Message);
                errBox.ShowDialog();
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ReceiveMessages(object obj)
        {
            try
            {
                while (true)
                {
                    byte[] receivedData = new byte[1024];

                    Array.Clear(receivedData, 0, receivedData.Length);

                    _client.Receive(receivedData);

                    this.Invoke((MethodInvoker)delegate ()
                    {
                        ShowMessages.AppendText('\n' + Encoding.UTF8.GetString(receivedData));
                        ShowMessages.ScrollToCaret();
                    });
                }
            }
            catch (Exception ex)
            {
                Error_Info errBox = new Error_Info(ex.Message);
                errBox.ShowDialog();
                //критическая ошибка
                Application.Restart();
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (NickBox.Text.Length > 20)
                    throw (new Exception("Ник слишком длинный"));

                if (NickBox.Text.Length < 1)
                    throw (new Exception("Ник слишком короткий"));

                _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _client.Connect(_ip, _port);

                Thread receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();

                _client.Send(Encoding.UTF8.GetBytes(NickBox.Text));

                //перераспределение окна
                NickBox.Enabled = false;
                ConnectToChatButton.Enabled = false;
                ShowMessages.Enabled = true;
                SendButtom.Enabled = true;
                InputMessages.Enabled = true;


            }
            catch (Exception ex)
            {
                NickBox.Text = "";
                Error_Info errBox = new Error_Info(ex.Message);
                errBox.ShowDialog();
            }
        }

        private void EnterSending(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (InputMessages.Text[InputMessages.Text.Length - 1] == '\n')
                    InputMessages.Text = InputMessages.Text.Substring(0, InputMessages.Text.Length - 1);
                SendButtom_Click(null, null);
            }
        }
    }
}
