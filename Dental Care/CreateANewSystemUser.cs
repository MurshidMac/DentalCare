using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Dental_Care
{
    public partial class CreateANewSystemUser : Form
    {
        public CreateANewSystemUser()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var age = textBox2.Text;
            var nic = textBox3.Text;
            var contactnumber = textBox4.Text;
            var address = textBox5.Text;
            var username = textBox6.Text;
            var registrationFee = "";
            var password = textBox7.Text;
            var accessLevel = textBox8.Text;
            var yearsofexperience = "";

            try
            {

                string sqlserverquery = "INSERT INTO [dbo].[User] ([Name],[Age],[NIC],[Contact],[Address],[YOE],[RegistrationFee],[Username],[Password],[RoleID])" +
                " VALUES ( @Name, @Age,@NIC, @Contact, @Address, @YOE, @RegistrationFee, @Username,@Password, @RoleID)";
                string connetionString = "Data Source=DESKTOP-S6B08UF\\SQLEXPRESS;Initial Catalog=DentalDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connetionString);
                SqlCommand cmd = new SqlCommand(sqlserverquery, con);

                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = name;
                cmd.Parameters.Add("@Age", SqlDbType.VarChar, 50).Value = age;
                cmd.Parameters.Add("@NIC", SqlDbType.VarChar, 50).Value = nic;
                cmd.Parameters.Add("@Contact", SqlDbType.VarChar, 50).Value = contactnumber;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = address;
                cmd.Parameters.Add("@YOE", SqlDbType.Int).Value = yearsofexperience;
                cmd.Parameters.Add("@RegistrationFee", SqlDbType.VarChar, 50).Value = registrationFee;
                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = password;
                cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = accessLevel;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox8.Text = "";
                //MessageBox.Show("Doctors Details Created");
            }
            catch (Exception)
            {
                MessageBox.Show("Please check all necessary field again and input in the correct format");
            }

        }
    }
}
