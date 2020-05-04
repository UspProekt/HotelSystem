using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Hotel_System
{
    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Stanislav\\Documents\\Visual Studio 2013\\Projects\\Hotel_System\\DataBase\\HotelDB.accdb; Persist Security Info=false";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            textBox1.Focus();
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            groupBox1.BackColor = Color.Transparent;
         
            pictureBox1.BackColor = Color.Transparent;
            
            try
            {
               
                label4.Text = "Connection Successful";
               
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            connection.Close(); 


        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "Select * from Служител where Име='"+textBox1.Text+"' and Парола='"+textBox2.Text+"' ";
            OleDbDataReader reader = command.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }

            if (count == 1)
            {
               // MessageBox.Show("Потребителското име и паролата са коректни");
                HotelManagemant ht = new HotelManagemant(textBox1.Text);
                ht.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show(" Грешно потребителско име или парола! ", " Грешка ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();

           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 14;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
            button1.PerformClick();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

      
       
    }
}
