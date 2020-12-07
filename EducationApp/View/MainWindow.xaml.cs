using EducationApp.View;
using EducationApp.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EducationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool UserStatus = false;
        public static Frame MainFrame;
        public static Button CloseButton;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new RegLogViewModelClass();
            MainFrame = mainFrame;
            CloseButton = CloseBtn;
            MainFrame.Navigate(new WelcomePage());
        }
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            //Set tooltip visibility
            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_success.Visibility = Visibility.Collapsed;
                tt_courses.Visibility = Visibility.Collapsed;
                tt_settings.Visibility = Visibility.Collapsed;
                tt_chat.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_success.Visibility = Visibility.Visible;
                tt_courses.Visibility = Visibility.Visible;
                tt_settings.Visibility = Visibility.Visible;
                tt_chat.Visibility = Visibility.Visible;
            }
        }
        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }
        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }
        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }
        private void nav_pnl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void NavigationBtn_Click(object sender, RoutedEventArgs e)
        {
            int indexPage = -1;
            if (UserStatus)
                indexPage = int.Parse(((Button)sender).Uid);

            OpenPage(indexPage);
        }
        private void OpenPage(int index)
        {
            switch (index)
            {
                case 0:
                    mainFrame.Navigate(new UserProfilePage());
                    break;
                case 1:
                    mainFrame.Navigate(new AllCoursesTestsPage());
                    break;
                case 2:
                    mainFrame.Navigate(new AllUserSuccessPage());
                    break;
                case 3:
                    mainFrame.Navigate(new AllUserEducationList());
                    break;
                case 4:
                    mainFrame.Navigate(new UserSettingsPage());
                    break;
                case 5:
                    mainFrame.Navigate(new AllCoursesTestsPage());
                    break;
                case 6:
                    mainFrame.Navigate(new AddNewTestCoursePage());
                    break;
                default:
                    mainFrame.Navigate(new LoginRegistrationPage());
                    break;
            }
        }
    }
}
