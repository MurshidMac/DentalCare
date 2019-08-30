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
using System.Globalization;



// Income Report Form to generate the Daily Income
namespace Dental_Care
{
    public partial class IncomeReport : Form
    {
        List<Models.IncomeModel> incomereport;
        SqlDataAdapter sda;
        DataTable dt;
        float totalIncome;

        public IncomeReport()
        {
            InitializeComponent();
            this.totalIncome = this.getDatabaseList();
        }

        // This is the object oriented approach which is bit risky
        float getDatabaseList()
        {
            string connetionString = "Data Source=DESKTOP-S6B08UF\\SQLEXPRESS;Initial Catalog=DentalDB;Integrated Security=True";

            SqlConnection con = new SqlConnection(connetionString);

            con.Open();
            DateTime myDate = DateTime.Parse(DateTime.Today.ToString(), CultureInfo.CreateSpecificCulture("en-US"));

            //string query = "SELECT [Bill].[date] ,[DocName] ,[Amount] ,[patientName] ,[treatmentdescription],[BillNo]  FROM [DentalDB].[dbo].[Bill] bill inner join [DentalDB].[dbo].[Appointment] ap on ap.[App_ID] = bill.[Appointment_ID];";
            string query = "Select  [DocName],[patientName],[BillNo], Sum([Amount]) Over (Order By [BillNo]) As Income From   [DentalDB].[dbo].[Bill] rm inner join [DentalDB].[dbo].[Appointment] ap on ap.App_ID = rm.Appointment_ID AND rm.[date] = '" + myDate.ToString("d") + "';";
            SqlCommand command = new SqlCommand(query, con);

            IDataReader dr = command.ExecuteReader();
            incomereport = new List<Models.IncomeModel>();
            List<KeyValuePair<int, Models.DoctorAmountAndBillModel>> docAmountBillList = new List<KeyValuePair<int, Models.DoctorAmountAndBillModel>>();
            List<int> billList = new List<int>();
            List<string> doctorslist = new List<string>();

            // First read to get the value
            while (dr.Read())
            {
                Models.IncomeModel model = new Models.IncomeModel(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                incomereport.Add(model);
                int billNo = int.Parse(dr[5].ToString());
                float amount = float.Parse(dr[2].ToString());
                billList.Add(billNo);
                Models.DoctorAmountAndBillModel docamountModel = new Models.DoctorAmountAndBillModel(billNo, dr[1].ToString(), amount);
                docAmountBillList.Add(new KeyValuePair<int, Models.DoctorAmountAndBillModel>(billNo, docamountModel));
                doctorslist.Add(dr[1].ToString());
            }

            var distinnctDoctorList = doctorslist.Distinct().ToList();
            List<Models.DoctorIncomeModel> incomeModel = new List<Models.DoctorIncomeModel>();
            List<KeyValuePair<string, List<float>>> doctorIncome = new List<KeyValuePair<string, List<float>>>();


            // Second read to compare
            while (dr.Read())
            {

                distinnctDoctorList.ForEach(element =>
                {
                    if (element == dr[1].ToString())
                    {

                    }
                });
            }

            float intialamount = 0;
            docAmountBillList.ForEach(element =>
            {
                var docandAmountModel = element.Value;
                int bilKey = element.Key;

                billList.ForEach(biNo =>
                {                    
                    if(biNo == bilKey)
                    {
                        distinnctDoctorList.ForEach(doctor =>
                        {
                            
                            if (docandAmountModel.GetDocName() == doctor)
                            {
                                intialamount = intialamount + docandAmountModel.GetAmount();
                            }
                        });
                        
                    }
                    
                });

            });




            // income report is genenrated only for today which means only daily
            //DateTime today = DateTime.Today;
            //MessageBox.Show(today.ToString("d"));
            incomereport.ForEach(elment =>
            {
                //MessageBox.Show(elment.getDate());
                //MessageBox.Show(elment.getDocName());
                //MessageBox.Show(elment.getPatientName());
                //MessageBox.Show(elment.getTreatmentDescription());
                //MessageBox.Show(elment.getAmount());


            });
            return intialamount;
        }

      

        //Generates Income Report Once Loaded
        private void IncomeReport_Load(object sender, EventArgs e)
        {
            DateTime myDate = DateTime.Parse(DateTime.Today.ToString(), CultureInfo.CreateSpecificCulture("en-US"));
            //MessageBox.Show("Showing Income for Today  " + myDate.ToString("d"));
            try
            {
                string connetionString = "Data Source=DESKTOP-S6B08UF\\SQLEXPRESS;Initial Catalog=DentalDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connetionString);
                string query = "Select  [DocName],[patientName],[BillNo], Sum([Amount]) Over (Order By [BillNo]) As Income From   [DentalDB].[dbo].[Bill] rm inner join [DentalDB].[dbo].[Appointment] ap on ap.App_ID = rm.Appointment_ID AND rm.[date] = '" + myDate.ToString("d") + "';";
                SqlCommand command = new SqlCommand(query, con);
                sda = new SqlDataAdapter(command);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                label2.Text = this.totalIncome.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Please input in the correct format");
            }
        }
    }
}
