using BusinessLayer.Models;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer.Interfaces;

public interface IJWTService
{
    public string CreateJWTToken(AccountModel accountModel);
}