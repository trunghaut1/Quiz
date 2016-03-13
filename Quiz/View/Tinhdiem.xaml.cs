using Core.Controller;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Quiz
{
    /// <summary>
    /// Interaction logic for Tinhdiem.xaml
    /// </summary>
    public partial class Tinhdiem : UserControl
    {
        MainWindowsController m = new MainWindowsController();
        TinhdiemController td = new TinhdiemController();
        private List<Question> listQuestion;
        int socaudung = 0;
        int current = 0;
        float diem = 0.00f;
        string sub;
        int numAns = 0;
        int time = 0;
        bool nap = false;
        public Tinhdiem(List<Question> _list, int time, string sub, bool napfromFile)
        {
            InitializeComponent();
            this.listQuestion = _list;
            this.sub = sub;
            this.time = time;
            nap = napfromFile;
        }
        private void getInfoFromList()
        {
            for(int i=0;i<listQuestion.Count;i++)
            {
                if (listQuestion[i].Traloi != null) numAns++;
                if (listQuestion[i].IsCorrect)
                    socaudung++;
            }
            diem = (float)socaudung / listQuestion.Count * 10;
        }
        private void loadAnswerCorrectIntoPanel()
        {
            Task putMask = new Task(() =>
            {
                while (current < socaudung)
                {
                    current++;
                    Task.Factory.StartNew(() =>
                    {
                        Application.Current.Dispatcher.Invoke(new Action(() => putCurrentIntoPanel()));
                    });
                    Thread.Sleep(0 + current * 10);
                }
                Task.Factory.StartNew(() =>
                {
                    Application.Current.Dispatcher.Invoke(new Action(() => loadDiemIntoPanel()));
                });
                
            });
            putMask.Start();
        }
        private void putCurrentIntoPanel()
        {
            if (current <= 5) lbTraloidung.Foreground = Brushes.Red;
            if (current > 5 && current <= 20) lbTraloidung.Foreground = Brushes.OrangeRed;
            if (current > 20 && current <= 30) lbTraloidung.Foreground = Brushes.Yellow;
            if (current > 30 && current <= 35) lbTraloidung.Foreground = Brushes.Green;
            if (current > 35 && current <= 40) lbTraloidung.Foreground = Brushes.Blue;
            lbTraloidung.Content = current.ToString();
        }
        private void loadAnswerCorrect()
        {
            for (int i = 0; i <= socaudung; i++)
            {
                lbTraloidung.Content = i.ToString();
            }
        }
        private void loadDiemIntoPanel()
        {
            lbDiem.Content = diem.ToString();
            Storyboard sb = this.FindResource("diemAppear") as Storyboard;
            sb.Begin();
        }

        private void InsertInfo()
        {
            try
            {
                if(nap==false)
                {
                    Info i = new Info();
                    AddUserController au = new AddUserController();
                    AspNetUser u = au.FindUserByUsername(Thongtindangnhap.Username);
                    i.SubId = sub;
                    i.UserId = u.Id;
                    i.NumAnswer = numAns;
                    i.NumAnswerTrue = socaudung;
                    i.TimeUse = time;
                    td.AddInfo(i);
                    
                }
            }
            catch (Exception e)
            {
                lbTrangthai.Content = "Lỗi cập nhật dữ liệu: "+e.Message;
            }
        }
        private void InsertHistory()
        {
            try
            {
                History h = new History();
                AddUserController au = new AddUserController();
                AspNetUser u = au.FindUserByUsername(Thongtindangnhap.Username);
                h.UserId = u.Id;
                h.SubId = sub;
                h.NumberQuest = listQuestion.Count;
                h.NumberAns = numAns;
                h.NumberCorrect = socaudung;
                h.DateTime = DateTime.Now;
                td.AddHistory(h);
                lbTrangthai.Content = "Cập nhật cơ sở dữ liệu thành công";
            }
            catch (Exception e)
            {
                lbTrangthai.Content = "Lỗi cập nhật dữ liệu: " + e.Message;
            }
        }

        private void lbDiem_Loaded(object sender, RoutedEventArgs e)
        {
            getInfoFromList();
            loadAnswerCorrectIntoPanel();
            lbTrangthai.Content = "";
            lbChutich.Content = "Chúc các bạn có kì thi thành công!";
            if(Thongtindangnhap.IsLogin && nap == false)
            {
                InsertInfo();
                InsertHistory();
            }
            
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)FindResource("Close");
            sb.Begin();
        }
        private void Close_Completed(object sender, EventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            
        }
        
    }
}
