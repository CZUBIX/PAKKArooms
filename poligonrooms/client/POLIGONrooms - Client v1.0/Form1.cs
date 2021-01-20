using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Media;

namespace POLIGONrooms___Client_v1._0
{
    public partial class Form1 : Form
    {
        const string ServerText = "Welcome to poligon rooms!\nGo to the \"client\" tab to connect to a server. If you want to create your own go to https://github.com/CZUBIX/POLIGONrooms and download poligonrooms/server.\n\nThen, do the following:\n    1. If you haven't already, install the latest python version from https://www.python.org/downloads/\n    2. Start server.py and close it right after (just to create the config.ini file)\n    3. Start server.py after config.ini is configured properly\n    4. Invite friends to your server!\n\nYou can also write custom plugins, which requires programming knowledge. If you have any problems, contact us. (https://discord.gg/w9FYqMDV)";

        Socket sock = null;

        private void MessageHandler()
        {
            byte[] bytes = new byte[1024];
            IPAddress ipAddress = IPAddress.Parse(host.Text);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, int.Parse(port.Text));

            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            chat.Text = $"Connecting to {host.Text}:{port.Text}...";
            socket.Connect(remoteEP);

            sock = socket;
            chat.Text = $"Connected to {host.Text}:{port.Text}\n";

            socket.Send(Encoding.ASCII.GetBytes($"USERNAME={username.Text}"));

            while (true)
            {
                try
                {
                    int bytesRec = socket.Receive(bytes);
                    chat.Text += Encoding.ASCII.GetString(bytes, 0, bytesRec) + "\n";
                    string[] lines = chat.Text.Split(Environment.NewLine.ToCharArray());
                    if (lines.Length >= 26) { chat.Text = string.Join("\n", lines.Skip(1).ToArray()); }
                }
                catch (Exception)
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chat.Text = ServerText;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sock != null)
            {
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Black), 150, 0, 150, 500);
        }

        private void server_Click(object sender, EventArgs e)
        {
            chat.Text = ServerText;
            client.BackColor = Color.FromArgb(42, 42, 42);
            client.ForeColor = Color.FromArgb(255, 255, 255);
            server.BackColor = Color.FromArgb(255, 255, 255);
            server.ForeColor = Color.FromArgb(0, 0, 0);

            host.Visible = false;
            hostText.Visible = false;
            port.Visible = false;
            portText.Visible = false;
            username.Visible = false;
            usernameText.Visible = false;
            connect.Visible = false;
            message.Enabled = false;
            send.Enabled = false;

            if (sock != null)
            {
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            }
        }

        private void client_Click(object sender, EventArgs e)
        {
            server.BackColor = Color.FromArgb(42, 42, 42);
            server.ForeColor = Color.FromArgb(255, 255, 255);
            client.BackColor = Color.FromArgb(255, 255, 255);
            client.ForeColor = Color.FromArgb(0, 0, 0);

            chat.Text = "";
            host.Visible = true;
            hostText.Visible = true;
            port.Visible = true;
            portText.Visible = true;
            username.Visible = true;
            usernameText.Visible = true;
            connect.Visible = true;
            message.Enabled = false;
            send.Enabled = false;

            if (sock != null)
            {
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            }
        }

        private void connect_Click(object sender, EventArgs e)
        {
            host.Visible = false;
            hostText.Visible = false;
            port.Visible = false;
            portText.Visible = false;
            username.Visible = false;
            usernameText.Visible = false;
            connect.Visible = false;
            message.Enabled = true;
            send.Enabled = true;
            server.Enabled = false;
            client.Enabled = false;

            new Thread(new ThreadStart(MessageHandler)).Start();
        }

        private void message_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                send_Click(sender, e);
            }
        }

        private void send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(message.Text)) { SystemSounds.Beep.Play(); return; }

            sock.Send(Encoding.ASCII.GetBytes($"{username.Text}: {message.Text}"));
            message.Text = "";
        }
    }
}
