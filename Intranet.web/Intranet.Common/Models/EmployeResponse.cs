using System;
using System.Collections.Generic;
using System.Text;

namespace Intranet.Common.Models
{
    public class EmployeResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Movil { get; set; }
        public bool Activo{ get; set; }
        public  ICollection<ExamsResponse> ExamsResponses { get; set; }
        public  ICollection<EndowmentResponse> EndowmentResponses { get; set; }
        public  ICollection<UserImageResponse> UserImageResponses { get; set; }
        public  ICollection<PersonCResponse> PersonCResponses { get; set; }
        public  ICollection<SonsResponse> SonsResponses { get; set; }
        public  ICollection<CreditResponse> CreditResponses { get; set; }
    }
}
