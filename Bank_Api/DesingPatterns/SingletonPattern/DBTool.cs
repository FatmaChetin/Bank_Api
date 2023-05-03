using Bank_Api.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank_Api.DesingPatterns.SingletonPattern
{
    public class DBTool
    {
        DBTool() { }
        static MyContext _dbInstance;
        public static MyContext DbInstance 
        {
            get 
            {
                if (_dbInstance==null)
                {
                    _dbInstance = new MyContext();
                }
            return _dbInstance;
            }
        
        }
    }
}