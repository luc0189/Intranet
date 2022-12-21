using Intranet.web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Intranet.web.Models
{
    public class AddAreaViewModel : Area
    {

        public int SiteId { get; set; }


        public IEnumerable<SelectListItem> Sities { get; set; }
    }
}
