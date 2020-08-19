using Intranet.web.Data;
using Intranet.web.Data.Entities;
using Intranet.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
