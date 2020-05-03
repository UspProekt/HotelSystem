using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class HotelManagemant : Form
    {
        public HotelManagemant(string username)
        {
            InitializeComponent();
            label3.Text = username;
           
            if(label3.Text=="Станислав"){
                label4.Text = "Димитров";
                label5.Text = "1";
            }
            if (label3.Text == "Теодор")
            {
                label4.Text = "Батев";
                label5.Text = "2";
            }
            if (label3.Text == "Петко")
            {
                label4.Text = "Литков";
                label5.Text = "3";
            }
            
        }


        private void HotelManagemant_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.Clock_label.Text = dateTime.ToString();
        }

        private void HotelManagemant_Load(object sender, EventArgs e)
        {
            

            groupBox1.BackColor = Color.Transparent;
            groupBox2.BackColor = Color.Transparent;
            timer1.Start();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation(this);
            reservation.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            ActiveReservations ActiveRes = new ActiveReservations(this);
            ActiveRes.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Rooms rooms = new Rooms();
            rooms.Show();
        }
    }
}
