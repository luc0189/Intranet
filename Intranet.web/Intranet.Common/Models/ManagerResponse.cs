using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intranet.Common.Models
{
    public class ManagerResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Document { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Movil { get; set; }
        public bool Activo { get; set; }
        public ICollection<ExamsResponse> Exams { get; set; }
        public ICollection<EndowmentResponse> Endowment { get; set; }
        public ICollection<UserImageResponse> UserImage { get; set; }
        public ICollection<PersonCResponse> PersonC { get; set; }
        public ICollection<SonsResponse> Sons { get; set; }
        public ICollection<CreditResponse> Credits { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string FirstImage => UserImage == null || UserImage.Count == 0
                ? "https://cdn3.iconfinder.com/data/icons/wpzoom-developer-icon-set/500/88-512.png"
                : UserImage.FirstOrDefault().ImageUrl;
    }
}
