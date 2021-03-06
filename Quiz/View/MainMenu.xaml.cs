﻿using Microsoft.Win32;
using Core.Controller;
using Core.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using KnightsWarriorAutoupdater;

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
            if (Thongtindangnhap.IsLogin)
            {
                Subject sub = new Subject();
                Grid a = ucMainMenu.Parent as Grid;
                a.Children.Add(sub);
            }
            else MessageBox.Show("Chưa đăng nhập!", "Thông báo");
        }

        private void btnMenu3_Click(object sender, RoutedEventArgs e)
        {
            if (Thongtindangnhap.IsLogin)
            {
                ucUser sub = new ucUser();
                Grid a = ucMainMenu.Parent as Grid;
                a.Children.Add(sub);
            }
            else MessageBox.Show("Chưa đăng nhập!", "Thông báo");
        }

        private void btnMenu4_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "DataFile (*.df)|*.df";
            o.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            if (o.ShowDialog() == true)
            {
                List<Core.Model.Question> list = new List<Core.Model.Question>();
                list = (List<Core.Model.Question>)d.readListFromFile(o.FileName);
                string pass = d.readPassFromFile(o.FileName);
                if (pass != "")
                {
                    InputPassword ip = new InputPassword();
                    if (ip.ShowDialog() == true)
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
            AutoUpdater au = new AutoUpdater();
            if (!au.Update())
                MessageBox.Show("Đã cập nhật cơ sở dữ liệu mới nhất!", "Thông báo");
        }

        private void MainCircle_MouseEnter(object sender, MouseEventArgs e)
        {
            imglogo.Visibility = Visibility.Visible;
        }

        private void MainCircle_MouseLeave(object sender, MouseEventArgs e)
        {
            imglogo.Visibility = Visibility.Hidden;
        }

        private void MainCircle_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/groups/NGUYENNGOCMINH/");
        }

    }
}
