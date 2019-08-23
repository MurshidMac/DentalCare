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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //Database connection for mysql or mssql
        private Boolean connectToDataBase()
        {
            //
            return true;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PatientRegistration form = new PatientRegistration();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoctorsRegistration form = new DoctorsRegistration();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Appointments form = new Appointments();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PatientEnquiry form = new PatientEnquiry();
            form.Show();
        }
    }
}
