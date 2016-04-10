using FlatTheme.ControlStyle;
using System.Windows;

namespace Quiz.View
{
    /// <summary>
    /// Interaction logic for InputPassword.xaml
    /// </summary>
    public partial class InputPassword : FlatWindow
    {
        public InputPassword()
        {
            InitializeComponent();
            txtPassword.Focus();
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public string Answer
        {
            get { return txtPassword.Password; }
        }

    }
}
