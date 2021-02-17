using System;
using System.ComponentModel.DataAnnotations;

namespace Profile
{
    public class Request
    {
        public int Id { get; set; }
        [Required, CreditCard]
        public string CreditCardNumber { get; set; }
        [Required]
        public string CardHolder { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }
        [MaxLength(3)]
        public string SecurityCode { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
