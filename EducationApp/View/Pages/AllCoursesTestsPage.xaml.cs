using EducationApp.Model;
using EducationApp.ViewModel;
using EducationApp.View.Cards;
using System.Windows.Controls;

namespace EducationApp.View
{
    /// <summary>
    /// Логика взаимодействия для AllCoursesPage.xaml
    /// </summary>
    public partial class AllCoursesTestsPage : Page
    {
        public AllCoursesTestsPage()
        {
            InitializeComponent();
            DataContext = new AppViewModelClass();
            //add cards
            var allObjects = ((AppViewModelClass)DataContext).EducationObjects;
            if(allObjects.Count >0)
                foreach (EducationObject eduObject in allObjects)
                {
                    EducationObjectCard card = new EducationObjectCard();
                    card.Uid = eduObject.Id.ToString();
                    card.TitleEduObject.Text = eduObject.Name;
                    card.TypeEduObject.Text = eduObject.Type;
                    card.LevelEduObject.Text = eduObject.Level.ToString();
                    int authorId = eduObject.AuthorId;
                    User author = null;
                    string defaultName = "Not found";
                    using(ApplicationContext db = new ApplicationContext())
                    {
                        author = db.Users.Find(eduObject.AuthorId);
                    }
                    if (author != null)
                        defaultName = author.FirstName + " " + author.LastName;
                    card.AuthorEduObject.Text = defaultName;
                    card.Margin = new System.Windows.Thickness(10);
                    AllCards.Children.Add(card);
                }
            else AllCards.Children.Add(new VoidNoticeCard());
        }
    }
}
