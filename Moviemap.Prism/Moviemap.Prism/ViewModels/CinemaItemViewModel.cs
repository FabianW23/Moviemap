using Moviemap.Common.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moviemap.Prism.ViewModels
{
    public class CinemaItemViewModel : CinemaResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _SelectCinemaCommand;

        public CinemaItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectCinemaCommand => _SelectCinemaCommand ??
            (_SelectCinemaCommand = new DelegateCommand(SelectCinemaAsync));

        private async void SelectCinemaAsync()
        {
            NavigationParameters parameters = new NavigationParameters
            {
                { "cinema", this }
            };

            await _navigationService.NavigateAsync("CinemaMoviesPage", parameters);
        }
    }
}
