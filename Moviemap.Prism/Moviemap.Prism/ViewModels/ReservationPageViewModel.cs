using Moviemap.Common.Models;
using Moviemap.Prism.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Moviemap.Prism.ViewModels
{
    public class ReservationPageViewModel :ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ReservationResponse _reservation;
        private string _chairs;

        public ReservationPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.Reservation;
            _navigationService = navigationService;
        }

        public ReservationResponse Reservation
        {
            get => _reservation;
            set => SetProperty(ref _reservation, value);
        }

        public string Chairs
        {
            get => _chairs;
            set => SetProperty(ref _chairs, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Reservation = parameters.GetValue<ReservationResponse>("reservation");
            Chairs = string.Join(", ", Reservation.ReservationChairs.Select(p => p.Chair.Name));
        }
    }
}
