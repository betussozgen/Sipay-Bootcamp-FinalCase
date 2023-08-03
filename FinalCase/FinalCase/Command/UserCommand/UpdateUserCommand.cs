using FinalCase.DBOperations;

namespace FinalCase.Command.UserCommand
{
    public class UpdateUserCommand
    {

        private readonly SiteManagementDbContext _context;  

        public string UserTcNo { get; set; } 
        public UpdateUserModel Model { get; set; }

        
        public UpdateUserCommand(SiteManagementDbContext context)
        {
            _context = context; 
        }

        public void Handle()
        {

            var user = _context.Users.SingleOrDefault(x => x.TcNo == UserTcNo);
            if (user is null)
              throw new InvalidOperationException("Güncellenecek user bulunamadı");
            

            user.Name = Model.Name != default ? Model.Name : user.Name;
            user.Surname = Model.Surname != default ? Model.Surname : user.Surname;
            //user.Email = Model.Email != default ? Model.Email : user.Email;
            // user.PhoneNumber = Model.PhoneNumber != default ? Model.PhoneNumber : user.PhoneNumber;
            user.CarInfo = Model.CarInfo != default ? Model.CarInfo : user.CarInfo;
            // user.CarInfo = !string.IsNullOrEmpty(Model.CarInfo) ? Model.CarInfo : user.CarInfo;

            _context.SaveChanges();

           
        }


        public class UpdateUserModel
        {
           
            public string Name { get; set; }
            public string Surname { get; set; }
           // public string Email { get; set; }
            //public string PhoneNumber { get; set; }
            public bool CarInfo { get; set; }
        }
    }
}
