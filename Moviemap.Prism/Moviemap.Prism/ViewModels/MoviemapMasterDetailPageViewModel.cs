using Moviemap.Common.Models;
using Moviemap.Common.Services;
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

        
    }
}
