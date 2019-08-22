using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Care
{
    public partial class DoctorsRegistration : Form
    {
        Dental_Care.Database.DBConnect database = new Database.DBConnect();
        public DoctorsRegistration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Alert the User to create the necessary details

            var name = textBox1.Text;
            var address = textBox2.Text;
            var dateofbirth = textBox3.Text;
            var nic = textBox4.Text;
            var contactnumber = textBox5.Text;
            var yearsofexperience = textBox6.Text;
 
            string query = "INSERT INTO `dentalcare`.`doctors`(`name`,`address`,`dateofbirth`,`nic`,`contactNumber`,`yearsofexperience`)VALUES ('" + name + "','" + address + "','" + dateofbirth + "','" + nic + "','"+ contactnumber + "','" + yearsofexperience +"');";

            Boolean output = database.Insert(query);

            if (output == true)
            {
                MessageBox.Show("Doctors Details Created");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
            else
            {
                MessageBox.Show("Doctors Details not created");
            }


        }
    }
}
