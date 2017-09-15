namespace Client
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.SendButtom = new System.Windows.Forms.Button();
            this.NickBox = new System.Windows.Forms.TextBox();
            this.labelNick = new System.Windows.Forms.Label();
            this.labelDialog = new System.Windows.Forms.Label();
            this.ConnectToChatButton = new System.Windows.Forms.Button();
            this.labelInput = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.InputMessages = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowMessages = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendButtom
            // 
            this.SendButtom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendButtom.Location = new System.Drawing.Point(250, 228);
            this.SendButtom.Name = "SendButtom";
            this.SendButtom.Size = new System.Drawing.Size(87, 43);
            this.SendButtom.TabIndex = 3;
            this.SendButtom.Text = "Send";
            this.SendButtom.UseVisualStyleBackColor = true;
            this.SendButtom.Click += new System.EventHandler(this.SendButtom_Click);
            // 
            // NickBox
            // 
            this.NickBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NickBox.Location = new System.Drawing.Point(17, 43);
            this.NickBox.Name = "NickBox";
            this.NickBox.Size = new System.Drawing.Size(203, 29);
            this.NickBox.TabIndex = 0;
            // 
            // labelNick
            // 
            this.labelNick.AutoSize = true;
            this.labelNick.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNick.Location = new System.Drawing.Point(14, 24);
            this.labelNick.Name = "labelNick";
            this.labelNick.Size = new System.Drawing.Size(39, 13);
            this.labelNick.TabIndex = 2;
            this.labelNick.Text = "Name";
            // 
            // labelDialog
            // 
            this.labelDialog.AutoSize = true;
            this.labelDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDialog.Location = new System.Drawing.Point(14, 79);
            this.labelDialog.Name = "labelDialog";
            this.labelDialog.Size = new System.Drawing.Size(43, 13);
            this.labelDialog.TabIndex = 3;
            this.labelDialog.Text = "Dialog";
            // 
            // ConnectToChatButton
            // 
            this.ConnectToChatButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConnectToChatButton.Location = new System.Drawing.Point(226, 41);
            this.ConnectToChatButton.Name = "ConnectToChatButton";
            this.ConnectToChatButton.Size = new System.Drawing.Size(112, 31);
            this.ConnectToChatButton.TabIndex = 1;
            this.ConnectToChatButton.Text = "Connect";
            this.ConnectToChatButton.UseVisualStyleBackColor = true;
            this.ConnectToChatButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInput.Location = new System.Drawing.Point(14, 212);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(36, 13);
            this.labelInput.TabIndex = 5;
            this.labelInput.Text = "Input";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // InputMessages
            // 
            this.InputMessages.Location = new System.Drawing.Point(14, 228);
            this.InputMessages.Name = "InputMessages";
            this.InputMessages.Size = new System.Drawing.Size(228, 43);
            this.InputMessages.TabIndex = 2;
            this.InputMessages.Text = "";
            this.InputMessages.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EnterSending);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(352, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Settings,
            this.Exit});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(37, 20);
            this.Menu.Text = "File";
            // 
            // Settings
            // 
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(152, 22);
            this.Settings.Text = "Settings";
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(152, 22);
            this.Exit.Text = "Exit";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ShowMessages
            // 
            this.ShowMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowMessages.Location = new System.Drawing.Point(14, 96);
            this.ShowMessages.Name = "ShowMessages";
            this.ShowMessages.ReadOnly = true;
            this.ShowMessages.Size = new System.Drawing.Size(323, 113);
            this.ShowMessages.TabIndex = 4;
            this.ShowMessages.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 283);
            this.Controls.Add(this.ShowMessages);
            this.Controls.Add(this.InputMessages);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.ConnectToChatButton);
            this.Controls.Add(this.labelDialog);
            this.Controls.Add(this.labelNick);
            this.Controls.Add(this.NickBox);
            this.Controls.Add(this.SendButtom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Byte Chat";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendButtom;
        private System.Windows.Forms.TextBox NickBox;
        private System.Windows.Forms.Label labelNick;
        private System.Windows.Forms.Label labelDialog;
        private System.Windows.Forms.Button ConnectToChatButton;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RichTextBox InputMessages;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu;
        private System.Windows.Forms.ToolStripMenuItem Settings;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.RichTextBox ShowMessages;
    }
}

