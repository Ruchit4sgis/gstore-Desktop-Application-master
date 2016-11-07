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

namespace gShoppersSTORE
{
    /// <summary>
    /// Interaction logic for stu_credit.xaml
    /// </summary>
    public partial class stu_credit : Window
    {
        //String path = System.IO.Directory.GetCurrentDirectory();
        private string path;

        public string passvalue
        {
            get { return path; }
            set { path = value; }
        }
        public stu_credit()
        {
            InitializeComponent();
            datapicker.SelectedDate = DateTime.Today;
        }

        private void settings(object sender, RoutedEventArgs e)
        {

        }

        private void back(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string mid = textBox.Text;
            if (mid.Length == 6)
            {
                try
                {
                    get_stu_details();
                }
                catch
                {
                    MessageBox.Show("Invallid MID");
                    name.Text="";
                    std.Text="";
                }            

            }
            else
            {
                
            }
           
        }
        private void get_stu_details() {
            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\Database_current.accdb;Persist Security Info=False";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from data where Member_Id='" + textBox.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    name.Text = reader["Name"].ToString();
                    std.Text = reader["Class"].ToString();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e) //make ENtry button click event
        {
            if (textBox.Text.Length==6 && (name.Text!="" || name.Text!="Name") && (std.Text!="" || std.Text!="Class"))
            {
                //true
                student_credit_record();
                //getcur_balance();
                //student_credit_update();
            }
            else
            {
                //false
                MessageBox.Show("Make Sure that the Member_ID is Corrent");
            }
        }
        private void clear()
        {
            textBox.Text = "";
            name.Text = "";
            std.Text = "";
            amt.Text = "";
            via.Text = "";
        } 
        private void student_credit_record()
        {
            string path_internal = @"\Database\";
            string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + "student_credit_record.accdb; Persist Security Info = False";

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = conn;

            try
            {

                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "INSERT INTo data values('" + textBox.Text + "','" + name.Text + "','" + std.Text + "','" + datapicker.Text + "','" + amt.Text + "','" + via.Text + "','"+ reciept.Text+"');";

                command.CommandText = query;

                command.ExecuteNonQuery();
                MessageBox.Show("Sucessfully Registered");
                connection.Close();
              

            }

            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }                         //Makes a new Redord as the Amount is paid
        //private void getcur_balance()
        //{
        //    string curbalance = "";
        //    String path_internal = @"\Database";
        //    OleDbConnection connection = new OleDbConnection();
        //    connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\student_current_balance.accdb;Persist Security Info=False";

        //    try
        //    {
        //        connection.Open();
        //        OleDbCommand command = new OleDbCommand();
        //        command.Connection = connection;
        //        string query = "select * from data where mid='" + textBox.Text + "'";
        //        command.CommandText = query;

        //        OleDbDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            curbalance = reader["Current_balance"].ToString();
        //        }
        //        connection.Close();
        //        int cur_bal = int.Parse(curbalance);
        //        int add_bal = int.Parse(amt.Text);
        //        int final_balance = cur_bal + add_bal;
        //        finalbalance.Text = final_balance.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("SOME THING IS WRONG" + ex);
        //    }
        //}                               //get the old balance & adds the new balance and places in TEXTBOX
        //private void student_credit_update()
        //{
        //    //String finalbalance="";

        //    string path_internal = @"\Database\";
        //    string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + "student_current_balance.accdb; Persist Security Info = False";

        //    OleDbConnection connection = new OleDbConnection();
        //    connection.ConnectionString = conn;

        //    try
        //    {

        //        connection.Open();
        //        OleDbCommand command = new OleDbCommand();
        //        command.Connection = connection;
        //        string query = "UPDATE data SET Current_balance='"+ finalbalance.Text + "' WHERE mid='"+textBox.Text+"' ";

        //        command.CommandText = query;

        //        command.ExecuteNonQuery();
        //        MessageBox.Show("Sucessfully Registered");
        //        connection.Close();
        //        clear();

        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("SOME THING IS WRONG" + ex);
        //    }
        //}                       //gets the new balance which is @ textbox and updates Students Balance.

    }
}
