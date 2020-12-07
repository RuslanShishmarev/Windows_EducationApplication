using EducationApp.ViewModel;
using System.Windows.Controls;

namespace EducationApp.View.Cards
{
    /// <summary>
    /// Логика взаимодействия для AddNewTestCourseCard.xaml
    /// </summary>
    public partial class AddNewTestCourseCard : UserControl
    {
        public AddNewTestCourseCard()
        {
            InitializeComponent();
            DataContext = new AppViewModelClass();
        }
    }
}
