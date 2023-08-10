using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.Schema;

public class DueResponse
{
    public int DuesId { get; set; }
    public int ApartmentId { get; set; }
    public string Month { get; set; }
    public int Year { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; }
}
