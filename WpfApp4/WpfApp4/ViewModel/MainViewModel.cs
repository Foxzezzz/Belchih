using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using ChemistryIS.Models;
using ChemistryIS.Services;
using ChemistryIS.Views;

namespace ChemistryIS.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _dbService;

        public ObservableCollection<Topic> Topics { get; set; }
        public Topic SelectedTopic { get; set; }

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set { _searchQuery = value; OnPropertyChanged(); }
        }

        private ChemicalElement _foundElement;
        public ChemicalElement FoundElement
        {
            get => _foundElement;
            set { _foundElement = value; OnPropertyChanged(); }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public ICommand LoadTopicsCommand { get; }
        public ICommand SearchElementCommand { get; }
        public ICommand OpenPeriodicTableCommand { get; }

        public MainViewModel()
        {
            _dbService = new DatabaseService();
            Topics = new ObservableCollection<Topic>();

            LoadTopicsCommand = new RelayCommand(_ => LoadData());
            SearchElementCommand = new RelayCommand(_ => SearchElement());
            OpenPeriodicTableCommand = new RelayCommand(_ => OpenPeriodicTable());

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var data = _dbService.GetAllTopics();
                Topics.Clear();
                foreach (var t in data) Topics.Add(t);

                if (Topics.Count > 0) SelectedTopic = Topics[0];

                OnPropertyChanged(nameof(Topics));
                OnPropertyChanged(nameof(SelectedTopic));
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Ошибка подключения к БД: {ex.Message}";
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        private void SearchElement()
        {
            ErrorMessage = null;
            FoundElement = null;
            OnPropertyChanged(nameof(ErrorMessage));
            OnPropertyChanged(nameof(FoundElement));

            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                ErrorMessage = "Введите название, символ или номер элемента.";
                OnPropertyChanged(nameof(ErrorMessage));
                return;
            }

            var result = _dbService.FindElement(SearchQuery);

            if (result.IsNotFound)
            {
                ErrorMessage = $"Элемент '{SearchQuery}' не найден в базе данных.";
            }
            else
            {
                FoundElement = result;
            }

            OnPropertyChanged(nameof(ErrorMessage));
            OnPropertyChanged(nameof(FoundElement));
        }

        private void OpenPeriodicTable()
        {
            var tableViewModel = new PeriodicTableViewModel();

            var tableWindow = new PeriodicTableWindow();

            tableWindow.DataContext = tableViewModel;

            tableWindow.Owner = Application.Current.MainWindow;
            tableWindow.ShowDialog();
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}