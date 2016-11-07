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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gShoppersSTORE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        

        public MainWindow()
        {
            InitializeComponent();

        }


        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please Contact to Developer");
        }

        

        public void button_Click(object sender, RoutedEventArgs e)
        {
            String t1, t2;t1 = txt1.Text;t2 = tex2.Password;
            if(((t1 == "store" || t1 == "mayank") && t2 == "si6583" )|| t1 == "print" && t2 == "p3856" || t1 == "hari" && t2 == "krushna001" || ((t1 == "swami" || t1=="admin") && t2=="kurbanho") || t1=="raipur" && t2=="store3856"){ Menu a = new Menu(); a.passvalue = t1; a.ShowDialog(); this.Close(); }else {  MessageBox.Show("Please Check your Username and Password"); }
        }
        

    }
       
    }
    

