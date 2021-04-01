using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public int PaymentId { get; set; }
        public int? UserId { get; set; }
        public string CardNameSurname { get; set; }
        public string CardNumber { get; set; }
        public string CardExpirationDateMonth { get; set; }
        public string CardExpirationDateYear { get; set; }
        public string CardCvv { get; set; }
        public decimal? CardLimit { get; set; }
    }
}
