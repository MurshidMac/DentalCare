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
    public partial class MainForm : Form
    {
        Boolean statusofLogin;
        List<Dental_Care.Models.UserModel> userlist = new List<Dental_Care.Models.UserModel>();


        public MainForm()
        {
            InitializeComponent();
            userlist = this.DatabaseUsers();
        }

        //Database connection for mysql or mssql
        private List<Dental_Care.Models.UserModel> DatabaseUsers()
        {
            string str = "Data Source=DESKTOP-S6B08UF\\SQLEXPRESS;Initial Catalog=DentalDB;Integrated Security=True";

            SqlConnection con = new SqlConnection(str);

            string query = "SELECT [Username] ,[Password] ,[RoleID] FROM [dbo].[User]";

            SqlCommand cmd = new SqlCommand(query, con);

            IDataReader reader;
            Boolean value = false;
            List<Dental_Care.Models.UserModel> list = new List<Dental_Care.Models.UserModel>();
            try

            {

                con.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())

                {

                    string sname = reader[0].ToString(); ; //name is coming from database
                    string pass = reader[1].ToString();
                    string roleId = reader[2].ToString();
                    Dental_Care.Models.UserModel obj = new Models.UserModel(sname, pass, roleId);
                    list.Add(obj);
                    //return value=true;
                }

            }

            catch (Exception es)

            {

                MessageBox.Show(es.Message);
                return null;
            }
            return list;
        }



        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var username = textBox1.Text;
            var password = textBox2.Text;

            // Validate the users
            // with SQL Queries
            // return the status
            userlist.ForEach(element =>
            {
                // These are the access level
                // 1 Doctor Only Patient Enquiry
                // 2 Front Clerk and 
                // 3 Manager who is the admin Will only have Full Access

                // This is for Doctor
                if (element.getUsername() == username && element.getPassword() == password && element.getRoleIdd() == "2")
                {
                    this.statusofLogin = true;
                    DoctorPanel form = new DoctorPanel(element);
                    form.Show();
                    textBox1.Text= "";
                    textBox2.Text = "";

                }

                // This is for Manager
                if (element.getUsername() == username && element.getPassword() == password && element.getRoleIdd() == "3")
                {
                    this.statusofLogin = true;
                    MainPanel form = new MainPanel();
                    form.Show();
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                // This is for Nurse
                if (element.getUsername() == username && element.getPassword() == password && element.getRoleIdd() == "4")
                {
                    this.statusofLogin = true;
                    MainPanel form = new MainPanel();
                    form.Show();
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                // This is for Front Clerk
                if (element.getUsername() == username && element.getPassword() == password && element.getRoleIdd() == "5")
                {
                    this.statusofLogin = true;
                    MainPanel form = new MainPanel();
                    form.Show();
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            });

        }

        public Boolean Status()
        {
            return this.statusofLogin;
        }
    }
}
