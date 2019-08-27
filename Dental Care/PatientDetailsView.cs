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
    public partial class PatientDetailsView : Form
    {
        string PatientName;
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public PatientDetailsView(string patientName)
        {
            InitializeComponent();
            this.PatientName = patientName;
            MessageBox.Show(PatientName);

        }

        private void PatientDetailsView_Load(object sender, EventArgs e)
        {
            string connetionString = "Data Source=DESKTOP-S6B08UF\\SQLEXPRESS;Initial Catalog=DentalDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connetionString);
            string query = "SELECT * FROM Treatment where Treatment.PatientName = '"+this.PatientName+"'";
            SqlCommand command = new SqlCommand(query, con);
            sda = new SqlDataAdapter(command);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
