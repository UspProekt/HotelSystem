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
using System.Text.RegularExpressions;

namespace Hotel_System
{
    public partial class Reservation : Form
    {
        public HotelManagemant HM;
        private OleDbConnection connection = new OleDbConnection();
        public Reservation(HotelManagemant HManagemant)
        {
            InitializeComponent();
            this.HM = HManagemant;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Stanislav\\Documents\\Visual Studio 2013\\Projects\\Hotel_System\\DataBase\\HotelDB.accdb; Persist Security Info=false";
            text_Number.KeyPress += new KeyPressEventHandler(text_Number_KeyPress);
            text_Name.KeyPress += new KeyPressEventHandler(text_Name_KeyPress);
            text_Surname.KeyPress += new KeyPressEventHandler(text_Surname_KeyPress);
        }

        private void text_Number_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '+') && ((sender as TextBox).Text.IndexOf('+') > -1))
            {
                e.Handled = true;
            }
        }

        Regex name = new Regex(@"([А-Я])\p{IsCyrillic}+");


        private void text_Name_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (name.IsMatch(text_Name.Text))
            {
                errorProvider1.SetError(text_Name, "");
            }
            else
            {
                errorProvider1.SetError(text_Name, " Името трябяа да е на кирилица и с главна буква ");

            }

        }

        private void text_Surname_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (name.IsMatch(text_Surname.Text))
            {
                errorProvider1.SetError(text_Surname, "");
            }
            else
            {
                errorProvider1.SetError(text_Surname, " Фамилията трябяа да е на кирилица и с главна буква ");

            }

        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String Select = "Select * from Заети Where Дата=#" + dateTimePicker1.Text + "# and Стая№='" + combo_Rooms.Text + "'";
                command.CommandText = Select;



                OleDbDataAdapter daAdapter = new OleDbDataAdapter(command);
                DataTable dTable = new DataTable();
                daAdapter.Fill(dTable);
                dataGridView2.DataSource = dTable;




            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "insert into Клиент (Име,Фамилия,Телефон) values('" + text_Name.Text + "', '" + text_Surname.Text + "', '" + text_Number.Text + "')";
                command.ExecuteNonQuery();
                
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            connection.Close();
            Klient_ID();   
            Insert_Reservation();
            Reservate_Rooms();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateTimePicker2.Value;

            TimeSpan time = date2 - date1;
            double ddays = time.TotalDays;

            int days = Convert.ToInt32(ddays);
            
            if (days >= 0)
            {
                
                text_Days.Text = (days).ToString();
                
            }
            else
            {
                text_Days.Clear();
                MessageBox.Show("Въведените дати са грешни!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        
        private void Reservation_Load(object sender, EventArgs e)
        {
            
            comboBox_RoomValue();
           
          
        }


        private void comboBox_RoomValue()
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String Select = "Select * from Стая";
                command.CommandText = Select;
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    combo_Rooms.Items.Add(reader["Стая№"].ToString());
                    
                }

                combo_Rooms.AutoCompleteMode = AutoCompleteMode.Suggest;
                combo_Rooms.AutoCompleteSource = AutoCompleteSource.ListItems;



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            connection.Close();
        }

        private void combo_Rooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String Select = "Select * from Стая where Стая№='" + combo_Rooms.Text + "'";
                command.CommandText = Select;
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    text_RoomID.Text = reader["СтаяID"].ToString();
                    text_RoomPrice.Text = reader["Цена"].ToString();
                    text_RoomType.Text = reader["Тип"].ToString();
                    

                }


            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error" + ex);
            }
            connection.Close();

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String Select = "Select * from Заети Where Стая№='" + combo_Rooms.Text + "' AND Дата BETWEEN #" + dateTimePicker1.Text + "# AND #" + dateTimePicker2.Text + "#";
                command.CommandText = Select;

                OleDbDataAdapter daAdapter = new OleDbDataAdapter(command);
                DataTable dTable = new DataTable();
                daAdapter.Fill(dTable);
                dataGridView2.DataSource = dTable;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            connection.Close();
            
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[1].Value == null)
                {
                    int days, price;
                    days = int.Parse(text_Days.Text);
                    price = int.Parse(text_RoomPrice.Text);
                    textBox1.Text = (days * price).ToString() + " Лева";
                    break;
                }
                if (row.Cells[1].Value.ToString() == combo_Rooms.Text )
                {

                    MessageBox.Show("Стаята е заета за избраните дати!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    combo_Rooms.SelectedIndex = -1;
                    text_RoomID.Clear(); text_RoomPrice.Clear(); text_RoomType.Clear(); textBox1.Clear();
                    break;
                    

                }
                

            }
            
            
        }

        private void Klient_ID(){
             try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String Select = "Select * from Клиент where Телефон='" + text_Number.Text + "'";
                command.CommandText = Select;
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                   
                    label12.Text = reader["КлиентID"].ToString();
                    
                }


            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error" + ex);
            }
            connection.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Insert_Reservation()
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "insert into Резервация (От,До,Нощувки,СтаяID,КлиентID,СлужителID) values('" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "', '" + dateTimePicker2.Value.ToString("dd/MM/yyyy") + "', '" + text_Days.Text + "', '"+text_RoomID.Text+"' , '" + label12.Text + "', '" +HM.label5.Text + "')";
                command.ExecuteNonQuery();
                MessageBox.Show("Резервацията беше направена успешно");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            connection.Close();
        }

        private void Reservate_Rooms()
        {
            var va = dateTimePicker1.Value;
            int days = int.Parse(text_Days.Text);
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "insert into Заети (Стая№,Дата,Ден) values('" + combo_Rooms.Text + "', '" + va.ToString("dd/MM/yyyy") + "','1')";
                command.ExecuteNonQuery();
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            connection.Close();

            for (int i = 0; i < days-1; i++)
            {

                va = va.AddDays(+1);
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "insert into Заети (Стая№,Дата,Ден) values('" + combo_Rooms.Text + "', '" + va.ToString("dd/MM/yyyy") + "','1')";
                    command.ExecuteNonQuery();
                    


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }
                connection.Close();
                
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

           
            
            
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void text_Name_TextChanged(object sender, EventArgs e)
        {
            
        }

        
        
    }
}
