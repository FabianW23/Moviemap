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
    public class MoviePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;

        public MoviePageViewModel(INavigationService navigationService, IApiService apiService)
            : base(navigationService)
        {
            Title = "Black";
            _navigationService = navigationService;
            _apiService = apiService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var movie = parameters.GetValue<MovieResponse>("movie");
        }
    }
}
