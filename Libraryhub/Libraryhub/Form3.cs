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
    public partial class Form3 : Form
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
        public Form3()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label13.Text = Environment.UserName;

            Database.Open();
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(" select * from account", Database.connection);
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                dataGridView1.DataSource = dbdataset;
                sda.Update(dbdataset);
                Database.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        void load_table()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 1;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 6;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 3;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 4;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 5;
        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 7;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dtgvr = dataGridView1.SelectedRows[0];
                label2.Text = dtgvr.Cells["id"].Value.ToString();
                textBox1.Text = dtgvr.Cells["fname"].Value.ToString();
                textBox2.Text = dtgvr.Cells["lname"].Value.ToString();
                comboBox3.Text = dtgvr.Cells["type"].Value.ToString();
                textBox4.Text = dtgvr.Cells["user"].Value.ToString();
                textBox5.Text = dtgvr.Cells["pass"].Value.ToString();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {




            exists user = new exists();
            if (String.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("please fill all fields !");
            }
            else
            {
                Database.Open();
                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM account WHERE user = @user", Database.connection);
                cmd1.Parameters.Add(new MySqlParameter("user", textBox8.Text));
                MySqlDataReader reader = cmd1.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("User already taken!");
                }


                else
                {
                    Database.Close();
                    Database.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO account VALUES (NULL, @type, @fname, @lname, @user, @pass)", Database.connection);
                    cmd.Parameters.Add(new MySqlParameter("fname", textBox6.Text));
                    cmd.Parameters.Add(new MySqlParameter("lname", textBox7.Text));
                    cmd.Parameters.Add(new MySqlParameter("user", textBox8.Text));
                    cmd.Parameters.Add(new MySqlParameter("pass", textBox9.Text));
                    cmd.Parameters.Add(new MySqlParameter("type", comboBox1.Text));
                    cmd.ExecuteNonQuery();
                    Database.Close();
                    button1_Click(sender, e);

                    try
                    {
                        Database.Open();
                        MySqlDataAdapter sda = new MySqlDataAdapter(" select * from account", Database.connection);
                        DataTable dbdataset = new DataTable();
                        sda.Fill(dbdataset);
                        dataGridView1.DataSource = dbdataset;
                        sda.Update(dbdataset);
                        Database.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                Database.Close();
            }


        }




        private void A_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Update this account?", "Update Account", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Database.Open();
                MySqlCommand cmd = new MySqlCommand("update account set fname = @fname, lname = @lname, user = @user, pass = @pass, type = @type where id = @id", Database.connection);
                cmd.Parameters.Add(new MySqlParameter("id", label2.Text));
                cmd.Parameters.Add(new MySqlParameter("fname", textBox1.Text));
                cmd.Parameters.Add(new MySqlParameter("lname", textBox2.Text));
                cmd.Parameters.Add(new MySqlParameter("user", textBox4.Text));
                cmd.Parameters.Add(new MySqlParameter("pass", textBox5.Text));
                cmd.Parameters.Add(new MySqlParameter("type", comboBox3.Text));
                cmd.ExecuteNonQuery();
                Database.Close();
                button1_Click(sender, e);

                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter(" select * from account", Database.connection);
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    dataGridView1.DataSource = dbdataset;
                    sda.Update(dbdataset);
                    Database.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //return
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }




        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete " + textBox4.Text, "Delete account", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Database.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM account where id=@id", Database.connection);
                cmd.Parameters.Add(new MySqlParameter("id", label2.Text));

                cmd.ExecuteNonQuery();
                Database.Close();
                button1_Click(sender, e);

                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter(" select * from account", Database.connection);
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    dataGridView1.DataSource = dbdataset;
                    sda.Update(dbdataset);
                    Database.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //return
            }
        }

        private void tabPage10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.label9.Text = dateTime.ToString("hh:mm:ss tt dd-mm-yyyy");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {




        }

        private void button5_Click(object sender, EventArgs e)
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

        private void button1_Click_2(object sender, EventArgs e)
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
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

        private void dataGridView6_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void dataGridView6_AutoSizeColumnsModeChanged(object sender, DataGridViewAutoSizeColumnsModeEventArgs e)
        {
            GetRecords();
        }

        private void tabControl2_MouseClick(object sender, MouseEventArgs e)
        {
            GetRecords();
        }

        

        private void dataGridView6_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetRecords();
        }

        private void label13_Click(object sender, EventArgs e)
        {

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
    }
}
