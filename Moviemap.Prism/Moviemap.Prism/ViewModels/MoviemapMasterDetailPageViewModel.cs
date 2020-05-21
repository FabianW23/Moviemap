using Moviemap.Common.Helpers;
using Moviemap.Common.Models;
using Moviemap.Common.Services;
using Moviemap.Prism.Helpers;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Moviemap.Prism.ViewModels
{
    public class MoviemapMasterDetailPageViewModel : ViewModelBase
    {
        private static MoviemapMasterDetailPageViewModel _instance;
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private UserResponse _user;
        public MoviemapMasterDetailPageViewModel(INavigationService navigationService, IApiService apiService)
            : base(navigationService)
        {
            _instance = this;
            _navigationService = navigationService;
            _apiService = apiService;
            LoadUser();
            LoadMenus();
        }

        public static MoviemapMasterDetailPageViewModel GetInstance()
        {
            return _instance;
        }

        public UserResponse User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        private void LoadUser()
        {
            if (Settings.IsLogin)
            {
                User = JsonConvert.DeserializeObject<UserResponse>(Settings.User);
            }
        }

        public async void ReloadUser()
        {
            string url = App.Current.Resources["UrlAPI"].ToString();
            bool connection = await _apiService.CheckConnectionAsync(url);
            if (!connection)
            {
                return;
            }

            UserResponse user = JsonConvert.DeserializeObject<UserResponse>(Settings.User);
            TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            EmailRequest emailRequest = new EmailRequest
            {
                CultureInfo = Languages.Culture,
                Email = user.Email
            };

            Response response = await _apiService.GetUserByEmail(url, "api", "/Account/GetUserByEmail", "bearer", token.Token, emailRequest);
            UserResponse userResponse = (UserResponse)response.Result;
            Settings.User = JsonConvert.SerializeObject(userResponse);
            LoadUser();
        }

        private void LoadMenus()
        {
            List<Menu> menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "CinemasIcon",
                    PageName = "CinemasPage",
                    Title = Languages.Cinemas
                },
                new Menu
                {
                    Icon = "ReservationIcon",
                    PageName = "MyReservationsPage",
                    Title = Languages.MyReservations
                },
                new Menu
                {
                    Icon = "AccountIcon",
                    PageName = "ModifyUserPage",
                    Title = Languages.ModifyUserMenu
                },
                new Menu
                {
                    Icon = "MapIcon",
                    PageName = "MapPage",
                    Title = Languages.Map
                },
                new Menu
                {
                    Icon = "LoginIcon",
                    PageName = "LoginPage",
                    Title = Settings.IsLogin ? Languages.LogOut : Languages.LogInMenu
                }
            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title
                }).ToList());
        }
    }
}
