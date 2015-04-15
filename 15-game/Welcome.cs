using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Welcome : Form
    {
        public Bitmap picture = WindowsFormsApplication1.Properties.Resources.kitty;

        public Welcome()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            comboBox1.Items.Add("Kitty");
            comboBox1.Items.Add("Pizza");
            comboBox1.Items.Add("Avatar");
            comboBox1.Items.Add("Nyaa");
            comboBox1.Items.Add("OH SHI~");
            comboBox1.Text = comboBox1.Items[0].ToString();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            comboBox1.Enabled = true;
            picture = WindowsFormsApplication1.Properties.Resources.kitty;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    textBox1.Text = file;
                    picture = new Bitmap(file);
                }
                catch (Exception exc)
                {
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Kitty")
                picture = WindowsFormsApplication1.Properties.Resources.kitty;
            if (comboBox1.Text == "Pizza")
                picture = WindowsFormsApplication1.Properties.Resources.pizza;
            if (comboBox1.Text == "Avatar")
                picture = WindowsFormsApplication1.Properties.Resources.photo; 
            if (comboBox1.Text == "Nyaa")
                picture = WindowsFormsApplication1.Properties.Resources.nyaa;
            if (comboBox1.Text == "OH SHI~")
                picture = WindowsFormsApplication1.Properties.Resources.OHSHI;

        }
    }
}
