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
    public partial class Form4 : Form
    {
        private void GetRecords()
        {

            try

            {
                Database.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter(" select * from log", Database.connection);
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                dataGridView6.DataSource = dbdataset;
                sda.Update(dbdataset);
                Database.Close();

                foreach (DataGridViewRow dtgvr in dataGridView6.Rows)
                {
                    if (dtgvr.Cells["timeout"].Value.ToString().ToLower().Equals("pending"))
                    {
                        dtgvr.DefaultCellStyle.BackColor = Color.Crimson;
                    }
                    else
                    {
                        dtgvr.DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string txtFname = textBox3.Text.Trim();
            string txtLname = textBox11.Text.Trim();
            string txtSchool = textBox12.Text.Trim();
            string txtIntent = textBox13.Text.Trim();

            User user = new User();
            if (String.IsNullOrEmpty(txtFname) || String.IsNullOrEmpty(txtLname) || String.IsNullOrEmpty(txtSchool) || String.IsNullOrEmpty(txtIntent))
            {
                MessageBox.Show("please fill all fields !");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Confirm", "Add Entry", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Database.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO log VALUES (NULL, @fname, @lname, @school, @intent, @timein, @timeout)", Database.connection);
                    cmd.Parameters.Add(new MySqlParameter("fname", textBox3.Text));
                    cmd.Parameters.Add(new MySqlParameter("lname", textBox13.Text));
                    cmd.Parameters.Add(new MySqlParameter("school", textBox11.Text));
                    cmd.Parameters.Add(new MySqlParameter("intent", textBox12.Text));
                    cmd.Parameters.Add(new MySqlParameter("timein", label9.Text));
                    cmd.Parameters.Add(new MySqlParameter("timeout", label10.Text));
                    cmd.ExecuteNonQuery();
                    Database.Close();

                    GetRecords();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label13.Text = Form1.loginas;

            Database.Open();
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(" select * from book", Database.connection);
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                dataGridView2.DataSource = dbdataset;
                sda.Update(dbdataset);
                Database.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Database.Open();
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(" select * from borrow", Database.connection);
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                dataGridView5.DataSource = dbdataset;
                sda.Update(dbdataset);
                Database.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
       
        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirm", "Log Out", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Form1 app = new Form1();
                app.Show();
                this.Hide();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 1;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 2;
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 3;
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 4;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.label9.Text = dateTime.ToString("hh:mm:ss tt dd-mm-yyyy");
        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow dtgvr = dataGridView2.SelectedRows[0];
                label7.Text = dtgvr.Cells["title"].Value.ToString();
                label8.Text = dtgvr.Cells["author"].Value.ToString();
                label24.Text = dtgvr.Cells["category"].Value.ToString();
                label25.Text = dtgvr.Cells["stock"].Value.ToString();
                label26.Text = dtgvr.Cells["bookID"].Value.ToString();
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRecords();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("User Timeout?", "Timeout", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Database.Open();
                MySqlCommand cmd = new MySqlCommand("update log set  fname = @fname , timeout = @timeout where id = @id", Database.connection);
                cmd.Parameters.Add(new MySqlParameter("id", label12.Text));
                cmd.Parameters.Add(new MySqlParameter("fname", textBox11.Text));
                cmd.Parameters.Add(new MySqlParameter("timeout", label9.Text));
                cmd.ExecuteNonQuery();
                Database.Close();
                GetRecords();
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter sda = new MySqlDataAdapter(" select * from book where title  like'" + textBox10.Text + "%' AND category like'" + comboBox2.Text + "%' OR author like'" + textBox10.Text + "%' ", Database.connection);
            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            dataGridView2.DataSource = dbdataset;
            sda.Update(dbdataset);
            Database.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter sda = new MySqlDataAdapter(" select * from book where category like'" + comboBox2.Text + "%' AND title  like'" + textBox10.Text + "%'", Database.connection);
            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            dataGridView2.DataSource = dbdataset;
            sda.Update(dbdataset);
            Database.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox10.Text = String.Empty;
            comboBox2.Text = String.Empty;
        }

        private void dataGridView6_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView6.SelectedRows.Count > 0)
            {
                DataGridViewRow dtgvr = dataGridView6.SelectedRows[0];
                label11.Text = dtgvr.Cells["fname"].Value.ToString();
                label12.Text = dtgvr.Cells["id"].Value.ToString();
            }
        }
    }
}

