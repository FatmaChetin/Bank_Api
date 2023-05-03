using Bank_Api.Models.Entities;
using Bank_Api.Models.Init;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bank_Api.Models.Context
{
    public class MyContext:DbContext
    {
        public MyContext():base("MyConnection") 
        {
            Database.SetInitializer(new MyInit());
        }
        public DbSet<CardInfo> Cards { get; set; }
    }
}