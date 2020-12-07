using System.ComponentModel;
using System.Runtime.CompilerServices;
using EducationApp.Model;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using EducationApp.View.Cards;

namespace EducationApp.ViewModel
{
    enum EducationType
    {
        Course,
        Test
    }
    class AppViewModelClass : INotifyPropertyChanged
    {
        public List<EducationObject> EducationObjects { get; set; }
        public List<EducationObjectCard> EducationObjectCards { get; set; }
        public string NameObject { get; set; }
        public string TopicObject { get; set; }
        public string DescriptionObject { get; set; }
        private int levelObject;
        public int LevelObject 
        { 
            get { return levelObject; }
            set
            {
                levelObject = value;
                OnPropertyChanged("LevelObject");
                OnPropertyChanged("IsZeroLevel");
            } 
        }
        //get level for education object
        public bool IsZeroLevel
        {
            get { return LevelObject == 0; }
            set { LevelObject = value ? 0 : LevelObject; }
        }
        public bool IsOneLevel
        {
            get { return LevelObject == 1; }
            set { LevelObject = value ? 1 : LevelObject; }
        }
        public bool IsTwoLevel
        {
            get { return LevelObject == 2; }
            set { LevelObject = value ? 2 : LevelObject; }
        }
        public bool IsThreeLevel
        {
            get { return LevelObject == 3; }
            set { LevelObject = value ? 3 : LevelObject; }
        }
        public bool IsFourLevel
        {
            get { return LevelObject == 4; }
            set { LevelObject = value ? 4 : LevelObject; }
        }
        public bool IsFiveLevel
        {
            get { return LevelObject == 5; }
            set { LevelObject = value ? 5 : LevelObject; }
        }
        //------------------------------------------------------------------------

        //get value of education object's type
        EducationType educationTypeValue;
        public EducationType EducationTypeValue
        {
            get { return educationTypeValue; }
            set
            {
                educationTypeValue = value;
                OnPropertyChanged("EducationTypeValue");
                OnPropertyChanged("IsEducationCourse");
                OnPropertyChanged("IsEducationTest");
            }
        }
        public bool IsEducationCourse
        {
            get { return EducationTypeValue == EducationType.Course; }
            set { EducationTypeValue = value ? EducationType.Course : EducationTypeValue; }
        }
        public bool IsEducationTest
        {
            get { return EducationTypeValue == EducationType.Test; }
            set { EducationTypeValue = value ? EducationType.Test : EducationTypeValue; }
        }
        // команда добавления нового объекта
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      using (ApplicationContext db = new ApplicationContext())
                      {
                          //create new education object
                          EducationObject educationObject = new EducationObject
                          {
                              Level = LevelObject,
                              Name = NameObject,
                              Description = DescriptionObject,
                              Topic = TopicObject,
                              Type = EducationTypeValue.ToString(),
                              Author = RegLogViewModelClass.LoginUser
                          };
                          //add to list
                          EducationObjects.Insert(0, educationObject);
                          //add to database
                          db.Add(educationObject);
                          db.SaveChanges();
                          MessageBox.Show("Ready!");
                      }
                  }));
            }
        }
        public AppViewModelClass()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                EducationObjects = db.EducationObjects.ToList();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
