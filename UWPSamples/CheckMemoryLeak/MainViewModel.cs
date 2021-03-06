﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CheckMemoryLeak
{
    public class MainViewModel : INotifyPropertyChanged, INavigable
    {
        private PersonViewModel _selectedPerson;
        private List<PersonViewModel> _personList;//{ get; set; }

        public List<PersonViewModel> PersonList
        {
            get
            {
                return _personList;
            }
            set
            {
                _personList = value;
                OnPropertyChanged();
            }
        }

        public PersonViewModel SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                _selectedPerson = value;
                OnPropertyChanged();
                NavigateEvent(this, new NavigationEventArgs
                {
                    PageName = "CheckMemoryLeak.SecondPage",
                    Parameter = new PersonViewModel { Name = _selectedPerson.Name, Age = _selectedPerson.Age }
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<NavigationEventArgs> NavigateEvent;
        public event EventHandler GoBackEvent;

        public MainViewModel()
        {
            PersonList = new List<PersonViewModel>
            {
                new PersonViewModel {  Name = "张三" , Age = 20 },
                new PersonViewModel {  Name = "李四" , Age = 30 },
                new PersonViewModel {  Name = "王五" , Age = 40 },
                new PersonViewModel {  Name = "赵六" , Age = 50 }
            };
        }

        private void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void OnNavigatedTo(object obj)
        {
        }

        public void OnNavigatedFrom(object obj)
        {
            
        }
    }
}
