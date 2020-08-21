using Intranet.web.Data;
using Intranet.web.Data.Entities;
using Intranet.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Intranet.web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;

        public ConverterHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Exams> ToExamAsync(ExamViewModel model, bool isNew)
        {
            return new Exams
            {
                Id= isNew ? 0 : model.Id,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Employee= await _dataContext.Employees.FindAsync(model.EmployeeId),
               
                ExamsType = await _dataContext.ExamsTypes.FindAsync(model.ExamTypeId)
                


            };
        }
        public async Task<Sons> ToSonsAsyncf(SonsViewModel model, bool isNew)
        {
            return new Sons
            {
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                Datebirth = model.Datebirth,
                Genero= model.Genero,
                Employee = await _dataContext.Employees.FindAsync(model.EmployeeId)

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
            return new Credit
            {
                Id = isNew ? 0 : model.Id,
                NumberL=model.NumberL,
                DeadlinePay=model.DeadlinePay,
                IsActive=model.IsActive,
                Quotmonthly=model.Quotmonthly,
                TotalPrice=model.TotalPrice,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Employee = await _dataContext.Employees.FindAsync(model.EmployeeIds),

                CreditEntities = await _dataContext.CreditEntities.FindAsync(model.EntityId)



            };
        }
        public async Task<PersonContact> ToPersonAsync(AddPersonContactViewModel model, bool isNew)
        {
            return new PersonContact
            {
                Id = isNew ? 0 : model.Id,
               Name=model.Name,
               relationship=model.relationship,
               Telephone=model.Telephone,
                Employee = await _dataContext.Employees.FindAsync(model.EmployeeId),

            };
        } 
        public async Task<Endowment> ToAddEndowmentAsync(AddEndowmentViewModel model, bool isNew)
        {
            return new Endowment
            {
                Id = isNew ? 0 : model.Id,
                Detail=model.Detail,
                Count=model.Count,
                 DateDelivery=model.DateDelivery,
                 Size=model.Size,
                Employee = await _dataContext.Employees.FindAsync(model.EmployeeId),

            };
        }

        public async Task<Area> ToAreaAsync(AddAreaViewModel model, bool isNew)
        {
            return new Area
            {
                Id = isNew ? 0 : model.Id,
               
              Nombre=model.Nombre,
               SiteHeadquarters = await _dataContext.SiteHeadquarters.FindAsync(model.SiteId),

            };
        }
    }
}

