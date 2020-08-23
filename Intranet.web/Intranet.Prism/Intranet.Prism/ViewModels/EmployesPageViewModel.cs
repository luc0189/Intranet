using Intranet.Common.Models;
using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intranet.Prism.ViewModels
{
    public class EmployesPageViewModel : ViewModelBase
    {
        private ManagerResponse _manager;
        public EmployesPageViewModel(
            INavigationService navigationService): base(navigationService)
        {
            Title = "Empleados";
        }
        //TODO: para crequer los parametros que vienen de la pagina anterior
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey("manager"))
            {
                _manager = parameters.GetValue<ManagerResponse>("manager");
                Title = _manager.FullName;
            }
        }
    }
}
