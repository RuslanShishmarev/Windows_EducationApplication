
using EducationApp.Model;
using EducationApp.View.Cards;
using EducationApp.ViewModel;
using System.Windows.Controls;

namespace EducationApp.View
{
    /// <summary>
    /// Логика взаимодействия для AllUserEducationList.xaml
    /// </summary>
    public partial class AllUserEducationList : Page
    {
        public AllUserEducationList()
        {
            InitializeComponent();
            DataContext = new UserActionViewModelClass();
            //add cards
            var allObjects = ((UserActionViewModelClass)DataContext).LoginUserEducationList;
            if(allObjects.Count > 0)
                using (ApplicationContext db = new ApplicationContext())
                {
                    foreach (UserEducationList userListObject in allObjects)
                    {
                        EducationObject eduObject = db.EducationObjects.Find(userListObject.EducationObjectId);
                        UserEducationObjectCard card = new UserEducationObjectCard();
                        card.Uid = eduObject.Id.ToString();
                        card.TitleEduObject.Text = eduObject.Name;
                        card.TypeEduObject.Text = eduObject.Type;
                        card.LevelEduObject.Text = eduObject.Level.ToString();
                        card.Margin = new System.Windows.Thickness(10);
                        card.DateEduObject.Text = userListObject.Start.ToShortDateString();
                        card.ResultEduObject.Text = userListObject.Result.ToString();
                        AllUserCards.Children.Add(card);
                    }
                }
            else 
                AllUserCards.Children.Add(new VoidNoticeCard());
            //var allObjects = ((UserActionViewModelClass)DataContext).LoginUserCardList;
            //foreach (EducationObjectCard card in allObjects)
            //    AllUserCards.Children.Add(card);
        }
    }
}
