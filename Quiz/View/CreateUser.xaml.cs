using FlatTheme.ControlStyle;
using Quiz.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Quiz.View
{
    /// <summary>
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : FlatWindow
    {
        AddUserController cr = new AddUserController();
        public CreateUser()
        {
            InitializeComponent();
            this.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txtUser.Text!="")
            {
                cr.AddUser(txtUser.Text);
                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtUser.Text == "") Application.Current.Shutdown();
        }
    }
}
