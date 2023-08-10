﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.Schema;

public class PaymentResponse
{
    public int PaymentId { get; set; }
    public int UserId { get; set; }
    public int BillId { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal PaymentAmount { get; set; }

}