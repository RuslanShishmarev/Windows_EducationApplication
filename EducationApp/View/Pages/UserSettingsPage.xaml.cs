using EducationApp.ViewModel;
using System.Windows.Controls;

namespace EducationApp.View
{
    /// <summary>
    /// Логика взаимодействия для UserSettingsPage.xaml
    /// </summary>
    public partial class UserSettingsPage : Page
    {
        public UserSettingsPage()
        {
            InitializeComponent();
            DataContext = new RegLogViewModelClass();
        }
    }
}
