
using ImTools;
using Moviemap.Common.Emuns;
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
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Moviemap.Prism.ViewModels
{
    public class ChooseChairspageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ObservableCollection<string> _chairChips;
        private DelegateCommand _confirmReservationCommand;
        private List<ChairResponse> SelectedChairs;
        private RoomResponse _room;
        private HourResponse _hour;
        private decimal _total;

        private DelegateCommand _SelectChairCommand00;
        private DelegateCommand _SelectChairCommand10;
        private DelegateCommand _SelectChairCommand20;
        private DelegateCommand _SelectChairCommand30;
        private DelegateCommand _SelectChairCommand40;
        private DelegateCommand _SelectChairCommand50;
        private DelegateCommand _SelectChairCommand60;
        private DelegateCommand _SelectChairCommand70;

        private DelegateCommand _SelectChairCommand01;
        private DelegateCommand _SelectChairCommand11;
        private DelegateCommand _SelectChairCommand21;
        private DelegateCommand _SelectChairCommand31;
        private DelegateCommand _SelectChairCommand41;
        private DelegateCommand _SelectChairCommand51;
        private DelegateCommand _SelectChairCommand61;
        private DelegateCommand _SelectChairCommand71;

        private DelegateCommand _SelectChairCommand02;
        private DelegateCommand _SelectChairCommand12;
        private DelegateCommand _SelectChairCommand22;
        private DelegateCommand _SelectChairCommand32;
        private DelegateCommand _SelectChairCommand42;
        private DelegateCommand _SelectChairCommand52;
        private DelegateCommand _SelectChairCommand62;
        private DelegateCommand _SelectChairCommand72;

        private DelegateCommand _SelectChairCommand03;
        private DelegateCommand _SelectChairCommand13;
        private DelegateCommand _SelectChairCommand23;
        private DelegateCommand _SelectChairCommand33;
        private DelegateCommand _SelectChairCommand43;
        private DelegateCommand _SelectChairCommand53;
        private DelegateCommand _SelectChairCommand63;
        private DelegateCommand _SelectChairCommand73;

        private DelegateCommand _SelectChairCommand04;
        private DelegateCommand _SelectChairCommand14;
        private DelegateCommand _SelectChairCommand24;
        private DelegateCommand _SelectChairCommand34;
        private DelegateCommand _SelectChairCommand44;
        private DelegateCommand _SelectChairCommand54;
        private DelegateCommand _SelectChairCommand64;
        private DelegateCommand _SelectChairCommand74;
        private DelegateCommand _SelectChairCommand84;

        private ImageSource _chair00;
        private ImageSource _chair10;
        private ImageSource _chair20;
        private ImageSource _chair30;
        private ImageSource _chair40;
        private ImageSource _chair50;
        private ImageSource _chair60;
        private ImageSource _chair70;

        private ImageSource _chair01;
        private ImageSource _chair11;
        private ImageSource _chair21;
        private ImageSource _chair31;
        private ImageSource _chair41;
        private ImageSource _chair51;
        private ImageSource _chair61;
        private ImageSource _chair71;


        private ImageSource _chair02;
        private ImageSource _chair12;
        private ImageSource _chair22;
        private ImageSource _chair32;
        private ImageSource _chair42;
        private ImageSource _chair52;
        private ImageSource _chair62;
        private ImageSource _chair72;

        private ImageSource _chair03;
        private ImageSource _chair13;
        private ImageSource _chair23;
        private ImageSource _chair33;
        private ImageSource _chair43;
        private ImageSource _chair53;
        private ImageSource _chair63;
        private ImageSource _chair73;

        private ImageSource _chair04;
        private ImageSource _chair14;
        private ImageSource _chair24;
        private ImageSource _chair34;
        private ImageSource _chair44;
        private ImageSource _chair54;
        private ImageSource _chair64;
        private ImageSource _chair74;
        private ImageSource _chair84;

        private bool _isRunning;
        private bool _isEnable;


        public ChooseChairspageViewModel(INavigationService navigationService, IApiService apiService)
            : base(navigationService)
        {
            SelectedChairs = new List<ChairResponse>();
            _navigationService = navigationService;
            _apiService = apiService;
        }

        public DelegateCommand SelectedChair00 => _SelectChairCommand00 ?? (_SelectChairCommand00 = new DelegateCommand(SelectedChair00Async));

        public DelegateCommand SelectedChair10 => _SelectChairCommand10 ?? (_SelectChairCommand10 = new DelegateCommand(SelectedChair10Async));

        public DelegateCommand SelectedChair20 => _SelectChairCommand20 ?? (_SelectChairCommand20 = new DelegateCommand(SelectedChair20Async));

        public DelegateCommand SelectedChair30 => _SelectChairCommand30 ?? (_SelectChairCommand30 = new DelegateCommand(SelectedChair30Async));

        public DelegateCommand SelectedChair40 => _SelectChairCommand40 ?? (_SelectChairCommand40 = new DelegateCommand(SelectedChair40Async));

        public DelegateCommand SelectedChair50 => _SelectChairCommand50 ?? (_SelectChairCommand50 = new DelegateCommand(SelectedChair50Async));

        public DelegateCommand SelectedChair60 => _SelectChairCommand60 ?? (_SelectChairCommand60 = new DelegateCommand(SelectedChair60Async));

        public DelegateCommand SelectedChair70 => _SelectChairCommand70 ?? (_SelectChairCommand70 = new DelegateCommand(SelectedChair70Async));

        public DelegateCommand SelectedChair01 => _SelectChairCommand01 ?? (_SelectChairCommand01 = new DelegateCommand(SelectedChair01Async));

        public DelegateCommand SelectedChair11 => _SelectChairCommand11 ?? (_SelectChairCommand11 = new DelegateCommand(SelectedChair11Async));

        public DelegateCommand SelectedChair21 => _SelectChairCommand21 ?? (_SelectChairCommand21 = new DelegateCommand(SelectedChair21Async));

        public DelegateCommand SelectedChair31 => _SelectChairCommand31 ?? (_SelectChairCommand31 = new DelegateCommand(SelectedChair31Async));

        public DelegateCommand SelectedChair41 => _SelectChairCommand41 ?? (_SelectChairCommand41 = new DelegateCommand(SelectedChair41Async));

        public DelegateCommand SelectedChair51 => _SelectChairCommand51 ?? (_SelectChairCommand51 = new DelegateCommand(SelectedChair51Async));

        public DelegateCommand SelectedChair61 => _SelectChairCommand61 ?? (_SelectChairCommand61 = new DelegateCommand(SelectedChair61Async));

        public DelegateCommand SelectedChair71 => _SelectChairCommand71 ?? (_SelectChairCommand71 = new DelegateCommand(SelectedChair71Async));


        public DelegateCommand SelectedChair02 => _SelectChairCommand02 ?? (_SelectChairCommand02 = new DelegateCommand(SelectedChair02Async));

        public DelegateCommand SelectedChair12 => _SelectChairCommand12 ?? (_SelectChairCommand12 = new DelegateCommand(SelectedChair12Async));

        public DelegateCommand SelectedChair22 => _SelectChairCommand22 ?? (_SelectChairCommand22 = new DelegateCommand(SelectedChair22Async));

        public DelegateCommand SelectedChair32 => _SelectChairCommand32 ?? (_SelectChairCommand32 = new DelegateCommand(SelectedChair32Async));

        public DelegateCommand SelectedChair42 => _SelectChairCommand42 ?? (_SelectChairCommand42 = new DelegateCommand(SelectedChair42Async));

        public DelegateCommand SelectedChair52 => _SelectChairCommand52 ?? (_SelectChairCommand52 = new DelegateCommand(SelectedChair52Async));

        public DelegateCommand SelectedChair62 => _SelectChairCommand62 ?? (_SelectChairCommand62 = new DelegateCommand(SelectedChair62Async));

        public DelegateCommand SelectedChair72 => _SelectChairCommand72 ?? (_SelectChairCommand72 = new DelegateCommand(SelectedChair72Async));


        public DelegateCommand SelectedChair03 => _SelectChairCommand03 ?? (_SelectChairCommand03 = new DelegateCommand(SelectedChair03Async));

        public DelegateCommand SelectedChair13 => _SelectChairCommand13 ?? (_SelectChairCommand13 = new DelegateCommand(SelectedChair13Async));

        public DelegateCommand SelectedChair23 => _SelectChairCommand23 ?? (_SelectChairCommand23 = new DelegateCommand(SelectedChair23Async));

        public DelegateCommand SelectedChair33 => _SelectChairCommand33 ?? (_SelectChairCommand33 = new DelegateCommand(SelectedChair33Async));

        public DelegateCommand SelectedChair43 => _SelectChairCommand43 ?? (_SelectChairCommand43 = new DelegateCommand(SelectedChair43Async));

        public DelegateCommand SelectedChair53 => _SelectChairCommand53 ?? (_SelectChairCommand53 = new DelegateCommand(SelectedChair53Async));

        public DelegateCommand SelectedChair63 => _SelectChairCommand63 ?? (_SelectChairCommand63 = new DelegateCommand(SelectedChair63Async));

        public DelegateCommand SelectedChair73 => _SelectChairCommand73 ?? (_SelectChairCommand73 = new DelegateCommand(SelectedChair73Async));


        public DelegateCommand SelectedChair04 => _SelectChairCommand04 ?? (_SelectChairCommand04 = new DelegateCommand(SelectedChair04Async));

        public DelegateCommand SelectedChair14 => _SelectChairCommand14 ?? (_SelectChairCommand14 = new DelegateCommand(SelectedChair14Async));

        public DelegateCommand SelectedChair24 => _SelectChairCommand24 ?? (_SelectChairCommand24 = new DelegateCommand(SelectedChair24Async));

        public DelegateCommand SelectedChair34 => _SelectChairCommand34 ?? (_SelectChairCommand34 = new DelegateCommand(SelectedChair34Async));

        public DelegateCommand SelectedChair44 => _SelectChairCommand44 ?? (_SelectChairCommand44 = new DelegateCommand(SelectedChair44Async));

        public DelegateCommand SelectedChair54 => _SelectChairCommand54 ?? (_SelectChairCommand54 = new DelegateCommand(SelectedChair54Async));

        public DelegateCommand SelectedChair64 => _SelectChairCommand64 ?? (_SelectChairCommand64 = new DelegateCommand(SelectedChair64Async));

        public DelegateCommand SelectedChair74 => _SelectChairCommand74 ?? (_SelectChairCommand74 = new DelegateCommand(SelectedChair74Async));

        public DelegateCommand SelectedChair84 => _SelectChairCommand84 ?? (_SelectChairCommand84 = new DelegateCommand(SelectedChair84Async));


        public DelegateCommand ConfirmReservationCommand => _confirmReservationCommand ?? (_confirmReservationCommand = new DelegateCommand(ConfirmReservationAsync));

        public ObservableCollection<string> ChairsChips
        {
            get => _chairChips;
            set
            {
                SetProperty(ref _chairChips, value);
                TotalValue = ChairsChips.Count * Hour.TicketPrice;
            }
        }

        public decimal TotalValue
        {
            get => _total;
            set => SetProperty(ref _total, value);
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

        public HourResponse Hour
        {
            get => _hour;
            set => SetProperty(ref _hour, value);
        }

        public RoomResponse Room
        {
            get => _room;
            set => SetProperty(ref _room, value);
        }

        //Row A-0
        public ImageSource Chair00
        {
            get => _chair00;
            set => SetProperty(ref _chair00, value);
        }

        public ImageSource Chair10
        {
            get => _chair10;
            set => SetProperty(ref _chair10, value);
        }

        public ImageSource Chair20
        {
            get => _chair20;
            set => SetProperty(ref _chair20, value);
        }

        public ImageSource Chair30
        {
            get => _chair30;
            set => SetProperty(ref _chair30, value);
        }

        public ImageSource Chair40
        {
            get => _chair40;
            set => SetProperty(ref _chair40, value);
        }

        public ImageSource Chair50
        {
            get => _chair50;
            set => SetProperty(ref _chair50, value);
        }

        public ImageSource Chair60
        {
            get => _chair60;
            set => SetProperty(ref _chair60, value);
        }

        public ImageSource Chair70
        {
            get => _chair70;
            set => SetProperty(ref _chair70, value);
        }

        //Row B-1
        public ImageSource Chair01
        {
            get => _chair01;
            set => SetProperty(ref _chair01, value);
        }

        public ImageSource Chair11
        {
            get => _chair11;
            set => SetProperty(ref _chair11, value);
        }

        public ImageSource Chair21
        {
            get => _chair21;
            set => SetProperty(ref _chair21, value);
        }

        public ImageSource Chair31
        {
            get => _chair31;
            set => SetProperty(ref _chair31, value);
        }

        public ImageSource Chair41
        {
            get => _chair41;
            set => SetProperty(ref _chair41, value);
        }

        public ImageSource Chair51
        {
            get => _chair51;
            set => SetProperty(ref _chair51, value);
        }

        public ImageSource Chair61
        {
            get => _chair61;
            set => SetProperty(ref _chair61, value);
        }

        public ImageSource Chair71
        {
            get => _chair71;
            set => SetProperty(ref _chair71, value);
        }

        //Row C-2
        public ImageSource Chair02
        {
            get => _chair02;
            set => SetProperty(ref _chair02, value);
        }

        public ImageSource Chair12
        {
            get => _chair12;
            set => SetProperty(ref _chair12, value);
        }

        public ImageSource Chair22
        {
            get => _chair22;
            set => SetProperty(ref _chair22, value);
        }

        public ImageSource Chair32
        {
            get => _chair32;
            set => SetProperty(ref _chair32, value);
        }

        public ImageSource Chair42
        {
            get => _chair42;
            set => SetProperty(ref _chair42, value);
        }

        public ImageSource Chair52
        {
            get => _chair52;
            set => SetProperty(ref _chair52, value);
        }

        public ImageSource Chair62
        {
            get => _chair62;
            set => SetProperty(ref _chair62, value);
        }

        public ImageSource Chair72
        {
            get => _chair72;
            set => SetProperty(ref _chair72, value);
        }

        //Row D-3
        public ImageSource Chair03
        {
            get => _chair03;
            set => SetProperty(ref _chair03, value);
        }

        public ImageSource Chair13
        {
            get => _chair13;
            set => SetProperty(ref _chair13, value);
        }

        public ImageSource Chair23
        {
            get => _chair23;
            set => SetProperty(ref _chair23, value);
        }

        public ImageSource Chair33
        {
            get => _chair33;
            set => SetProperty(ref _chair33, value);
        }

        public ImageSource Chair43
        {
            get => _chair43;
            set => SetProperty(ref _chair43, value);
        }

        public ImageSource Chair53
        {
            get => _chair53;
            set => SetProperty(ref _chair53, value);
        }

        public ImageSource Chair63
        {
            get => _chair63;
            set => SetProperty(ref _chair63, value);
        }

        public ImageSource Chair73
        {
            get => _chair73;
            set => SetProperty(ref _chair73, value);
        }

        //Row E-2
        public ImageSource Chair04
        {
            get => _chair04;
            set => SetProperty(ref _chair04, value);
        }

        public ImageSource Chair14
        {
            get => _chair14;
            set => SetProperty(ref _chair14, value);
        }

        public ImageSource Chair24
        {
            get => _chair24;
            set => SetProperty(ref _chair24, value);
        }

        public ImageSource Chair34
        {
            get => _chair34;
            set => SetProperty(ref _chair34, value);
        }

        public ImageSource Chair44
        {
            get => _chair44;
            set => SetProperty(ref _chair44, value);
        }

        public ImageSource Chair54
        {
            get => _chair54;
            set => SetProperty(ref _chair54, value);
        }

        public ImageSource Chair64
        {
            get => _chair64;
            set => SetProperty(ref _chair64, value);
        }

        public ImageSource Chair74
        {
            get => _chair74;
            set => SetProperty(ref _chair74, value);
        }

        public ImageSource Chair84
        {
            get => _chair84;
            set => SetProperty(ref _chair84, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.Count != 0)
            {
                base.OnNavigatedTo(parameters);
                Hour = parameters.GetValue<HourResponse>("hour");
                LoadRoomAsync(Hour);
            }
        }

        private async void LoadRoomAsync(HourResponse hour)
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
            RoomRequest request = new RoomRequest
            {
                RoomId = hour.Room.Id,
                HourId = hour.Id,
                CultureInfo = Languages.Culture
            };

            Response response = await _apiService.GetRoomAsync<RoomResponse>(
            url, "/api", "/Room/GetRoom", request);
            IsRunning = false;
            IsEnable = true;
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                IsRunning = false;
                IsEnable = true;
                return;
            }
            Room = (RoomResponse)response.Result;
            ChargeChairs();
        }

        private async void ConfirmReservationAsync()
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

                DoReservationRequest request = new DoReservationRequest
                {
                    UserId = Guid.Parse(user.Id),
                    HourId = Hour.Id,
                    Chairs = SelectedChairs,
                    CultureInfo = Languages.Culture
                };

                Response response = await _apiService.DoReservationAsync(
                url, "/api", "/Reservation/DoReservation", request, "bearer", token.Token);
                IsRunning = false;
                IsEnable = true;
                if (!response.IsSuccess)
                {
                    await App.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                    IsRunning = false;
                    IsEnable = true;
                    return;
                }
                await App.Current.MainPage.DisplayAlert(Languages.Successful, response.Message, Languages.Accept);
                IsRunning = false;
                IsEnable = true;
                await _navigationService.NavigateAsync("/MoviemapMasterDetailPage/NavigationPage/MyReservationsPage");
                return;
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.LogInRequired, Languages.Accept);
            }
        }


        //Row A
        private async void SelectedChair00Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 0 && c.RowLocation == 0);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair00 = "Blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair00 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair10Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 1 && c.RowLocation == 0);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair10 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair10 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair20Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 2 && c.RowLocation == 0);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair20 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair20 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair30Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 3 && c.RowLocation == 0);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair30 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair30 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair40Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 4 && c.RowLocation == 0);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair40 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair40 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair50Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 5 && c.RowLocation == 0);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair50 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair50 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair60Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 6 && c.RowLocation == 0);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair60 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair60 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair70Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 7 && c.RowLocation == 0);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair70 = "Blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair70 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        //Row B
        private async void SelectedChair01Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 0 && c.RowLocation == 1);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair01 = "Blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair01 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair11Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 1 && c.RowLocation == 1);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair11 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair11 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair21Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 2 && c.RowLocation == 1);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair21 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair21 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair31Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 3 && c.RowLocation == 1);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair31 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair31 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair41Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 4 && c.RowLocation == 1);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair41 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair41 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair51Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 5 && c.RowLocation == 1);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair51 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair51 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair61Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 6 && c.RowLocation == 1);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair61 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair61 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair71Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 7 && c.RowLocation == 1);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair71 = "Blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair71 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        //Row C
        private async void SelectedChair02Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 0 && c.RowLocation == 2);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair02 = "Blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair02 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair12Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 1 && c.RowLocation == 2);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair12 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair12 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair22Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 2 && c.RowLocation == 2);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair22 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair22 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair32Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 3 && c.RowLocation == 2);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair32 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair32 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair42Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 4 && c.RowLocation == 2);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair42 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair42 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair52Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 5 && c.RowLocation == 2);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair52 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair52 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair62Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 6 && c.RowLocation == 2);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair62 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair62 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair72Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 7 && c.RowLocation == 2);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair72 = "Blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair72 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        //Row D
        private async void SelectedChair03Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 0 && c.RowLocation == 3);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair03 = "Blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair03 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair13Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 1 && c.RowLocation == 3);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair13 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair13 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair23Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 2 && c.RowLocation == 3);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair23 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair23 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair33Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 3 && c.RowLocation == 3);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair33 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair33 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair43Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 4 && c.RowLocation == 3);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair43 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair43 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair53Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 5 && c.RowLocation == 3);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair53 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair53 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair63Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 6 && c.RowLocation == 3);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair63 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair63 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair73Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 7 && c.RowLocation == 3);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair73 = "Blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair73 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        //Row E
        private async void SelectedChair04Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 0 && c.RowLocation == 4);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair04 = "Blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair04 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair14Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 1 && c.RowLocation == 4);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair14 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair14 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair24Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 2 && c.RowLocation == 4);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair24 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair24 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair34Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 3 && c.RowLocation == 4);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair34 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair34 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair44Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 4 && c.RowLocation == 4);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair44 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair44 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair54Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 5 && c.RowLocation == 4);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair54 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair54 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair64Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 6 && c.RowLocation == 4);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair64 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair64 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair74Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 7 && c.RowLocation == 4);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair74 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair74 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async void SelectedChair84Async()
        {
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 8 && c.RowLocation == 4);
            if (chair.ChairType == ChairType.Selected)
            {
                Chair84 = "blue";
                SelectedChairs.Remove(chair);
                chair.ChairType = ChairType.Available;
                ChargeChairsChips();
                return;
            }
            if (chair.ChairType == ChairType.Available && await ChairsCount())
            {
                Chair84 = "Green";
                chair.ChairType = ChairType.Selected;
                SelectedChairs.Add(chair);
                ChargeChairsChips();
                return;
            }
        }

        private async Task<bool> ChairsCount()
        {
            if (SelectedChairs.Count == 5)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "Maximo 5 sillas", Languages.Accept);
                return false;
            }
            return true;
        }

        private void ChargeChairsChips()
        {
            ChairsChips = new ObservableCollection<string>(SelectedChairs.Select(sc => sc.Name).ToList());
        }

        private void ChargeChairs()
        {
            //Row A
            var chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 0 && c.RowLocation == 0);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair00 = "blue";
                }
                else
                {
                    Chair00 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 1 && c.RowLocation == 0);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair10 = "blue";
                }
                else
                {
                    Chair10 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 2 && c.RowLocation == 0);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair20 = "blue";
                }
                else
                {
                    Chair20 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 3 && c.RowLocation == 0);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair30 = "blue";
                }
                else
                {
                    Chair30 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 4 && c.RowLocation == 0);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair40 = "blue";
                }
                else
                {
                    Chair40 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 5 && c.RowLocation == 0);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair50 = "blue";
                }
                else
                {
                    Chair50 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 6 && c.RowLocation == 0);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair60 = "blue";
                }
                else
                {
                    Chair60 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 7 && c.RowLocation == 0);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair70 = "blue";
                }
                else
                {
                    Chair70 = "red";
                }
            }

            //Row B

            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 0 && c.RowLocation == 1);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair01 = "blue";
                }
                else
                {
                    Chair01 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 1 && c.RowLocation == 1);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair11 = "blue";
                }
                else
                {
                    Chair11 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 2 && c.RowLocation == 1);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair21 = "blue";
                }
                else
                {
                    Chair21 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 3 && c.RowLocation == 1);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair31 = "blue";
                }
                else
                {
                    Chair31 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 4 && c.RowLocation == 1);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair41 = "blue";
                }
                else
                {
                    Chair41 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 5 && c.RowLocation == 1);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair51 = "blue";
                }
                else
                {
                    Chair51 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 6 && c.RowLocation == 1);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair61 = "blue";
                }
                else
                {
                    Chair61 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 7 && c.RowLocation == 1);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair71 = "blue";
                }
                else
                {
                    Chair71 = "red";
                }
            }

            //Row C

            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 0 && c.RowLocation == 2);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair02 = "blue";
                }
                else
                {
                    Chair02 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 1 && c.RowLocation == 2);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair12 = "blue";
                }
                else
                {
                    Chair12 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 2 && c.RowLocation == 2);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair22 = "blue";
                }
                else
                {
                    Chair22 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 3 && c.RowLocation == 2);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair32 = "blue";
                }
                else
                {
                    Chair32 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 4 && c.RowLocation == 2);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair42 = "blue";
                }
                else
                {
                    Chair42 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 5 && c.RowLocation == 2);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair52 = "blue";
                }
                else
                {
                    Chair52 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 6 && c.RowLocation == 2);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair62 = "blue";
                }
                else
                {
                    Chair62 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 7 && c.RowLocation == 2);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair72 = "blue";
                }
                else
                {
                    Chair72 = "red";
                }
            }

            //Row D

            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 0 && c.RowLocation == 3);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair03 = "blue";
                }
                else
                {
                    Chair03 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 1 && c.RowLocation == 3);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair13 = "blue";
                }
                else
                {
                    Chair13 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 2 && c.RowLocation == 3);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair23 = "blue";
                }
                else
                {
                    Chair23 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 3 && c.RowLocation == 3);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair33 = "blue";
                }
                else
                {
                    Chair33 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 4 && c.RowLocation == 3);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair43 = "blue";
                }
                else
                {
                    Chair43 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 5 && c.RowLocation == 3);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair53 = "blue";
                }
                else
                {
                    Chair53 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 6 && c.RowLocation == 3);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair63 = "blue";
                }
                else
                {
                    Chair63 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 7 && c.RowLocation == 3);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair73 = "blue";
                }
                else
                {
                    Chair73 = "red";
                }
            }

            //Row E

            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 0 && c.RowLocation == 4);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair04 = "blue";
                }
                else
                {
                    Chair04 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 1 && c.RowLocation == 4);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair14 = "blue";
                }
                else
                {
                    Chair14 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 2 && c.RowLocation == 4);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair24 = "blue";
                }
                else
                {
                    Chair24 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 3 && c.RowLocation == 4);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair34 = "blue";
                }
                else
                {
                    Chair34 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 4 && c.RowLocation == 4);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair44 = "blue";
                }
                else
                {
                    Chair44 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 5 && c.RowLocation == 4);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair54 = "blue";
                }
                else
                {
                    Chair54 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 6 && c.RowLocation == 4);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair64 = "blue";
                }
                else
                {
                    Chair64 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 7 && c.RowLocation == 4);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair74 = "blue";
                }
                else
                {
                    Chair74 = "red";
                }
            }
            chair = Room.Chairs.FirstOrDefault(c => c.ColumnLocation == 8 && c.RowLocation == 4);
            if (chair != null)
            {
                if (chair.ChairType == ChairType.Available)
                {
                    Chair84 = "blue";
                }
                else
                {
                    Chair84 = "red";
                }
            }
        }
    }
}
