using Intranet.web.Data;
using Intranet.web.Data.Entities;
using Intranet.web.Data.Entities.Compras;
using Intranet.web.Models;
using Intranet.web.Models.Compras;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Threading.Tasks;

namespace Intranet.web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelpers _combosHelpers;

        public ConverterHelper(DataContext dataContext,
            ICombosHelpers combosHelpers)
        {
            _dataContext = dataContext;
            _combosHelpers = combosHelpers;
        }

        public async Task<Incapacity> ToIncapAsync(AddIncapacityViewModel model, bool isNew)
        {
            return new Incapacity
            {
                Id = isNew ? 0 : model.Id,
                StartDate = model.StartDate,
                EndDate = model.StartDate.AddDays(model.CantDay),
                Employee = await _dataContext.Employees.FindAsync(model.EmployeeIds),
                DateRegistro = DateTime.Now,
                UserRegistra = model.UserRegistra,
                Novedad=model.Novedad,
                CantDay=model.CantDay,
                TypeNew = await _dataContext.TypeNews.FindAsync(model.TypeId)
         


            };
        }


        public async Task<Exams> ToExamAsync(ExamViewModel model, bool isNew)
        {
            return new Exams
            {
                Id = isNew ? 0 : model.Id,
                StartDate = model.StartDate,
                EndDate = model.StartDate.AddYears(1).AddDays(1),
                Employee = await _dataContext.Employees.FindAsync(model.EmployeeId),
                DateRegistro=DateTime.Now,
                UserRegistra=model.UserRegistra,
                ExamsType = await _dataContext.ExamsTypes.FindAsync(model.ExamTypeId)



            };
        }
        public EditExamViewModel ToExamViewModel(Exams exams)
        {
            return new EditExamViewModel
            {
                Id = exams.Id,
                StartDate = exams.StartDate.ToUniversalTime(),

                Employee = exams.Employee,
                EmployeeId = exams.Employee.Id,
                ExamTypeId = exams.ExamsType.Id,
                ExamTypes = _combosHelpers.GetComboExamTypes()

            };
        }
        //public ReportExam ToReportExamViewModel(Exams exams)
        //{
        //    string states = "";
        //    var valor = ((TimeSpan)(DateTime.Now - exams.EndDate)).Days;
        //    if (valor <= 1)
        //    {
        //        states = "Vencido";
        //    }
        //    if (valor <= 30)
        //    {
        //        states = "A vences";
        //    }
        //    if (valor >= 31)
        //    {
        //        states = "Activo";
        //    }

        //    return new ReportExam
        //    {
           
        //    Id = exams.Id,
        //         Document= exams.Employee.Document,
        //         ExamtypeId=exams.ExamsType.Id,
        //         FullName=exams.Employee.FullName,
        //         Activo=exams.Activo,
        //         State= states,
        //         EndDate=exams.EndDate,
        //         PositionEmpId= exams.ExamsType.Id,
                
        //         DateModify=exams.DateModify,
        //         StartDate=exams.StartDate,
        //         UserModify=exams.UserModify

               

        //    };
        //}
        public EditIncapacityViewModel ToIncapViewModel(Incapacity incap)
        {
            return new EditIncapacityViewModel
            {
                Id = incap.Id,
                EmployeeIds=incap.Employee.Id,
                StartDate = incap.StartDate,
                Employee = incap.Employee,
                CantDay=incap.CantDay,
                DateModify=incap.DateModify,
                DateRegistro=incap.DateRegistro,
                EndDate=incap.StartDate,
                Novedad=incap.Novedad,
                UserModify=incap.UserModify,
                
                UserRegistra=incap.UserRegistra,
                TypeId=incap.TypeNew.Id,
                TypeNews = _combosHelpers.GetComboTypeNew()

            };
        }
        public async Task<Sons> ToSonsAsync(SonsViewModel model, bool isNew)
        {
            return new Sons
            {
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                Datebirth = model.Datebirth,
                Genero = model.Genero,
                UserRegistra = model.UserRegistra,

                DateRegistro = model.DateRegistro,

                Employee = await _dataContext.Employees.FindAsync(model.EmployeeId)

            };
        }//
        public async Task<Sons> ToEditSonsAsync(EditSonViewModel model)
        {
            return new Sons
            {
                Id = model.Id,
                Name = model.Name,
                Datebirth = model.Datebirth,
                Genero = model.Genero,
                UserRegistra = model.UserRegistra,
                UserModify = model.UserModify,
                DateModify = model.DateModify,
                DateRegistro = model.DateRegistro,

                Employee = await _dataContext.Employees.FindAsync(model.EmployeeId)

            };
        }//
        public EditSonViewModel ToEditSonViewModel(Sons son)
        {
            return new EditSonViewModel
            {
                Id = son.Id,
                Name = son.Name,
                Datebirth = son.Datebirth,
                Genero = son.Genero,
                EmployeeId = son.Employee.Id,
                DateRegistro = son.DateRegistro,
                UserRegistra = son.UserRegistra,
                DateModify = son.DateModify,
                UserModify = son.UserModify,

            };
        }//

        public async Task<Verificado> ToVerificaAsync(VerificaViewModel model, bool isNew)
        {
            return new Verificado
            {
                Id = isNew ? 0 : model.Id,
                Novedad = model.Novedad,
                
                Dateregistro=model.Dateregistro,
                UserRegistro=model.UserRegistro,

                Negociation= await _dataContext.Negociation.FindAsync(model.NegociacionId)

            };
        }//

        public async Task<Pagos> ToPagoAsync(PagoViewModel model, bool isNew)
        {
            return new Pagos
            {
                Id = isNew ? 0 : model.Id,
                Novedad = model.Novedad,
                DocCobro = model.DocCobro,
                DocLegalizacion = model.DocLegalizacion,
                ValorPagado = model.ValorPagado,
                DatePago = model.DatePago,
                Dateregistro = model.Dateregistro,
                Userregistro = model.Userregistro,

                Negociation = await _dataContext.Negociation.FindAsync(model.NegociacionId)

            };
        }//


        public async Task<ProductBonifi> ToProductBonAsync(ProductBonViewModel model, bool isNew)
        {
            return new ProductBonifi
            {
                Id = isNew ? 0 : model.Id,
                Plu = model.Plu,
                Articulo = model.Articulo,
                Cant = model.Cant,
                ValorUnit = model.ValorUnit,
                
                Dateregistro = model.Dateregistro,
                Userregistro = model.Userregistro,

                Negociation = await _dataContext.Negociation.FindAsync(model.NegociacionId)

            };
        }//

        public async Task<Credit> ToCreditAsync(CreditViewModel model, bool isNew)
        {
            int mes = int.Parse(model.DeadlinePay.ToString());
            return new Credit
            {
                Id = isNew ? 0 : model.Id,
                NumberL = model.NumberL,
                DeadlinePay = model.DeadlinePay,
                IsActive = model.IsActive,
                Quotmonthly = model.Quotmonthly,
                TotalPrice = model.TotalPrice,
                StartDate = model.StartDate,
                EndDate = model.StartDate.AddMonths(mes).AddDays(1),
                Employee = await _dataContext.Employees.FindAsync(model.EmployeeIds),
                DateRegistro = model.DateRegistro,
                UserRegistra = model.UserRegistra,

                CreditEntities = await _dataContext.CreditEntities.FindAsync(model.EntityId)



            };
        }//
        public async Task<Credit> ToEditCreditAsync(EditCreditViewModel model)
        {
            return new Credit
            {
                Id = model.Id,
               DeadlinePay=model.DeadlinePay,
               EndDate=model.EndDate,
               IsActive=model.IsActive,
               NumberL=model.NumberL,
               Quotmonthly=model.Quotmonthly,
               StartDate=model.StartDate,
               TotalPrice=model.TotalPrice,
                UserRegistra = model.UserRegistra,
                UserModify = model.UserModify,
                DateModify = model.DateModify,
                DateRegistro = model.DateRegistro,
                CreditEntities = await _dataContext.CreditEntities.FindAsync(model.EntityId),
                Employee = await _dataContext.Employees.FindAsync(model.EmployeeIds)

            };
        }
        public EditCreditViewModel ToEditCreditViewModel(Credit credit)
        {
            return new EditCreditViewModel
            {
                Id = credit.Id,
                NumberL = credit.NumberL,
                DeadlinePay = credit.DeadlinePay,
                IsActive = credit.IsActive,
                Quotmonthly = credit.Quotmonthly,
                TotalPrice = credit.TotalPrice,
                StartDate = credit.StartDate,
                EndDate = credit.EndDate,
                EmployeeIds = credit.Employee.Id,
                EntityId = credit.CreditEntities.Id,
                UserRegistra = credit.UserRegistra,
                DateRegistro = credit.DateRegistro,
                UserModify = credit.UserModify,
                DateModify = credit.DateModify,
                Entityes = _combosHelpers.GetComboCreditEntities()

            };
        }


        public async Task<PersonContact> ToPersonAsync(AddPersonContactViewModel model, bool isNew)
        {
            return new PersonContact
            {
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                relationship = model.relationship,
                Telephone = model.Telephone,
                Employee = await _dataContext.Employees.FindAsync(model.EmployeeId),

            };
        }
        public EditPersonVieModel ToPersonContactViewModel(PersonContact person)
        {
            return new EditPersonVieModel
            {
                Id = person.Id,
                Name = person.Name,
                relationship = person.relationship,
                Telephone = person.Telephone,
                EmployeeId = person.Employee.Id,
                UserRegistra=person.UserRegistra,
                DateRegistro=person.DateRegistro,
                DateModify=person.DateModify,
                UserModify=person.UserModify
                
                
            };
        }

        public async Task<Endowment> ToAddEndowmentAsync(AddEndowmentViewModel model, bool isNew)
        {
            return new Endowment
            {
                Id = isNew ? 0 : model.Id,
                Detail = model.Detail,
                Count = model.Count,
                DateDelivery = model.DateDelivery,
                Size = model.Size,
                Employee = await _dataContext.Employees.FindAsync(model.EmployeeId),
                EndowmentType=await _dataContext.EndowmentsTypes.FindAsync(model.EndowmentTypeId),
                DateVence=model.DateVence,
                DateRegistro=DateTime.Now,
                UserRegistra=model.UserRegistra
            };
        }
        public EditEndowmentVieModel ToEndowmentViewModel(Endowment endowment)
        {
            return new EditEndowmentVieModel
            {
                Id = endowment.Id,
                Detail = endowment.Detail,
                Count = endowment.Count,
                DateDelivery = endowment.DateDelivery.ToUniversalTime(),
                Size = endowment.Size,
                EmployeeId = endowment.Employee.Id,
                Employee = endowment.Employee,
                DateRegistro=endowment.DateRegistro,
                UserRegistra=endowment.UserRegistra,
                DateModify=endowment.DateModify,
                UserModify=endowment.UserModify,
                EndowmnetsTypes = _combosHelpers.GetComboEndowmentType()
            };
        }

        public async Task<Area> ToAreaAsync(AddAreaViewModel model, bool isNew)
        {
            return new Area
            {
                Id = isNew ? 0 : model.Id,
                Nombre = model.Nombre,
                SiteHeadquarters = await _dataContext.SiteHeadquarters.FindAsync(model.SiteId)

            };
        }
        public AddAreaViewModel ToAreaViewModel(Area area)
        {
            return new AddAreaViewModel
            {
                Id = area.Id,
                Nombre = area.Nombre,
                SiteId = area.SiteHeadquarters.Id

            };
        }

        public ReportExam ToReportExamViewModel(Exams model)
        {
            string states = "";
            var valor = ((TimeSpan)(DateTime.Now - model.EndDate)).Days;
            if (valor <= 1)
            {
                states = "Vencido";
            }
            if (valor <= 30)
            {
                states = "A vences";
            }
            if (valor >= 31)
            {
                states = "Activo";
            }

            return new ReportExam
            {

                Id = model.Id,
                Document = model.Employee.Document,
                ExamtypeId = model.ExamsType.Id,
                FullName = model.Employee.FullName,
                Activo = model.Activo,
                State = states,
                EndDate = model.EndDate,
                PositionEmpId = model.ExamsType.Id,

                DateModify = model.DateModify,
                StartDate = model.StartDate,
                UserModify = model.UserModify



            };
        }
    }
}

