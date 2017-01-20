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
                        Form2 app = new Form2();
                        app.Show();
                        this.Hide();
                        
                    }
                    else
                    {
                        MessageBox.Show("Wrong username or password !", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
