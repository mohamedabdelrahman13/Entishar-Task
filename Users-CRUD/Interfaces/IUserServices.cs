using Users_CRUD.Models;
using Users_CRUD.ViewModels;

namespace Users_CRUD.Interfaces
{
    public interface IUserServices
    {
        Task AddNewUser(UserViewModel user);
        Task DeleteUser(string Id);
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserByID(string id);
        Task UpdateUser(User user);
    }
}