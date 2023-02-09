using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lab5
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            Console.WriteLine("Добро пожаловать на Андромеду");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mForm = new MainForm(int.Parse(gencount1.Value.ToString()), int.Parse(gencount2.Value.ToString()), int.Parse(gencount3.Value.ToString()), int.Parse(gencount4.Value.ToString()), int.Parse(gencount5.Value.ToString()));
            Visible = false;
            if (mForm.ShowDialog() == DialogResult.Cancel)
                Close();
        }
        
    }
}
