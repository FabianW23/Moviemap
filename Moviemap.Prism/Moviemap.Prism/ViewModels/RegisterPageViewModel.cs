using Moviemap.Common.Helpers;
using Moviemap.Common.Models;
using Moviemap.Common.Services;
using Moviemap.Prism.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Prism.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IRegexHelper _regexHelper;
        private readonly IApiService _apiService;
        private UserRequest _user;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _registerCommand;

        public RegisterPageViewModel(
            INavigationService navigationService,
            IRegexHelper regexHelper,
            IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _regexHelper = regexHelper;
            _apiService = apiService;
            Title = Languages.Register;
            IsEnabled = true;
            User = new UserRequest();
        }

        //public DelegateCommand RegisterCommand => _registerCommand ?? (_registerCommand = new DelegateCommand(RegisterAsync));

        public UserRequest User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        
    }
}
