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
