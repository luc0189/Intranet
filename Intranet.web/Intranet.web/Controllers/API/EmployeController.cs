using Intranet.Common.Models;
using Intranet.web.Data;
using Intranet.web.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Intranet.web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public EmployeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpPost]
        [Route ("GetEmployeByEmail")]
        public async Task<IActionResult> GetEmployeByEmailAsync(EmailRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var employe = await _dataContext.Employees
                .Include(e => e.User)
                .Include(e => e.Credits)
                .ThenInclude(c=>c.CreditEntities)
                .Include(e => e.Endowments)
                .Include(e => e.Exams)
                .ThenInclude(ex=>ex.ExamsType)
                .Include(e => e.PersonContacts)
                .Include(e => e.UserImages)
                .Include(e => e.Sons)
                .FirstOrDefaultAsync(e => e.User.Email.ToLower() == request.Email.ToLower());
            if (employe==null)
            {
                return NotFound();
            }
            var response = new EmployeResponse
            {
                Id=employe.Id,
                Document=employe.User.Document,
                FirstName=employe.User.FirstName,
                LastName=employe.User.LastName,
                Address=employe.User.Address,
                Activo=employe.User.Activo,
                Email=employe.User.Email,
                Movil=employe.User.Movil,
                CreditResponses=employe.Credits?.Select(c => new CreditResponse
                {
                    Id=c.Id,
                    NumberL=c.NumberL,
                    Quotmonthly=c.Quotmonthly,
                    TotalPrice=c.TotalPrice,
                    DeadlinePay=c.DeadlinePay,
                    StartDate=c.StartDate,
                    EndDate=c.EndDate,
                    IsActive=c.IsActive,
                    EntitiesCreditResponse= ToEntitiesResponse(c.CreditEntities)
                    
                }).ToList(),
                EndowmentResponses=employe.Endowments?.Select(e=> new EndowmentResponse
                {
                    Id=e.Id,
                    Detail=e.Detail,
                    Count=e.Count,
                    Size=e.Size,
                    DateDelivery=e.DateDelivery
                }).ToList(),
                PersonCResponses=employe.PersonContacts?.Select(p=> new PersonCResponse
                {
                    Id=p.Id,
                    Name=p.Name,
                    Telephone=p.Telephone,
                    relationship=p.relationship
                }).ToList(),
                SonsResponses=employe.Sons?.Select(so=> new SonsResponse
                {
                    Id=so.Id,
                    Name=so.Name,
                    Datebirth=so.Datebirth,
                    Genero=so.Genero
                }).ToList(),
                UserImageResponses=employe.UserImages?.Select(i=>new UserImageResponse
                { 
                 Id=i.Id,
                 ImageUrl=i.ImageFullPath
                }).ToList(),
                ExamsResponses=employe.Exams?.Select(ex=>new ExamsResponse
                {
                    Id=ex.Id,
                    ExamTypeResponse=ToExamResponse(ex.ExamsType),
                    StartDate=ex.StartDate,
                    EndDate=ex.EndDate
                }).ToList()
             
            };
            return Ok(response);
        }

        private ExamTypeResponse ToExamResponse(ExamsType examsType)
        {
            return new ExamTypeResponse
            {
                Id=examsType.Id,
                Name=examsType.Name
            };
        }

        private EntitiesCreditResponse ToEntitiesResponse(CreditEntities creditEntities)
        {
            return new EntitiesCreditResponse
            {
                Id=creditEntities.Id,
                Name=creditEntities.Name
            };
        }
    }
}
