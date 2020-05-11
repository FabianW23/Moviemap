using Moviemap.Common.Models;
using Moviemap.Common.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Moviemap.Prism.ViewModels
{
    public class CinemasPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private List<CinemaItemViewModel> _Cinemas;
        private bool _isRunning;
        private bool _isEnable;

        public CinemasPageViewModel(INavigationService navigationService, IApiService apiService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            LoadCinemasAsync();
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

        public List<CinemaItemViewModel> Cinemas
        {
            get => _Cinemas;
            set => SetProperty(ref _Cinemas, value);
        }

        private async void LoadCinemasAsync()
        {
            IsRunning = true;
            IsEnable = false;
            string url = App.Current.Resources["UrlAPI"].ToString();
            bool connection = await _apiService.CheckConnectionAsync(url);
            if (!connection)
            {
                IsRunning = true;
                await App.Current.MainPage.DisplayAlert("Languages.Error", "Languages.ConnectionError", "Languages.Accept");
                return;
            }

            Response response = await _apiService.GetListAsync<CinemaResponse>(
            url, "/api", "/Cinema/GetCinemas");
            IsRunning = false;
            IsEnable = true;
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Languages.Error", response.Message, "Languages.Accept");
                IsRunning = false;
                IsEnable = true;
                return;
            }
            var cinemas = (List<CinemaResponse>)response.Result;
            Cinemas = cinemas.Select(c => new CinemaItemViewModel(_navigationService)
            {
                Id = c.Id,
                Name = c.Name,
                Latitude = c.Latitude,
                Longitude = c.Longitude,
                Brand = c.Brand,
                User = c.User
            }).ToList();
            
        }
    }
}
