using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DinnerPartyCost
{
    public partial class Form1 : Form
    {
        DinnerParty dinnerParty = new DinnerParty();
        public int a, b, c, d, l, i, j, fan;
        public double finalTotal, forDec, forSpace;
        const int decFancy = 5000, decReg = 2000, spaceHall = 220, spaceOpen = 200;
        String name, mealValue, drinkValue, halloropen;
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        public Form1()
        {
            InitializeComponent();
        }

        public void CreateTable()
        {

            //using (con = new SqlConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\visual_databases\\AccessDatabase1.accdb"));
            //{
            //  con.Open();
            //try
            //{
            //  using (com = new SqlCommand("CREATE TABLE cust (customer_name TEXT, NumOfGuests INT, Meal TEXT, Drink TEXT, Fancy INT, Total_Price VARCHAR)", con))
            //{
            //  com.ExecuteNonQuery();
            // }
            //}
            //catch (Exception e)
            //{
            //        MessageBox.Show(e.ToString(), "Please re-run to save querries", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            //}
            //}
            //System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            // TODO: Modify the connection string and include any
            // additional required properties for your database.
            //conn.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0;" + @"Data source= C:\visual_databases\AccessDatabase1.accdb";
            try
            {
                //conn.Open();
                //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Micheal\Documents\Mydb.mdf;Integrated Security=True;Connect Timeout=30
                System.Data.OleDb.OleDbConnection myConnection = new System.Data.OleDb.OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0;" + @"Data source= C:\visual_databases\AccessDatabase1.accdb");
                System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = "CREATE TABLE "+ name +" (NumOfGuests INT, Meal TEXT, Drink TEXT, Fancy INT, Hall TEXT, Total_Price VARCHAR)";
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = "INSERT INTO " + name + "(NumOfGuests, Meal, Drink, Fancy, Hall, Total_Price) VALUES ("+d+",'"+mealValue+"','"+drinkValue+"',"+fan+",'"+halloropen+"',"+finalTotal+")";
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close(); 
                //System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();

                //myCommand.Connection = conn;
                //myCommand.CommandText = "CREATE TABLE cust (customer_name TEXT, NumOfGuests INT, Meal TEXT, Drink TEXT, Fancy INT, Total_Price VARCHAR)";
                //myCommand.ExecuteNonQuery();
                //myCommand.Connection.Close();
                MessageBox.Show("Table created", "Dinner Planner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Insert code to process data.
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Please re-run to save querries", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            //finally
            //{
                //conn.Close();
            //}
        }
        public void GetData()
        {
           
            name = textBox1.Text;
            mealValue = comboBox1.SelectedItem.ToString();
            drinkValue = comboBox2.SelectedItem.ToString();
            a = comboBox1.SelectedIndex;
            b = comboBox2.SelectedIndex;
            d = (int) numericUpDown1.Value;
            switch (a)
            {
                case 0:
                    c = 500;
                    break;
                case 1:
                    c = 750;
                    break;
                case 2:
                    c = 400;
                    break;
                case 3:
                    c = 1000;
                    break;
            }
            switch (b)
            {
                case 0:
                    l = 7;
                    break;
                case 1:
                    l = 125;
                    break;
                case 2:
                    l = 130;
                    break;
            }

            if (checkBox1.Checked)
            {
                checkBox2.Hide();
                halloropen = "Hall";
                forSpace = spaceHall * d;
            }
            else if (checkBox2.Checked)
            {
                checkBox1.Hide();
                halloropen = "Open";
                forSpace = spaceOpen * d;
            }
            else if (checkBox3.Checked)
            {
                checkBox4.Hide();
                fan = 1;
                forDec = decFancy * d;
            }
            else if (checkBox4.Checked)
            {
                checkBox3.Hide();
                fan = 0;
                forDec = decReg * d;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GetData();
            if (a >= 0 && b >= 0)
            {
                finalTotal = dinnerParty.CostTotal(i, j, d, c, l) + forDec + forSpace;
                label6.Text = '#' + finalTotal.ToString();
                CreateTable();
            } else {
                MessageBox.Show("Some fields are empty", "Dinner Party Planner", MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }
        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
