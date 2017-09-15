﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Error_Info : Form
    {
        public Error_Info(string errorMessage)
        {
            InitializeComponent();
            ErrorMessage.Text = errorMessage;
        }

        private void Error_Info_Load(object sender, EventArgs e)
        {

        }

        private void ErrorMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
