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
    }
}
