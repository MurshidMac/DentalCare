using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Dental_Care
{
    static class Program
    {

        public static Boolean connectToDatabase()
        {
            SqlConnection connection = new SqlConnection("Server=tcp:jobs.database.windows.net,1433;Initial Catalog=Jobs;Persist Security Info=False;User ID=murshid;Password=10170@Hotmail;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return true;
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            connectToDatabase();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
