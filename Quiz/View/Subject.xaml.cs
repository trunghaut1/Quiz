using Quiz.Controller;
using Quiz.Model;
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

namespace Quiz.View
{
    /// <summary>
    /// Interaction logic for Subject.xaml
    /// </summary>
    public partial class Subject : UserControl
    {
        SubjectController sc;
        public Subject()
        {
            InitializeComponent();
            sc = new SubjectController();
            createSubButton();
        }
        private void createSubButton()
        {
            List<SubButton> _list = sc.loadSubjectButton();
            for(int i=0;i<_list.Count;i++)
            {
                Button btn = new Button();
                //Style style = this.FindResource("btnSub") as Style;
                //btn.Style = style;
                btn.Name = _list[i].ButtonName;
                btn.IsTabStop = false;
                btnPanel.Children.Add(btn);
                btn.Click += btn_Click;
                btn.DataContext = _list[i] as SubButton;
                //MessageBox.Show(btn.Height.ToString());
            }
        }
        void btn_Click(object sender, RoutedEventArgs e)
        {
            Button _temp = sender as Button;
            Question q = new Question(_temp.Name.Substring(3));
            Grid a = subUC.Parent as Grid;
            a.Children.Add(q);
        }

        private void homebtn_Click(object sender, RoutedEventArgs e)
        {
            Grid a = subUC.Parent as Grid;
            a.Children.Remove(subUC);
        }
    }
}
