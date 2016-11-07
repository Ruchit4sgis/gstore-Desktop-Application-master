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
using System.IO;
using Microsoft.VisualBasic;

namespace gShoppersSTORE
{

    /// <summary>
    /// Interaction logic for Stockin.xaml
    /// 
    ///
    /// </summary>
   

    public partial class Stockin : Window
    {
       
        public Stockin()
        {
            InitializeComponent();
        }



        //public String path = logi;//System.IO.Directory.GetCurrentDirectory();
        public String sls = "\"";
       private string path;
        
        public string passvalue
        {
            get { return path; }
            set { path = value; }
        }
        
        private void back(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void settings(object sender, RoutedEventArgs e)
        {
           if(passss.Password == "kurbanho")
            {
                hide.Visibility = Visibility.Visible;
            }
        }
        private void settings()
        {
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
           

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comboBox_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

      

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {            
          
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void refresh1(object sender, RoutedEventArgs e)
        {
            combo_all.Items.Clear();
            combo_sub.Items.Clear();
            String path_internal = @"\Database\Stock_in\Group_Sub\";
            string a = combo_group.Text;
            string b = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ path+ path_internal+ a + ".accdb;Persist Security Info=False";

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = b;

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "Select Item from data";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    combo_sub.Items.Add(reader["Item"].ToString());
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }
       

        private void refresh2(object sender, RoutedEventArgs e)
        {
            combo_all.Items.Clear();
            
            string a = combo_sub.Text;
            String path_internal = @"\Database\Stock_in\Group_Items\";
            string b = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+path+path_internal+ a + ".accdb;Persist Security Info=False";

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = b;

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "Select Item from data";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    combo_all.Items.Add(reader["Item"].ToString());
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }

        private void refresh0(object sender, RoutedEventArgs e)
        {

            combo_group.Items.Clear();
            combo_sub.Items.Clear();
            combo_all.Items.Clear();
            String path_internal = @"\Database\Stock_in\";

            OleDbConnection connection = new OleDbConnection();           
            string b = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+path+path_internal+"Group.accdb;Persist Security Info=False";


            connection.ConnectionString = b;

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "Select Item from data";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    combo_group.Items.Add(reader["Item"].ToString());
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }

        private void Make_Entry_Click(object sender, RoutedEventArgs e)
        {            
            string bill_num = bill.Text;                   
            string Group = combo_group.Text;
            string Sub_group = combo_sub.Text;
            string item = combo_all.Text;
            if (datapicker.Text == "Select a date" || datapicker.Text == "" || bill.Text == "" || qty.Text == "" || amt.Text == "" || combo_group.Text == "" || combo_sub.Text == "" || combo_all.Text == "")
            {
                MessageBox.Show("Please Fill all the above details");
            }
            else
            {
                string path_internal = @"\Database\Stock_in\";
                string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source ="+path+path_internal+"Database.accdb; Persist Security Info = False";

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = conn;

                try
                {

                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "INSERT INTo data values('" + datapicker.Text + "','" + bill.Text + "','" + qty.Text + "','" + amt.Text + "','" + combo_group.Text + "','" + combo_sub.Text + "','" + combo_all.Text + "');";

                    command.CommandText = query;

                    command.ExecuteNonQuery();
                    MessageBox.Show("Sucessfully Registered");
                    connection.Close();
                    clear();

                }

                catch (Exception ex)
                {
                    MessageBox.Show("SOME THING IS WRONG" + ex);
                }
            }
        }
        public void clear() {
            bill.Text = "";
            datapicker.Text = "Select a date";
            qty.Text = "";
            amt.Text = "";
            combo_all.Text = "";
            combo_group.Text = "";
            combo_sub.Text = "";
        }

        private void refresh(object sender, RoutedEventArgs e)
        {
            String path_internal = @"\Database\Stock_in\";

            combo_group.Text = "";
            string a = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + "Group.accdb;Persist Security Info=False";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = a;
            string group = New_group.Text;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "Select Item from data";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    combo_group.Items.Add(reader["Item"].ToString());
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
            Refresh0.Visibility = Visibility.Hidden;
        }

        private void remove1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This Feature is Undr Maintance \n So Manuualy Delect it \n If u forget to Delect Mannually Contact to : r4sgis@gurukul.org");
        }

        private void add2_Click(object sender, RoutedEventArgs e)
        {
            if (combo_group.Text == "" && New_sub_Group.Text == "New Sub-Group")
            {
                MessageBox.Show("To Add New Sub-Group Make sure you have selected The Group to which u want to Add Subgroup");
            }
            else {
                string combo_group_txt = combo_group.Text;
                String path_internal = @"\Database\Stock_in\Group_Sub\";

                string a = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+path+path_internal + combo_group_txt + ".accdb;Persist Security Info=False";
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = a;
                string group = New_sub_Group.Text;

                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "insert into data values('" + New_sub_Group.Text + "')";
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    connection.Close();

                    try
                    {
                        // string rename_file = @"\\G_INNOVATION\gShoppersSTORE\gShoppersSTORE\Database\Stock_in\Group_Sub\empty.accdb";
                        //   string rename_dest = @"\\G_INNOVATION\gShoppersSTORE\gShoppersSTORE\Database\Stock_in\Group_Sub\" + group + ".accdb";
                        FileInfo file = new FileInfo(@"\\G_INNOVATION\gShoppersSTORE\gShoppersSTORE\Database\Stock_in\empty.accdb");
                        file.CopyTo(@"\\G_INNOVATION\gShoppersSTORE\gShoppersSTORE\Database\Stock_in\Group_Items\" + group + ".accdb");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("1. Check the Network access (Try this if again same Problem then follow) 2. Contsct to the ADMIN serious Problem" + ex);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("1. Check the Network access (Try this if again same Problem then follow) 2. Contsct to the ADMIN serious Problem" + ex);
                }

                

            }

        }

        private void remove2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This Feature is Undr Maintance \n So Manuualy Delect it \n If u forget to Delect Mannually Contact to : r4sgis@gurukul.org");
        }

        private void add3_Click(object sender, RoutedEventArgs e)
        {
            if (combo_sub.Text == "" && New__items.Text == "New Sub-Group")
            {
                MessageBox.Show("To Add New Item Make sure you have selected The Group & Sub-Group to which u want to Add Item");
            }
            else
            {
                string New_items = combo_sub.Text;
                String path_internal = @"\Database\Stock_in\Group_Items\";

                string a = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+path+path_internal + New_items + ".accdb;Persist Security Info=False";
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = a;
                string sub_group = combo_sub.Text;

                if (sub_group == "")
                {
                    MessageBox.Show("Insert The Sub-Group Name");
                }
                else
                {
                    try
                    {
                        connection.Open();
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        string query = "insert into data values('" + New__items.Text + "')";
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                        connection.Close();           
                   }
                   catch (Exception ex)
                   {
                     MessageBox.Show("SOME THING IS WRONG CONTACT TO ADMIN" + ex);
                   }
               }

            }
        }

        private void remove3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This Feature is Undr Maintance \n So Manuualy Delect it \n If u forget to Delect Mannually Contact to : r4sgis@gurukul.org");
        }

        
        private void add1_1_Click(object sender, RoutedEventArgs e)
        {
            String path_internal = @"\Database\Stock_in\";
            string a = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+path+path_internal+"Group.accdb;Persist Security Info=False";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = a;
            string group = New_group.Text;
            if (group == "" && New_group.Text == "New Group") {
                MessageBox.Show("Insert The Group Name");
            }
            else {

                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "insert into data values('" + New_group.Text + "')";
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    connection.Close();

                    //---------------------------------------------------------------------------------------------------------------------

                    try {

                        // string rename_file = @"\\G_INNOVATION\gShoppersSTORE\gShoppersSTORE\Database\Stock_in\Group_Sub\empty.accdb";
                        //   string rename_dest = @"\\G_INNOVATION\gShoppersSTORE\gShoppersSTORE\Database\Stock_in\Group_Sub\" + group + ".accdb";
                        FileInfo file = new FileInfo(@"\\G_INNOVATION\gShoppersSTORE\gShoppersSTORE\Database\Stock_in\empty.accdb");
                        file.CopyTo(@"\\G_INNOVATION\gShoppersSTORE\gShoppersSTORE\Database\Stock_in\Group_Sub\" + group + ".accdb");

                    }
                    catch (Exception ex) {
                        MessageBox.Show("1. Check the Network access (Try this if again same Problem then follow) 2. Contsct to the ADMIN serious Problem" + ex);
                    }                   

                }

                catch (Exception ex)
                {
                    MessageBox.Show("SOME THING IS WRONG CONTACT TO ADMIN" + ex);
                }

            }
           
        }

        private void button1_Click_2(object sender, RoutedEventArgs e)
        {
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            hide.Visibility = Visibility.Hidden;           
            clear();
        }

        private void clear(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
           // userw.Text = path;
        }
    }
    }

    





    

    
