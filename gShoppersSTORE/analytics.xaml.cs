using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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

namespace gShoppersSTORE
{
    /// <summary>
    /// Interaction logic for analytics.xaml
    /// </summary>
    ///  private string path;


    public partial class analytics : Window
    {
        private string path;

        public string passvalue
        {
            get { return path; }
            set { path = value; }
        }

        public analytics()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
           
        }
        private void combo1_details()
        {
            string path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\items_purshase.accdb;Persist Security Info=False";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select item from data;";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string store_items = reader.GetString(0);
                    comboBox133.Items.Add(store_items);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }
        public void whole_data()
        {
            string path_internal = @"\Database\";
            string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + @"\student_store_record.accdb; Persist Security Info = False";

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = conn;

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "SELECT * FROM data;";

                command.CommandText = query;
                command.ExecuteNonQuery();
                OleDbDataAdapter dataadp = new OleDbDataAdapter(command);
                DataTable dt = new DataTable("data");
                dataadp.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;
                //MessageBox.Show("Swaminarayan");
                connection.Close();
                DataView dv = (DataView)dataGrid1.ItemsSource;
                DataRowCollection drc = dv.Table.Rows;
                IEnumerator rowEnum = drc.GetEnumerator();
            }

            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }
        public void top_rate()
        {
            string path_internal = @"\Database\";
            string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + @"\student_store_record.accdb; Persist Security Info = False";

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = conn;

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "SELECT top 10 item, sum(qty)  as Quantity FROM data group by item ORDER BY sum(qty) DESC ;";

                command.CommandText = query;
                command.ExecuteNonQuery();
                OleDbDataAdapter dataadp = new OleDbDataAdapter(command);
                DataTable dt = new DataTable("data");
                dataadp.Fill(dt);
                dataGrid2.ItemsSource = dt.DefaultView;
                //MessageBox.Show("Swaminarayan");
                connection.Close();
                DataView dv = (DataView)dataGrid2.ItemsSource;
                DataRowCollection drc = dv.Table.Rows;
                IEnumerator rowEnum = drc.GetEnumerator();
            }

            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }

        private void itm_sold_date_Copy_Click(object sender, RoutedEventArgs e)                                 //Search by mid
        {
            dataGrid1.ItemsSource = null;
            string path_internal = @"\Database\";
            string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + @"\student_store_record.accdb; Persist Security Info = False";

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = conn;

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "SELECT * FROM data where Member_Id = '"+mid_search.Text+"';";

                command.CommandText = query;
                command.ExecuteNonQuery();
                OleDbDataAdapter dataadp = new OleDbDataAdapter(command);
                DataTable dt = new DataTable("data");
                dataadp.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;
                //MessageBox.Show("Swaminarayan");
                connection.Close();
                DataView dv = (DataView)dataGrid1.ItemsSource;
                DataRowCollection drc = dv.Table.Rows;
                IEnumerator rowEnum = drc.GetEnumerator();
            }

            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }

        private void product_id_search_Click(object sender, RoutedEventArgs e)
        {
            dataGrid1.ItemsSource = null;
            string path_internal = @"\Database\";
            string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + @"\student_store_record.accdb; Persist Security Info = False";

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = conn;

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "SELECT * FROM data where product_id = '" + product_id_search1.Text + "';";

                command.CommandText = query;
                command.ExecuteNonQuery();
                OleDbDataAdapter dataadp = new OleDbDataAdapter(command);
                DataTable dt = new DataTable("data");
                dataadp.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;
                //MessageBox.Show("Swaminarayan");
                connection.Close();
                DataView dv = (DataView)dataGrid1.ItemsSource;
                DataRowCollection drc = dv.Table.Rows;
                IEnumerator rowEnum = drc.GetEnumerator();
            }

            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }                                 // Search by Product ID

        private void itm_sold_date_Click(object sender, RoutedEventArgs e)
        {
            dataGrid1.ItemsSource = null;
            string path_internal = @"\Database\";
            string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + @"\student_store_record.accdb; Persist Security Info = False";

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = conn;

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "SELECT * FROM data;";

                command.CommandText = query;
                command.ExecuteNonQuery();
                OleDbDataAdapter dataadp = new OleDbDataAdapter(command);
                DataTable dt = new DataTable("data");
                dataadp.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;
                //MessageBox.Show("Swaminarayan");
                connection.Close();
                DataView dv = (DataView)dataGrid1.ItemsSource;
                DataRowCollection drc = dv.Table.Rows;
                IEnumerator rowEnum = drc.GetEnumerator();
            }

            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
            mid_search.Text = "Enter MID";
            product_id_search1.Text = "Product ID";
            roomno.Text = "Room Number";

        }

        private void roomno1_Click(object sender, RoutedEventArgs e)
        {
            dataGrid1.ItemsSource = null;
            string path_internal = @"\Database\";
            string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + @"\student_store_record.accdb; Persist Security Info = False";

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = conn;

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "SELECT * FROM data where Room_cup LIKE '" + roomno.Text + "%';";

                command.CommandText = query;
                command.ExecuteNonQuery();
                OleDbDataAdapter dataadp = new OleDbDataAdapter(command);
                DataTable dt = new DataTable("data");
                dataadp.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;
                //MessageBox.Show("Swaminarayan");
                connection.Close();
                DataView dv = (DataView)dataGrid1.ItemsSource;
                DataRowCollection drc = dv.Table.Rows;
                IEnumerator rowEnum = drc.GetEnumerator();
            }
            catch {
                MessageBox.Show("SOME THING IS WRONG");
            }

            }                                  //Search by ROOM

        private void date_info_Click(object sender, RoutedEventArgs e)                                   // Search by DATE
        {
            dataGrid1.ItemsSource = null;
            string path_internal = @"\Database\";
            string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + @"\student_store_record.accdb; Persist Security Info = False";

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = conn;

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "SELECT * FROM data where Datee = '" + datapicker.Text + "';";

                command.CommandText = query;
                command.ExecuteNonQuery();
                OleDbDataAdapter dataadp = new OleDbDataAdapter(command);
                DataTable dt = new DataTable("data");
                dataadp.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;
                //MessageBox.Show("Swaminarayan");
                connection.Close();
                DataView dv = (DataView)dataGrid1.ItemsSource;
                DataRowCollection drc = dv.Table.Rows;
                IEnumerator rowEnum = drc.GetEnumerator();
            }
            catch
            {
                MessageBox.Show("SOME THING IS WRONG");
            }
        }

        private void getp_code_Click(object sender, RoutedEventArgs e)                            // Get Product CODE
        {
            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\items_purshase.accdb;Persist Security Info=False";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from data where Item='" + comboBox133.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    p_code.Text = reader["product_id"].ToString();
                   amt.Text = reader["Price"].ToString();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }

     
        OleDbConnection con;
        OleDbDataAdapter adap;
        DataSet ds;
        OleDbCommandBuilder cmdbl;

        //--------------------------------------------
        OleDbConnection con1;
        OleDbDataAdapter adap1;
        DataSet ds1;
        OleDbCommandBuilder cmdbl1;


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //whole_data();
            top_rate();
            combo1_details();
            ////////////////////////////////////////////////////////
            con = new OleDbConnection();
            string path_internal = @"\Database\";
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + @"\Database_current.accdb; Persist Security Info = False";
            con.Open();
            adap = new OleDbDataAdapter("select * from data;",con);
            ds = new System.Data.DataSet();
            adap.Fill(ds, "details");
            dataGrid.ItemsSource = ds.Tables[0].DefaultView;
            ////////////////////////////////////////////////////////////
           
            con1 = new OleDbConnection();
            //string path_internal = @"\Database\";
            con1.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + @"\student_store_record.accdb; Persist Security Info = False";
            con1.Open();
            adap1 = new OleDbDataAdapter("select * from data;", con1);
            ds1 = new System.Data.DataSet();
            adap1.Fill(ds1, "details");
            dataGrid1.ItemsSource = ds1.Tables[0].DefaultView;
            /////////////////////////////////////////////////////////////
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {           
           
        }

        private void update_data_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cmdbl = new OleDbCommandBuilder(adap);
                adap.Update(ds, "details");
                MessageBox.Show("Information Updated", "Update", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK);
            }

        }

        private void update_data_storerecord_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cmdbl1 = new OleDbCommandBuilder(adap1);
                adap1.Update(ds1, "details");
                MessageBox.Show("Information Updated", "Update", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK);
            }

        }

    } 
   


}
        
   