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

// All Appointments Listed
namespace Dental_Care
{
    public partial class AllAppointments : Form
    {
        SqlDataAdapter sda;
        DataTable dt;
        public AllAppointments()
        {
            InitializeComponent();
        }

        // Gets ALL the appointments available for working day.
        private void AllAppointments_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            MessageBox.Show(today.ToString("d"));
            try
            {
                string connetionString = "Data Source=DESKTOP-S6B08UF\\SQLEXPRESS;Initial Catalog=DentalDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connetionString);
                string query = "SELECT * FROM [DentalDB].[dbo].[Appointment] ap inner join [DentalDB].[dbo].[Treatment] tr on tr.Code = ap.treatment_ID where ap.[Date] = '" + today.ToString("d") + "';";
                SqlCommand command = new SqlCommand(query, con);
                sda = new SqlDataAdapter(command);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Please try in few minutes");
            }
        }
    }
}
