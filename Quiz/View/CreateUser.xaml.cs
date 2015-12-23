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

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            panelDangki.Visibility = System.Windows.Visibility.Visible;
        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "Tên đăng nhập")
                txtUsername.Text = "";
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password == "Mật khẩu")
                txtPassword.Password = "";
        }

        private void txtName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "Tên đăng nhập")
                txtName.Text = "";
        }

        private void txtPass_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPass.Password == "Mật khẩu")
                txtPass.Password = "";
        }

        private void txtRetypePass_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtRetypePass.Password == "Nhập lại mật khẩu")
                txtRetypePass.Password = "";
        }

        private void txtUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "")
                txtUsername.Text = "Tên đăng nhập";
        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password == "")
                txtPassword.Password = "Mật khẩu";
        }

        private void txtName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "")
                txtName.Text = "Tên đăng nhập";
        }

        private void txtPass_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPass.Password == "")
                txtPass.Password = "Mật khẩu";
        }

        private void txtRetypePass_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtRetypePass.Password == "")
                txtRetypePass.Password = "Nhập lại mật khẩu";
        }

        private void btnDangnhap_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text != "" && txtUsername.Text != "Tên đăng nhập"
                && txtPassword.Password != "Mật khẩu" && txtPassword.Password != "")
            {
                AddUserController au = new AddUserController();
                bool check = au.CheckLogin(txtUsername.Text, txtPassword.Password);
                if (check)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    DialogResult = true;
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                    DialogResult = false;
                }
            }
            else
                MessageBox.Show("Lỗi nhập liệu");
        }
        private void btnDangki_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text != "" && txtUsername.Text != "Tên đăng nhập"
                && txtPassword.Password != "Mật khẩu" && txtPassword.Password != "")
            {
                AddUserController au = new AddUserController();
                bool check = au.CheckLogin(txtUsername.Text, txtPassword.Password);
                if (check)
                    MessageBox.Show("Đăng nhập thành công");
                else MessageBox.Show("Đăng nhập thất bại");
            }
        }
    }
}
