using ProductDemo.Models;
using ProductDemo.Repository.Interface;
using ProductDemo.ViewModels;

namespace ProductDemo.Repository.BL
{
    public class LoginRepository : ILoginRepository
    {

        private readonly ProductDemoContext _context;

        public LoginRepository(ProductDemoContext context)
        {
            _context = context;
        }

        public UserViewModel GetUserDetails(string userName, string password)
        {

            var userData = (from us in _context.UserInfos
                               where  us.UserName == userName && us.Password == password
                               select new UserViewModel
                               {
                                   UserId = us.UserId,
                                   FirstName = us.FirstName,
                                   LastName = us.LastName
                               }).FirstOrDefault();

            return userData;

        }
    }
}
