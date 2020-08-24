using Intranet.Common.Models;
using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Intranet.Prism.ViewModels
{
    public class EmployesPageViewModel : ViewModelBase
    {
        private EmployeResponse _manager;
        private ObservableCollection<CreditResponse> _credits;
        private ObservableCollection<UserImageResponse> _images;
        public EmployesPageViewModel(
            INavigationService navigationService): base(navigationService)
        {
            Title = "Empleados";
            
        }
        public ObservableCollection<CreditResponse> Credits
        {
            get => _credits;
            set => SetProperty(ref _credits, value);
        } public ObservableCollection<UserImageResponse> Imagenes
        {
            get => _images;
            set => SetProperty(ref _images, value);
        }
        //TODO: para crequer los parametros que vienen de la pagina anterior
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey("manager"))
            {
                _manager = parameters.GetValue<EmployeResponse>("manager");
                Title = _manager.FirstName;
                Imagenes = new ObservableCollection<UserImageResponse>(_manager.UserImage);
                Credits = new ObservableCollection<CreditResponse>(_manager.Credits);
               
            }
        }
    }
}
