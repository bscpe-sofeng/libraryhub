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
            label13.Text = Form1.loginas;

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
            Database.Open();
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(" select * from book", Database.connection);
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                dataGridView4.DataSource = dbdataset;
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
                label14.Text = dtgvr.Cells["user"].Value.ToString();
                textBox5.Text = dtgvr.Cells["pass"].Value.ToString();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        { 
            exists user = new exists();
            if (String.IsNullOrEmpty(textBox8.Text) || String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrEmpty(textBox7.Text) || String.IsNullOrEmpty(textBox9.Text) || String.IsNullOrEmpty(comboBox1.Text))
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
                    MessageBox.Show("Account Added!");
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
            string txtfname = textBox1.Text.Trim();
            string txtlname = textBox2.Text.Trim();
            string txtpass = textBox5.Text.Trim();
            string txttype = comboBox3.Text.Trim();
            
            if (String.IsNullOrEmpty(txtfname) || String.IsNullOrEmpty(txtlname) || String.IsNullOrEmpty(txtpass) || String.IsNullOrEmpty(txttype))
            {
                MessageBox.Show("please fill all fields !");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Update this account?", "Update Account", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Database.Open();
                    MySqlCommand cmd = new MySqlCommand("update account set fname = @fname, lname = @lname, user = @user, pass = @pass, type = @type where id = @id", Database.connection);
                    cmd.Parameters.Add(new MySqlParameter("id", label2.Text));
                    cmd.Parameters.Add(new MySqlParameter("fname", textBox1.Text));
                    cmd.Parameters.Add(new MySqlParameter("lname", textBox2.Text));
                    cmd.Parameters.Add(new MySqlParameter("user", label14.Text));
                    cmd.Parameters.Add(new MySqlParameter("pass", textBox5.Text));
                    cmd.Parameters.Add(new MySqlParameter("type", comboBox3.Text));
                    cmd.ExecuteNonQuery();
                    Database.Close();
                    button1_Click(sender, e);
                    MessageBox.Show("Account Updated!");
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
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }




        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete " + label14.Text, "Delete account", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Database.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM account where id=@id", Database.connection);
                cmd.Parameters.Add(new MySqlParameter("id", label2.Text));

                cmd.ExecuteNonQuery();
                Database.Close();
                button1_Click(sender, e);
                MessageBox.Show("Account Deleted!");
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

        private void dataGridView4_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.SelectedRows.Count > 0)
            {
                DataGridViewRow dtgvr = dataGridView4.SelectedRows[0];
                label22.Text = dtgvr.Cells["bookID"].Value.ToString();
                textBox16.Text = dtgvr.Cells["title"].Value.ToString();
                textBox17.Text = dtgvr.Cells["author"].Value.ToString();
                comboBox5.Text = dtgvr.Cells["category"].Value.ToString();
                textBox19.Text = dtgvr.Cells["pub"].Value.ToString();
                label23.Text = dtgvr.Cells["stock"].Value.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            exists user = new exists();
            if (String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox14.Text) || String.IsNullOrEmpty(textBox18.Text) || String.IsNullOrEmpty(textBox15.Text) || String.IsNullOrEmpty(comboBox4.Text))
            {
                MessageBox.Show("please fill all fields !");
            }
            else
            {
                Database.Open();
                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM book WHERE title = @title", Database.connection);
                cmd1.Parameters.Add(new MySqlParameter("title", textBox4.Text));
                MySqlDataReader reader = cmd1.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Book Already exist!");
                }


                else
                {
                    Database.Close();
                    Database.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO book VALUES (NULL, @title, @author, @category, @pub, @stock)", Database.connection);
                    cmd.Parameters.Add(new MySqlParameter("title", textBox4.Text));
                    cmd.Parameters.Add(new MySqlParameter("author", textBox14.Text));
                    cmd.Parameters.Add(new MySqlParameter("category", comboBox4.Text));
                    cmd.Parameters.Add(new MySqlParameter("pub", textBox18.Text));
                    cmd.Parameters.Add(new MySqlParameter("stock", textBox15.Text));
                    cmd.ExecuteNonQuery();
                    Database.Close();
                    button1_Click(sender, e);
                    MessageBox.Show("Book Added!");
                    try
                    {
                        Database.Open();
                        MySqlDataAdapter sda = new MySqlDataAdapter(" select * from book", Database.connection);
                        DataTable dbdataset = new DataTable();
                        sda.Fill(dbdataset);
                        dataGridView4.DataSource = dbdataset;
                        dataGridView2.DataSource = dbdataset;
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

        private void button9_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox16.Text) || String.IsNullOrEmpty(textBox17.Text) || String.IsNullOrEmpty(comboBox5.Text) || String.IsNullOrEmpty(textBox19.Text) || String.IsNullOrEmpty(label23.Text))
            {
                MessageBox.Show("please fill all fields !");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Update this book?", "Update Book", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Database.Open();
                    MySqlCommand cmd = new MySqlCommand("update book set title = @title, author = @author, category = @category, pub = @pub, stock = @stock where bookID = @bookID", Database.connection);
                    cmd.Parameters.Add(new MySqlParameter("bookID", label22.Text));
                    cmd.Parameters.Add(new MySqlParameter("title", textBox16.Text));
                    cmd.Parameters.Add(new MySqlParameter("author", textBox17.Text));
                    cmd.Parameters.Add(new MySqlParameter("category", comboBox5.Text));
                    cmd.Parameters.Add(new MySqlParameter("pub", textBox19.Text));
                    cmd.Parameters.Add(new MySqlParameter("stock", label23.Text));
                    cmd.ExecuteNonQuery();
                    Database.Close();
                    button1_Click(sender, e);
                    MessageBox.Show("Book Updated!");
                    try
                    {
                        MySqlDataAdapter sda = new MySqlDataAdapter(" select * from book", Database.connection);
                        DataTable dbdataset = new DataTable();
                        sda.Fill(dbdataset);
                        dataGridView4.DataSource = dbdataset;
                        dataGridView2.DataSource = dbdataset;
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
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Delete " + label22.Text, "Delete book", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Database.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM book where bookID=@bookID", Database.connection);
                cmd.Parameters.Add(new MySqlParameter("bookID", label22.Text));

                cmd.ExecuteNonQuery();
                Database.Close();
                button1_Click(sender, e);
                MessageBox.Show("Book Deleted!");
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter(" select * from book", Database.connection);
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    dataGridView4.DataSource = dbdataset;
                    dataGridView2.DataSource = dbdataset;
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

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

            MySqlDataAdapter sda = new MySqlDataAdapter(" select * from book where title  like'" + textBox10.Text + "%'", Database.connection);
            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            dataGridView2.DataSource = dbdataset;
            sda.Update(dbdataset);
            Database.Close();

        }
    }
}
