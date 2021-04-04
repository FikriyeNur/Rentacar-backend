using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Concrete
{
    public class CreditCard : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string CardNameSurname { get; set; }
        public string CardNumber { get; set; }
        public string CardExpirationMonth { get; set; }
        public string CardExpirationYear { get; set; }
        public string CardSecurityNumber { get; set; }
        public decimal? CardLimit { get; set; }
    }
}
