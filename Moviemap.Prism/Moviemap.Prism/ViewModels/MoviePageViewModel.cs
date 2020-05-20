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
        private ObservableCollection<MyDate> _dates;
        private ObservableCollection<MyHour> _hours;
        private DelegateCommand _registerCommand;
        private DelegateCommand _changeDateCommand;
        private MyHour _selectedHour;
        private MyDate _selectedDate;
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

        public MyDate SelectedDate
        {
            get => _selectedDate;
            set
            { 
                SetProperty(ref _selectedDate, value);
                DoAny();
            }
        }

        private void DoAny()
        {
            if(SelectedDate.Date == null || SelectedDate.Date == DateTime.MinValue)
            {
                return;
            }
            else
            {
                LoadHours(SelectedDate.Date);
            }
        }

        public MyHour SelectedHour
        {
            get => _selectedHour;
            set => SetProperty(ref _selectedHour, value);
        }

        public MovieResponse Movie
        {
            get => _movie;
            set => SetProperty(ref _movie, value);
        }

        public ObservableCollection<MyDate> MDates
        {
            get => _dates;
            set => SetProperty(ref _dates, value);
        }

        public ObservableCollection<MyHour> MHours
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
            LoadHours(SelectedDate.Date);
        }

        private async void RegisterAsync()
        {
            HourResponse algo = Movie.Hours.Single(h => h.StartDate == SelectedHour.HourOfDate);
            NavigationParameters parameters = new NavigationParameters
            {
                { "hour", algo }
            };
            await _navigationService.NavigateAsync("ChooseChairspage", parameters);
        }

        private void ChangeDateAsync()
        {
            LoadDate();
            LoadHours(SelectedDate.Date);
        }

        private void LoadHours(DateTime date)
        {
            List<DateTime> list = new List<DateTime>();
            list = Movie.Hours.Select(h => h.StartDate).Where(h => h.Date == date).ToList();
            MHours = new ObservableCollection<MyHour>(list.Select(d => new MyHour
            {
                HourOfDate = d
            }).ToList());
        }

        private void LoadDate()
        {
            List<DateTime> list = new List<DateTime>();
            list = Movie.Hours.Select(h => h.StartDate.Date).Distinct().ToList();
            MDates = new ObservableCollection<MyDate>(list.Select(d => new MyDate { 
                Date = d.Date
            }).ToList());
            SelectedDate = MDates.First();
        }

    }
}
