﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PAUP_zgrade.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class zgrade_dbEntities1 : DbContext
    {
        public zgrade_dbEntities1()
            : base("name=zgrade_dbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<stanar> stanars { get; set; }
        public virtual DbSet<zgrada> zgradas { get; set; }
        public virtual DbSet<financije> financijes { get; set; }
        public virtual DbSet<obavijesti> obavijestis { get; set; }
        public virtual DbSet<poruka> porukas { get; set; }
    }
}
