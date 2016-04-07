using Core.Model;
using Quiz.Controller;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace Quiz.View
{
    /// <summary>
    /// Interaction logic for FeedbackView.xaml
    /// </summary>
    public partial class FeedbackView : Window
    {
        FeedbackController db = new FeedbackController();
        bool acceptclose = false;
        public FeedbackView()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!acceptclose)
            {
                if (MessageBox.Show("Bạn có muốn thoát hộp thoại?", "Thoát", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
        }
        private bool CheckNull()
        {
            if (!String.IsNullOrEmpty(txtEmail.Text))
            {
                if (!IsValidEmail(txtEmail.Text))
                {
                    MessageBox.Show("Địa chỉ email không hợp lệ!", "Thông báo");
                    return false;
                }
            }
            if (String.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề!", "Thông báo");
                return false;
            }
            if (String.IsNullOrEmpty(txtContent.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung!", "Thông báo");
                return false;
            }
            return true;
        }
        private bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNull())
            {
                var now = DateTime.Now;
                var record = new Feedback()
                {
                    Name = txtName.Text,
                    Email = txtEmail.Text,
                    Title = txtTitle.Text,
                    Content = txtContent.Text,
                    Status = 0,
                    SentDate = now
                };
                if (db.Add(record))
                {
                    if (MessageBox.Show("Gửi phản hồi thành công, cảm ơn bạn đã đóng góp!\nBạn có muốn đóng hộp thoại phản hồi?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        acceptclose = true;
                        this.Close();
                    }
                    else
                    {
                        acceptclose = false;
                        txtName.Text = null;
                        txtEmail.Text = null;
                        txtTitle.Text = null;
                        txtContent.Text = null;
                    }
                }
                else MessageBox.Show("Gửi phản hồi thất bại, vui lòng kiểm tra lại nội dung!", "Thông báo");
            }
        }
    }
}
