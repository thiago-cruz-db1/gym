using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GymApi.Domain;
using Microsoft.IdentityModel.Tokens;

namespace GymApi.UseCases;

public class GenerateTokenUseCase
{
    public string Create(User user)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("id", user.Id),
            new Claim("email", user.Email),
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bjklsbjlf84165jbsjkfbksbj!@#$FFAEA|ERW"));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(expires: DateTime.Now.AddMinutes(5), claims: claims, signingCredentials: signingCredentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}