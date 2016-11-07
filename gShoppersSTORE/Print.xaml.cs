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
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace gShoppersSTORE
{
    /// <summary>
    /// Interaction logic for Print.xaml
    /// </summary>
    public partial class Print : Window
    {
        string path_temp = System.IO.Directory.GetCurrentDirectory();
        private string path;

        public string passvalue
        {
            get { return path; }
            set { path = value; }
        }
        public Print()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void back(object sender, RoutedEventArgs e)
        {
            Menu  a = new Menu();
            a.Show();
            this.Close();
        }

        private void search_bymid(object sender, RoutedEventArgs e)
        {
            search_function();
        }
        private void search_function()
        {
            get_Stu_details();
            data1_search();
            data2_search();
            double a = 0.0; double b = 0.0; double result=0.0;
            try { a = double.Parse(cre.Text); } catch (Exception ex) { }
            try { b = double.Parse(debt.Text); } catch (Exception ex) { }
            try { result = a - b; } catch (Exception ex) { }
            bal.Text = result.ToString();
        }
        private void data1_search()
        {
            string path_internal = @"\Database\";
            string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + "student_store_record.accdb; Persist Security Info = False";

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = conn;

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "SELECT Datee,Item,Qty,per_itm,Amount_debit FROM data WHERE Member_Id='" + mid.Text + "';";

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
                decimal sum = 0;
                
                while (rowEnum.MoveNext())
                {
                    // sum +=
                    string s = (string)((DataRow)rowEnum.Current)[4];
                    sum = sum + int.Parse(s);//assuming the 'Total' column has index 3.
                }
                debt.Text = sum.ToString();                
            }

            catch (Exception ex)
            {
             //   MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }
        private void data2_search()
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
                string query = "SELECT Date,via,amount FROM data WHERE mid='" + mid.Text + "';";

                command.CommandText = query;
                command.ExecuteNonQuery();
                OleDbDataAdapter dataadp = new OleDbDataAdapter(command);
                DataTable dt = new DataTable("data");
                dataadp.Fill(dt);
                dataGrid2.ItemsSource = dt.DefaultView;
                dataadp.Update(dt);

                //MessageBox.Show("Swaminarayan");
                connection.Close();
                DataView dv = (DataView)dataGrid2.ItemsSource;
                DataRowCollection drc = dv.Table.Rows;
                IEnumerator rowEnum = drc.GetEnumerator();
                decimal sum = 0;
                while (rowEnum.MoveNext())
                {
                    // sum +=
                    string s = (string)((DataRow)rowEnum.Current)[2];
                    sum = sum + int.Parse(s);
                }
                cre.Text = sum.ToString();
            }

            catch (Exception ex)
            {
              //  MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }
        private void get_Stu_details()
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
                    mid_p.Text = reader["Member_Id"].ToString();
                    name_p.Text = reader["Name"].ToString();
                    std_p.Text = reader["Class"].ToString();
                    room_p.Text = reader["Room_cup"].ToString();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
               // MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }

        private void print_bymid(object sender, RoutedEventArgs e)
        {
            print_method();
        }
        private void print_method()
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(swami, "Swaminarayan");
            }
        }
        private void room_wise_p_Click(object sender, RoutedEventArgs e)
        {
            room_wise_p.IsEnabled =false;
            custom_p.IsEnabled = true;
            room_wise_print_screen.Visibility = Visibility.Hidden;
            mid_screen.Visibility = Visibility.Visible;            
        }
        private void roomcombo_populate()
        {
            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\Database_current.accdb;Persist Security Info=False";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select DISTINCT room from data;";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String rom = reader.GetString(0);
                    room.Items.Add(rom);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
               // MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }
        private void stdcombo_print()
        {
            String path_internal = @"\Database";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + path_internal + @"\Database_current.accdb;Persist Security Info=False";

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select std from std_print;";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String std_str = reader.GetString(0);
                    std_combo.Items.Add(std_str);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
              //  MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }

        private void custom_p_Click(object sender, RoutedEventArgs e)
        {
            room_wise_p.IsEnabled = true;
            custom_p.IsEnabled = false;
            room_wise_print_screen.Visibility = Visibility.Visible;
            mid_screen.Visibility = Visibility.Hidden;
            
        }

        private void room_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void searchby_room(int i)
        {
            string path_internal = @"\Database\";
            string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + "Database_current.accdb; Persist Security Info = False";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = conn;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "SELECT Member_Id FROM data WHERE room='" + room.Text + "' AND cup='" + i + "';";

                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    mid.Text = reader["Member_Id"].ToString();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
              //  MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }
        private void print_room(object sender, RoutedEventArgs e)
        {
            int cup_1= int.Parse(cup1.Text);
            int cup_2= int.Parse(cup2.Text);

            for(int i=cup_1; i <= cup_2; i++)
            {
               searchby_room(i);
               search_function();
               print_method();
               MessageBox.Show("Swaminarayan"+i);
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            roomcombo_populate();
            stdcombo_print();
        }

        private void print_std(object sender, RoutedEventArgs e)
        {
            int cup_1 = int.Parse(start_id.Text);
            int cup_2 = int.Parse(end_id.Text);
            for (int i = cup_1; i <= cup_2; i++)
            {
               print_std(i);
               search_function();
               print_method();
              
            } //MessageBox.Show("Swaminarayan" + i);
        }

        private void print_std(int i)
        {
            string path_internal = @"\Database\";
            string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + "Database_current.accdb; Persist Security Info = False";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = conn;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "SELECT Member_Id FROM data WHERE id='" + i + "';";

                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    mid.Text = reader["Member_Id"].ToString();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
              //  MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }

        private void std_all_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void get_id()
        {
            string path_internal = @"\Database\";
            string conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + path + path_internal + "Database_current.accdb; Persist Security Info = False";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = conn;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from std_print where std='" + std_combo.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    start_id.Text = reader["start"].ToString();
                    end_id.Text = reader["end"].ToString();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
              //  MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }
        private void refresh(object sender, RoutedEventArgs e)
        {
            get_id();
        }
        private void class_print_btn_Click(object sender, RoutedEventArgs e)
        {
            class_wise_screen.Visibility = Visibility.Hidden;
          //room_wise_print_screen.Visibility = Visibility.Visible;
         // mid_screen.Visibility = Visibility.Visible;
        }
    }
}
