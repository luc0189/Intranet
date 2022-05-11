﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Intranet.web.Helpers
{
    public interface ICombosHelpers
    {
        IEnumerable<SelectListItem> GetComboExamTypes();
        IEnumerable<SelectListItem> GetComboCreditEntities();
        IEnumerable<SelectListItem> GetComboCargos();
        IEnumerable<SelectListItem> GetComboSedes();
        IEnumerable<SelectListItem> GetComboAreas();
        IEnumerable<SelectListItem> GetComboEndowmentType();
   
        IEnumerable<SelectListItem> GetComboAreaEntities();
        IEnumerable<SelectListItem> GetComboEps();

        IEnumerable<SelectListItem> GetComboPension();
        IEnumerable<SelectListItem> GetComboCajaCompensacion();
        IEnumerable<SelectListItem> GetComboPositionEmploye();
        IEnumerable<SelectListItem> GetComboProveedor();
        IEnumerable<SelectListItem> GetComboModel();
        IEnumerable<SelectListItem> GetComboCategory();
        IEnumerable<SelectListItem> GetComboFabricante();
        IEnumerable<SelectListItem> GetComboTypeNew();

        //compras
        IEnumerable<SelectListItem> GetComboClasification();
        IEnumerable<SelectListItem> GetComboRols();
        IEnumerable<SelectListItem> GetComboProviderCompras();
        IEnumerable<SelectListItem> GetComboMes();
        IEnumerable<SelectListItem> GetComboSalaVentas();
    }
}