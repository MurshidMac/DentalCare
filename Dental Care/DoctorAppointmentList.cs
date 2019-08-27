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
    public partial class DoctorAppointmentList : Form
    {
        Models.UserModel model;
        public DoctorAppointmentList(Models.UserModel model)
        {
            InitializeComponent();
            this.model = model;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var date = textBox1.Text;
            DoctorsAppointmentView form = new DoctorsAppointmentView(model, date);
            form.Show();
        }
    }
}
