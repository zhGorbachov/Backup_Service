using BusinessLayer.Models;

namespace BusinessLayer.Interfaces;

public interface IAuthorizationService
{
    public Task<bool> RegistrationAccountAsync(AccountModel accountModel);
    public Task<string> LoginAccountAsync(AccountModel accountModel);
}