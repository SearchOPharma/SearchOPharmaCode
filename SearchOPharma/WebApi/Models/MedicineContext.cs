﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class MedicineContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MedicineContext() : base("name=MedicineContext")
        {
        }

        public System.Data.Entity.DbSet<WebApi.Models.Medicine> Medicines { get; set; }
        public System.Data.Entity.DbSet<WebApi.Models.MedicineSearch> MedicineSearch { get; set; }
        public System.Data.Entity.DbSet<WebApi.Models.Notification> Notification { get; set; }
    }
}
