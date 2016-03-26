using Core.Controller;
using Core.Model;
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
    /// Interaction logic for ucUser.xaml
    /// </summary>
    public partial class ucUser : UserControl
    {
        const string UNRANK = "/Images/Unranked.png";
        const string DONG = "/Images/bronze.png";
        const string BAC = "/Images/sliver.png";
        const string VANG = "/Images/gold.png";
        const string BACHKIM = "/Images/platium.png";
        const string KIMCUONG = "/Images/diamond.png";
        const string CAOTHU = "/Images/master.png";
        const string THACHDAU = "/Images/challenger.png";
        string[] rank = {"/Images/Unranked.png","/Images/bronze.png","/Images/sliver.png",
                        "/Images/gold.png","/Images/platium.png","/Images/diamond.png",
                        "/Images/master.png","/Images/challenger.png"};
        string[] danhgia = { "Tệ", "Cần cố gắng", "Tạm được", "Tốt", "Xuất xắc" };

        long[] danhgiaDiem = { 2, 4, 6, 8, 9 };
        long[] numAnsCorrect = { 10, 50, 100, 300, 700, 1200, 1700, 2400 };
        long[] numAns = { 40, 100, 300, 700, 1200, 1700, 2400, 3000 };
        long[] Time = { 100, 500, 5000, 15000, 30000, 70000, 150000, 40000 };

        long traloidung = 0;
        long traloi = 0;
        long time = 0;

        UCUserController uc = new UCUserController();
        List<Info> list = new List<Info>();
        List<History> history = new List<History>();
        AspNetUser user = new AspNetUser();
        public ucUser()
        {
            InitializeComponent();
            user = uc.getUser();
            list = uc.getInfo(user.Id);
            history = uc.getHistory();
            setValueRank();
            doJob();
            doJob2();
        }
        private void doJob()
        {
            lbName.Content = user.Email;
            rankAns.Source = new BitmapImage(new Uri(@""+rank[getRank(numAns, traloi)], UriKind.Relative));
            lbNumAns.Content = traloi.ToString();
            rankAnsCorrect.Source = new BitmapImage(new Uri(@"" + rank[getRank(numAnsCorrect, traloidung)], UriKind.Relative));
            lbNumAnsCorrect.Content = traloidung.ToString();
            rankTimeUse.Source = new BitmapImage(new Uri(@"" + rank[getRank(Time, time)], UriKind.Relative));
            lbTimeUse.Content = convert_int2time(Convert.ToInt32(time));
        }
        private string convert_int2time(int n)
        {
            string minute = (n / 60).ToString();
            string second = (n % 60).ToString();
            if (int.Parse(second) < 10) second = "0" + second;
            return "" + minute + ":" + second;
        }
        private void doJob2()
        {
            List<InfoHistory> _li = new List<InfoHistory>();
            foreach(History his in history)
            {
                InfoHistory infH = new InfoHistory();
                infH.SubId = his.SubId;
                float diem = ((float)his.NumberCorrect / his.NumberQuest * 10)??0;
                infH.Diem = "Điểm số: " + diem.ToString();
                infH.Danhgia = "Đánh giá: " + danhgia[getRank(danhgiaDiem, (long)diem)];
                if (diem > 6) infH.Color = "Green";
                else infH.Color = "Red";
                infH.Date = "Ngày làm bài: " + his.DateTime.Day.ToString() + "/" + his.DateTime.Month.ToString() + "/" + his.DateTime.Year.ToString() +" " + his.DateTime.Hour+":"+his.DateTime.Minute;
                _li.Add(infH);
            }
            listBox.ItemsSource = _li;
        }
        private int getRank(long[] a, long b)
        {
            for(int i =0; i<a.Length;i++)
            {
                if (b < a[i]) return i;
            }
            return a.Length - 1;
        }
        private void setValueRank()
        {
            for(int i = 0; i<list.Count;i++)
            {
                Info inf = list[i] as Info;
                traloi += inf.NumAnswer;
                traloidung += inf.NumAnswerTrue;
                time += inf.TimeUse;
            }
        }
        private class InfoHistory
        {
            public string SubId {set;get;}
            public string Diem { set; get; }
            public string Danhgia { set; get; }
            public string Date { set; get; }
            public string Color { set; get; }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtChitiet.Text = "";
            History h = history[listBox.SelectedIndex] as History;
            txtChitiet.Text = "Môn kiểm tra : " + h.SubId + System.Environment.NewLine;
            txtChitiet.Text += "Số câu hỏi : " + h.NumberQuest + System.Environment.NewLine;
            txtChitiet.Text += "Số câu trả lời : " + h.NumberAns + System.Environment.NewLine;
            txtChitiet.Text += "Số câu trả lời đúng : " + h.NumberCorrect;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Grid a = ucGrid.Parent as Grid;
            a.Children.Remove(ucGrid);
        }
    }
    
}
