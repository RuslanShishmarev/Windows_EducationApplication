using EducationApp.View.Windows;
using EducationApp.ViewModel;
using System.Windows;
using System.Windows.Controls;


namespace EducationApp.View.Cards
{
    /// <summary>
    /// Логика взаимодействия для LoginCard.xaml
    /// </summary>
    public partial class LoginCard : UserControl
    {
        public LoginCard()
        {
            InitializeComponent();
            DataContext = new RegLogViewModelClass();
        }


        private void OpenRegWind_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registration = new RegistrationWindow();
            registration.Owner = MainWindow.GetWindow(this);
            registration.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            registration.ShowDialog();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            RegLogViewModelClass.Password = PasswordBox.Password;
        }
    }
}
