using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Windows;
using EducationApp.Model;
using EducationApp.View;
using EducationApp.View.Cards;
using EducationApp.View.Windows;

namespace EducationApp.ViewModel
{
    class UserActionViewModelClass : INotifyPropertyChanged
    {
        public List<UserEducationList> LoginUserEducationList { get; set; }
        //public List<EducationObjectCard> LoginUserCardList { get; set; }
        private bool userIn = RegLogViewModelClass.StatusUser;
        private Visibility addBtnVisibility = Visibility.Hidden;
        public Visibility AddBtnVisibility { 
            get 
            {
                if (userIn) addBtnVisibility = Visibility.Visible;
                return addBtnVisibility;
            }
        }
        //add uid of the card
        private int cardUid;
        public int CardUid
        {
            get
            {
                return cardUid;
            }
            set
            {
                cardUid = value;
                OnPropertyChanged("CardUid");
            }
        }
        //command to add course or test to user list
        private RelayCommand addEducationObjectToUserList;
        public RelayCommand AddEducationObjectToUserList
        {
            get
            {
                return addEducationObjectToUserList ??
                    (addEducationObjectToUserList = new RelayCommand( obj =>
                    { 
                        using (ApplicationContext db = new ApplicationContext())
                        {
                            int cardId = Convert.ToInt32(obj);
                            UserEducationList selectedUserEducationObject = GetCardById(db, cardId);

                            if (selectedUserEducationObject == null)
                            {
                                UserEducationList newUserEducationObject = new UserEducationList();
                                newUserEducationObject.UserId = RegLogViewModelClass.LoginUser.Id;
                                //CardUid = Convert.ToInt32(obj);
                                EducationObject selectedEducationObject = db.EducationObjects.Find(cardId);
                                newUserEducationObject.EducationObjectId = selectedEducationObject.Id;
                                newUserEducationObject.Result = 0;
                                newUserEducationObject.Start = DateTime.Now;
                                //db.UserEducationLists.Add(newUserEducationObject);
                                db.Entry(newUserEducationObject).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                                db.SaveChanges();
                                //show attention message 
                                ShowUserMessage("Ready");
                            }
                            else 
                                ShowUserMessage("It's already on your list");
                        }
                    }));
            }
        }
        private RelayCommand removeEducationObjectFromUserList;
        public RelayCommand RemoveEducationObjectFromUserList
        {
            get
            {
                return removeEducationObjectFromUserList ??
                    (removeEducationObjectFromUserList = new RelayCommand(obj =>
                    {
                        using (ApplicationContext db = new ApplicationContext())
                        {
                            //het card 
                            int cardId = Convert.ToInt32(obj);
                            UserEducationList selectedUserEducationObject = GetCardById(db, cardId);

                            if (selectedUserEducationObject != null)
                            {
                                //db.UserEducationLists.Remove(selectedUserEducationObject);
                                db.Entry(selectedUserEducationObject).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                                db.SaveChanges();
                                //update the UI MainFrame                                
                                MainWindow.MainFrame.Navigate(new VoidPageUpdater());
                                MainWindow.MainFrame.Navigate(new AllUserEducationList());
                                //show message
                                ShowUserMessage("Ready");
                            }
                        }
                    }));
            }
        }
        public UserActionViewModelClass()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //get all added objects by user
                if(RegLogViewModelClass.StatusUser)
                    LoginUserEducationList = (from userEducationList in db.UserEducationLists
                                          where userEducationList.UserId == RegLogViewModelClass.LoginUser.Id 
                                          select userEducationList).ToList();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        private void ShowUserMessage(string text)
        {
            AttentionWindow attention = new AttentionWindow(text);
        }
        private UserEducationList GetCardById(ApplicationContext db, int id)
        {
            return (from userEducationList in db.UserEducationLists
                    where userEducationList.EducationObjectId == id
                    select userEducationList).SingleOrDefault();
        }
    }
}
