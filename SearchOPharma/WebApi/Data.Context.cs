﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class searchopharmaEntities1 : DbContext
    {
        public searchopharmaEntities1()
            : base("name=searchopharmaEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DmnMedicine> DmnMedicines { get; set; }
        public virtual DbSet<MedicineSearch> MedicineSearches { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Pharmacy> Pharmacies { get; set; }
    }
}
