using FlatTheme.Code;
using FlatTheme.ControlStyle;
using Core.Model;
using Quiz.View;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : FlatWindow
    {
        string color = "Material";
        string theme = "Light";
        public MainWindow()
        {
            InitializeComponent();
            //string dir = System.AppDomain.CurrentDomain.BaseDirectory;
            //string cnn ="metadata=res://*/Model.QuizModel.csdl|res://*/Model.QuizModel.ssdl|res://*/Model.QuizModel.msl;provider=System.Data.SQLite.EF6;provider connection string='data source=&quot;"+dir+"quizdb.db&quot;'";

            //updateConfigFile(cnn);
            //var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            //connectionStringsSection.ConnectionStrings["quizdbEntities"].ConnectionString = cnn;
            //config.Save();
            //ConfigurationManager.RefreshSection("connectionStrings");

            //var connectionString = ConfigurationManager.ConnectionStrings["quizdbEntities"].ConnectionString;
            //MessageBox.Show(connectionString.ToString());
            MainMenu sub = new MainMenu();
            mainGrid.Children.Add(sub);
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.R) // Ctrl + R key pressed
            {
                if (Keyboard.IsKeyDown(Key.LeftCtrl))
                {
                    CreateDataFile cr = new CreateDataFile();
                    cr.Show();
                }
            }
        }
        private void Do_Login()
        {
            if (Thongtindangnhap.IsLogin)
            {
                menuHeader.Header = Thongtindangnhap.Username;
                menuDangnhap.Visibility = Visibility.Collapsed;
                menuDangxuat.Visibility = Visibility.Visible;
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDark_Click(object sender, RoutedEventArgs e)
        {
            if (color != "BlueGrey")
            {
                if (!btnDark.IsChecked.Value)
                {
                    theme = "Light";
                    ChangeTheme.Change(color + theme);
                }
                else
                {
                    theme = "Dark";
                    ChangeTheme.Change(color + theme);
                }
            }
            else
            {
                theme = "Light";
                btnDark.IsChecked = false;
            }
        }

        private void menuDangnhap_Click(object sender, RoutedEventArgs e)
        {
            if (!Thongtindangnhap.IsLogin)
            {
                CreateUser cr = new CreateUser();
                if (cr.ShowDialog() == true)
                {
                    Do_Login();
                }
            }
        }

        private void menuDangxuat_Click(object sender, RoutedEventArgs e)
        {
            Thongtindangnhap.IsLogin = false;
            Thongtindangnhap.Username = "";
            Thongtindangnhap.Password = "";
            menuHeader.Header = "Tài khoản";
            menuDangxuat.Visibility = Visibility.Collapsed;
            menuDangnhap.Visibility = Visibility.Visible;
        }

        private void FlatWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ứng dụng?", "Thoát", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;

        }

        private void ChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            color = btn.Tag.ToString();
            if (btn.Tag.ToString() != "BlueGrey")
            {
                ChangeTheme.Change(color + theme);
            }
            else
            {
                ChangeTheme.Change(color);
            }
        }

        private void menuAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutView ab = new AboutView();
            ab.ShowDialog();
        }

        private void menuFeedback_Click(object sender, RoutedEventArgs e)
        {
            FeedbackView fb = new FeedbackView();
            fb.ShowDialog();
        }
    }
}
