using FinalCase.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.Schema.Bill
{
    internal class BillResponse
    {
        public int BillId { get; set; }
        public int ApartmentId { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Amount { get; set; }
        public int BillStatus { get; set; }
        public Apartment Apartment { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
