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
    public partial class ActiveReservations : Form
    {
        public HotelManagemant Hm;
        private OleDbConnection connection = new OleDbConnection();
        public ActiveReservations(HotelManagemant hotelmanagemant)
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Stanislav\\Documents\\Visual Studio 2013\\Projects\\Hotel_System\\DataBase\\HotelDB.accdb; Persist Security Info=false";
            this.Hm = hotelmanagemant;
           
        }

        private void ActiveReservations_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
               // String Select = "Select Стая.Стая№, Стая.Тип, Стая.Цена, Резервация.От, Резервация.До, Резервация.Нощувки, Клиент.Име, Клиент.Фамилия, Клиент.Телефон FROM ((Резервация INNER JOIN Стая ON Резервация.СтаяID=Стая.СтаяID) INNER JOIN Клиент ON Резервация.КлиентID=Клиент.КлиентID) Where Резервация.До BETWEEN #"+dateTimePicker1.Text+"# AND #30/04/2050# ";
               // String Select = "Select Стая.Стая№, Стая.Тип, Стая.Цена, Резервация.От, Резервация.До, Резервация.Нощувки,Клиент.КлиентID, Клиент.Име, Клиент.Фамилия, Клиент.Телефон, Служител.Име, Служител.Фамилия  FROM (((Резервация INNER JOIN Стая ON Резервация.СтаяID=Стая.СтаяID) INNER JOIN Клиент ON Резервация.КлиентID=Клиент.КлиентID) INNER JOIN Служител ON Резервация.СлужителID=Служител.СлужителID) Where Резервация.До BETWEEN #" + dateTimePicker1.Text + "# AND #30/04/2050# ";
               // String Select = "Select Стая.Стая№, Стая.Тип, Стая.Цена, Резервация.От, Резервация.До, Резервация.Нощувки, Клиент.Име, Клиент.Фамилия, Клиент.Телефон FROM ((Резервация INNER JOIN Стая ON Резервация.СтаяID=Стая.СтаяID) INNER JOIN Клиент ON Резервация.КлиентID=Клиент.КлиентID) Where Резервация.От BETWEEN #" + dateTimePicker1.Text + "# AND #05/05/2020# and Резервация.До BETWEEN #05/05/2020# AND #10/05/2020# ";
                String Select = "Select Стая.Стая№, Стая.Тип, Стая.Цена, Резервация.От, Резервация.До, Резервация.Нощувки, Клиент.Име, Клиент.Фамилия, Клиент.Телефон FROM ((Резервация INNER JOIN Стая ON Резервация.СтаяID=Стая.СтаяID) INNER JOIN Клиент ON Резервация.КлиентID=Клиент.КлиентID) Where Резервация.До> #" + dateTimePicker1.Text + "# Order by Резервация.От";
                command.CommandText = Select;

                

                OleDbDataAdapter daAdapter = new OleDbDataAdapter(command);
                DataTable dTable = new DataTable();
                daAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;




            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            connection.Close();
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
