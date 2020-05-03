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
    public partial class Rooms : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Rooms()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Stanislav\\Documents\\Visual Studio 2013\\Projects\\Hotel_System\\DataBase\\HotelDB.accdb; Persist Security Info=false";
            
        }

        private void Rooms_Load(object sender, EventArgs e)
        {

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
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
                    comboBox1.Items.Add(reader["Стая№"].ToString());

                }

                comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            connection.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            room_MonthReservation();
            room_MonthReservation2();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            room_MonthReservation();
            room_MonthReservation2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                sum += Convert.ToInt32(dataGridView2.Rows[i].Cells["Ден"].Value);
            }
            textBox1.Text = sum.ToString();



            if (comboBox2.Text == "Април" || comboBox2.Text == "Юни" || comboBox2.Text == "Септември" || comboBox2.Text == "Ноември")
            {
                textBox2.Text = (100*sum/30).ToString()+"%";
            }
            if (comboBox2.Text == "Януари" || comboBox2.Text == "Март" || comboBox2.Text == "Май" || comboBox2.Text == "Юли" || comboBox2.Text == "Август" || comboBox2.Text == "Октомври" || comboBox2.Text == "Декември")
            {
                textBox2.Text = (100 * sum / 31).ToString() + "%";
               
            }
            if (comboBox2.Text == "Февруари")
            {
                textBox2.Text = (100 * sum / 29).ToString() + "%";
            }

        }

        private void room_MonthReservation()
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                if (comboBox2.Text == "Януари")
                {
                    String select = "Select Стая.Стая№, Стая.Тип, Стая.Цена, Резервация.От, Резервация.До, Резервация.Нощувки, Клиент.Име, Клиент.Фамилия, Клиент.Телефон FROM ((Резервация INNER JOIN Стая ON Резервация.СтаяID=Стая.СтаяID) INNER JOIN Клиент ON Резервация.КлиентID=Клиент.КлиентID) Where Стая.Стая№='" + comboBox1.Text + "' and Резервация.От BETWEEN #01/01/2020# AND #31/01/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Февруари")
                {
                    String select = "Select Стая.Стая№, Стая.Тип, Стая.Цена, Резервация.От, Резервация.До, Резервация.Нощувки, Клиент.Име, Клиент.Фамилия, Клиент.Телефон FROM ((Резервация INNER JOIN Стая ON Резервация.СтаяID=Стая.СтаяID) INNER JOIN Клиент ON Резервация.КлиентID=Клиент.КлиентID) Where Стая.Стая№='" + comboBox1.Text + "' and Резервация.От BETWEEN #02/01/2020# AND #02/29/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Март")
                {
                    String select = "Select Стая.Стая№, Стая.Тип, Стая.Цена, Резервация.От, Резервация.До, Резервация.Нощувки, Клиент.Име, Клиент.Фамилия, Клиент.Телефон FROM ((Резервация INNER JOIN Стая ON Резервация.СтаяID=Стая.СтаяID) INNER JOIN Клиент ON Резервация.КлиентID=Клиент.КлиентID) Where Стая.Стая№='" + comboBox1.Text + "' and Резервация.От BETWEEN #03/01/2020# AND #03/31/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Април")
                {
                    String select = "Select Стая.Стая№, Стая.Тип, Стая.Цена, Резервация.От, Резервация.До, Резервация.Нощувки, Клиент.Име, Клиент.Фамилия, Клиент.Телефон FROM ((Резервация INNER JOIN Стая ON Резервация.СтаяID=Стая.СтаяID) INNER JOIN Клиент ON Резервация.КлиентID=Клиент.КлиентID) Where Стая.Стая№='" + comboBox1.Text + "' and Резервация.От BETWEEN #04/01/2020# AND #04/30/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Май")
                {
                    String select = "Select Стая.Стая№, Стая.Тип, Стая.Цена, Резервация.От, Резервация.До, Резервация.Нощувки, Клиент.Име, Клиент.Фамилия, Клиент.Телефон FROM ((Резервация INNER JOIN Стая ON Резервация.СтаяID=Стая.СтаяID) INNER JOIN Клиент ON Резервация.КлиентID=Клиент.КлиентID) Where Стая.Стая№='" + comboBox1.Text + "' and Резервация.От BETWEEN #05/01/2020# AND #05/31/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Юни")
                {
                    String select = "Select Стая.Стая№, Стая.Тип, Стая.Цена, Резервация.От, Резервация.До, Резервация.Нощувки, Клиент.Име, Клиент.Фамилия, Клиент.Телефон FROM ((Резервация INNER JOIN Стая ON Резервация.СтаяID=Стая.СтаяID) INNER JOIN Клиент ON Резервация.КлиентID=Клиент.КлиентID) Where Стая.Стая№='" + comboBox1.Text + "' and Резервация.От BETWEEN #06/01/2020# AND #06/30/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Юли")
                {
                    String select = "Select Стая.Стая№, Стая.Тип, Стая.Цена, Резервация.От, Резервация.До, Резервация.Нощувки, Клиент.Име, Клиент.Фамилия, Клиент.Телефон FROM ((Резервация INNER JOIN Стая ON Резервация.СтаяID=Стая.СтаяID) INNER JOIN Клиент ON Резервация.КлиентID=Клиент.КлиентID) Where Стая.Стая№='" + comboBox1.Text + "' and Резервация.От BETWEEN #07/01/2020# AND #07/31/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Август")
                {
                    String select = "Select Стая.Стая№, Стая.Тип, Стая.Цена, Резервация.От, Резервация.До, Резервация.Нощувки, Клиент.Име, Клиент.Фамилия, Клиент.Телефон FROM ((Резервация INNER JOIN Стая ON Резервация.СтаяID=Стая.СтаяID) INNER JOIN Клиент ON Резервация.КлиентID=Клиент.КлиентID) Where Стая.Стая№='" + comboBox1.Text + "' and Резервация.От BETWEEN #08/01/2020# AND #08/31/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Септември")
                {
                    String select = "Select Стая.Стая№, Стая.Тип, Стая.Цена, Резервация.От, Резервация.До, Резервация.Нощувки, Клиент.Име, Клиент.Фамилия, Клиент.Телефон FROM ((Резервация INNER JOIN Стая ON Резервация.СтаяID=Стая.СтаяID) INNER JOIN Клиент ON Резервация.КлиентID=Клиент.КлиентID) Where Стая.Стая№='" + comboBox1.Text + "' and Резервация.От BETWEEN #09/01/2020# AND #09/30/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Октомври")
                {
                    String select = "Select Стая.Стая№, Стая.Тип, Стая.Цена, Резервация.От, Резервация.До, Резервация.Нощувки, Клиент.Име, Клиент.Фамилия, Клиент.Телефон FROM ((Резервация INNER JOIN Стая ON Резервация.СтаяID=Стая.СтаяID) INNER JOIN Клиент ON Резервация.КлиентID=Клиент.КлиентID) Where Стая.Стая№='" + comboBox1.Text + "' and Резервация.От BETWEEN #10/01/2020# AND #10/31/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Ноември")
                {
                    String select = "Select Стая.Стая№, Стая.Тип, Стая.Цена, Резервация.От, Резервация.До, Резервация.Нощувки, Клиент.Име, Клиент.Фамилия, Клиент.Телефон FROM ((Резервация INNER JOIN Стая ON Резервация.СтаяID=Стая.СтаяID) INNER JOIN Клиент ON Резервация.КлиентID=Клиент.КлиентID) Where Стая.Стая№='" + comboBox1.Text + "' and Резервация.От BETWEEN #11/01/2020# AND #11/30/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Декември")
                {
                    String select = "Select Стая.Стая№, Стая.Тип, Стая.Цена, Резервация.От, Резервация.До, Резервация.Нощувки, Клиент.Име, Клиент.Фамилия, Клиент.Телефон FROM ((Резервация INNER JOIN Стая ON Резервация.СтаяID=Стая.СтаяID) INNER JOIN Клиент ON Резервация.КлиентID=Клиент.КлиентID) Where Стая.Стая№='" + comboBox1.Text + "' and Резервация.От BETWEEN #12/01/2020# AND #12/31/2020# ";
                    command.CommandText = select;
                }
               



                OleDbDataAdapter daAdapter = new OleDbDataAdapter(command);
                DataTable dTable = new DataTable();
                daAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;




            }
            catch (Exception ex)
            {
              //  MessageBox.Show("Error" + ex);
            }
            connection.Close();
        }

        private void room_MonthReservation2()
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                if (comboBox2.Text == "Януари")
                {
                    String select = "Select Стая№, Дата, Ден from Заети Where Стая№='" + comboBox1.Text + "' and Дата BETWEEN #01/01/2020# AND #31/01/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Февруари")
                {
                    String select = "Select Стая№, Дата, Ден from Заети Where Стая№='" + comboBox1.Text + "' and Дата BETWEEN #02/01/2020# AND #02/29/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Март")
                {
                    String select = "Select Стая№, Дата, Ден from Заети Where Стая№='" + comboBox1.Text + "' and Дата BETWEEN #03/01/2020# AND #03/31/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Април")
                {
                    String select = "Select Стая№, Дата, Ден from Заети Where Стая№='" + comboBox1.Text + "' and Дата BETWEEN #04/01/2020# AND #04/30/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Май")
                {
                    String select = "Select Стая№, Дата, Ден from Заети Where Стая№='" + comboBox1.Text + "' and Дата BETWEEN #05/01/2020# AND #05/31/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Юни")
                {
                    String select = "Select Стая№, Дата, Ден from Заети Where Стая№='" + comboBox1.Text + "' and Дата BETWEEN #06/01/2020# AND #06/30/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Юли")
                {
                    String select = "Select Стая№, Дата, Ден from Заети Where Стая№='" + comboBox1.Text + "' and Дата BETWEEN #07/01/2020# AND #07/31/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Август")
                {
                    String select = "Select Стая№, Дата, Ден from Заети Where Стая№='" + comboBox1.Text + "' and Дата BETWEEN #08/01/2020# AND #08/31/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Септември")
                {
                    String select = "Select Стая№, Дата, Ден from Заети Where Стая№='" + comboBox1.Text + "' and Дата BETWEEN #09/01/2020# AND #09/30/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Октомври")
                {
                    String select = "Select Стая№, Дата, Ден from Заети Where Стая№='" + comboBox1.Text + "' and Дата BETWEEN #10/01/2020# AND #10/31/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Ноември")
                {
                    String select = "Select Стая№, Дата, Ден from Заети Where Стая№='" + comboBox1.Text + "' and Дата BETWEEN #11/01/2020# AND #11/30/2020# ";
                    command.CommandText = select;
                }
                if (comboBox2.Text == "Декември")
                {
                    String select = "Select Стая№, Дата, Ден from Заети Where Стая№='" + comboBox1.Text + "' and Дата BETWEEN #12/01/2020# AND #12/31/2020# ";
                    command.CommandText = select;
                }




                OleDbDataAdapter daAdapter = new OleDbDataAdapter(command);
                DataTable dTable = new DataTable();
                daAdapter.Fill(dTable);
                dataGridView2.DataSource = dTable;




            }
            catch (Exception ex)
            {
                //  MessageBox.Show("Error" + ex);
            }
            connection.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
