using Microsoft.Win32;
using Quiz.Controller;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz.View
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    /// 
    
    public partial class MainMenu : UserControl
    {
        DataFileController d = new DataFileController();

        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnMenu1_Click(object sender, RoutedEventArgs e)
        {
            Subject sub = new Subject();
            Grid a = ucMainMenu.Parent as Grid;
            //a.Children.Remove(ucMainMenu);
            a.Children.Add(sub);
        }

        private void btnMenu3_Click(object sender, RoutedEventArgs e)
        {
            ucUser sub = new ucUser();
            Grid a = ucMainMenu.Parent as Grid;
            //a.Children.Remove(ucMainMenu);
            a.Children.Add(sub);
        }

        private void btnMenu4_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "DataFile (*.df)|*.df";
            o.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            if (o.ShowDialog() == true)
            {
                List<Model.Question> list = new List<Model.Question>();
                list = (List<Model.Question>)d.readListFromFile(o.FileName);
                string pass = d.readPassFromFile(o.FileName);
                if(pass!="")
                {
                    InputPassword ip = new InputPassword();
                    if(ip.ShowDialog()==true)
                    { 
                        if (pass != ip.Answer) 
                            MessageBox.Show("Password sai");
                        else
                        {
                            Question q = new Question(list);
                            Grid a = ucMainMenu.Parent as Grid;
                            a.Children.Add(q);
                            q.Focus();
                        }
                    }
                }
                else
                {
                    Question q = new Question(list);
                    Grid a = ucMainMenu.Parent as Grid;
                    a.Children.Add(q);
                    q.Focus();
                }
            }

        }

        private void btnMenu2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Coming soon!","Thông báo");
        }

    }
}
