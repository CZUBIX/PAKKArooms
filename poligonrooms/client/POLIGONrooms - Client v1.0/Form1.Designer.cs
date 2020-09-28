namespace POLIGONrooms___Client_v1._0
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.poligon = new System.Windows.Forms.Label();
            this.rooms = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.TextBox();
            this.server = new System.Windows.Forms.Button();
            this.client = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chat = new System.Windows.Forms.Label();
            this.host = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.connect = new System.Windows.Forms.Button();
            this.send = new System.Windows.Forms.Button();
            this.usernameText = new System.Windows.Forms.Label();
            this.hostText = new System.Windows.Forms.Label();
            this.portText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // poligon
            // 
            this.poligon.AutoSize = true;
            this.poligon.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.poligon.ForeColor = System.Drawing.Color.White;
            this.poligon.Location = new System.Drawing.Point(12, 9);
            this.poligon.Name = "poligon";
            this.poligon.Size = new System.Drawing.Size(119, 37);
            this.poligon.TabIndex = 0;
            this.poligon.Text = "Poligon";
            // 
            // rooms
            // 
            this.rooms.AutoSize = true;
            this.rooms.Font = new System.Drawing.Font("Segoe UI Black", 15F);
            this.rooms.ForeColor = System.Drawing.Color.White;
            this.rooms.Location = new System.Drawing.Point(14, 46);
            this.rooms.Name = "rooms";
            this.rooms.Size = new System.Drawing.Size(76, 28);
            this.rooms.TabIndex = 1;
            this.rooms.Text = "rooms";
            // 
            // message
            // 
            this.message.Enabled = false;
            this.message.Location = new System.Drawing.Point(179, 425);
            this.message.MaxLength = 50;
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(524, 20);
            this.message.TabIndex = 2;
            this.message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.message_KeyDown);
            // 
            // server
            // 
            this.server.BackColor = System.Drawing.Color.White;
            this.server.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.server.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.server.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.server.ForeColor = System.Drawing.Color.Black;
            this.server.Location = new System.Drawing.Point(19, 95);
            this.server.Name = "server";
            this.server.Size = new System.Drawing.Size(80, 30);
            this.server.TabIndex = 3;
            this.server.Text = "Server";
            this.server.UseVisualStyleBackColor = false;
            this.server.Click += new System.EventHandler(this.server_Click);
            // 
            // client
            // 
            this.client.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.client.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.client.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.client.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.client.ForeColor = System.Drawing.Color.White;
            this.client.Location = new System.Drawing.Point(18, 131);
            this.client.Name = "client";
            this.client.Size = new System.Drawing.Size(80, 30);
            this.client.TabIndex = 4;
            this.client.Text = "Client";
            this.client.UseVisualStyleBackColor = false;
            this.client.Click += new System.EventHandler(this.client_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "v1.0";
            // 
            // chat
            // 
            this.chat.AutoSize = true;
            this.chat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chat.ForeColor = System.Drawing.Color.White;
            this.chat.Location = new System.Drawing.Point(176, 26);
            this.chat.MaximumSize = new System.Drawing.Size(589, 460);
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(0, 15);
            this.chat.TabIndex = 6;
            // 
            // host
            // 
            this.host.Location = new System.Drawing.Point(395, 157);
            this.host.MaxLength = 20;
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(100, 20);
            this.host.TabIndex = 7;
            this.host.Visible = false;
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(395, 183);
            this.port.MaxLength = 6;
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(100, 20);
            this.port.TabIndex = 8;
            this.port.Text = "2202";
            this.port.Visible = false;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(395, 131);
            this.username.MaxLength = 10;
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(100, 20);
            this.username.TabIndex = 9;
            this.username.Visible = false;
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(395, 211);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(100, 20);
            this.connect.TabIndex = 11;
            this.connect.Text = "connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Visible = false;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // send
            // 
            this.send.Enabled = false;
            this.send.Location = new System.Drawing.Point(714, 425);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(54, 20);
            this.send.TabIndex = 12;
            this.send.Text = "send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // usernameText
            // 
            this.usernameText.AutoSize = true;
            this.usernameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.usernameText.ForeColor = System.Drawing.Color.White;
            this.usernameText.Location = new System.Drawing.Point(312, 132);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(77, 15);
            this.usernameText.TabIndex = 13;
            this.usernameText.Text = "Username:";
            this.usernameText.Visible = false;
            // 
            // hostText
            // 
            this.hostText.AutoSize = true;
            this.hostText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.hostText.ForeColor = System.Drawing.Color.White;
            this.hostText.Location = new System.Drawing.Point(349, 158);
            this.hostText.Name = "hostText";
            this.hostText.Size = new System.Drawing.Size(40, 15);
            this.hostText.TabIndex = 14;
            this.hostText.Text = "Host:";
            this.hostText.Visible = false;
            // 
            // portText
            // 
            this.portText.AutoSize = true;
            this.portText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.portText.ForeColor = System.Drawing.Color.White;
            this.portText.Location = new System.Drawing.Point(352, 184);
            this.portText.Name = "portText";
            this.portText.Size = new System.Drawing.Size(37, 15);
            this.portText.TabIndex = 15;
            this.portText.Text = "Port:";
            this.portText.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(780, 457);
            this.Controls.Add(this.portText);
            this.Controls.Add(this.hostText);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.send);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.username);
            this.Controls.Add(this.port);
            this.Controls.Add(this.host);
            this.Controls.Add(this.chat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.client);
            this.Controls.Add(this.server);
            this.Controls.Add(this.message);
            this.Controls.Add(this.rooms);
            this.Controls.Add(this.poligon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.Text = "Poligon rooms - Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label poligon;
        private System.Windows.Forms.Label rooms;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.Button server;
        private System.Windows.Forms.Button client;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label chat;
        private System.Windows.Forms.TextBox host;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.Label usernameText;
        private System.Windows.Forms.Label hostText;
        private System.Windows.Forms.Label portText;
    }
}

