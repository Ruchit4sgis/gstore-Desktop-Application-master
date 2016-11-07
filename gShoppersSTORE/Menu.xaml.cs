using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Net;
using System.IO;

namespace gShoppersSTORE
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        string result = System.IO.Path.GetTempPath();
        string path_con = @""+ System.IO.Path.GetTempPath()+ @"\gd.txt";
        string path_user = @""+ System.IO.Path.GetTempPath()+@"\gu.txt";
        string path_pass = @"" + System.IO.Path.GetTempPath() + @"\gp.txt";
        string path_file = @"" + System.IO.Path.GetTempPath() + @"\file.txt";
        string path = @"" + System.IO.Path.GetTempPath() + @"\swaminarayan.txt";
        private string login_as;
        public string passvalue
        {
            get { return login_as; }
            set { login_as = value; }
        }
        

        public Menu()
        {
            InitializeComponent();
            datapicker.SelectedDate = DateTime.Today;
        }

        private void BtnStockin (object sender, RoutedEventArgs e)
        {
            getconnect();
            connect();
            string pass = file_c.Text;         
            Stockin stockin = new Stockin();
            stockin.passvalue = pass;
            stockin.ShowDialog();            
        }

             

        private void back(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            userq.Text = login_as;
            if (userq.Text == "store" || userq.Text == "mayank")
            {
                store.Visibility = Visibility.Visible;
                sett1.Visibility = Visibility.Visible;
                raipur2.Visibility = Visibility.Visible;
            }
            if (userq.Text == "print")
            {
                print1.Visibility = Visibility.Visible;
                print2.Visibility = Visibility.Visible;
                sett1.Visibility = Visibility.Visible;
            }
            if (userq.Text == "hari")
            {
                print1.Visibility = Visibility.Visible;
                sett1.Visibility = Visibility.Visible;
            }
            if (userq.Text == "raipur")
            {
                raipur1.Visibility = Visibility.Visible;
                raipur2.Visibility = Visibility.Visible;
            }
        }

        private void swaminarayan()
        {
            if (File.Exists(path_con) && File.Exists(path_user) && File.Exists(path_pass) && File.Exists(path_file))
            {
                getconnect();
                connect();
            }
            else
            {
                //MessageBox.Show("The gStore Servers are Down Right Now | Try to Login Later or Contact to Administrator");
                label1.Content = "The gStore Servers are Down Right Now | Try to Login Later or Contact to Administrator";
            }
        }
        private void connect()
        {
            try
            {
                System.Net.NetworkCredential readCredentials = new NetworkCredential(domain.Text+"\\"+user_c.Text, password.Password);

                string filepath = file_c.Text;
                using (new NetworkConnection(filepath, readCredentials))
                {
                    if (File.Exists(file_c.Text + @"\Database\stockin\swaminarayan.txt"))
                    {
                        File.Delete(file_c.Text + @"\Database\stockin\swaminarayan.txt");
                    }
                    try
                    {
                        File.Copy(file_c.Text + @"\Database\swaminarayan.txt", file_c.Text + @"\Database\stockin");
                    }
                    catch
                    {

                    }
                    
                }
                //Assert.AreEqual<string>("01", "01", "Success");
            }
            catch(Exception e)
            {
                //Assert.Fail();
                MessageBox.Show(""+e);
            }
        }
        //public static string TextFollowing(string txt, string value)
        //{
        //    if (!String.IsNullOrEmpty(txt) && !String.IsNullOrEmpty(value))
        //    {
        //        int index = txt.IndexOf(value);
        //        if (-1 < index)
        //        {
        //            int start = index + value.Length;
        //            if (start <= txt.Length)
        //            {
        //                return txt.Substring(start);
        //            }
        //        }
        //    }
        //    return null;
        //}
        private void getconnect()
        {

            try
            {
                string dom = File.ReadAllText(path_con, Encoding.UTF8);
                string us = File.ReadAllText(path_user, Encoding.UTF8);
                string pass = File.ReadAllText(path_pass, Encoding.UTF8);
                string fil = File.ReadAllText(path_file, Encoding.UTF8);
                dom = dom.Replace(System.Environment.NewLine, string.Empty);
                us = us.Replace(System.Environment.NewLine, string.Empty);
                pass = pass.Replace(System.Environment.NewLine, string.Empty);
                fil = fil.Replace(System.Environment.NewLine, string.Empty);
                domain.Text = dom;
                user_c.Text = us;
                password.Password = pass;
                file_c.Text = fil;
            }
            catch
            {
                MessageBox.Show("Connection Coudld not Establish Contact to Admin");
            }
           
            
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Store Butten_click evnts
        {
            getconnect();
            connect();
            string pass = file_c.Text;
            gstore Gstore = new gstore();
            Gstore.passvalue = pass;
            Gstore.ShowDialog();
            

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            connect();
            getconnect();
            if (name.Text == "" || name.Text == "Name" || prob.Text == "" || prob.Text == "How we can Help ?")
            {
                MessageBox.Show("Name or PRoblem is Empty will fill it");
            }
            else
            {
                feedback();
            }
        }   // feedback butojn click
        private void feedback() {
            string path_internal = @"\Database\";
            string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + "feedback.accdb; Persist Security Info = False";

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = conn;

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "INSERT INTo data values('" + name.Text + "','" + prob.Text + "','" + datapicker.DataContext + "');";

                command.CommandText = query;

                command.ExecuteNonQuery();
                MessageBox.Show("Your Problem is Successfully Noted soon you will get the Solution");
                connection.Close();
                name.Text = "";
                prob.Text = "";
            }

            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }          //Feedback method

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            getconnect();
            connect();
            string pass = file_c.Text;
            Print print = new Print();
            print.passvalue = pass;
            print.ShowDialog();
           

        }

        private void stu_credit(object sender, RoutedEventArgs e)
        {
            getconnect();
            connect();
            String pass = file_c.Text;
            stu_credit stu_credit = new stu_credit();
            stu_credit.passvalue = pass;
            stu_credit.ShowDialog();
        }

        private void store_list_horizantal(object sender, RoutedEventArgs e)
        {
            getconnect();
            connect();
            string pass = file_c.Text;
            store_list_horizantal slh = new store_list_horizantal();
            slh.passvalue = pass;
            slh.ShowDialog();            

        }
            


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(path_con))
            {
                File.Delete(path_con);
            }
            if (File.Exists(path_user))
            {
                File.Delete(path_user);
            }
            if (File.Exists(path_pass))
            {
                File.Delete(path_pass);
            }
            if (File.Exists(path_file))
            {
                File.Delete(path_file);
            }
            if (!File.Exists(path_user) )
            {
                //File.Create(path_user);
                using (TextWriter tw = new StreamWriter(path_user))
                {
                    tw.WriteLine(user_c.Text);
                    tw.Close();
                }
            }
            if(!File.Exists(path_con))
            {
                //File.Create(path_con);
                using (TextWriter tw = new StreamWriter(path_con))
                {
                    tw.WriteLine(domain.Text);
                    tw.Close();
                }                    
                
                
            }
            if (!File.Exists(path_pass))
            {
                //File.Create(path_pass);
                using (TextWriter tw = new StreamWriter(path_pass))
                {
                    tw.WriteLine(password.Password);
                    tw.Close();
                }
            }
            if (!File.Exists(path_file))
            {
                //File.Create(path_file);
                using (TextWriter tw = new StreamWriter(path_file))
                {
                    tw.WriteLine(file_c.Text);
                    tw.Close();
                }
            }
            getconnect();
            MessageBox.Show("Updated Successfully");

        }

        public class NetworkConnection : IDisposable
        {
            string _networkName;

            public NetworkConnection(string networkName,
                NetworkCredential credentials)
            {
                _networkName = networkName;

                var netResource = new NetResource()
                {
                    Scope = ResourceScope.GlobalNetwork,
                    ResourceType = ResourceType.Disk,
                    DisplayType = ResourceDisplaytype.Share,
                    RemoteName = networkName
                };
               
                var result = WNetAddConnection2(
                    netResource,
                    credentials.Password,
                    credentials.UserName,
                    0);

                if (result != 0)
                {
                    throw new Win32Exception(result, "Error connecting to remote share");
                }
            }

            ~NetworkConnection()
            {
                Dispose(false);
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                WNetCancelConnection2(_networkName, 0, true);
            }

            [DllImport("mpr.dll")]
            private static extern int WNetAddConnection2(NetResource netResource,
                string password, string username, int flags);

            [DllImport("mpr.dll")]
            private static extern int WNetCancelConnection2(string name, int flags,
                bool force);
        }

        [StructLayout(LayoutKind.Sequential)]
        public class NetResource
        {
            public ResourceScope Scope;
            public ResourceType ResourceType;
            public ResourceDisplaytype DisplayType;
            public int Usage;
            public string LocalName;
            public string RemoteName;
            public string Comment;
            public string Provider;
        }

        public enum ResourceScope : int
        {
            Connected = 1,
            GlobalNetwork,
            Remembered,
            Recent,
            Context
        };

        public enum ResourceType : int
        {
            Any = 0,
            Disk = 1,
            Print = 2,
            Reserved = 8,
        }

        public enum ResourceDisplaytype : int
        {
            Generic = 0x0,
            Domain = 0x01,
            Server = 0x02,
            Share = 0x03,
            File = 0x04,
            Group = 0x05,
            Network = 0x06,
            Root = 0x07,
            Shareadmin = 0x08,
            Directory = 0x09,
            Tree = 0x0a,
            Ndscontainer = 0x0b
        }

        private void colse_sett(object sender, RoutedEventArgs e)
        {
            sett.Visibility = Visibility.Hidden;
        }

        private void set(object sender, RoutedEventArgs e)
        {
            sett.Visibility = Visibility.Visible;
        }

        private void store_list(object sender, RoutedEventArgs e)
        {
            getconnect();
            connect();
            string pass = file_c.Text;
            store_list slh = new store_list();
            slh.passvalue = pass;
            slh.ShowDialog();
        }

        private void report_today_Click(object sender, RoutedEventArgs e)
        {
            getconnect();
            connect();
            string pass = file_c.Text;
            daily_store_record slh = new daily_store_record();
            slh.passvalue = pass;
            slh.ShowDialog();
        }

        private void analystics_Click(object sender, RoutedEventArgs e)
        {
            getconnect();
            connect();
            string pass = file_c.Text;
            analytics slh = new analytics();
            slh.passvalue = pass;
            slh.ShowDialog();
        }
    }
}
