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



// Income Report Form to generate the Daily Income
namespace Dental_Care
{
    public partial class IncomeReport : Form
    {
        List<Models.IncomeModel> incomereport;
        SqlDataAdapter sda;
        DataTable dt;
        

        public IncomeReport()
        {
            InitializeComponent();
            //this.getDatabaseList();
        }

        // This is the object oriented approach which is bit risky
        List<Models.IncomeModel> getDatabaseList()
        {
            string connetionString = "Data Source=DESKTOP-S6B08UF\\SQLEXPRESS;Initial Catalog=DentalDB;Integrated Security=True";

            SqlConnection con = new SqlConnection(connetionString);

            con.Open();

            string query = "SELECT [Bill].[date] ,[DocName] ,[Amount] ,[patientName] ,[treatmentdescription] FROM [DentalDB].[dbo].[Bill] bill inner join Appointment ap on ap.[App_ID] = bill.[Appointment_ID];";
            SqlCommand command = new SqlCommand(query, con);

            IDataReader dr = command.ExecuteReader();
            incomereport = new List<Models.IncomeModel>();

            while (dr.Read())
            {
                Models.IncomeModel model = new Models.IncomeModel(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                incomereport.Add(model);

                //MessageBox.Show(dr[0].ToString());
            }

            // income report is genenrated only for today which means only daily
            DateTime today = DateTime.Today;
            MessageBox.Show(today.ToString("d"));
            incomereport.ForEach(elment =>
            {
                MessageBox.Show(elment.getDate());
                MessageBox.Show(elment.getDocName());
                MessageBox.Show(elment.getPatientName());
                MessageBox.Show(elment.getTreatmentDescription());
                MessageBox.Show(elment.getAmount());
            });
            return incomereport;
        }


        //Generates Income Report Once Loaded
        private void IncomeReport_Load(object sender, EventArgs e)
        {
            DateTime myDate = DateTime.Parse(DateTime.Today.ToString(), CultureInfo.CreateSpecificCulture("en-US"));
            MessageBox.Show("Showing Income for Today  " + myDate.ToString("d"));
            try
            {
                string connetionString = "Data Source=DESKTOP-S6B08UF\\SQLEXPRESS;Initial Catalog=DentalDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connetionString);
                string query = "Select  [DocName],[patientName],[BillNo], Sum([Amount]) Over (Order By [BillNo]) As Income From   [DentalDB].[dbo].[Bill] rm inner join [DentalDB].[dbo].[Appointment] ap on ap.App_ID = rm.Appointment_ID AND rm.[date] = '" + myDate.ToString("d") + "';";
                SqlCommand command = new SqlCommand(query, con);
                sda = new SqlDataAdapter(command);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Please input in the correct format");
            }
        }
    }
}
