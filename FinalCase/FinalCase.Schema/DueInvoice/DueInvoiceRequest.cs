using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.Schema;

public class DueInvoiceRequest
{
    public int DuesInvoiceId { get; set; }
    public int ApartmentId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal MonthlyDues { get; set; }
    public decimal WaterBill { get; set; }
    public decimal ElectricityBill { get; set; }
    public decimal GasBill { get; set; }
}

