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
    public partial class DoctorsDetails : Form
    {

        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;

        public DoctorsDetails()
        {
            InitializeComponent();
        }

        private void DoctorsDetails_Load(object sender, EventArgs e)
        {
            string connetionString = "Data Source=DESKTOP-S6B08UF\\SQLEXPRESS;Initial Catalog=DentalDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connetionString);
            string query = "Select [Name],[Age], [NIC], [Contact], [Address], [YOE] FROM [dbo].[User] r where r.RoleID = 2 ORDER BY YOE DESC;";
            SqlCommand command = new SqlCommand(query, con);
            sda = new SqlDataAdapter(command);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
