using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.Schema;

public class UserResponse
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool CarInfo { get; set; }
    public string RoleName { get; set; }
    public string ApartmentName { get; set; }

    // Ek olarak, kullanıcıya ait mesajların sayısını da almak için.
    public int MessageCount { get; set; }







}


