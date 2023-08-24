using ProductDemo.ViewModels;

namespace ProductDemo.Repository.Interface
{
    public interface ILoginRepository
    {
        UserViewModel GetUserDetails(string userName, string password);
    }
}
