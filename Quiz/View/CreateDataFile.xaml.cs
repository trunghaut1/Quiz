﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Core.Controller;
using FlatTheme.ControlStyle;

namespace Quiz.View
{
    /// <summary>
    /// Interaction logic for CreateDataFile.xaml
    /// </summary>
    public partial class CreateDataFile : FlatWindow
    {

        DataFileController d = new DataFileController();
        List<Core.Model.Question> list = new List<Core.Model.Question>();
        public CreateDataFile()
        {
            InitializeComponent();
            refreshChitiet();
        }

        private bool checkQuestion()
        {
            if (txtMonhoc.Text == "")
            {
                txtMonhoc.Focus();
                return false;
            }
            if (txtCauhoi.Text == "")
            {
                txtCauhoi.Focus();
                return false;
            }
            if (txtA.Text == "")
            {
                txtA.Focus();
                return false;
            }
            if (txtB.Text == "")
            {
                txtB.Focus();
                return false;
            }
            if (txtC.Text == "")
            {
                txtC.Focus();
                return false;
            }
            if (txtD.Text == "")
            {
                txtD.Focus();
                return false;
            }
            if (isUsePass.IsChecked == true)
            {
                if (txtPass.Password == "")
                {
                    txtPass.Focus();
                    return false;
                }
            }
            if (rA.IsChecked == true)
                return true;
            if (rB.IsChecked == true)
                return true;
            if (rC.IsChecked == true)
                return true;
            if (rD.IsChecked == true)
                return true;
            MessageBox.Show("Chưa chọn câu trả lời", "Thông báo");
            return false;
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (checkQuestion())
            {
                Core.Model.Question q = new Core.Model.Question();
                q.Id = (int)lvQuest.Items.Count;
                q.SubId = txtMonhoc.Text;
                q.Content = txtCauhoi.Text;
                q.Opt1 = txtA.Text;
                q.Opt2 = txtB.Text;
                q.Opt3 = txtC.Text;
                q.Opt4 = txtD.Text;
                if (rA.IsChecked == true) q.Answer = txtA.Text;
                else if (rB.IsChecked == true) q.Answer = txtB.Text;
                else if (rC.IsChecked == true) q.Answer = txtC.Text;
                else q.Answer = txtD.Text;
                q.DateAdd = DateTime.Now;
                q.Note = txtGiaithich.Text;
                q.UserAdd = txtNguoilap.Text;
                list.Add(q);
                lvQuest.ItemsSource = null;
                lvQuest.ItemsSource = list;
                refreshChitiet();
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult =
                System.Windows.MessageBox.Show("Câu hỏi hiện tại sẽ bị xóa \n Tiếp tục?",
                "Xác nhân", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                list.RemoveAt(lvQuest.SelectedIndex);
                lvQuest.ItemsSource = null;
                lvQuest.ItemsSource = list;
            }
        }


        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (checkQuestion())
            {
                Core.Model.Question q = lvQuest.SelectedItem as Core.Model.Question;
                q.Content = txtCauhoi.Text;
                q.Opt1 = txtA.Text;
                q.Opt2 = txtB.Text;
                q.Opt3 = txtC.Text;
                q.Opt4 = txtD.Text;
                q.Note = txtGiaithich.Text;
                q.DateAdd = DateTime.Now;
                if (rA.IsChecked == true) q.Answer = txtA.Text;
                else if (rB.IsChecked == true) q.Answer = txtB.Text;
                else if (rC.IsChecked == true) q.Answer = txtC.Text;
                else q.Answer = txtD.Text;
            }
        }

        private void btnGhi_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "DataFile (*.df)|*.df";
            s.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            if (s.ShowDialog() == true)
            {
                populateFile(s.FileName);
            }
            MessageBox.Show("Success!", "Notice");
        }

        private void populateFile(string url)
        {
            string pass = txtPass.Password;
            d.write2File(url, false, pass);
            d.write2File(url, true, lvQuest.Items.Count.ToString());
            foreach (Core.Model.Question q in lvQuest.Items)
            {
                d.write2File(url, true, q.Id.ToString());
                d.write2File(url, true, q.SubId);
                d.write2File(url, true, q.Content);
                d.write2File(url, true, q.Opt1);
                d.write2File(url, true, q.Opt2);
                d.write2File(url, true, q.Opt3);
                d.write2File(url, true, q.Opt4);
                d.write2File(url, true, q.Answer);
                d.write2File(url, true, q.UserAdd.ToString());
                string dateAdd = q.DateAdd.Month.ToString() + "/" + q.DateAdd.Day.ToString() + "/" + q.DateAdd.Year.ToString();
                d.write2File(url, true, dateAdd);
                d.write2File(url, true, q.Note);
            }
        }

        private void btnPickFile_Click(object sender, RoutedEventArgs e)
        {
            lvQuest.ItemsSource = null;

            isUsePass.IsChecked = false;
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "DataFile (*.df)|*.df";
            o.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            if (o.ShowDialog() == true)
            {
                list = (List<Core.Model.Question>)d.readListFromFile(o.FileName);

                lvQuest.ItemsSource = list;
                string pass = d.readPassFromFile(o.FileName);
                if (pass != "")
                {
                    isUsePass.IsChecked = true;
                    txtPass.Password = pass;
                    txtPass.IsEnabled = false;
                    isUsePass.IsEnabled = false;
                }
                txtFileUrl.Text = o.FileName;
            }
        }

        private void refreshChitiet()
        {
            txtCauhoi.Text = "";
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtD.Text = "";
            txtGiaithich.Text = "";
            rA.IsChecked = false;
            rB.IsChecked = false;
            rC.IsChecked = false;
            rD.IsChecked = false;
            btnThem.IsEnabled = true;
            btnXoa.IsEnabled = false;
            btnLuu.IsEnabled = false;
            txtNguoilap.IsEnabled = true;
            //lvQuest.SelectedIndex = -1;
        }
        private void lvQuest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnThem.IsEnabled = false;
            btnXoa.IsEnabled = true;
            btnLuu.IsEnabled = true;
            Core.Model.Question s = lvQuest.SelectedItem as Core.Model.Question;
            if (s != null)
            {
                gridChitiet.DataContext = s;
                if (s.UserAdd != null) txtNguoilap.IsEnabled = false;
                else txtNguoilap.IsEnabled = true;
                if (s.Answer == s.Opt1)
                    rA.IsChecked = true;
                else if (s.Answer == s.Opt2)
                    rB.IsChecked = true;
                else if (s.Answer == s.Opt3)
                    rC.IsChecked = true;
                else rD.IsChecked = true;
            }
        }

        private void isUsePass_Checked(object sender, RoutedEventArgs e)
        {
            txtPass.IsEnabled = true;
        }

        private void isUsePass_Unchecked(object sender, RoutedEventArgs e)
        {
            txtPass.Password = "";
            txtPass.IsEnabled = false;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            refreshChitiet();
        }


    }
}
