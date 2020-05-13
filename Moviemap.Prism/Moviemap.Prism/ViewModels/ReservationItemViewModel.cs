using Moviemap.Common.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moviemap.Prism.ViewModels
{
    public class ReservationItemViewModel : ReservationResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _SelectReservationCommand;

        public ReservationItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectReservationCommand => _SelectReservationCommand ??
            (_SelectReservationCommand = new DelegateCommand(SelectReservationAsync));

        private async void SelectReservationAsync()
        {
            NavigationParameters parameters = new NavigationParameters
            {
                { "reservation", this }
            };

            await _navigationService.NavigateAsync("ReservationPage", parameters);
        }
    }
}
