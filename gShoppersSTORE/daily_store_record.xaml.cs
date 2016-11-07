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
    /// Interaction logic for daily_store_record.xaml
    /// </summary>
    public partial class daily_store_record : Window
    {
        private string path;

        public string passvalue
        {
            get { return path; }
            set { path = value; }
        }

        public daily_store_record()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                data1_search();
            }
            catch(Exception EX)
            {
                MessageBox.Show(EX + "");
            }
                
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
                string query = "SELECT idd,Member_Id,Item,Qty,per_itm,Amount_debit FROM data WHERE Datee='" + datapicker1.Text + "';";

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            print_method();
        }
        private void print_method()
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(swami, "DONE");
            }
        }

        private void export_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dataGrid1.SelectAllCells();
                dataGrid1.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, dataGrid1);
                String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                String result = (string)Clipboard.GetData(DataFormats.Text);
                dataGrid1.UnselectAllCells();
                string link = dir.Text;
                System.IO.StreamWriter file = new System.IO.StreamWriter(link);
                file.WriteLine(result.Replace(',', ' '));
                file.Close();

                MessageBox.Show("Exporting DataGrid data to Excel file created");
            }
            catch(Exception ex) {
                MessageBox.Show(ex + "");
            }
        }

        private void dir_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
