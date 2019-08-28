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
    public partial class PatientRegistration : Form
    {

        PatientModel element;
        SqlDataAdapter adapter;
        SqlCommandBuilder cmdBuilder;
        DataTable dt;
        Dental_Care.Database.DBConnect database = new Database.DBConnect();
        public PatientRegistration()
        {
            InitializeComponent();
        }

        // Validations are done later
        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var age = textBox2.Text;
            var nationalIdentitycard = textBox3.Text;
            var contactNumber = textBox4.Text;
            var address = textBox5.Text;
            var registrationFee = textBox6.Text;
            var username = "";
            var password = "";


            element = new PatientModel(name, address, nationalIdentitycard, contactNumber);
            //database.OpenConnection();

            try
            {
                string sqlserverquery = "INSERT INTO [dbo].[User] ([Name],[Age],[NIC],[Contact],[Address],[YOE],[RegistrationFee],[Username],[Password],[RoleID])" +
                    " VALUES ( @Name, @Age,@NIC, @Contact, @Address, @YOE, @RegistrationFee, @Username,@Password, @RoleID)";
                string connetionString = "Data Source=DESKTOP-S6B08UF\\SQLEXPRESS;Initial Catalog=DentalDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connetionString);
                SqlCommand cmd = new SqlCommand(sqlserverquery, con);

                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = name;
                cmd.Parameters.Add("@Age", SqlDbType.VarChar, 50).Value = age;
                cmd.Parameters.Add("@NIC", SqlDbType.VarChar, 50).Value = nationalIdentitycard;
                cmd.Parameters.Add("@Contact", SqlDbType.VarChar, 50).Value = contactNumber;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = address;
                cmd.Parameters.Add("@YOE", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@RegistrationFee", SqlDbType.VarChar, 50).Value = registrationFee;
                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = password;
                cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = 1;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";

                //MessageBox.Show("Patient Details Created");
            }
            catch (Exception)
            {
                MessageBox.Show("Please check all necessary field again and input in the correct format");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
