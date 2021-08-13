using Intranet.web.Data.Entities;
using Intranet.web.Data.Entities.Compras;
using Intranet.web.Models;
using Intranet.web.Models.Compras;
using Microsoft.EntityFrameworkCore.Query;
using System.Threading.Tasks;

namespace Intranet.web.Helpers
{
    public interface IConverterHelper
    {
        Task<Exams> ToExamAsync(ExamViewModel model, bool isNew);
        EditExamViewModel ToExamViewModel(Exams exams);


        Task<Incapacity> ToIncapAsync(AddIncapacityViewModel model, bool isNew);
       
        EditIncapacityViewModel ToIncapViewModel(Incapacity incap);


        Task<Credit> ToCreditAsync(CreditViewModel model, bool isNew);//
        Task<Credit> ToEditCreditAsync(EditCreditViewModel model);//
        EditCreditViewModel ToEditCreditViewModel(Credit credit);


        Task<PersonContact> ToPersonAsync(AddPersonContactViewModel model, bool isNew);
        EditPersonVieModel ToPersonContactViewModel(PersonContact person);

        Task<Endowment> ToAddEndowmentAsync(AddEndowmentViewModel model, bool isNew);
        EditEndowmentVieModel ToEndowmentViewModel(Endowment endowment);

        Task<Area> ToAreaAsync(AddAreaViewModel model, bool isNew);
        AddAreaViewModel ToAreaViewModel(Area area);



        Task<Sons> ToSonsAsync(SonsViewModel model, bool isNew);//
        Task<Pagos> ToPagoAsync(PagoViewModel model, bool isNew);//
        EditPagoViewModel ToEditPagoViewModel(Pagos pagos);




        Task<ProductBonifi> ToProductBonAsync(ProductBonViewModel model, bool isNew);//


        Task<Verificado> ToVerificaAsync(VerificaViewModel model, bool isNew);//
        Task<Sons> ToEditSonsAsync(EditSonViewModel modelfull);//
        ReportExam ToReportExamViewModel(Exams model);
        EditSonViewModel ToEditSonViewModel(Sons son);//
       
    }
}