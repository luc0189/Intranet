using Intranet.web.Data.Entities;
using Intranet.web.Models;
using System.Threading.Tasks;

namespace Intranet.web.Helpers
{
    public interface IConverterHelper
    {
        Task<Exams> ToExamAsync(ExamViewModel model, bool isNew);
        Task<Sons> ToSonsAsync(SonsViewModel model, bool isNew);
    }
}