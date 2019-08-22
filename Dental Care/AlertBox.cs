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
    public partial class AlertBox : Form
    {
        //PatientModel valueSent;
        public AlertBox(string value)
        {
            InitializeComponent();
            //valueSent = value;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //label1.Text = valueSent.getName();
        }
    }
}
