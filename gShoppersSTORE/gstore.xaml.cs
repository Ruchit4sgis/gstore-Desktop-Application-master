using System;
using System.Collections.Generic;
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
    /// Interaction logic for gstore.xaml
    /// </summary>
    public partial class gstore : Window
    {
        //String path = System.IO.Directory.GetCurrentDirectory();
        // private String login_as;
        public string path;

        public string passvalue
        {
            get { return path; }
            set { path = value; }
        }


        public gstore()
        {
            InitializeComponent();
            datapicker.SelectedDate = DateTime.Today;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            //userq.Text = login_as;
            combo1_details();
            combo2_details();
            combo3_details();
            combo4_details();
            combo5_details();
            combo6_details();
            combo7_details();
            combo8_details();
            string a = path;
            if (mid.Text.Length == 5 || Name.Text != "" || befor_balance.Text != "")
            {

            }
            else { tip1.Visibility = Visibility.Visible; }

        }


        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            String path_internal = @"\Database\stu_imgs\";
            String student_entry = mid.Text;
            if (student_entry.Length == 6)
            {
                try
                {
                    image.Source = new BitmapImage(new Uri(@"" + path + path_internal + student_entry + ".jpg"));
                }
                catch
                {
                    image.Source = new BitmapImage(new Uri(@"" + path + path_internal + "no_image.jpg"));
                }

                try
                {

                    get_student_details();
                    //get_before_details();    
                }
                catch (Exception)
                {
                    MessageBox.Show("Invallid MID");
                    Name.Text = "";
                    c_sec.Content = "";
                    Room_cup.Content = "";
                }
            }
            else
            {
                image.Source = new BitmapImage(new Uri(@"" + path + path_internal + "no_image.jpg"));
            }



        }
        private void get_student_details()
        {
            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\Database_current.accdb;Persist Security Info=False";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from data where Member_Id='" + mid.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Name.Text = reader["Name"].ToString();
                    c_sec.Content = reader["Class"].ToString();
                    Room_cup.Content = reader["Room_cup"].ToString();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }
        //private void get_before_details()
        //{
        //    String path_internal = @"\Database";
        //    OleDbConnection connection = new OleDbConnection();
        //    connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\student_current_balance.accdb;Persist Security Info=False";

        //    try
        //    {
        //        connection.Open();
        //        OleDbCommand command = new OleDbCommand();
        //        command.Connection = connection;
        //        string query = "select current_balance from data where mid='" + mid.Text + "'";
        //        command.CommandText = query;

        //        OleDbDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            befor_balance.Text = reader["Current_balance"].ToString();                   
        //        }
        //        connection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("SOME THING IS WRONG" + ex);
        //    }
        //}


        private void combo1_details()
        {
            String path_internal = @"\Database";
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
                    comboBox1.Items.Add(store_items);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }
        private void combo2_details()
        {

            String path_internal = @"\Database";
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
                    comboBox2.Items.Add(store_items);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }

        }
        private void combo3_details()
        {

            String path_internal = @"\Database";
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
                    comboBox3.Items.Add(store_items);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }

        }
        private void combo4_details()
        {

            String path_internal = @"\Database";
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
                    comboBox4.Items.Add(store_items);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }

        }
        private void combo5_details()
        {

            String path_internal = @"\Database";
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
                    String store_items = reader.GetString(0);
                    comboBox5.Items.Add(store_items);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }
        private void combo6_details()
        {

            String path_internal = @"\Database";
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
                    String store_items = reader.GetString(0);
                    comboBox6.Items.Add(store_items);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }
        private void combo7_details()
        {

            String path_internal = @"\Database";
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
                    String store_items = reader.GetString(0);
                    comboBox7.Items.Add(store_items);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }
        private void combo8_details()
        {

            String path_internal = @"\Database";
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
                    String store_items = reader.GetString(0);
                    comboBox8.Items.Add(store_items);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\items_purshase.accdb;Persist Security Info=False";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select price from data where item = '" + comboBox1.SelectedItem + "';";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String store_price = reader.GetString(0);
                    itm_price.Text = store_price;
                }
                connection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("SOME THING IS WRONG" + ex);
                itm_price.Text = "";
            }
            if (comboBox1.SelectedValue == null) {
                itm_price.Text = "";
            }
            prodict_id1();
           

        }
        public void prodict_id1()
        {

            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\items_purshase.accdb;Persist Security Info=False";
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select product_id from data where item = '" + comboBox1.SelectedItem + "';";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string product_id = reader.GetString(0);
                    pid1.Content = product_id;
                }
                connection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("SOME THING IS WRONG" + ex);
                pid1.Content = "";
            }
        }
        public void prodict_id2()
        {

            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\items_purshase.accdb;Persist Security Info=False";
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select product_id from data where item = '" + comboBox2.SelectedItem + "';";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string product_id = reader.GetString(0);
                    pid2.Content = product_id;
                }
                connection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("SOME THING IS WRONG" + ex);
                pid2.Content = "";
            }
        }
        public void prodict_id3()
        {

            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\items_purshase.accdb;Persist Security Info=False";
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select product_id from data where item = '" + comboBox3.SelectedItem + "';";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string product_id = reader.GetString(0);
                    pid3.Content = product_id;
                }
                connection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("SOME THING IS WRONG" + ex);
                pid3.Content = "";
            }
        }
        public void prodict_id4()
        {

            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\items_purshase.accdb;Persist Security Info=False";
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select product_id from data where item = '" + comboBox4.SelectedItem + "';";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string product_id = reader.GetString(0);
                    pid4.Content = product_id;
                }
                connection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("SOME THING IS WRONG" + ex);
                pid4.Content = "";
            }
        }
        public void prodict_id5()
        {

            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\items_purshase.accdb;Persist Security Info=False";
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select product_id from data where item = '" + comboBox5.SelectedItem + "';";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string product_id = reader.GetString(0);
                    pid5.Content = product_id;
                }
                connection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("SOME THING IS WRONG" + ex);
                pid5.Content = "";
            }
        }
        public void prodict_id6()
        {

            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\items_purshase.accdb;Persist Security Info=False";
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select product_id from data where item = '" + comboBox6.SelectedItem + "';";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string product_id = reader.GetString(0);
                    pid6.Content = product_id;
                }
                connection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("SOME THING IS WRONG" + ex);
                pid6.Content = "";
            }
        }
        public void prodict_id7()
        {

            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\items_purshase.accdb;Persist Security Info=False";
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select product_id from data where item = '" + comboBox7.SelectedItem + "';";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string product_id = reader.GetString(0);
                    pid7.Content = product_id;
                }
                connection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("SOME THING IS WRONG" + ex);
                pid7.Content = "";
            }
        }
        public void prodict_id8()
        {

            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\items_purshase.accdb;Persist Security Info=False";
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select product_id from data where item = '" + comboBox8.SelectedItem + "';";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string product_id = reader.GetString(0);
                    pid8.Content = product_id;
                }
                connection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("SOME THING IS WRONG" + ex);
                pid8.Content = "";
            }
        }
        private void comboBox1_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\items_purshase.accdb;Persist Security Info=False";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select price from data where item = '" + comboBox2.SelectedItem + "';";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String store_price = reader.GetString(0);
                    itm_price2.Text = store_price;
                }
                connection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("SOME THING IS WRONG" + ex);
                itm_price2.Text = "";
            }
            if (comboBox2.SelectedValue == null)
            {
                itm_price2.Text = "";
            }
            prodict_id2();
           
        }
        private void comboBox1_SelectionChanged3(object sender, SelectionChangedEventArgs e)
        {
            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\items_purshase.accdb;Persist Security Info=False";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select price from data where item = '" + comboBox3.SelectedItem + "';";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String store_price = reader.GetString(0);
                    itm_price3.Text = store_price;
                }
                connection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("SOME THING IS WRONG" + ex);
                itm_price3.Text = "";
            }
            if (comboBox3.SelectedValue == null)
            {
                itm_price3.Text = "";
            }
            prodict_id3();
           
        }
        private void comboBox1_SelectionChanged4(object sender, SelectionChangedEventArgs e)
        {
            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\items_purshase.accdb;Persist Security Info=False";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select price from data where item = '" + comboBox4.SelectedItem + "';";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String store_price = reader.GetString(0);
                    itm_price4.Text = store_price;
                }
                connection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("SOME THING IS WRONG" + ex);
                itm_price4.Text = "";
            }
            if (comboBox4.SelectedValue == null)
            {
                itm_price4.Text = "";
            }
            prodict_id4();
           
        }
        private void comboBox1_SelectionChanged5(object sender, SelectionChangedEventArgs e)
        {
            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\items_purshase.accdb;Persist Security Info=False";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select price from data where item = '" + comboBox5.SelectedItem + "';";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String store_price = reader.GetString(0);
                    itm_price5.Text = store_price;
                }
                connection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("SOME THING IS WRONG" + ex);
                itm_price5.Text = "";
            }
            if (comboBox5.SelectedValue == null)
            {
                itm_price5.Text = "";
            }
            prodict_id5();
           
        }
        private void comboBox1_SelectionChanged6(object sender, SelectionChangedEventArgs e)
        {
            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\items_purshase.accdb;Persist Security Info=False";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select price from data where item = '" + comboBox6.SelectedItem + "';";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String store_price = reader.GetString(0);
                    itm_price6.Text = store_price;
                }
                connection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("SOME THING IS WRONG" + ex);
                itm_price6.Text = "";
            }
            if (comboBox6.SelectedValue == null)
            {
                itm_price6.Text = "";
            }
            prodict_id6();
            
        }
        private void comboBox1_SelectionChanged7(object sender, SelectionChangedEventArgs e)
        {
            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\items_purshase.accdb;Persist Security Info=False";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select price from data where item = '" + comboBox7.SelectedItem + "';";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String store_price = reader.GetString(0);
                    itm_price7.Text = store_price;
                }
                connection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("SOME THING IS WRONG" + ex);
                itm_price7.Text = "";
            }
            if (comboBox7.SelectedValue == null)
            {
                itm_price7.Text = "";
            }
            prodict_id7();
            
        }
        private void comboBox1_SelectionChanged8(object sender, SelectionChangedEventArgs e)
        {
            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\items_purshase.accdb;Persist Security Info=False";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select price from data where item = '" + comboBox8.SelectedItem + "';";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String store_price = reader.GetString(0);
                    itm_price8.Text = store_price;
                }
                connection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("SOME THING IS WRONG" + ex);
                itm_price8.Text = "";
            }
            if (comboBox8.SelectedValue == null)
            {
                itm_price8.Text = "";
            }
            prodict_id8();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                int a;
                a = comboBox_itm_qty.SelectedIndex;
            if (comboBox1.SelectedIndex > -1)
            {
                double total;
                double price_itm = 0.0;
                price_itm = double.Parse(itm_price.Text);
                total = (a + 1) * price_itm;
                itm_total.Text = total.ToString();
                del1.Visibility = Visibility.Visible;
                row2.IsEnabled = true;
                
            }
            else
            {
                //MessageBox.Show("Make Sure that You Have Selected between 1 to 10");
            }               

        }
        private void comboBox_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            int a;
            a = comboBox_itm_qty2.SelectedIndex;
            if (comboBox2.SelectedIndex > -1)
            {
                double total;
                double price_itm = 0.0;
                price_itm = double.Parse(itm_price2.Text);
                total = (a + 1) * price_itm;
                itm_total2.Text = total.ToString();
                del2.Visibility = Visibility.Visible;
                row3.IsEnabled = true;
            }
            else
            {
               // MessageBox.Show("Make Sure that You Have Selected between 1 to 10");
            }

        }
        private void comboBox_SelectionChanged3(object sender, SelectionChangedEventArgs e)
        {
            int a;
            a = comboBox_itm_qty3.SelectedIndex;
            if (comboBox3.SelectedIndex > -1)
            {
                double total;
                double price_itm = 0.0;
                price_itm = double.Parse(itm_price3.Text);
                total = (a + 1) * price_itm;
                itm_total3.Text = total.ToString();
                del3.Visibility = Visibility.Visible;
                row4.IsEnabled = true;
            }
            else
            {
               // MessageBox.Show("Make Sure that You Have Selected between 1 to 10");
            }

        }
        private void comboBox_SelectionChanged4(object sender, SelectionChangedEventArgs e)
        {
            int a;
            a = comboBox_itm_qty4.SelectedIndex;
            if (comboBox4.SelectedIndex > -1)
            {
                double total;
                double price_itm = 0.0;
                price_itm = double.Parse(itm_price4.Text);
                total = (a + 1) * price_itm;
                itm_total4.Text = total.ToString();
                del4.Visibility = Visibility.Visible;
                row5.IsEnabled = true;
            }
            else
            {
              //  MessageBox.Show("Make Sure that You Have Selected between 1 to 10");
            }


        }
        private void comboBox_SelectionChanged5(object sender, SelectionChangedEventArgs e)
        {
            int a;
            a = comboBox_itm_qty5.SelectedIndex;
            if (comboBox5.SelectedIndex > -1)
            {
                double total;
                double price_itm = 0.0;
                price_itm = double.Parse(itm_price5.Text);
                total = (a + 1) * price_itm;
                itm_total5.Text = total.ToString();
                del5.Visibility = Visibility.Visible;
                row6.IsEnabled = true;
            }
            else
            {
              //  MessageBox.Show("Make Sure that You Have Selected between 1 to 10");
            }
        }
        private void comboBox_SelectionChanged6(object sender, SelectionChangedEventArgs e)
        {
            int a;
            a = comboBox_itm_qty6.SelectedIndex;
            if (comboBox6.SelectedIndex > -1)
            {
                double total;
                double price_itm=0.0;
                price_itm = double.Parse(itm_price6.Text);
                total = (a + 1) * price_itm;
                itm_total6.Text = total.ToString();
                del6.Visibility = Visibility.Visible;
                row7.IsEnabled = true;
            }
            else
            {
               // MessageBox.Show("Make Sure that You Have Selected between 1 to 10");
            }
        }
        private void comboBox_SelectionChanged7(object sender, SelectionChangedEventArgs e)
        {
            int a;
            a = comboBox_itm_qty7.SelectedIndex;
            if (comboBox7.SelectedIndex > -1)
            {
                double total;
                double price_itm = 0.0;
                price_itm = double.Parse(itm_price7.Text);
                total = (a + 1) * price_itm;
                itm_total7.Text = total.ToString();
                del7.Visibility = Visibility.Visible;
                row8.IsEnabled = true;
            }
            else
            {
              //  MessageBox.Show("Make Sure that You Have Selected between 1 to 10");
            }
        }
        private void comboBox_SelectionChanged8(object sender, SelectionChangedEventArgs e)
        {
            int a;
            a = comboBox_itm_qty8.SelectedIndex;
            if (comboBox8.SelectedIndex > -1)
            {
                double total;
                double price_itm = 0.0;
                price_itm = double.Parse(itm_price8.Text);
                total = (a + 1) * price_itm;
                itm_total8.Text = total.ToString();
                del8.Visibility = Visibility.Visible;
            }
            else
            {
               // MessageBox.Show("Make Sure that You Have Selected between 1 to 10");
            }
        }

        private void itm_total_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (itm_total.Text == "")
            {
                one_row.Text = "";
            }
            else
            {
                one_row.Text = "1";
            }

        }
        private void itm_total2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (itm_total2.Text == "")
            {
                two_row.Text = "";
            }
            else
            {
                two_row.Text = "1";
            }
        }
        private void itm_total3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (itm_total3.Text == "")
            {
                three_row.Text = "";
            }
            else
            {
                three_row.Text = "1";
            }

        }
        private void itm_total4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (itm_total4.Text == "")
            {
                four_row.Text = "";
            }
            else
            {
                four_row.Text = "1";
            }
        }
        private void itm_total5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (itm_total5.Text == "")
            {
                five_row.Text = "";
            }
            else
            {
                five_row.Text = "1";
            }
        }
        private void itm_total6_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (itm_total6.Text == "")
            {
                six_row.Text = "";
            }
            else
            {
                six_row.Text = "1";
            }
        }
        private void itm_total7_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (itm_total7.Text == "")
            {
                seven_row.Text = "";
            }
            else
            {
                seven_row.Text = "1";
            }
        }
        private void itm_total8_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (itm_total8.Text == "")
            {
                eight_row.Text = "";
            }
            else
            {
                eight_row.Text = "1";
            }
        }

        private void del1_Click(object sender, RoutedEventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox_itm_qty.SelectedIndex = -1;
            itm_price.Text = "";
            itm_total.Text = "";
            pid1.Content = "";
        }
        private void del2_Click(object sender, RoutedEventArgs e)
        {
            comboBox2.SelectedIndex = -1;
            comboBox_itm_qty2.SelectedIndex = -1;
            itm_price2.Text = "";
            itm_total2.Text = "";
            pid2.Content = "";

        }
        private void del3_Click(object sender, RoutedEventArgs e)
        {
            comboBox3.SelectedIndex = -1;
            comboBox_itm_qty3.SelectedIndex = -1;
            itm_price3.Text = "";
            itm_total3.Text = "";
            pid3.Content = "";
        }
        private void del4_Click(object sender, RoutedEventArgs e)
        {
            comboBox4.SelectedIndex = -1;
            comboBox_itm_qty4.SelectedIndex = -1;
            itm_price4.Text = "";
            itm_total4.Text = "";
            pid4.Content = "";
        }
        private void del5_Click(object sender, RoutedEventArgs e)
        {
            comboBox5.SelectedIndex = -1;
            comboBox_itm_qty5.SelectedIndex = -1;
            itm_price5.Text = "";
            itm_total5.Text = "";
            pid5.Content = "";
        }
        private void del6_Click(object sender, RoutedEventArgs e)
        {
            comboBox6.SelectedIndex = -1;
            comboBox_itm_qty6.SelectedIndex = -1;
            itm_price6.Text = "";
            itm_total6.Text = "";
        }
        private void del7_Click(object sender, RoutedEventArgs e)
        {
            comboBox7.SelectedIndex = -1;
            comboBox_itm_qty7.SelectedIndex = -1;
            itm_price7.Text = "";
            itm_total7.Text = "";
            pid7.Content = "";
        }
        private void del8_Click(object sender, RoutedEventArgs e)
        {
            comboBox8.SelectedIndex = -1;
            comboBox_itm_qty8.SelectedIndex = -1;
            itm_price8.Text = "";
            itm_total8.Text = "";
            pid8.Content = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)  //BUY BUTTON
        {
            if (Name.Text == "")
            {
                Environment.Exit(0);
            }
            row_one();
            row_two();
            row_three();
            row_four();
            row_five();
            row_six();
            row_seven();
            row_eight();
            clear_all();

            //int a = 0;
            //int b = 0;
            //int c = 0;
            //int d = 0;
            //int swaminarayan = 0;
            //int f = 0;
            //int g = 0;
            //int h = 0;

            //int total_price;
            //if (itm_price.Text == "")  { } else {  a = int.Parse(itm_total.Text);  }
            //if (itm_price2.Text == "") { } else {  b = int.Parse(itm_total2.Text); }
            //if (itm_price3.Text == "") { } else {  c = int.Parse(itm_total3.Text); }
            //if (itm_price4.Text == "") { } else {  d = int.Parse(itm_total4.Text); }
            //if (itm_price5.Text == "") { } else {  swaminarayan = int.Parse(itm_total5.Text); }
            //if (itm_price6.Text == "") { } else {  f = int.Parse(itm_total6.Text); }
            //if (itm_price7.Text == "") { } else {  g = int.Parse(itm_total7.Text); }
            //if (itm_price8.Text == "") { } else {  h = int.Parse(itm_total8.Text); }

            //total_price = a + b + c + d + swaminarayan + f + g + h;
            //debit.Content = total_price.ToString();
            //int balance;
            //int b_balance = int.Parse(befor_balance.Text);
            //balance = b_balance - total_price;
            //final_balance.Content = balance.ToString();
            //final_call();

            //tip1.Visibility = Visibility.Visible;



        }

        private void row_one()
        {
            if (one_row.Text == "1")
            {
                string path_internal = @"\Database";
                string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + @"\student_store_record.accdb; Persist Security Info = False";

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = conn;

                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "INSERT INTo data(Member_Id,Name,Room_cup,Class,Datee,product_id,Item,Qty,per_itm,Amount_debit) values('" + mid.Text + "','" + Name.Text + "','" + Room_cup.Content + "','" + c_sec.Content + "','" + datapicker.Text + "','" + pid1.Content + "','" + comboBox1.Text + "','" + comboBox_itm_qty.Text + "','" + itm_price.Text + "','" + itm_total.Text + "');";
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    MessageBox.Show(comboBox1.Text+" "+comboBox_itm_qty.Text+" X "+ itm_price.Text+" = "+ itm_total.Text +" Successfully Recoreded");
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e + "");
                }
            }
            else
            {
            }          
        }
        private void row_two()
        {
            if (two_row.Text == "1")
            {
                string path_internal = @"\Database";
                string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + @"\student_store_record.accdb; Persist Security Info = False";

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = conn;
                //Member_Id	Name	Room_cup	Class	Date	product_id	Item	Qty	per_itm	Amount_debit

                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "INSERT INTo data(Member_Id,Name,Room_cup,Class,Datee,product_id,Item,Qty,per_itm,Amount_debit) values('" + mid.Text + "','" + Name.Text + "','" + Room_cup.Content + "','" + c_sec.Content + "','" + datapicker.Text + "','" + pid2.Content + "','" + comboBox2.Text + "','" + comboBox_itm_qty2.Text + "','" + itm_price2.Text + "','" + itm_total2.Text + "');";
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    MessageBox.Show(comboBox2.Text + " " + comboBox_itm_qty2.Text + " X " + itm_price2.Text + " = " + itm_total2.Text + " Successfully Recoreded");
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e + "");
                }
            }
            else
            {
            }
        }
        private void row_three()
        {
            if (three_row.Text == "1")
            {
                string path_internal = @"\Database";
                string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + @"\student_store_record.accdb; Persist Security Info = False";

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = conn;

                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "INSERT INTo data(Member_Id,Name,Room_cup,Class,Datee,product_id,Item,Qty,per_itm,Amount_debit) values('" + mid.Text + "','" + Name.Text + "','" + Room_cup.Content + "','" + c_sec.Content + "','" + datapicker.Text + "','" + pid3.Content + "','" + comboBox3.Text + "','" + comboBox_itm_qty3.Text + "','" + itm_price3.Text + "','" + itm_total3.Text + "');";
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    MessageBox.Show(comboBox3.Text + " " + comboBox_itm_qty3.Text + " X " + itm_price3.Text + " = " + itm_total3.Text + " Successfully Recoreded");
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e + "");
                }
            }
            else
            {
            }
        }
        private void row_four()
        {
            if (four_row.Text == "1")
            {
                string path_internal = @"\Database";
                string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + @"\student_store_record.accdb; Persist Security Info = False";

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = conn;

                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "INSERT INTo data(Member_Id,Name,Room_cup,Class,Datee,product_id,Item,Qty,per_itm,Amount_debit) values('" + mid.Text + "','" + Name.Text + "','" + Room_cup.Content + "','" + c_sec.Content + "','" + datapicker.Text + "','" + pid4.Content + "','" + comboBox4.Text + "','" + comboBox_itm_qty4.Text + "','" + itm_price4.Text + "','" + itm_total4.Text + "');";
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    MessageBox.Show(comboBox4.Text + " " + comboBox_itm_qty4.Text + " X " + itm_price4.Text + " = " + itm_total4.Text + " Successfully Recoreded");
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e + "");
                }
            }
            else
            {
            }
        }
        private void row_five()
        {
            if (five_row.Text == "1")
            {
                string path_internal = @"\Database";
                string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + @"\student_store_record.accdb; Persist Security Info = False";

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = conn;

                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "INSERT INTo data(Member_Id,Name,Room_cup,Class,Datee,product_id,Item,Qty,per_itm,Amount_debit) values('" + mid.Text + "','" + Name.Text + "','" + Room_cup.Content + "','" + c_sec.Content + "','" + datapicker.Text + "','" + pid5.Content + "','" + comboBox5.Text + "','" + comboBox_itm_qty5.Text + "','" + itm_price5.Text + "','" + itm_total5.Text + "');";
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    MessageBox.Show(comboBox5.Text + " " + comboBox_itm_qty5.Text + " X " + itm_price5.Text + " = " + itm_total5.Text + " Successfully Recoreded");
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e + "");
                }
            }
            else
            {
            }
        }
        private void row_six()
        {
            if (six_row.Text == "1")
            {
                string path_internal = @"\Database";
                string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + @"\student_store_record.accdb; Persist Security Info = False";

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = conn;

                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "INSERT INTo data(Member_Id,Name,Room_cup,Class,Datee,product_id,Item,Qty,per_itm,Amount_debit) values('" + mid.Text + "','" + Name.Text + "','" + Room_cup.Content + "','" + c_sec.Content + "','" + datapicker.Text + "','" + pid6.Content + "','" + comboBox6.Text + "','" + comboBox_itm_qty6.Text + "','" + itm_price6.Text + "','" + itm_total6.Text + "');";
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    MessageBox.Show(comboBox6.Text + " " + comboBox_itm_qty6.Text + " X " + itm_price6.Text + " = " + itm_total6.Text + " Successfully Recoreded");
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e + "");
                }
            }
            else
            {
            }
        }
        private void row_seven()
        {
            if (seven_row.Text == "1")
            {
                string path_internal = @"\Database";
                string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + @"\student_store_record.accdb; Persist Security Info = False";

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = conn;

                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "INSERT INTo data(Member_Id,Name,Room_cup,Class,Datee,product_id,Item,Qty,per_itm,Amount_debit) values('" + mid.Text + "','" + Name.Text + "','" + Room_cup.Content + "','" + c_sec.Content + "','" + datapicker.Text + "','" + pid7.Content + "','" + comboBox7.Text + "','" + comboBox_itm_qty7.Text + "','" + itm_price7.Text + "','" + itm_total7.Text + "');";
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    MessageBox.Show(comboBox7.Text + " " + comboBox_itm_qty7.Text + " X " + itm_price7.Text + " = " + itm_total7.Text + " Successfully Recoreded");
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e + "");
                }
            }
            else
            {
            }
        }
        private void row_eight()
        {
            if (eight_row.Text == "1")
            {
                string path_internal = @"\Database";
                string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + @"\student_store_record.accdb; Persist Security Info = False";

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = conn;

                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "INSERT INTo data(Member_Id,Name,Room_cup,Class,Datee,product_id,Item,Qty,per_itm,Amount_debit) values('" + mid.Text + "','" + Name.Text + "','" + Room_cup.Content + "','" + c_sec.Content + "','" + datapicker.Text + "','" + pid8.Content + "','" + comboBox8.Text + "','" + comboBox_itm_qty8.Text + "','" + itm_price8.Text + "','" + itm_total8.Text + "');";
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    MessageBox.Show(comboBox8.Text + " " + comboBox_itm_qty8.Text + " X " + itm_price8.Text + " = " + itm_total8.Text + " Successfully Recoreded");
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e + "");
                }
            }
            else
            {
            }
        }
        //private void final_call()
        //{
        //    string path_internal = @"\Database";
        //    string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + @"\student_current_balance.accdb; Persist Security Info = False";

        //    OleDbConnection connection = new OleDbConnection();
        //    connection.ConnectionString = conn;

        //    try
        //    {
        //        connection.Open();
        //        OleDbCommand command = new OleDbCommand();
        //        command.Connection = connection;
        //        string query = "UPDATE data SET current_balance='"+final_balance.Content+"' WHERE mid='"+mid.Text+"'" ;
        //        command.CommandText = query;
        //        command.ExecuteNonQuery();
        //        MessageBox.Show("Sucessfully Amount Detected");
        //        connection.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e + "");
        //    }
        //}


        int total_itms=0;  //1 or ""
        private void one_row_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (one_row.Text == "1")
            {
                total_itms++;               
            }
            else
            {
                total_itms--;
            }
            cart.Text = total_itms.ToString();

        }
        private void two_row_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (two_row.Text == "1")
            {
                total_itms++;
            }
            else
            {
                total_itms--;
            }
            cart.Text = total_itms.ToString();
        }
        private void four_row_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (four_row.Text == "1")
            {
                total_itms++;
            }
            else
            {
                total_itms--;
            }
            cart.Text = total_itms.ToString();
        }
        private void five_row_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (five_row.Text == "1")
            {
                total_itms++;
            }
            else
            {
                total_itms--;
            }
            cart.Text = total_itms.ToString();
        }
        private void six_row_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (six_row.Text == "1")
            {
                total_itms++;
            }
            else
            {
                total_itms--;
            }
            cart.Text = total_itms.ToString();
        }
        private void seven_row_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (seven_row.Text == "1")
            {
                total_itms++;
            }
            else
            {
                total_itms--;
            }
            cart.Text = total_itms.ToString();
        }
        private void eight_row_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (eight_row.Text == "1")
            {
                total_itms++;
            }
            else
            {
                total_itms--;
            }
            cart.Text = total_itms.ToString();
        }
        private void three_row_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (three_row.Text == "1")
            {
                total_itms++;
            }
            else
            {
                total_itms--;
            }
            cart.Text = total_itms.ToString();
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            tip1.Visibility = Visibility.Hidden;
        }

        private void cancle_purchace_Click(object sender, RoutedEventArgs e)
        {
            clear_all();
            tip1.Visibility = Visibility.Visible;

        }
        private void clear_per_values()
        {
            comboBox1.SelectedIndex = -1;
            comboBox_itm_qty.SelectedIndex = -1;
            itm_price.Text = "";
            itm_total.Text = "";

            comboBox2.SelectedIndex = -1;
            comboBox_itm_qty2.SelectedIndex = -1;
            itm_price2.Text = "";
            itm_total2.Text = "";

            comboBox3.SelectedIndex = -1;
            comboBox_itm_qty3.SelectedIndex = -1;
            itm_price3.Text = "";
            itm_total3.Text = "";

            comboBox4.SelectedIndex = -1;
            comboBox_itm_qty4.SelectedIndex = -1;
            itm_price4.Text = "";
            itm_total4.Text = "";

            comboBox5.SelectedIndex = -1;
            comboBox_itm_qty5.SelectedIndex = -1;
            itm_price5.Text = "";
            itm_total5.Text = "";

            comboBox6.SelectedIndex = -1;
            comboBox_itm_qty6.SelectedIndex = -1;
            itm_price6.Text = "";
            itm_total6.Text = "";

            comboBox7.SelectedIndex = -1;
            comboBox_itm_qty7.SelectedIndex = -1;
            itm_price7.Text = "";
            itm_total7.Text = "";

            comboBox8.SelectedIndex = -1;
            comboBox_itm_qty8.SelectedIndex = -1;
            itm_price8.Text = "";
            itm_total8.Text = "";
        }
        private void clear_all()
        {
            mid.Text = "";
            c_sec.Content = "";
            Name.Text = "";
            Room_cup.Content = "";
            befor_balance.Text = "";
            debit.Content = "";
            final_balance.Content = "";
            clear_per_values();
            tip1.Visibility = Visibility.Visible;
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            if (name_Copy.Text == "" || name_Copy.Text == "Name" || prob_Copy.Text == "" || prob_Copy.Text == "How we can Help ?")
            {
                MessageBox.Show("Name or PRoblem is Empty will fill it");
            }
            else
            {
                feedback();
            }
        }
        private void feedback()
        {
            string path_internal = @"\Database\";
            string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + "feedback.accdb; Persist Security Info = False";

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = conn;

            try
            {

                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "INSERT INTo data values('" + name_Copy.Text + "','" + prob_Copy.Text + "','" + datapicker.Text + "');";

                command.CommandText = query;

                command.ExecuteNonQuery();
                MessageBox.Show("Your Problem is Successfully Noted soon you will get the Solution");
                connection.Close();
                name_Copy.Text = "";
                prob_Copy.Text = "";


            }

            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }

        private void get_total_Click(object sender, RoutedEventArgs e)
        {
            double total = 0;
            if (itm_price.Text != "")
            {
                double a = double.Parse(itm_total.Text);
                total = total + a;
            }
            if (itm_price2.Text != "")
            { double b = double.Parse(itm_total2.Text); total = total + b; } 
            if (itm_price3.Text != "") { double c = double.Parse(itm_total3.Text); total = total + c; } 
            if (itm_price4.Text != "") { double d = double.Parse(itm_total4.Text); total = total + d; } 
            if (itm_price5.Text !="") { double ee = double.Parse(itm_total5.Text); total = total + ee; } 
            if (itm_price6.Text != "") { double f = double.Parse(itm_total6.Text); total = total + f; } 
            if (itm_price7.Text != "") { double g = double.Parse(itm_total7.Text); total = total + g; } 
            if (itm_price8.Text != "") { double h = double.Parse(itm_total8.Text); total = total + h; } 
            total_price.Text = total.ToString();
        }
    }
}
