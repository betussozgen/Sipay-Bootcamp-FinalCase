using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.Schema;

public class ApartmentResponse
{
    public int ApartmentId { get; set; }
    public string BlockNumber { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    public int FloorNumber { get; set; }
    public int ApartmentNumber { get; set; }
    public string OwnerOrTenant { get; set; }
}
