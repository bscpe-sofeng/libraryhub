using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Libraryhub
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Database.Open();
            label1.BackColor = Color.Transparent;


        }

        private void button1_Click_1(object sender, EventArgs e)

        {
            {
                string txtUsername = textBox1.Text.Trim();
                string txtPassword = textBox2.Text.Trim();

                User user = new User();
                if (String.IsNullOrEmpty(txtUsername) || String.IsNullOrEmpty(txtPassword))
                {
                    MessageBox.Show("please fill all fields !");
                }
                else
                {
                    user = User.login(txtUsername, txtPassword);
                    if (txtUsername == user.username && txtPassword == user.password)
                    {
                        if (user.type.ToLower() == "admin")
                        {
                            Form2 app = new Form2();
                            app.Show();
                            this.Hide();
                        }
                        else
                        {
                            Form4 app = new Form4();
                            app.Show();
                            this.Hide();
                        }


                    }
                    else
                    {
                        MessageBox.Show("Wrong username or password !", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                Form3 app = new Form3();
                app.Show();
                this.Hide();
            }
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.Font = new Font(label1.Font.Name, label1.Font.SizeInPoints, FontStyle.Underline);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.Font = new Font(label1.Font.Name, label1.Font.SizeInPoints, FontStyle.Regular);
        }
    }
}
