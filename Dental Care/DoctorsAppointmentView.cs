﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

// Doctors Appointment View to See the list of Patients in the System
namespace Dental_Care
{
    public partial class DoctorsAppointmentView : Form
    {
        SqlDataAdapter sda;
        DataTable dt;
        Models.UserModel md;
        string date;
        public DoctorsAppointmentView(Models.UserModel model,string date)
        {
            InitializeComponent();
            this.md = model;
            this.date = date;
        }

        // Loads Data Initially
        private void DoctorsAppointmentView_Load(object sender, EventArgs e)
        {
            try
            {
                string connetionString = "Data Source=DESKTOP-S6B08UF\\SQLEXPRESS;Initial Catalog=DentalDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connetionString);
                string query = "SELECT [DocName] ,[Date], [description], [amount] FROM [DentalDB].[dbo].[Appointment] a inner join [DentalDB].[dbo].[Treatment] r on r.Code = a.treatment_ID where a.Date = '" + this.date + "' AND a.DocName = '" + this.md.getUsername() + "';";
                SqlCommand command = new SqlCommand(query, con);
                sda = new SqlDataAdapter(command);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Please input in the correct format");
            }
        }
    }
}
