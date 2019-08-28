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


// Appointment Patient Details to Be collected and set to the Database
namespace Dental_Care
{
    public partial class AppointPatientDetails : Form
    {
        string doctorSelected;
        List<string> patients;
        public AppointPatientDetails(string doctor)
        {
            InitializeComponent();
            this.doctorSelected = doctor;
            this.getDatabaseList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        List<string> getDatabaseList()
        {
            string connetionString = "Data Source=DESKTOP-S6B08UF\\SQLEXPRESS;Initial Catalog=DentalDB;Integrated Security=True";

            SqlConnection con = new SqlConnection(connetionString);

            con.Open();

            string query = "SELECT [Name] FROM [DentalDB].[dbo].[User] where [DentalDB].[dbo].[User].RoleID = 1;";
            SqlCommand command = new SqlCommand(query, con);

            IDataReader dr = command.ExecuteReader();
            patients = new List<string>();

            while (dr.Read())
            {
                patients.Add(dr[0].ToString());
                //MessageBox.Show(dr[0].ToString());
            }

            patients.ForEach(elment =>
            {
                comboBox1.Items.Add(elment);
            });
            return patients;
        }


        // Sends an appointment Details to SQL Server with Appointment Made and Treatments Done
        private void button1_Click(object sender, EventArgs e)
        {
            string date = textBox1.Text;
            var patientName = comboBox1.Text;
            var description = textBox3.Text;
            var amount = textBox4.Text;
            string timeandate = date.Trim();
            

            try
            {
                DateTime myDate = DateTime.Parse(timeandate, CultureInfo.CreateSpecificCulture("en-US"));

                //MessageBox.Show(date);
                //MessageBox.Show(myDate.ToString());

                string firstquery = "INSERT INTO [dbo].[Treatment] ([Amount] ,[description] ,[PatientName]) VALUES (@AppointmentamountTreat, @Description, @PatientName)";
                string query = "INSERT INTO [dbo].[Appointment] ([DocName] ,[Date],[treatment_ID],[patientName]) VALUES (@DocName, @AppointmentDate , (SELECT TOP 1 [Code] FROM Treatment where Amount= @Appointmentamount), @PatientName)";
                string billquery = "INSERT INTO [DentalDB].[dbo].[Bill] ([Amount] ,[Appointment_ID] ,[date] ,[treatmentdescription]) VALUES ( @amount ,(select TOP 1 [App_ID] from [DentalDB].[dbo].[Appointment] ap inner join [DentalDB].[dbo].[Treatment] tr on tr.Code = ap.treatment_ID where ap.patientName=@Patient AND ap.[Date] = @DateValue  AND ap.[DocName] = @DocNameforBill), @DateValue ,@TreatmentDesc);";


                string connetionString = "Data Source=DESKTOP-S6B08UF\\SQLEXPRESS;Initial Catalog=DentalDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connetionString);
                SqlCommand command = new SqlCommand(firstquery, con);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlCommand billCommand = new SqlCommand(billquery, con);


                command.Parameters.Add("@AppointmentamountTreat", SqlDbType.Float).Value = amount;
                command.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = description;
                command.Parameters.Add("@PatientName", SqlDbType.VarChar, 50).Value = patientName;

                cmd.Parameters.Add("@DocName", SqlDbType.VarChar, 50).Value = this.doctorSelected;
                cmd.Parameters.Add("@AppointmentDate", SqlDbType.Date).Value = myDate;
                cmd.Parameters.Add("@Appointmentamount", SqlDbType.Int).Value = amount;
                cmd.Parameters.Add("@PatientName", SqlDbType.VarChar, 50).Value = patientName;

                billCommand.Parameters.Add("@Amount", SqlDbType.Float).Value = amount;
                billCommand.Parameters.Add("@Patient", SqlDbType.VarChar, 50).Value = patientName;
                billCommand.Parameters.Add("@DateValue", SqlDbType.VarChar, 50).Value = myDate.ToString("d");
                billCommand.Parameters.Add("@TreatmentDesc", SqlDbType.VarChar, 50).Value = description;
                billCommand.Parameters.Add("@DocNameforBill", SqlDbType.VarChar, 50).Value = this.doctorSelected;

                con.Open();
                command.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                billCommand.ExecuteNonQuery();
                con.Close();
                
                textBox1.Text = "";
                comboBox1.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

                MessageBox.Show("Thanks for Payment  " + timeandate);
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
