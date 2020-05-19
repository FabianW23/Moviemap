using Moviemap.Common.Models;
using Moviemap.Common.Services;
using Moviemap.Prism.Helpers;
using Moviemap.Prism.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms.Maps;

namespace Moviemap.Prism.ViewModels
{
    public class MapPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private List<CinemaResponse> _Cinemas;
        private bool _isRunning;
        private bool _isEnable;

        public MapPageViewModel(INavigationService navigationService, IApiService apiService)
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

        public List<CinemaResponse> Cinemas
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
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.ConnectionError, Languages.Accept);
                return;
            }

            Response response = await _apiService.GetListAsync<CinemaResponse>(
            url, "/api", "/Cinema/GetCinemas");
            IsRunning = false;
            IsEnable = true;
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                IsRunning = false;
                IsEnable = true;
                return;
            }
            Cinemas = (List<CinemaResponse>)response.Result;
            MapPage.GetInstance().DrawPins(Cinemas);
        }
    }
}
