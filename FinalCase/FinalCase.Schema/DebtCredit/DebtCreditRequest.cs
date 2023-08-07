using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.Schema;


public class DebtCreditRequest
{
    public int UserId { get; set; }
    public string Month { get; set; }
    public decimal DebtAmount { get; set; }
    public decimal CreditAmount { get; set; }
}

