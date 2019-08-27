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
using System.Globalization;

namespace Dental_Care
{
    public partial class AppointPatientDetails : Form
    {
        string doctorSelected;
        int startHour = 8;
        int startMinute = 30;
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
            string date = textBox1.Text;
            var patientName = textBox2.Text;
            var description = textBox3.Text;
            var amount = textBox4.Text;
            
            string timeandate = date.Trim();
            

            try
            {
                DateTime myDate = DateTime.Parse(timeandate, CultureInfo.CreateSpecificCulture("en-US"));

                //MessageBox.Show(date);
                //MessageBox.Show(myDate.ToString());

                string firstquery = "INSERT INTO [dbo].[Treatment] ([Amount] ,[description] ,[PatientName]) VALUES (@AppointmentamountTreat, @Description, @PatientName)";
                string query = "INSERT INTO [dbo].[Appointment] ([DocName] ,[Date],[treatment_ID]) VALUES (@DocName, @AppointmentDate , (SELECT TOP 1 [Code] FROM Treatment where Amount= @Appointmentamount))";
                string connetionString = "Data Source=DESKTOP-S6B08UF\\SQLEXPRESS;Initial Catalog=DentalDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connetionString);
                SqlCommand command = new SqlCommand(firstquery, con);
                SqlCommand cmd = new SqlCommand(query, con);

                command.Parameters.Add("@AppointmentamountTreat", SqlDbType.Float).Value = amount;
                command.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = description;
                command.Parameters.Add("@PatientName", SqlDbType.VarChar, 50).Value = patientName;

                cmd.Parameters.Add("@DocName", SqlDbType.VarChar, 50).Value = this.doctorSelected;
                cmd.Parameters.Add("@AppointmentDate", SqlDbType.Date).Value = myDate;
                cmd.Parameters.Add("@Appointmentamount", SqlDbType.Int).Value = amount;

                con.Open();
                command.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                con.Close();
                
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

                MessageBox.Show("Thanks for Payment" + timeandate);
                Models.AppointmentModel appointmentmodel = new Models.AppointmentModel(this.doctorSelected, patientName, description, amount, date);
                Invoice invoiceForm = new Invoice(appointmentmodel);
                invoiceForm.Show();

            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter in the correct Date time Format");
            }
        }
    }
}
