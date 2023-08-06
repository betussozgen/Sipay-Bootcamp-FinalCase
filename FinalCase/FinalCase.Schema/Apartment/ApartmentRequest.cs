using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.Schema;

public class ApartmentRequest
{
    public string Block { get; set; }
    public bool IsOccupied { get; set; }
    public string Type { get; set; }
    public int FloorNo { get; set; }
    public int ApartmentNo { get; set; }
    public bool IsOwner { get; set; }
}

