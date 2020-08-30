﻿using Intranet.web.Data.Entities;
using Intranet.web.Models;
using System.Threading.Tasks;

namespace Intranet.web.Helpers
{
    public interface IConverterHelper
    {
        Task<Exams> ToExamAsync(ExamViewModel model, bool isNew);
        Task<Sons> ToSonsAsync(SonsViewModel model, bool isNew);
     
        Task<Credit> ToEntitiesCreditAsync(CreditViewModel model, bool isNew);
        Task<PersonContact> ToPersonAsync(AddPersonContactViewModel model, bool isNew);
        Task<Endowment> ToAddEndowmentAsync(AddEndowmentViewModel model, bool isNew);
        Task<Area> ToAreaAsync(AddAreaViewModel model, bool isNew);
        AddAreaViewModel ToAreaViewModel(Area area);
        SonsViewModel ToSonViewModel(Sons son);
        EditSonViewModel ToEditSonViewModel(Sons son);
        CreditViewModel ToCreditViewModel(Credit credit);
        AddPersonContactViewModel ToPersonContactViewModel(PersonContact person);
        ExamViewModel ToExamViewModel(Exams exams);
        AddEndowmentViewModel ToEndowmentViewModel(Endowment endowment);
        Task<Sons> ToEditSonsAsync(EditSonViewModel modelfull);
    }
}