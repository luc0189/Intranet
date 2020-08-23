using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.web.Data.Entities
{
    public class purchasing
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Area Area { get; set; }
        public Eps Eps { get; set; }

        public PositionEmployee PositionEmployee { get; set; }
        public Pension Pension { get; set; }
        public CajaCompensacion cajaCompensacion { get; set; }
        public ICollection<UserImages> UserImages { get; set; }
        public ICollection<Credit> Credits { get; set; }
        public ICollection<Sons> Sons { get; set; }
        public ICollection<Endowment> Endowments { get; set; }
        public ICollection<Exams> Exams { get; set; }
        public ICollection<PersonContact> PersonContacts { get; set; }
    }
}
