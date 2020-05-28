using Moviemap.Common.Models;
using Moviemap.Common.Services;
using Moviemap.Prism.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Moviemap.Prism.ViewModels
{
    public class CinemaMoviesPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ObservableCollection<CinemaMoviesItemViewModel> _movies;
        private CinemaResponse _cinema;
        private bool _isRunning;
        private bool _isEnable;

        public CinemaMoviesPageViewModel(INavigationService navigationService, IApiService apiService)
            : base(navigationService)
        {
            Title = "Movies";
            _navigationService = navigationService;
            _apiService = apiService;
        }

        public bool IsEnable
        {
            get => _isEnable;
            set => SetProperty(ref _isEnable, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public CinemaResponse Cinema
        {
            get => _cinema;
            set => SetProperty(ref _cinema, value);
        }
        public List<CinemaMoviesItemViewModel> MoviesList { get; set; }

        public ObservableCollection<CinemaMoviesItemViewModel> Movies
        {
            get => _movies;
            set => SetProperty(ref _movies, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if(parameters.Count != 0)
            {
                base.OnNavigatedTo(parameters);
                Cinema = parameters.GetValue<CinemaResponse>("cinema");
                Title = Cinema.Name;
                LoadCinemaMoviesAsync();
            }
        }

        private async void LoadCinemaMoviesAsync()
        {
            IsRunning = true;
            IsEnable = false;
            string url = App.Current.Resources["UrlAPI"].ToString();
            bool connection = await _apiService.CheckConnectionAsync(url);
            if (!connection)
            {
                IsRunning = true;
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.ConnectionError, Languages.Accept);
                return;
            }
            var id = Cinema.Id;
            CinemaMoviesRequest request = new CinemaMoviesRequest
            {
                CinemaId = Cinema.Id,
                CultureInfo = Languages.Culture
            };

            Response response = await _apiService.GetCinemaMoviesAsync<CinemaMoviesRequest>(
            url, "/api", "/Movie/GetCinemaMovies", request);
            IsRunning = false;
            IsEnable = true;
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                IsRunning = false;
                IsEnable = true;
                return;
            }
            List<MovieResponse> movies = (List<MovieResponse>)response.Result;
            MoviesList = movies.Select(m => new CinemaMoviesItemViewModel(_navigationService)
            {
                Id = m.Id,
                Description = m.Description,
                LogoPath = m.LogoPath,
                Duration = m.Duration,
                TrailerUrl = m.TrailerUrl,
                Name = m.Name,
                Hours = m.Hours
            }).ToList();
            Movies = new ObservableCollection<CinemaMoviesItemViewModel>(MoviesList.OrderBy(t => t.Name));
        }
    }
}