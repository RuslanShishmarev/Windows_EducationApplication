using EducationApp.ViewModel;
using System.Windows.Controls;

namespace EducationApp.View
{
    /// <summary>
    /// Логика взаимодействия для WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
            DataContext = new RegLogViewModelClass();
        }
    }
}
