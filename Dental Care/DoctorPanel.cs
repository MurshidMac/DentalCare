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
    public partial class DoctorPanel : Form
    {
        Models.UserModel model;
        public DoctorPanel(Models.UserModel userLogged)
        {
            InitializeComponent();
            this.model = userLogged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PatientEnquiry form = new PatientEnquiry();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoctorAppointmentList form = new DoctorAppointmentList(this.model);
            form.Show();
        }
    }
}
