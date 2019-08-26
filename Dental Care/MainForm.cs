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
                    MessageBox.Show(sname + "  " + pass);
                    Dental_Care.Models.UserModel obj = new Models.UserModel(sname, pass);
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

       
        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button6_Click(object sender, EventArgs e)
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
                if (element.getUsername() == username && element.getPassword() == password)
                {
                    this.statusofLogin = true;
                    MainPanel form = new MainPanel();
                    form.Show();
                }

            });

        }

        public Boolean Status()
        {
            return this.statusofLogin;
        }
    }
}
