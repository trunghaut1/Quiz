using Core.Controller;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Quiz.View
{
    /// <summary>
    /// Interaction logic for Subject.xaml
    /// </summary>
    public partial class Subject : UserControl
    {
        SubjectHandle subjectHandle;
        string subid;
        public Subject()
        {
            InitializeComponent();
            subjectHandle = new SubjectHandle();
            createSubButton();
        }
        private void createSubButton()
        {
            List<SubButton> _list = subjectHandle.GetAllSubjectButton();
            for (int i = 0; i < _list.Count; i++)
            {
                Button btn = new Button();
                Style style = this.FindResource("btnSub") as Style;
                btn.Style = style;
                btn.Name = _list[i].ButtonName;
                btn.IsTabStop = false;
                btn.Margin = new Thickness(10, 10, 0, 0);
                btnPanel.Children.Add(btn);
                btn.Click += btn_Click;
                btn.DataContext = _list[i] as SubButton;
                //MessageBox.Show(btn.Height.ToString());
            }
        }
        void btn_Click(object sender, RoutedEventArgs e)
        {
            Button _temp = sender as Button;
            subid = _temp.Name.Substring(3);
            lblSubject.Content = subid;            
        }

        private void homebtn_Click(object sender, RoutedEventArgs e)
        {
            Grid a = subUC.Parent as Grid;
            a.Children.Remove(subUC);
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(subid))
            {
                Question q = new Question(subid);
                Grid a = subUC.Parent as Grid;
                a.Children.Add(q);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn môn học!", "Thông báo");
            }
        }
    }
}
