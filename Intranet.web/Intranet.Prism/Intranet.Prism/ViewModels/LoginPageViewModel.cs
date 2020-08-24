using DryIoc;
using Intranet.Common.Models;
using Intranet.Common.Services;
using Intranet.Prism.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Xamarin.Essentials;

namespace Intranet.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private string _password;
        private bool _isRunning;
        private bool _isEnable;
        private DelegateCommand _loginCommand;

        public LoginPageViewModel(
            INavigationService navigationService,
            IApiService apiService): base(navigationService)
        {
            Title = "Login";
            IsEnable = true;
            _navigationService = navigationService;
            _apiService = apiService;
            Email = "yency0187@gmail.com";
            Password = "123456";
        }
        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login));

   

        public string Email { get; set; }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }
        public bool IsEnable
        {
            get => _isEnable;
            set => SetProperty(ref _isEnable, value);
        }
        private  async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "No Digito Email", "Aceptar");
                return;
            };
            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "No Digito Password", "Aceptar");
                return;
            };

            IsRunning = true;
            IsEnable = false;
            var request = new TokenRequest
            {
                Password = Password,
               Username = Email
            };

            var url = App.Current.Resources["UrlAPI"].ToString();
            var connection = await _apiService.CheckConnectionAsync(url);
            if (!connection)
            {
               
                await App.Current.MainPage.DisplayAlert("Error", "No hay Conexion", "Aceptar");
                IsRunning = true;
                IsEnable = false;
                return;

            }

            var response = await _apiService.GetTokenAsync(url, "/Account", "/CreateToken", request);

          
            if (!response.IsSuccess)
            {
                IsRunning = false;
                IsEnable = true;
                await App.Current.MainPage.DisplayAlert("Error", "Usuario o Contraseña Incorrecto", "Aceptar");
                Password = string.Empty;
                return;
            }
            var token = response.Result;
            //TODO: aqui traigo la info que quiero mostrar
            var response2 = await _apiService.GetEmployeByEmailAsync(
                url,
                "api",
                "/Employe/GetEmployeByEmail",
                "bearer",
                token.Token,
                Email
                );
            if (!response2.IsSuccess)
            {
                IsRunning = false;
                IsEnable = true;
                await App.Current.MainPage.DisplayAlert("Error", "Falta Permisos \nSolicite Roles", "Aceptar");
                return;
            }
            var manager = response2.Result;
            //TODO:aqui puedo adicionar mas parametros a pasar o consulta de la BD
            var parameters = new NavigationParameters
            {
                { "manager", manager }
            };

            await _navigationService.NavigateAsync("EmployesPage",parameters);
            IsRunning = false;
            IsEnable = true;
        }

    }
}
