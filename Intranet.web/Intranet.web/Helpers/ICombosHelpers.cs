using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Intranet.web.Helpers
{
    public interface ICombosHelpers
    {
        IEnumerable<SelectListItem> GetComboExamTypes();
        IEnumerable<SelectListItem> GetComboCreditEntities();
        IEnumerable<SelectListItem> GetComboSedes();
        IEnumerable<SelectListItem> GetComboAreas();
        IEnumerable<SelectListItem> GetComboEndowmentType();
   
        IEnumerable<SelectListItem> GetComboAreaEntities();
        IEnumerable<SelectListItem> GetComboEps();
        IEnumerable<SelectListItem> GetComboRoles();
        IEnumerable<SelectListItem> GetComboPension();
        IEnumerable<SelectListItem> GetComboCajaCompensacion();
        IEnumerable<SelectListItem> GetComboPositionEmploye();
        IEnumerable<SelectListItem> GetComboProveedor();
        IEnumerable<SelectListItem> GetComboModel();
        IEnumerable<SelectListItem> GetComboCategory();
        IEnumerable<SelectListItem> GetComboFabricante();
    }
}