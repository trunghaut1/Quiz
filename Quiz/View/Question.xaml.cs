using Quiz.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    public partial class Question : UserControl
    {
        List<Quiz.Model.Question> _list; //danh sach cau hoi
        QuestionController qc;
        string NameSub;
        int numOfQuestion;
        int index;//cau hoi dang duoc chon
        int time;
        Timer timer = new Timer();
        bool nopbai = false;
        bool DataFromFile = false;
        /// <summary>
        /// Đọc câu hỏi từ file .df
        /// </summary>
        /// <param name="list"></param>
        public Question(List<Model.Question> list)
        {
            InitializeComponent();
            _list = new List<Quiz.Model.Question>();
            //_ans = new List<string>();
            qc = new QuestionController();
            _list = list;
            NameSub = _list[0].SubId;
            numOfQuestion = _list.Count;
            index = 0;
            time = 0;
            DataFromFile = true;

            setLableValue(NameSub);
            createQuestionButton(numOfQuestion);
            setColor4ButtonCurrentSelected(index);
            loadCauhoi(index);
            demgio();
            txtQuest.Focus();
        }
        /// <summary>
        /// Đọc câu hỏi từ cơ sở dữ liệu
        /// </summary>
        /// <param name="btnName"></param>
        public Question(string btnName)
        {
            InitializeComponent();
            _list = new List<Quiz.Model.Question>();
            //_ans = new List<string>();
            qc = new QuestionController();
            NameSub = btnName;
            numOfQuestion = 40;
            index = 0;
            time = 0;
            
            setLableValue();
            populateQuestion();
            //populateAnswer();
            createQuestionButton(numOfQuestion);
            setColor4ButtonCurrentSelected(index);
            loadCauhoi(index);
            demgio();
            txtQuest.Focus();
        }
        /// <summary>
        /// Lấy danh sách câu hỏi
        /// </summary>
        private void populateQuestion()
        {
            try
            {
                _list = qc.getQuestion(NameSub, numOfQuestion);
            }
            catch(Exception e)
            {
                MessageBox.Show("Populating Question Failed /n" + e.Message, "Error");
            }
        }
        /// <summary>
        /// Tạo button cho danh sách câu hỏi
        /// </summary>
        /// <param name="num"></param>
        private void createQuestionButton(int num)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                Style style = FindResource("btn") as Style;
                Button btn = new Button();
                btn.Style = style;
                btn.Content = (i+1).ToString();
                btn.Name = "Button" + i.ToString();
                btn.Tag = i;
                btn.Click += btn_Click;
                btn.IsTabStop = false;
                btnPanel.Children.Add(btn);
            }
            //DataContext = l;
            //this.DataContext = new SubjectButton() { BtnName = "aaa", SubName = "aaasd", Height = 190, Width = 50, Note = "adadad", ImgUrl = "" };
        }

        void btn_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender as Button;
            if(bt.Tag.ToString()!=index.ToString())
            {
                setColor4ButtonToNormal(index);
                setColor4ButtonCurrentSelected(int.Parse(bt.Tag.ToString()));
                loadCauhoi(int.Parse(bt.Tag.ToString()));
                reloadStateRadioButton();
            }
        }
        /// <summary>
        /// dùng để load câu hỏi thứ ? (num)
        /// </summary>
        /// <param name="num"></param>
        private void loadCauhoi(int num)
        {
            Model.Question qs = new Model.Question();
            qs.Id = _list[num].Id;
            qs.SubId = _list[num].SubId;
            qs.Content = _list[num].Content;
            qs.Opt1 = _list[num].Opt1;
            qs.Opt2 = _list[num].Opt2;
            qs.Opt3 = _list[num].Opt3;
            qs.Opt4 = _list[num].Opt4;
            qs.Answer = _list[num].Answer;
            qs.DateAdd = _list[num].DateAdd;
            qs.UserAdd = _list[num].UserAdd;
            qs.Note = _list[num].Note;
            txtQuest.Document.Blocks.Clear();
            txtQuest.Document.Blocks.Add(new Paragraph(new Run("Câu " + (num + 1) + ": --Đóng góp: "+qs.UserAdd+ " -- \n" + qs.Content.Replace("\\n", "\n"))));
            qs.Opt1 = _list[num].Opt1.Insert(0, "A. ");
            qs.Opt2 = _list[num].Opt2.Insert(0, "B. ");
            qs.Opt3 = _list[num].Opt3.Insert(0, "C. ");
            qs.Opt4 = _list[num].Opt4.Insert(0, "D. ");
            DataContext = qs;
            index = num; //cap nhat nut dang duoc chon
        }
        /// <summary>
        /// cài tên môn học
        /// </summary>
        private void setLableValue()
        {
            lbName.Content = qc.getSubName(NameSub);
        }
        private void setLableValue(string abc)
        {
            lbName.Content = abc;
        }
        
        private void changeStyleButton(int z, string style)
        {
            Style sbans = FindResource(style) as Style;
            Button btn = FindButtonByIndex(z);
            btn.Style = sbans;
        }
        
        private void rdButton_Click(object sender, RoutedEventArgs e)
        {
            if (!nopbai)
            {
                changeStyleButton(index, "btnAnswered");
                RadioButton rb = sender as RadioButton;
                _list[index].Traloi = rb.Content.ToString().Remove(0, 3);
            }
        }
        /// <summary>
        /// Cập nhật câu trả lời cho câu hỏi hiện đang chọn
        /// </summary>
        private void reloadStateRadioButton()
        {
            rbOpt1.IsChecked = false;
            rbOpt2.IsChecked = false;
            rbOpt3.IsChecked = false;
            rbOpt4.IsChecked = false;
            if(nopbai)
            {
                Style s = FindResource("radioBBassic") as Style;
                rbOpt1.Style = s;
                rbOpt2.Style = s;
                rbOpt3.Style = s;
                rbOpt4.Style = s;
                setStyleRadioButton();
            }
            else
            {
                if (_list[index].Traloi != null)
                {
                    if (_list[index].Traloi == rbOpt1.Content.ToString().Remove(0, 3))
                        rbOpt1.IsChecked = true;
                    else if (_list[index].Traloi == rbOpt2.Content.ToString().Remove(0, 3))
                        rbOpt2.IsChecked = true;
                    else if (_list[index].Traloi == rbOpt3.Content.ToString().Remove(0, 3))
                        rbOpt3.IsChecked = true;
                    else if (_list[index].Traloi == rbOpt4.Content.ToString().Remove(0, 3))
                        rbOpt4.IsChecked = true;
                }
            }
            
            
        }
        /// <summary>
        /// Gắn màu trắng cho câu hỏi đang chọn
        /// </summary>
        /// <param name="z"></param>
        private void setColor4ButtonCurrentSelected(int z)
        {
            Button btn = FindButtonByIndex(z);
            btn.Foreground = Brushes.AliceBlue;
        }
        private void setColor4ButtonToNormal(int z)
        {
            Button btn = FindButtonByIndex(z);
            btn.Foreground = Brushes.Black;
        }

        /// <summary>
        /// Điều hướng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetNextQuest(object sender, RoutedEventArgs e)
        {
            int _nextIndex = getValueIndex(index, "+");
            Button btn = FindButtonByIndex(_nextIndex);
            btn_Click(btn, e);
            
        }
        private void btnPre_Click(object sender, RoutedEventArgs e)
        {
            int _nextIndex = getValueIndex(index, "-");
            Button btn = FindButtonByIndex(_nextIndex);
            btn_Click(btn, e);
        }
        private int getValueIndex(int i, string command)
        {
            int value=0;
            switch (command)
            {
                case "+":
                    if (i < 39) value = ++i;
                    break;
                case "-":
                    if (i > 0) value = --i;
                    else value = _list.Count - 1;
                    break;
            }
            return value;
        }
        private void XZ_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int _nextIndex;
            Button btn = new Button();
            switch (e.Key)
            {
                case Key.X:
                    _nextIndex = getValueIndex(index, "+");
                    btn = FindButtonByIndex(_nextIndex);
                    btn_Click(btn, e);
                    break;
                case Key.Z:
                    _nextIndex = getValueIndex(index, "-");
                    btn = FindButtonByIndex(_nextIndex);
                    btn_Click(btn, e);
                    break;
            }
        }

        private Button FindButtonByIndex(int z)
        {
            var myEnumerator = btnPanel.Children.GetEnumerator();
            for (int i = 0; i <= z; i++)
                myEnumerator.MoveNext();
            Button btn = (Button)myEnumerator.Current as Button;
            return btn;
        }
        /// <summary>
        /// Đếm giờ
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private string convert_int2time(int n)
        {
            string minute = (n / 60).ToString();
            string second = (n % 60).ToString();
            if (int.Parse(second) < 10) second = "0" + second;
            return "" + minute + ":" + second;
        }
        private void demgio()
        {
            timer = new Timer(1000);
            timer.Elapsed += timer_Elapsed;
            timer.Enabled = true;
            timer.Start();
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            time++;
            Dispatcher.Invoke(new Action(() =>
            {
                lbTime.Content = convert_int2time(time);
            }));
        }

        /// <summary>
        /// nộp bài
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = 
                System.Windows.MessageBox.Show("Quay lại, dữ liệu bài tập sẽ mất hết! \n Tiếp tục?", 
                "Quay lại", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Grid a = QuestionUC.Parent as Grid;
                a.Children.Remove(QuestionUC);
            }
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            nopbai = true;
            change4Submit();
            setStateButton();
            loadCauhoi(index);
            Tinhdiem td = new Tinhdiem(_list, time, NameSub, DataFromFile);
            Grid a = QuestionUC.Parent as Grid;
            a.Children.Add(td);
        }

        private void change4Submit()
        {
            rbOpt1.IsEnabled = false;
            rbOpt2.IsEnabled = false;
            rbOpt3.IsEnabled = false;
            rbOpt4.IsEnabled = false;
            btnNote.Visibility = Visibility.Visible;
            btnDone.IsEnabled = false;
            index = 0;
        }
        private void setStateButton()
        {
            Style sbanswr = FindResource("btnAnswerWrong") as Style;
            Style sbanscor = FindResource("btnAnswerCorrect") as Style;
            for(int i = 0; i<_list.Count;i++)
            {
                if (_list[i].Traloi != "")
                {
                    Button btn = FindButtonByIndex(i);
                    btn.Foreground = Brushes.Black;
                    if (_list[i].IsCorrect)
                       btn.Style = sbanscor;
                    else btn.Style = sbanswr;
                }
            }
        }
        private void setStyleRadioButton()
        {
            //reloadStateRadioButton();
            Style srCor = FindResource("radioBCorrect") as Style;
            Style srWr = FindResource("radioBWrong") as Style;
            string opt1 = rbOpt1.Content.ToString().Remove(0, 3);
            string opt2 = rbOpt2.Content.ToString().Remove(0, 3);
            string opt3 = rbOpt3.Content.ToString().Remove(0, 3);
            string opt4 = rbOpt4.Content.ToString().Remove(0, 3);
            if (_list[index].Answer == opt1) rbOpt1.Style = srCor;
            else if (_list[index].Answer == opt2) rbOpt2.Style = srCor;
            else if (_list[index].Answer == opt3) rbOpt3.Style = srCor;
            else if (_list[index].Answer == opt4) rbOpt4.Style = srCor;
            if(!_list[index].IsCorrect && _list[index].Traloi!="")
            {
                if (_list[index].Traloi == opt1) rbOpt1.Style = srWr;
                else if (_list[index].Traloi == opt2) rbOpt2.Style = srWr;
                else if (_list[index].Traloi == opt3) rbOpt3.Style = srWr;
                else if (_list[index].Traloi == opt4) rbOpt4.Style = srWr;
            }

        }

        private void btnNote_Click(object sender, RoutedEventArgs e)
        {
            if (txtNote.Visibility == Visibility.Hidden)
                txtNote.Visibility = Visibility.Visible;
            else txtNote.Visibility = Visibility.Hidden;
        }
    }
}
