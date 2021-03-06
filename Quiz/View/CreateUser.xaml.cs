﻿using FlatTheme.ControlStyle;
using Core.Controller;
using System;
using System.Windows;
using System.Windows.Input;

namespace Quiz.View
{
    /// <summary>
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : FlatWindow
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnDangnhap_Click(sender, e);
            }
        }
        private void btnDangnhap_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUsername.Text) && !String.IsNullOrEmpty(txtPassword.Password))
            {
                UserHandle userHandle = new UserHandle();
                bool check = userHandle.AuthenticateLogin(txtUsername.Text, txtPassword.Password);
                if (check)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    DialogResult = true;
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                    //DialogResult = false;
                }
            }
            else
                MessageBox.Show("Lỗi nhập liệu");
        }
        private void btnDangki_Click(object sender, RoutedEventArgs e)
        {
            if (Check_Dangki())
            {
                UserHandle userHandle = new UserHandle();
                bool b = userHandle.Add(txtName.Text, txtPass.Password);
                if (b == true)
                {
                    MessageBox.Show("Đăng kí thành công", "Thông báo");
                    panelDangki.Visibility = Visibility.Collapsed;
                    btnShowDangKy.Visibility = Visibility.Visible;
                    panelDangnhap.Width = 220;
                    CenterBorder.Visibility = Visibility.Collapsed;
                }
                else
                    MessageBox.Show("Tên đăng nhập đã có người sử dụng");
            }
        }
        private bool Check_Dangki()
        {
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Chưa nhập tên đăng kí");
                txtName.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtPass.Password))
            {
                MessageBox.Show("Chưa nhập mật khẩu");
                txtPass.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtRetypePass.Password))
            {
                MessageBox.Show("Chưa nhập lại mật khẩu");
                txtRetypePass.Focus();
                return false;
            }
            if (txtPass.Password != txtRetypePass.Password)
            {
                MessageBox.Show("Mật khẩu không khớp");
                txtRetypePass.Focus();
                return false;
            }
            return true;
        }

        private void btnShowDangKy_Click(object sender, RoutedEventArgs e)
        {
            panelDangki.Visibility = Visibility.Visible;
            btnShowDangKy.Visibility = Visibility.Collapsed;
            panelDangnhap.Width = 160;
            CenterBorder.Visibility = Visibility.Visible;
        }
    }
}
