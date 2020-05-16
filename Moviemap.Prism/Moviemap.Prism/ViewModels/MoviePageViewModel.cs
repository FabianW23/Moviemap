using Moviemap.Common.Models;
using Moviemap.Common.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Prism.ViewModels
{
    public class MoviePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<DateTime> _dates;
        private ObservableCollection<DateTime> _hours;
        private DelegateCommand _registerCommand;
        private DelegateCommand _changeDateCommand;
        private DateTime _selectedHour;
        private DateTime _selectedDate;
        private MovieResponse _movie;
        private readonly IApiService _apiService;


        public MoviePageViewModel(INavigationService navigationService, IApiService apiService)
            : base(navigationService)
        {
            Title = "Black";
            _navigationService = navigationService;
            _apiService = apiService;
        }

        public DelegateCommand ReservationCommand => _registerCommand ?? (_registerCommand = new DelegateCommand(RegisterAsync));

        public DelegateCommand ChangeDateCommand => _changeDateCommand ?? (_changeDateCommand = new DelegateCommand(ChangeDateAsync));

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value);
        }

        public DateTime SelectedHour
        {
            get => _selectedHour;
            set => SetProperty(ref _selectedHour, value);
        }

        public MovieResponse Movie
        {
            get => _movie;
            set => SetProperty(ref _movie, value);
        }

        public ObservableCollection<DateTime> MDates
        {
            get => _dates;
            set => SetProperty(ref _dates, value);
        }

        public ObservableCollection<DateTime> MHours
        {
            get => _hours;
            set => SetProperty(ref _hours, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Movie = parameters.GetValue<MovieResponse>("movie");
            Title = Movie.Name;
            LoadDate();
            LoadHours(new DateTime(2020, 4, 29));
        }

        private async void RegisterAsync()
        {
            HourResponse algo = Movie.Hours.Single(h => h.StartDate == SelectedHour);
            await _navigationService.NavigateAsync("ChooseChairspage");
        }

        private void ChangeDateAsync()
        {
            LoadDate();
            LoadHours(SelectedDate);
        }

        private void LoadHours(DateTime date)
        {
            List<DateTime> list = new List<DateTime>();
            list = Movie.Hours.Select(h => h.StartDate).Where(h => h.Date == date).ToList();
            MHours = new ObservableCollection<DateTime>(list);
        }

        private void LoadDate()
        {
            List<DateTime> list = new List<DateTime>();
            list = Movie.Hours.Select(h => h.StartDate.Date).Distinct().ToList();
            
            MDates = new ObservableCollection<DateTime>(list.Select(d => d.Date));
        }

    }
}
