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
    public partial class MainPanel : Form
    {
        public MainPanel()
        {
            InitializeComponent();
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

        private void button4_Click(object sender, EventArgs e)
        {
            PatientEnquiry form = new PatientEnquiry();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DoctorsDetails form = new DoctorsDetails();
            form.Show();
        }
    }
}
