﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Api.DBEntities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ABCEntities : DbContext
    {
        public ABCEntities()
            : base("name=ABCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<COLOR> COLOR { get; set; }
        public virtual DbSet<MODEL> MODEL { get; set; }
        public virtual DbSet<TYPE> TYPE { get; set; }
        public virtual DbSet<MODEL_DETAILS> MODEL_DETAILS { get; set; }
    }
}
