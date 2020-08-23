using Intranet.Common.Models;
using Intranet.web.Data;
using Intranet.web.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController :ControllerBase
    {
        private readonly DataContext _dataContext;

        public ManagerController(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpPost]
        [Route("GetManagerByEmail")]
        public async Task<IActionResult> GetManagerByEmailAsync(EmailRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var manager = await _dataContext.Managers
                .Include(e => e.User)
                .Include(e => e.Credits)
                .ThenInclude(c => c.CreditEntities)
                .Include(e => e.Endowments)
                .Include(e => e.Exams)
                .ThenInclude(ex => ex.ExamsType)
                .Include(e => e.PersonContacts)
                .Include(e => e.UserImages)
                .Include(e => e.Sons)
                .FirstOrDefaultAsync(e => e.User.Email.ToLower() == request.Email.ToLower());
            if (manager == null)
            {
                return NotFound();
            }
            var response = new ManagerResponse
            {
                Id = manager.Id,
                Document = manager.User.Document,
                FirstName = manager.User.FirstName,
                LastName = manager.User.LastName,
                Address = manager.User.Address,
                Activo = manager.User.Activo,
                Email = manager.User.Email,
                Movil = manager.User.Movil,
                CreditResponses = manager.Credits?.Select(c => new CreditResponse
                {
                    Id = c.Id,
                    NumberL = c.NumberL,
                    Quotmonthly = c.Quotmonthly,
                    TotalPrice = c.TotalPrice,
                    DeadlinePay = c.DeadlinePay,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    IsActive = c.IsActive,
                    EntitiesCreditResponse = ToEntitiesResponse(c.CreditEntities)

                }).ToList(),
                EndowmentResponses = manager.Endowments?.Select(e => new EndowmentResponse
                {
                    Id = e.Id,
                    Detail = e.Detail,
                    Count = e.Count,
                    Size = e.Size,
                    DateDelivery = e.DateDelivery
                }).ToList(),
                PersonCResponses = manager.PersonContacts?.Select(p => new PersonCResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Telephone = p.Telephone,
                    relationship = p.relationship
                }).ToList(),
                SonsResponses = manager.Sons?.Select(so => new SonsResponse
                {
                    Id = so.Id,
                    Name = so.Name,
                    Datebirth = so.Datebirth,
                    Genero = so.Genero
                }).ToList(),
                UserImageResponses = manager.UserImages?.Select(i => new UserImageResponse
                {
                    Id = i.Id,
                    ImageUrl = i.ImageFullPath
                }).ToList(),
                ExamsResponses = manager.Exams?.Select(ex => new ExamsResponse
                {
                    Id = ex.Id,
                    ExamTypeResponse = ToExamResponse(ex.ExamsType),
                    StartDate = ex.StartDate,
                    EndDate = ex.EndDate
                }).ToList()

            };
            return Ok(response);
        }

        private ExamTypeResponse ToExamResponse(ExamsType examsType)
        {
            return new ExamTypeResponse
            {
                Id = examsType.Id,
                Name = examsType.Name
            };
        }

        private EntitiesCreditResponse ToEntitiesResponse(CreditEntities creditEntities)
        {
            return new EntitiesCreditResponse
            {
                Id = creditEntities.Id,
                Name = creditEntities.Name
            };
        }
    }
}
