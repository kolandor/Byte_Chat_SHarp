using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Client
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void SaveButtom_Click(object sender, EventArgs e)
        {
            try
            {
                if (IPBox.Text.Length > 0 && PortBox.Text.Length > 0)
                {
                    FileStream serverInfo = new FileStream(@"Settings.inf", FileMode.Create, FileAccess.Write);
                    string toWrite = IPBox.Text + ':' + PortBox.Text;
                    serverInfo.Write(Encoding.UTF8.GetBytes(toWrite), 0, toWrite.Length);
                    serverInfo.Flush();
                    serverInfo.Close();
                }
            }
            catch (Exception ex)
            {
                Error_Info errBox = new Error_Info(ex.Message);
                errBox.ShowDialog();
            }
            Application.Restart();
        }

        private void Info_Click(object sender, EventArgs e)
        {

        }
    }
}
