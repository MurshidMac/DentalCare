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
    public partial class AppointPatientDetails : Form
    {
        string doctorSelected;
        public AppointPatientDetails(string doctor)
        {
            InitializeComponent();
            this.doctorSelected = doctor;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var date = textBox1.Text;
            var amount = textBox2.Text;
            MessageBox.Show(date.Trim());
            DateTime oDate = Convert.ToDateTime(date.Trim());

            MessageBox.Show(date);

            string query = "INSERT INTO [dbo].[Appointment] ([DocName] ,[Date],[treatment_ID]) VALUES (@DocName, @AppointmentDate , (SELECT TOP 1 [Code] FROM Treatment where Amount= @Appointmentamount))";
            string connetionString = "Data Source=DESKTOP-S6B08UF\\SQLEXPRESS;Initial Catalog=DentalDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.Add("@DocName", SqlDbType.VarChar, 50).Value = this.doctorSelected;
            cmd.Parameters.Add("@AppointmentDate", SqlDbType.Date).Value = oDate;
            cmd.Parameters.Add("@Appointmentamount", SqlDbType.Int).Value = amount;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Appointment Made");
        }
    }
}
