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
    public partial class Appointments : Form
    {
        public Appointments()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string doctorsSelection = comboBox1.Text;
            AppointPatientDetails form = new AppointPatientDetails(doctorsSelection);
            form.Show();
        }
    }
}
