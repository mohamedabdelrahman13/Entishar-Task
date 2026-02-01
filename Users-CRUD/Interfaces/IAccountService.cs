using Users_CRUD.ViewModels;

namespace Users_CRUD.Interfaces
{
    public interface IAccountService
    {
        SignInMessage SignInCheck (LoginVM loginVM);
    }
}
