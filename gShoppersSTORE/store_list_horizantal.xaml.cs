using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Dynamic;
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
    /// Interaction logic for store_list_horizantal.xaml
    /// </summary>
    public partial class store_list_horizantal : Window
    {
        //String path = System.IO.Directory.GetCurrentDirectory();
        private string path;

        public string passvalue
        {
            get { return path; }
            set { path = value; }
        }

        public store_list_horizantal()
        {
            InitializeComponent();
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
                string query = "SELECT * FROM data WHERE id='" + i + "';";

                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    mid.Text = reader["Member_Id"].ToString();
                    name.Text = reader["Name"].ToString();
                    room.Text = reader["room"].ToString();
                    cup.Text = reader["cup"].ToString();
                    r_c.Text = reader["Room_cup"].ToString();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }
        private void search_function()
        {
            data1_search();
            data2_search();
            double a = double.Parse(cre.Text);
            double b = double.Parse(debt.Text);
            double result = a - b;
            bal.Text = result.ToString();
        }
        private void populate_master()
        {   
            string[] labels = new string[] { q.Text, w.Text, ee.Text, r.Text, t.Text, y.Text, u.Text, i.Text, o.Text,p.Text,aa.Text,ss.Text,dd.Text,ff.Text,gg.Text };
            
            string[] values = new string[] { mid.Text, name.Text, r_c.Text, bal.Text, "", "", "", "", "","","","" ,"","",""};
            dynamic row = new ExpandoObject();
            for (int i = 0; i < labels.Length; i++)
                ((IDictionary<String, Object>)row)[labels[i].Replace(' ', '_')] = values[i];
            master.Items.Add(row);
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
                MessageBox.Show("SOME THING IS WRONG" + ex);
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
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            stdcombo_print();
            roomcombo_populate();
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
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }

        private void refresh(object sender, RoutedEventArgs e)
        {
            get_id();
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
                    start.Text = reader["start"].ToString();
                    end.Text = reader["end"].ToString();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
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
                string query = "SELECT * FROM data WHERE room='" + room_p.Text + "' AND cup='" + i + "';";

                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    mid.Text = reader["Member_Id"].ToString();
                    name.Text = reader["Name"].ToString();
                    room.Text = reader["room"].ToString();
                    cup.Text = reader["cup"].ToString();
                    r_c.Text = reader["Room_cup"].ToString();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
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
                    room_p.Items.Add(rom);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOME THING IS WRONG" + ex);
            }
        }

        private void print_std(object sender, RoutedEventArgs e)
        {
            int cup_1 = int.Parse(start.Text);
            int cup_2 = int.Parse(end.Text);
            for (int i = cup_1; i <= cup_2; i++)
            {
                print_std(i);
                search_function();
                populate_master();
                //MessageBox.Show("Swaminarayan" + i);
            }
            rm.Text = std_combo.Text;
            label6.Content = "Class";
        }

        private void print_room(object sender, RoutedEventArgs e)
        {
            int cup_1 = int.Parse(cup1.Text);
            int cup_2 = int.Parse(cup2.Text);

            for (int i = cup_1; i <= cup_2; i++)
            {
                searchby_room(i);
                search_function();
                // print_method();
                populate_master();
                //MessageBox.Show("Swaminarayan" + i);
            }
            rm.Text = room_p.Text;
            label6.Content = "Room";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string[] labels = new string[] { q.Text, w.Text, ee.Text, r.Text, t.Text, y.Text, u.Text, i.Text, o.Text, p.Text,aa.Text,ss.Text,dd.Text,ff.Text,gg.Text };
            foreach (string label in labels)
            {
                DataGridTextColumn column = new DataGridTextColumn();
                column.Header = label;
                column.Binding = new Binding(label.Replace(' ', '_'));
                master.Columns.Add(column);
            }
        }

        private void clear_table(object sender, RoutedEventArgs e)
        {
            master.ItemsSource = null;
            master.Items.Clear();

        }

        private void print(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(swami, "Print");
            }
            master.ItemsSource = null;
            master.Items.Clear();
            int a = room_p.SelectedIndex;
            int b = a + 1;
            room_p.SelectedIndex = b;
            int cup_1 = int.Parse(cup1.Text);
            int cup_2 = int.Parse(cup2.Text);

            for (int i = cup_1; i <= cup_2; i++)
            {
                searchby_room(i);
                search_function();
                // print_method();
                populate_master();
                //MessageBox.Show("Swaminarayan" + i);
            }
            rm.Text = room_p.Text;
            label6.Content = "Room";
        }

        private void clear_rtr_columns(object sender, RoutedEventArgs e)
        {
            master.Columns.Clear();
        }

        private void refresh_height(object sender, RoutedEventArgs e)
        {
            string row_h = row_height.Text;
            string font_si = font_size.Text;
            master.RowHeight = double.Parse(row_h);
            master.FontSize = double.Parse(font_si);
        }

        private void export_Click(object sender, RoutedEventArgs e)
        {
            master.SelectAllCells();
            master.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, master);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            master.UnselectAllCells();
            string link = dir.Text;
            System.IO.StreamWriter file = new System.IO.StreamWriter(link);
            file.WriteLine(result.Replace(',', ' '));
            file.Close();

            MessageBox.Show("Exporting DataGrid data to Excel file created");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Press OK /n And Wait for 5 Minutes to Loade Data");
            //start.Text = "1";
            int cup_1 = int.Parse(start.Text);
            int cup_2 = int.Parse(end.Text);
            for (int i = cup_1; i <= cup_2; i++)
            {
                print_std(i);
                search_function();
                populate_master();
                //MessageBox.Show("Swaminarayan" + i);
            }
        }
    }
}
