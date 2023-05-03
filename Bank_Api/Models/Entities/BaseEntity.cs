using Bank_Api.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank_Api.Models.Entities
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus DataStatus { get; set; }
        public BaseEntity()
        {
            DataStatus = DataStatus.Inserted;
            CreatedDate=DateTime.Now;
        }
    }
}