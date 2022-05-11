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
        public IEnumerable<SelectListItem> GetComboCargos()
        {
            var list = _dataContext.PositionEmployees.Select(et => new SelectListItem
            {
                Text = et.Position,
                Value = $"{et.Id}"
            }).OrderBy(et => et.Text)
             .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Cargo...)",
                Value = "0"
            });
            return list;
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
    
             public IEnumerable<SelectListItem> GetComboTypeNew()
        {
            var list = _dataContext.TypeNews.Select(et => new SelectListItem
            {
                Text = et.Nombre,
                Value = $"{et.Id}"
            }).OrderBy(et => et.Text)
             .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Tipo de Novedad...)",
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
                Text = "(Seleccione una Entidad...)",
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

        public IEnumerable<SelectListItem> GetComboAreaEntities()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem> GetComboEps()
        {
            var list = _dataContext.Eps.Select(a => new SelectListItem
            {
                Text = a.Nombre,
                Value = $"{a.Id}"
            }).OrderBy(a => a.Text)
             .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Eps...)",
                Value = "0"
            });
            return list;
        }
        public IEnumerable<SelectListItem> GetComboRols()
        {
            var list = _dataContext.Roles.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = $"{a.Id}"
            }).OrderBy(a => a.Text)
             .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Rol...)",
                Value = "0"
            });
            return list;
        }
        public IEnumerable<SelectListItem> GetComboPension()
        {
            var list = _dataContext.Pensions.Select(a => new SelectListItem
            {
                Text = a.Nombre,
                Value = $"{a.Id}"
            }).OrderBy(a => a.Text)
            .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione Una Entidad...)",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboCajaCompensacion()
        {
            var list = _dataContext.CajaCompensacions.Select(a => new SelectListItem
            {
                Text = a.Nombre,
                Value = $"{a.Id}"
            }).OrderBy(a => a.Text)
            .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione Una Entidad...)",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboPositionEmploye()
        {
            var list = _dataContext.PositionEmployees.Select(a => new SelectListItem
            {
                Text = a.Position,
                Value = $"{a.Id}"
            }).OrderBy(a => a.Text)
            .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Cargo...)",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboEndowmentType()
        {
            var list = _dataContext.EndowmentsTypes.Select(a => new SelectListItem
            {
                Text = a.NameType,
                Value = $"{a.Id}"
            }).OrderBy(a => a.Text)
            .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Elemento...)",
                Value = "0"
            });
            return list;
        }
        public IEnumerable<SelectListItem> GetComboProveedor()
        {
            var list = _dataContext.Providers.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = $"{a.Id}"
            }).OrderBy(a => a.Text)
             .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione Un Proveedor...)",
                Value = "0"
            });
            return list;
        }
        public IEnumerable<SelectListItem> GetComboModel()
        {
            var list = _dataContext.Models.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = $"{a.Id}"
            }).OrderBy(a => a.Text)
             .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione Un Modelo...)",
                Value = "0"
            });
            return list;
        } 
        public IEnumerable<SelectListItem> GetComboCategory()
        {
            var list = _dataContext.Categories.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = $"{a.Id}"
            }).OrderBy(a => a.Text)
             .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione Una Categoria...)",
                Value = "0"
            });
            return list;
        }
        public IEnumerable<SelectListItem> GetComboFabricante()
        {
            var list = _dataContext.Fabrics.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = $"{a.Id}"
            }).OrderBy(a => a.Text)
             .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione Un Fabricante...)",
                Value = "0"
            });
            return list;
        }
        //compras
        public IEnumerable<SelectListItem> GetComboClasification()
        {
            var list = _dataContext.Clasifications.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = $"{a.Id}"
            }).OrderBy(a => a.Text)
             .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione Una Clasificacion...)",
                Value = "0"
            });
            return list;
        } 
        public IEnumerable<SelectListItem> GetComboProviderCompras()
        {
            var list = _dataContext.Providercompras.Select(a => new SelectListItem
            {
                Text = a.NameProvider,
                Value = $"{a.Id}"
            }).OrderBy(a => a.Text)
             .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione Un Proveedor...)",
                Value = "0"
            });
            return list;
        }
        public IEnumerable<SelectListItem> GetComboMes()
        {
            var list = _dataContext.Mes.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = $"{a.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione Un Mes...)",
                Value = "0"
            });
            return list;
        }
        public IEnumerable<SelectListItem> GetComboSalaVentas()
        {
            var list = _dataContext.SalaVentas.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = $"{a.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione Una Sala De Ventas...)",
                Value = "0"
            });
            return list;
        }
    }
}
