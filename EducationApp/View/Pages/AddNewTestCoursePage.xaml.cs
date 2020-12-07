using EducationApp.ViewModel;
using EducationApp.View.Cards;
using System.Windows.Controls;

namespace EducationApp.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewTestCoursePage.xaml
    /// </summary>
    public partial class AddNewTestCoursePage : Page
    {
        public AddNewTestCoursePage()
        {
            InitializeComponent();
            DataContext = new AppViewModelClass();
            AddNewTestCourseCard card = new AddNewTestCourseCard();
            CardPlace.Children.Add(card);
        }
    }
}
