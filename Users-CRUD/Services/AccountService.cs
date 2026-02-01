using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Users_CRUD.Interfaces;
using Users_CRUD.Models;
using Users_CRUD.Repository.Interfaces;
using Users_CRUD.ViewModels;

namespace Users_CRUD.Services
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository<User> userRepo;

        public AccountService(IBaseRepository<User> UserRepo)
        {
            userRepo = UserRepo;
        }
        public SignInMessage SignInCheck(LoginVM loginVM)
        {
            if (loginVM == null) 
            {
                return new SignInMessage
                {
                    message = "invalid Username or password",
                    isSuccessful = false,
                };
            }
            //Check Username ..
            var user = userRepo.GetAll().SingleOrDefault(u =>u.Username == loginVM.Username);
            if (user == null)
            {
                return new SignInMessage
                {
                    message = "invalid Username or password",
                    isSuccessful = false,
                };
            }

            //Check account state ..
            if (user.IsActive == false)
            {
                return new SignInMessage
                {
                    message = "User is suspended",
                    isSuccessful = false,
                };
            }


            //Check password ..
            if (user.Password == null || user.Password != loginVM.Password)
            {
                return new SignInMessage
                {
                    message = "invalid Username or password",
                    isSuccessful = false,
                };
            }

           
            return new SignInMessage
            {
                message = "Signed In Successfully",
                isSuccessful = true,
            };
            
        }
    }
}
