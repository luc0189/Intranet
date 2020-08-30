using Intranet.web.Data.Entities;
using Intranet.web.Models;
using System.Threading.Tasks;

namespace Intranet.web.Helpers
{
    public interface IConverterHelper
    {
        Task<Exams> ToExamAsync(ExamViewModel model, bool isNew);
        ExamViewModel ToExamViewModel(Exams exams);


       
     

        Task<Credit> ToCreditAsync(CreditViewModel model, bool isNew);//
        Task<Credit> ToEditCreditAsync(EditCreditViewModel model);//
        EditCreditViewModel ToEditCreditViewModel(Credit credit);


        Task<PersonContact> ToPersonAsync(AddPersonContactViewModel model, bool isNew);
        EditPersonVieModel ToPersonContactViewModel(PersonContact person);

        Task<Endowment> ToAddEndowmentAsync(AddEndowmentViewModel model, bool isNew);
        AddEndowmentViewModel ToEndowmentViewModel(Endowment endowment);

        Task<Area> ToAreaAsync(AddAreaViewModel model, bool isNew);
        AddAreaViewModel ToAreaViewModel(Area area);



        Task<Sons> ToSonsAsync(SonsViewModel model, bool isNew);//
        Task<Sons> ToEditSonsAsync(EditSonViewModel modelfull);//
        EditSonViewModel ToEditSonViewModel(Sons son);//
       
    }
}