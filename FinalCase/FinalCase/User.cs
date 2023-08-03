using System.ComponentModel.DataAnnotations.Schema;

namespace FinalCase
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TcNo { get; set; }
        public string  Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool CarInfo { get; set; }

    }
}
