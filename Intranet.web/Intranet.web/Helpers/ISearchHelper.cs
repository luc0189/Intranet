using Intranet.web.Data.EntitiesSP;
using Intranet.web.Models.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Helpers
{
    public interface ISearchHelper
    {
        Task<Articulo> ToAreaAsync(ProductViewModel model, bool isNew);
     
    }
}
