using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json.Serialization;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace BusinessLayer.Service;

public class JWTService : IJWTService
{
    private readonly IConfiguration _configuration;

    public JWTService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string CreateJWTToken(AccountModel accountModel)
    {
        var secretKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Key"]));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
        
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, accountModel.Login),
            new Claim(JwtRegisteredClaimNames.UniqueName, accountModel.Login),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N"))
        };

        var jwt = new JwtSecurityToken
        (
            issuer: _configuration["ISSUER"],
            audience: _configuration["AUDIENCE"],
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: signingCredentials            
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}