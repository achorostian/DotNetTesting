using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private IWebApiService _apiService;
        private IDialogBoxService _dialogService;

        private List<Person> _persons { get; set; }
        public List<Person> Persons { get { return _persons; } set { _persons = value; OnPropertyChanged("Persons"); } }

        private string _name { get; set; }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        private string _surname { get; set; }
        public string Surname { get { return _surname; } set { _surname = value; OnPropertyChanged("Surname"); } }
        private int _age { get; set; } = 18;
        public int Age { get { return _age; } set { _age = value; OnPropertyChanged("Age"); } }

        public MainWindowViewModel()
        {
            _apiService = new WebApiService();
            _dialogService = new DialogBoxService();
            Persons = new List<Person>();
        }

        public MainWindowViewModel(IWebApiService service)
        {
            _apiService = service;
            _dialogService = new DialogBoxService();
            Persons = new List<Person>();
        }

        public MainWindowViewModel(IDialogBoxService service)
        {
            _apiService = new WebApiService();
            _dialogService = service;
            Persons = new List<Person>();
        }

        public ICommand AddPerson { get { return new RelayCommand(AddPersonExecute, CanAddPerson); } }
        public ICommand DeletePerson { get { return new RelayCommand(DeletePersonExecute, CanDeletePerson); } }
        public ICommand FeedPerson { get { return new RelayCommand(FeedPersonExecute, () => true); } }

        private void AddPersonExecute()
        {
            var temp = new List<Person>(Persons);
            temp.Add(new Person
            {
                Name = Name,
                Surname = Surname,
                Age = Age
            });

            Persons = temp;
            //MessageBox.Show($"About to add {Name} {Surname} of age {Age}!");
        }
        private bool CanAddPerson() => Persons.Count < 5;

        private void DeletePersonExecute()
        {
            if (!_dialogService.AreYouSureQuestion($"Deletion of {Name} {Surname} will proceed."))
                return;

            var temp = new List<Person>(Persons);
            temp.RemoveAll(person => person.Name == Name && person.Surname == Surname && person.Age == Age);

            Persons = temp;
            //MessageBox.Show($"About to delete {Name} {Surname} of age {Age}!");
        }
        private bool CanDeletePerson() => Persons.Count > 0;

        private async void FeedPersonExecute()
        {
            Persons = await _apiService?.GetPeopleAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
