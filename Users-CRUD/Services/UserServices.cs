using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Users_CRUD.Interfaces;
using Users_CRUD.Models;
using Users_CRUD.Repository.Interfaces;
using Users_CRUD.ViewModels;

namespace Users_CRUD.Services
{
    public class UserServices : IUserServices
    {
        private readonly IBaseRepository<User> userRepo;

        public UserServices(IBaseRepository<User> userRepo)
        {
            this.userRepo = userRepo;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await userRepo.GetAll().Where(u=>u.IsActive == true).ToListAsync();
            return users;
        }

        public async Task<User?> GetUserByID(string id)
        {
            var user = await userRepo.GetByID(id);
            if (user == null)
                return null;
            return user;
        }

        public async Task UpdateUser(User user)
        {
            userRepo.Update(user);
            await userRepo.SaveAsync();
        }

        public async Task DeleteUser(string Id)
        {
            var user = await userRepo.GetByID(Id);
            if (user == null)
                return;

            user.IsActive = false;
            await UpdateUser(user);
            await userRepo.SaveAsync();
        }

        public async Task AddNewUser(UserViewModel userVM)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                Username = userVM.Username,
                Password = userVM.Password,
                DateOfBirth = userVM.DateOfBirth,
                UserFullName = userVM.UserFullName,
                IsActive = true
            };

            await userRepo.AddAsync(newUser);
            await userRepo.SaveAsync();
        }

    }
}
