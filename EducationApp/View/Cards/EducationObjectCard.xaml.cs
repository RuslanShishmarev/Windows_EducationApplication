using EducationApp.ViewModel;
using System.Windows.Controls;

namespace EducationApp.View.Cards
{
    /// <summary>
    /// Логика взаимодействия для EducationObject.xaml
    /// </summary>
    public partial class EducationObjectCard : UserControl
    {
        public EducationObjectCard()
        {
            InitializeComponent();
            DataContext = new UserActionViewModelClass();
        }
    }
}
