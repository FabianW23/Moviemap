using Moviemap.Common.Interfaces;
using Moviemap.Prism.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Moviemap.Prism.Helpers
{
    public static class Languages
    {
        static Languages()
        {
            CultureInfo ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            Culture = ci.ToString();
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Culture { get; set; }

        public static string Error => Resource.Error;

        public static string Accept => Resource.Accept;

        public static string LoginError => Resource.LoginError;

        public static string ConnectionError => Resource.ConnectionError;

        public static string LogOut => Resource.LogOut;

        public static string LogInRequired => Resource.LogInRequired;

        public static string DocumentError => Resource.DocumentError;

        public static string FirstNameError => Resource.FirstNameError;

        public static string LastNameError => Resource.LastNameError;

        public static string DocumentPlaceHolder => Resource.DocumentPlaceHolder;

        public static string FirstNamePlaceHolder => Resource.FirstNamePlaceHolder;

        public static string LastNamePlaceHolder => Resource.LastNamePlaceHolder;

        public static string PasswordConfirm => Resource.PasswordConfirm;

        public static string PasswordConfirmError1 => Resource.PasswordConfirmError1;

        public static string PasswordConfirmError2 => Resource.PasswordConfirmError2;

        public static string PasswordConfirmPlaceHolder => Resource.PasswordConfirmPlaceHolder;

        public static string Ok => Resource.Ok;

        public static string ForgotPassword => Resource.ForgotPassword;

        public static string PasswordRecover => Resource.PasswordRecover;

        public static string Save => Resource.Save;

        public static string ChangePassword => Resource.ChangePassword;

        public static string UserUpdated => Resource.UserUpdated;

        public static string ConfirmNewPassword => Resource.ConfirmNewPassword;

        public static string ConfirmNewPasswordError => Resource.ConfirmNewPasswordError;

        public static string ConfirmNewPasswordError2 => Resource.ConfirmNewPasswordError2;

        public static string ConfirmNewPasswordPlaceHolder => Resource.ConfirmNewPasswordPlaceHolder;

        public static string CurrentPassword => Resource.CurrentPassword;

        public static string CurrentPasswordError => Resource.CurrentPasswordError;

        public static string CurrentPasswordPlaceHolder => Resource.CurrentPasswordPlaceHolder;

        public static string NewPassword => Resource.NewPassword;

        public static string NewPasswordError => Resource.NewPasswordError;

        public static string NewPasswordPlaceHolder => Resource.NewPasswordPlaceHolder;

        public static string StartDate => Resource.StartDate;

        public static string EndDate => Resource.EndDate;

        public static string Date => Resource.Date;

        public static string StartDatePalceHolder => Resource.StartDatePalceHolder;

        public static string EndDatePlaceHolder => Resource.EndDatePlaceHolder;

        public static string Description => Resource.Description;

        public static string DescriptionError => Resource.DescriptionError;

        public static string DateError => Resource.DateError;

        public static string StartDateError => Resource.StartDateError;

        public static string EndDateError => Resource.EndDateError;

        public static string Cancel => Resource.Cancel;

        public static string AdminCantLogIn => Resource.AdminCantLogIn;

        public static string AddTripDetail => Resource.AddTripDetail;

        public static string LogInMenu => Resource.LogInMenu;

        public static string ModifyUserMenu => Resource.ModifyUserMenu;

        public static string Email => Resource.Email;

        public static string EmailPlaceHolder => Resource.EmailPlaceHolder;

        public static string EmailError => Resource.EmailError;

        public static string Password => Resource.Password;

        public static string PasswordError => Resource.PasswordError;

        public static string PasswordPlaceHolder => Resource.PasswordPlaceHolder;

        public static string Register => Resource.Register;

        public static string Cinemas => Resource.Cinemas;
    }
}
