using Moviemap.Common.Helpers;
using Moviemap.Common.Models;
using Moviemap.Common.Services;
using Moviemap.Prism.Helpers;
using Newtonsoft.Json;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Moviemap.Prism.ViewModels
{
    public class MyReservationsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private List<ReservationItemViewModel> _Trips;
        private bool _isRunning;
        private bool _isEnable;
        private string _statusC;

        public MyReservationsPageViewModel(INavigationService navigationService, IApiService apiService)
            : base(navigationService)
        {
            Title = Languages.MyReservations;
            _navigationService = navigationService;
            _apiService = apiService;
            LoadMyReservationsAsync();
        }

        public string StatusC
        {
            get => _statusC;
            set => SetProperty(ref _statusC, value);
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

        public List<ReservationItemViewModel> Reservations
        {
            get => _Trips;
            set => SetProperty(ref _Trips, value);
        }
        private async void LoadMyReservationsAsync()
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
            if (Settings.IsLogin == true)
            {
                TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
                UserResponse user = JsonConvert.DeserializeObject<UserResponse>(Settings.User);

                ReservationRequest request = new ReservationRequest
                {
                    UserId = Guid.Parse(user.Id),
                    CultureInfo = Languages.Culture
                };

                Response response = await _apiService.GetListAsync<ReservationRequest>(
                url, "/api", "/Reservation/GetUserReservations", "bearer", token.Token, request);
                IsRunning = false;
                IsEnable = true;
                if (!response.IsSuccess)
                {
                    await App.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                    IsRunning = false;
                    IsEnable = true;
                    return;
                }
                List<ReservationResponse> reservations = (List<ReservationResponse>)response.Result;
                
                Reservations = reservations.Select(r => new ReservationItemViewModel(_navigationService)
                {
                    Id = r.Id,
                    Hour = r.Hour,
                    Status = r.Status,
                    ReservationChairs = r.ReservationChairs,
                }).ToList();
                //string.Format(Languages.StatusC, r.Status);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.LogInRequired, Languages.Accept);
            }
        }
    }
}
