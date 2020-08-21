using Intranet.web.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Helpers
{
    public class CombosHelpers : ICombosHelpers
    {
        private readonly DataContext _dataContext;

        public CombosHelpers(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<SelectListItem> GetComboExamTypes()
        {
            var list = _dataContext.ExamsTypes.Select(et => new SelectListItem
            {
                Text = et.Name,
                Value = $"{et.Id}"
            }).OrderBy(et => et.Text)
             .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Tipo de Examen...)",
                Value = "0"
            });
            return list;
        }
        public IEnumerable<SelectListItem> GetComboCreditEntities()
        {
            var list = _dataContext.CreditEntities.Select(et => new SelectListItem
            {
                Text = et.Name,
                Value = $"{et.Id}"
            }).OrderBy(et => et.Text)
             .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Tipo de Examen...)",
                Value = "0"
            });
            return list;
        }
        public IEnumerable<SelectListItem> GetComboSedes()
        {
            var list = _dataContext.SiteHeadquarters.Select(sh => new SelectListItem
            {
                Text = sh.Nombre,
                Value = $"{sh.Id}"
            }).OrderBy(sh => sh.Text)
             .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione una Sede...)",
                Value = "0"
            });
            return list;
        }
        public IEnumerable<SelectListItem> GetComboAreas()
        {
            var list = _dataContext.Areas.Select(a => new SelectListItem
            {
                Text = a.Nombre,
                Value = $"{a.Id}"
            }).OrderBy(a => a.Text)
             .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Area...)",
                Value = "0"
            });
            return list;
        }
    }
}
