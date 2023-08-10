using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.Schema;

public class DueRequest
{
    public int ApartmentId { get; set; }
    public string Month { get; set; }
    public string Year { get; set; }
    public decimal Amount { get; set; }
}
