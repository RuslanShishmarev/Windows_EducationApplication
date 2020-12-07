using EducationApp.Model;
using EducationApp.ViewModel;
using EducationApp.View.Cards;
using System.Windows.Controls;

namespace EducationApp.View
{
    /// <summary>
    /// Логика взаимодействия для AllCoursesPage.xaml
    /// </summary>
    public partial class AllUserSuccessPage : Page
    {
        public AllUserSuccessPage()
        {
            InitializeComponent();
            //DataContext = new AppViewModelClass();
            //add cards
            AllCards.Children.Add(new VoidNoticeCard());
        }
    }
}
