using Moviemap.Common.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Moviemap.Prism.ViewModels
{
    public class ChooseChairspageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;

        public ChooseChairspageViewModel(INavigationService navigationService, IApiService apiService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
        }
    }
}
