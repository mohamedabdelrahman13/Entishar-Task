using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Users_CRUD.Interfaces;
using Users_CRUD.Models;
using Users_CRUD.Services;
using Users_CRUD.ViewModels;


namespace Users_CRUD.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserServices userService;

        public UserController(IUserServices userService)
        {
            this.userService = userService;
        }
        public async Task<IActionResult> ShowAllUsers()
        {
            var users = await userService.GetAllUsers();
            return View("ShowAllUsers" , users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            var user = await userService.GetUserByID(Id);
            return View("Edit" , user);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEdit(User userFromView)
        {
            if (ModelState.IsValid)
            {
                var userFromDB = await userService.GetUserByID(userFromView.Id);
                if (userFromDB != null) 
                {
                    userFromDB.UserFullName = userFromView.UserFullName;
                    userFromDB.Username = userFromView.Username;
                    userFromDB.Password = userFromView.Password;
                    userFromDB.DateOfBirth = userFromView.DateOfBirth;
                    userFromDB.IsActive = userFromView.IsActive;

                  await  userService.UpdateUser(userFromDB);
                    return RedirectToAction("ShowAllUsers" , "User");

                }

                return RedirectToAction("Error" , "Home");
            }
            return View("Edit", userFromView);
        }


        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewUser(UserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                await userService.AddNewUser(userVM);
                return RedirectToAction("ShowAllUsers", "User");
            }
            return View("Create", userVM);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await userService.DeleteUser(id);
            return RedirectToAction("ShowAllUsers");
        }

    }
}
