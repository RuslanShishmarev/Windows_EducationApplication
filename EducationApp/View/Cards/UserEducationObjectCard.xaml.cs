using EducationApp.ViewModel;
using System.Windows.Controls;

namespace EducationApp.View.Cards
{
    /// <summary>
    /// Логика взаимодействия для EducationObject.xaml
    /// </summary>
    public partial class UserEducationObjectCard : UserControl
    {
        public UserEducationObjectCard()
        {
            InitializeComponent();
            DataContext = new UserActionViewModelClass();
        }
    }
}
