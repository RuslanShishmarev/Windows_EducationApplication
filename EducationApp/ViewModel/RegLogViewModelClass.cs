using EducationApp.Model;
using EducationApp.View;
using EducationApp.View.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace EducationApp.ViewModel
{
    class RegLogViewModelClass : INotifyPropertyChanged
    {
        public List<User> Users { get; set; }
        public static User LoginUser { get; set; }
        public string FirstNameUser { get; set; }
        public string LastNameUser { get; set; }
        public byte[] PhotoUser { get; set; }
        public string EmailUser { get; set; }
        public string PasswordUser { get; set; }
        public string PasswordUserCheck { get; set; }
        public string NewPasswordUser { get; set; }
        public static string Password { get; set; }
        public static bool StatusUser { get; set; }

        private SolidColorBrush borderColorLoginError = Brushes.Black;
        public SolidColorBrush BorderColorLoginError
        {
            get
            {
                return borderColorPassError;
            }
            set
            {
                borderColorPassError = value;
                OnPropertyChanged("BorderColorLoginError");
            }
        }

        private SolidColorBrush borderColorPassError = Brushes.Black;
        public SolidColorBrush BorderColorPassError 
        {
            get
            {
                return borderColorPassError;
            }
            set
            {
                borderColorPassError = value;
                OnPropertyChanged("BorderColorPassError");
            }
        }
        
        //command to login
        private RelayCommand loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ??
                    (loginCommand = new RelayCommand(obj =>
                    {
                        using (ApplicationContext db = new ApplicationContext())
                        {
                            //check email for existing
                            try
                            {
                                //get user by email
                                var userLogin = (from user in db.Users where user.Email == EmailUser select user).First();
                                //check password
                                PasswordUser = Password;
                                if (userLogin.Password == PasswordUser)
                                {
                                    userLogin.Active = StatusUser = true;
                                    LoginUser = userLogin;
                                    BorderColorLoginError = Brushes.ForestGreen;
                                    MainWindow.UserStatus = StatusUser;
                                    ShowUserMessage("You in!");
                                    //MessageBox.Show("You in!");
                                    //show logout button
                                    MainWindow.CloseButton.Visibility = Visibility.Visible;
                                    //redirect to profile
                                    MainWindow.MainFrame.Navigate(new UserProfilePage());
                                }
                                else
                                {
                                    BorderColorLoginError = Brushes.Red;
                                    ShowUserMessage("Password is not correct!");
                                    //MessageBox.Show("Password is not correct!");
                                }
                            }
                            catch(InvalidOperationException)
                            {
                                BorderColorLoginError = Brushes.Red;
                                ShowUserMessage("This user is not in base!");
                                //MessageBox.Show("This user is not in base!");
                            }
                        }
                    }));
            }
        }

        //command to registration
        private RelayCommand regCommand;
        public RelayCommand RegCommand
        {
            get
            {
                return regCommand ??
                (regCommand = new RelayCommand(obj =>
                {
                    if (IsDataCorrect() == true && PasswordUser == PasswordUserCheck)
                    {
                        using (ApplicationContext db = new ApplicationContext())
                        {
                            //create new User object
                            User newUser = new User()
                            {
                                FirstName = FirstNameUser,
                                LastName = LastNameUser,
                                Email = EmailUser,
                                Password = PasswordUser,
                                Photo = PhotoUser,
                                Created = DateTime.Now,
                                Active = true
                            };
                            //add to User list and data base
                            Users.Add(newUser);
                            db.Users.Add(newUser);
                            db.SaveChanges();
                            ShowUserMessage("Ready!");
                            //MessageBox.Show("Ready!");
                            //redirect to login page
                            //close window
                        }
                    }
                    else
                    {
                        BorderColorPassError = Brushes.Red;
                        ShowUserMessage("Password error");
                    }
                }));
            }
        }
        //command to logout
        private RelayCommand logoutCommand;
        public RelayCommand LogoutCommand
        {
            get
            {
                return logoutCommand ?? 
                    (logoutCommand = new RelayCommand(obj =>
                    {
                        MessageBoxResult userDecision = MessageBox.Show("Are you sure?", "EXIT", MessageBoxButton.YesNo);
                        if (userDecision == MessageBoxResult.Yes)
                        {
                            LoginUser.Active = false;
                            LoginUser = null;
                            StatusUser = false;
                            //redirect to login page
                            MainWindow.MainFrame.Navigate(new LoginRegistrationPage());
                            MainWindow.UserStatus = StatusUser;
                            //hide the close button
                            MainWindow.CloseButton.Visibility = Visibility.Hidden;
                        }
                    }));
            }
        }
        private RelayCommand changeUserData;
        public RelayCommand ChangeUserData
        {
            get
            {
                return changeUserData ??
                (changeUserData = new RelayCommand(obj =>
                {
                    if (PasswordUser == LoginUser.Password)
                    {
                        using (ApplicationContext db = new ApplicationContext())
                        {
                            MessageBoxResult userDecision = MessageBox.Show("Are you sure?", "CHANGE DATA", MessageBoxButton.YesNo);
                            if (userDecision == MessageBoxResult.Yes)
                            {
                                //get login user from database
                                User loginUser = db.Users.Find(LoginUser.Id);
                                if (FirstNameUser != null)
                                    loginUser.FirstName = FirstNameUser;
                                if (LastNameUser != null)
                                    loginUser.LastName = LastNameUser;
                                if (EmailUser != null)
                                    loginUser.Email = EmailUser;
                                if (NewPasswordUser != null)
                                    loginUser.Password = NewPasswordUser;
                                LoginUser = loginUser;

                                db.SaveChanges();
                                ShowUserMessage("Ready!");
                                //MessageBox.Show("Ready!");
                                //go to profile
                                MainWindow.MainFrame.Navigate(new UserProfilePage());
                            }
                        }
                    }
                    else
                    {
                        //show error message
                        BorderColorPassError = Brushes.Red;
                        ShowUserMessage("Password error");
                    }
                }));
            }
        }
        public RegLogViewModelClass()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Users = db.Users.ToList();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        private bool IsDataCorrect()
        {
            if (FirstNameUser != null &&
                LastNameUser != null &&
                EmailUser != null &&
                PasswordUser != null &&
                PasswordUserCheck != null)
                return true;
            else return false;
        }
        private void ShowUserMessage(string text)
        {
            AttentionWindow attention = new AttentionWindow(text);
        }
    }
}

