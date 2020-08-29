﻿using Intranet.web.Data;
using Intranet.web.Data.Entities;
using Intranet.web.Models;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2.HPack;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
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

        public async Task<Exams> ToExamAsync(ExamViewModel model, bool isNew)
        {
            return new Exams
            {
                Id = isNew ? 0 : model.Id,
                StartDate = model.StartDate,
                EndDate = model.StartDate.AddYears(1).AddDays(1),
                Employee = await _dataContext.Employees.FindAsync(model.EmployeeId),
                
                ExamsType = await _dataContext.ExamsTypes.FindAsync(model.ExamTypeId)



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
                Employee = await _dataContext.Employees.FindAsync(model.EmployeeId)

            };
        }
        public async Task<Credit> ToEntitiesCreditAsync(CreditViewModel model, bool isNew)
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

                CreditEntities = await _dataContext.CreditEntities.FindAsync(model.EntityId)



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

        public SonsViewModel ToSonViewModel(Sons son)
        {
            return new SonsViewModel
            {
                Id = son.Id,
                Name = son.Name,
                Datebirth = son.Datebirth,
                Genero = son.Genero,
                EmployeeId = son.Employee.Id
            };
        }

        public CreditViewModel ToCreditViewModel(Credit credit)
        {
            return new CreditViewModel
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

                Entityes = _combosHelpers.GetComboCreditEntities()

            };
        }
       

        public AddPersonContactViewModel ToPersonContactViewModel(PersonContact person)
        {
            return new AddPersonContactViewModel
            {
                Id = person.Id,
                Name = person.Name,
                relationship = person.relationship,
                Telephone = person.Telephone,
                EmployeeId = person.Employee.Id

            };
        }

        public ExamViewModel ToExamViewModel(Exams exams)
        {
            return new ExamViewModel
            {
                Id = exams.Id,
                StartDate = exams.StartDate.ToUniversalTime(),
                
                Employee = exams.Employee,
                EmployeeId = exams.Employee.Id,
                ExamTypeId = exams.ExamsType.Id,
                ExamTypes = _combosHelpers.GetComboExamTypes()

            };
        }

        public AddEndowmentViewModel ToEndowmentViewModel(Endowment endowment)
        {
            return new AddEndowmentViewModel
            {
                Id = endowment.Id,
                Detail = endowment.Detail,
                Count = endowment.Count,
                DateDelivery = endowment.DateDelivery.ToUniversalTime(),
                Size = endowment.Size,
                EmployeeId = endowment.Employee.Id,
                Employee = endowment.Employee
            };
        }

       

      

    }
}

