using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Intranet.web.Helpers
{
    public interface ICombosHelpers
    {
        IEnumerable<SelectListItem> GetComboExamTypes();
    }
}