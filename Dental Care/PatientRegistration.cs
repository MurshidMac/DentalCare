using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Dental_Care
{
    public partial class PatientRegistration : Form
    {

        PatientModel element;
        Dental_Care.Database.DBConnect database = new Database.DBConnect();
        public PatientRegistration()
        {
            InitializeComponent();
        }

        // Validations are done later
        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var address = textBox2.Text;
            var nationalIdentitycard = textBox3.Text;
            var contactNumber = textBox4.Text;

            element = new PatientModel(name, address, nationalIdentitycard, contactNumber);
            //database.OpenConnection();

            string query = "INSERT INTO `dentalcare`.`patients`(`name`,`address`,`nic`,`contactNumber`)VALUES('"+ name +"','"+address+"','"+nationalIdentitycard+"','"+contactNumber+"');";

            Boolean output = database.Insert(query);
     
            if(output == true)
            {
                MessageBox.Show("Patient Details Created");
                textBox1.Text="";
                textBox2.Text="";
                textBox3.Text="";
                textBox4.Text="";
            }
            else
            {
                MessageBox.Show("Patient Details not created");
            }
        }
    }
}
