using Blog.API.DataTransferObject;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Blog.API.Authentication
{
    public static class TokenHandler
    {
        public static Token CreateToken(IConfiguration configuration)
        {
            Token token = new Token();
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));

            SigningCredentials credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            token.ExpirationTime = DateTime.Now.AddMinutes(Convert.ToInt16(configuration["Token:ExpirationTime"]));
            JwtSecurityToken jwtToken = new(
                issuer: configuration["Token:Issuer"],
                audience: configuration["Token.Audience"],
                expires: token.ExpirationTime,
                notBefore: DateTime.Now,
                signingCredentials: credential
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = tokenHandler.WriteToken(jwtToken);
            return token;
        }
    }
}
