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

// Available A 
namespace Dental_Care
{
    public partial class Appointments : Form
    {
        List<string> listofDoctors;

        public Appointments()
        {
            InitializeComponent();
            this.getDatabaseList();
        }


        // The available Doctor is selected for an appointment initially
        List<string> getDatabaseList()
        {
            string connetionString = "Data Source=DESKTOP-S6B08UF\\SQLEXPRESS;Initial Catalog=DentalDB;Integrated Security=True";

            SqlConnection con = new SqlConnection(connetionString);

            con.Open();

            string query = "SELECT [Name] FROM [dbo].[User] WHERE RoleID=2;";
            SqlCommand command = new SqlCommand(query, con);

            IDataReader dr = command.ExecuteReader();
            listofDoctors = new List<string>();

                while (dr.Read())
                {
                    listofDoctors.Add(dr[0].ToString());
                    //MessageBox.Show(dr[0].ToString());
                }

            listofDoctors.ForEach(elment =>
            {
                comboBox1.Items.Add(elment);
            });
            return listofDoctors;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string doctorsSelection = comboBox1.Text;

            AppointPatientDetails form = new AppointPatientDetails(doctorsSelection);
            form.Show();
        }

        private void Appointments_Load(object sender, EventArgs e)
        {

        }
    }
}
