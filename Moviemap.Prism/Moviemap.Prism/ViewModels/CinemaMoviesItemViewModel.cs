using Moviemap.Common.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moviemap.Prism.ViewModels
{
    public class CinemaMoviesItemViewModel : MovieResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _SelectMovieCommand;

        public CinemaMoviesItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectMovieCommand => _SelectMovieCommand ??
            (_SelectMovieCommand = new DelegateCommand(SelectMovieAsync));

        private async void SelectMovieAsync()
        {
            NavigationParameters parameters = new NavigationParameters
            {
                { "movie", this }
            };

            await _navigationService.NavigateAsync("MoviePage", parameters);
        }
    }
}
