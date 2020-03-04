//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Component_A_ClassLibrary
//{
//    class DBConnection
//    {
//        private DBConnection()
//        {
//            // Empty constructor
//        }
//        // locker allows only one thread to enter the datbase at a time
//        // for expandablity mutex could be implemented to limite access across multiple processes
//        private static readonly object locker = new object();
//        private static DBConnection instance = null;

//        public static DBConnection Instance
//        {
//            get
//            {
//                lock (locker)
//                {
//                    if (instance == null)
//                    {
//                        instance = new DBConnection();
//                    }
//                    return instance;
//                }
//            }
//        }

//        //connection string
//        public static void GetConnection()
//        {
//            string connectionPath;
//            connectionPath = "Data Source=sql-server;Initial Catalog=ea3996r;User ID=ea3996r;Password=!1SQLServer";
//            SqlConnection cnn = new SqlConnection(connectionPath);
//            MessageBox.Show(connectionPath);

//            try
//            {
//                cnn.Open();
//                MessageBox.Show("Connection Open!!");
//            }
//            catch (Exception e)
//            {
//                MessageBox.Show("Connection cant open :( ");
//                throw;
//            }
             
//        }
//    }
//}
