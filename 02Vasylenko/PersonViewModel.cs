using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _02Vasylenko
{
    public class PersonViewModel : INotifyPropertyChanged
    {
    
        private readonly Person domObject;
        private readonly PersonManager PersonManager;
        private readonly ObservableCollection<Person> _Persons;
        public PersonViewModel()
        {
            domObject = new Person();
            PersonManager = new PersonManager();
            _Persons = new ObservableCollection<Person>();
            AddPersonCmd = new RelayCommand(Add);
        }
        public string LastName
        {
            get { return domObject.LastName; }
            set
            {
                domObject.LastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string Name
        {
            get { return domObject.Name; }
            set
            {
                domObject.Name = value;
                OnPropertyChanged("Name");
            }
        }
       public string Email
        {
            get { return domObject.Email; }
            set
            {
                domObject.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public DateTime DateOfBirth
        {
            get { return domObject.DateOfBirth; }
            set
            {
                domObject.DateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }
        public bool IsAdult
        {
            get { return domObject.IsAdult; }
        }
        public string SunSign
        {
            get { return domObject.SunSign; }
        }
        public string ChineseSign
        {
            get { return domObject.ChineseSign; }
        }
        public bool IsBirthday
        {
            get { return domObject.IsBirthday; }
        }

        public ObservableCollection<Person> Persons { get { return _Persons; } }
        public ICommand AddPersonCmd { get; }


        public void Add(object obj)
        {
            var person = new Person {LastName = LastName, Name = Name, Email = Email, DateOfBirth = DateOfBirth};
            if (PersonManager.Add(person))
            {
                Persons.Add(person);
                ResetPerson();
                MessageBox.Show("Person Add Successful !");
            }
            else
                MessageBox.Show("Person with this ID already exists !");
        }

   
        private void ResetPerson()
        {
            LastName = string.Empty;
            Name = string.Empty;
            Email = string.Empty;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
