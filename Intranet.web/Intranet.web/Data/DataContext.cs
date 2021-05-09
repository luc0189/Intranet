﻿using Intranet.web.Data.Entities;
using Intranet.web.Data.Entities.Activos;
using Intranet.web.Data.Entities.More;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Intranet.web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Area> Areas { get; set; }
        public DbSet<CajaCompensacion> CajaCompensacions { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<CreditEntities> CreditEntities { get; set; }
  
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Endowment> Endowments { get; set; }
        public DbSet<EndowmentType> EndowmentsTypes { get; set; }
        public DbSet<Eps> Eps { get; set; }
        public DbSet<Exams> Exams { get; set; }
        public DbSet<ExamsType> ExamsTypes { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Pension> Pensions { get; set; }
        public DbSet<PersonContact> PersonContacts { get; set; }
        public DbSet<PositionEmployee> PositionEmployees { get; set; }
        public DbSet<purchasing> Purchasings { get; set; }
        public DbSet<Recursoshumanos> Recursoshumanos { get; set; }
        public DbSet<SiteHeadquarters> SiteHeadquarters { get; set; }
        public DbSet<Sons> Sons { get; set; }
        public DbSet<Incapacity> Incapacities { get; set; }
        public DbSet<StoreLeader> StoreLeaders { get; set; }
        public DbSet<UserImages> UserImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Fabric> Fabrics { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<City> Cities { get; set; }


    }
}
