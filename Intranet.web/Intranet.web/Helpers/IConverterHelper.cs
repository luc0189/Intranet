using Intranet.web.Data.Entities;
using Intranet.web.Data.Entities.Compras;
using Intranet.web.Data.Entities.Fidelizacion;
using Intranet.web.Models;
using Intranet.web.Models.Compras;
using Intranet.web.Models.Fidelizacion;
using Intranet.web.Models.Report;
using System.Threading.Tasks;

namespace Intranet.web.Helpers
{
    public interface IConverterHelper
    {
        Task<Exams> ToExamAsync(ExamViewModel model, bool isNew);
        EditExamViewModel ToExamViewModel(Exams exams);


        Task<Incapacity> ToIncapAsync(AddIncapacityViewModel model, bool isNew);
        Task<Redimidos> ToredimidosAsync(AddRedimidosViewModel model, bool isNew);

        EditIncapacityViewModel ToIncapViewModel(Incapacity incap);


        Task<Credit> ToCreditAsync(CreditViewModel model, bool isNew);//
        Task<Credit> ToEditCreditAsync(EditCreditViewModel model);//
        EditCreditViewModel ToEditCreditViewModel(Credit credit);


        Task<PersonContact> ToPersonAsync(AddPersonContactViewModel model, bool isNew);
        EditPersonVieModel ToPersonContactViewModel(PersonContact person);

        Task<Endowment> ToAddEndowmentAsync(AddEndowmentViewModel model, bool isNew);
        //EditEndowmentVieModel ToEditEndowmentViewModel(Endowment credit);
        Task<Contract> ToContractoAsync(ContractViewModel model, bool isNew);
        EditEndowmentVieModel ToEndowmentViewModel(Endowment endowment);
        EditContractViewModel ToContractViewModel(Contract endowment);

        Task<Area> ToAreaAsync(AddAreaViewModel model, bool isNew);
        AddAreaViewModel ToAreaViewModel(Area area);


        Task<CargosAsg> ToCargosAsync(CargosViewModels model, bool isNew);//
        Task<Sons> ToSonsAsync(SonsViewModel model, bool isNew);//
        Task<HistorialEmpleado> ToHistorialAsync(AddHistorialEmpleadoViewModel model, bool isNew);//
        Task<Pagos> ToPagoAsync(PagoViewModel model, bool isNew);//
        EditPagoViewModel ToEditPagoViewModel(Pagos pagos);




        Task<ProductBonifi> ToProductBonAsync(ProductBonViewModel model, bool isNew);//


        Task<Verificado> ToVerificaAsync(VerificaViewModel model, bool isNew);//
        Task<Sons> ToEditSonsAsync(EditSonViewModel modelfull);//

        ReportExam ToReportExamViewModel(Exams model);
        EditSonViewModel ToEditSonViewModel(Sons son);//
        EditHistorialEmpleadoViewModel ToEditHistorialEmpleadoViewModel(HistorialEmpleado historial);//
        Task<HistorialEmpleado> ToEditHistorialsAsync(EditHistorialEmpleadoViewModel modelfull);//

    }
}