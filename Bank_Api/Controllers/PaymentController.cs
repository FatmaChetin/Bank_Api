using Bank_Api.DesingPatterns.SingletonPattern;
using Bank_Api.Models.Context;
using Bank_Api.Models.Entities;
using Bank_Api.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Bank_Api.Controllers
{
    public class PaymentController : ApiController
    {
        MyContext _db;
        public PaymentController()
        {
            _db = DBTool.DbInstance;
        }
        [HttpPost]
        public IHttpActionResult ReceivePayment(PaymentRequestModel item)
        {
            CardInfo ci = _db.Cards.FirstOrDefault(x => x.CardNumber == item.CardNumber && x.SecurityNumber == item.SecurityNumber && x.CardUserName == item.CardUserName && x.CardExpiryYear == item.CardExpiryYear && item.CardExpiryMonth == item.CardExpiryMonth);

            if (ci != null)
            {
                if (ci.CardExpiryYear < DateTime.Now.Year)
                {
                    return BadRequest("Expired Card");
                }
                else if (ci.CardExpiryYear == DateTime.Now.Year)
                {
                    if (ci.CardExpiryMonth < DateTime.Now.Month)
                    {

                        return BadRequest("Expired Card(Month)");
                    }

                    if (ci.Balance >= item.ShoppingPrice)
                    {
                        SetBalance(item, ci);
                        return Ok();
                    }
                    else
                    {
                        return BadRequest("Balance exceeded");
                    }
                }

                else if (ci.Balance >= item.ShoppingPrice)
                {
                    SetBalance(item, ci);
                    return Ok();
                }

                return BadRequest("Balance exceeded");

            }


            return BadRequest("Card Info Wrong");
        }
        private void SetBalance(PaymentRequestModel item, CardInfo ci)
        {
            ci.Balance -= item.ShoppingPrice;
            
            _db.SaveChanges();


        }
    }
}