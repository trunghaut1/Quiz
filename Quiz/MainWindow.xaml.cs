using Quiz.Controller;
using Quiz.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SQLite;
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
using System.Xml;

namespace Quiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        MainWindowsController ctr = new MainWindowsController();
        public MainWindow()
        {
            InitializeComponent();
            //string dir = System.AppDomain.CurrentDomain.BaseDirectory;
            //string cnn ="metadata=res://*/Model.QuizModel.csdl|res://*/Model.QuizModel.ssdl|res://*/Model.QuizModel.msl;provider=System.Data.SQLite.EF6;provider connection string='data source=&quot;"+dir+"quizdb.db&quot;'";

            //updateConfigFile(cnn);
            //var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            //connectionStringsSection.ConnectionStrings["quizdbEntities"].ConnectionString = cnn;
            //config.Save();
            //ConfigurationManager.RefreshSection("connectionStrings");
            
            //var connectionString = ConfigurationManager.ConnectionStrings["quizdbEntities"].ConnectionString;
            //MessageBox.Show(connectionString.ToString());
            MainMenu sub = new MainMenu();
            mainGrid.Children.Add(sub);
            /*if(ctr.getUser()==0)
            {
                CreateUser cr = new CreateUser();
                cr.ShowDialog();
            }*/
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) // Is Alt key pressed
            {
                //if (Keyboard.IsKeyDown(Key.R))
                //{
                    CreateDataFile cr = new CreateDataFile();
                    cr.Show();
                //}
            }
        }
        /*public void updateConfigFile(string con)
        {
            //updating config file
            XmlDocument XmlDoc = new XmlDocument();
            //Loading the Config file
            XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            foreach (XmlElement xElement in XmlDoc.DocumentElement)
            {
                if (xElement.Name == "connectionStrings")
                {
                    //setting the coonection string
                    xElement.FirstChild.Attributes[0].Value = con;
                }
            }
            //writing the connection string in config file
            XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }*/
    }
}
