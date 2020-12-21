using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SEProject.MyBlogProject.Business.StringInfos;
using SEProject.MyBlogProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SEProject.MyBlogProject.Business.Utilities.JwtTool
{
    public class JwtManager : IJwtService
    {
        private readonly IOptions<JwtInfo> _jwtInfoOptions;

        public JwtManager(IOptions<JwtInfo> jwtInfoOptions)
        {
            _jwtInfoOptions = jwtInfoOptions;
        }

        public JwtToken GenerateJwt(AppUser appUser)
        {
            var jwtInfo = _jwtInfoOptions.Value;

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtInfo.SecurityKey));

            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: jwtInfo.Issuer,
                audience: jwtInfo.Audience,
                claims: SetClaims(appUser),
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(jwtInfo.Expires),
                signingCredentials: signingCredentials
                );

            JwtToken jwtToken = new JwtToken();
    
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            
            jwtToken.Token = handler.WriteToken(jwtSecurityToken);

            return jwtToken;
        }

        private List<Claim> SetClaims(AppUser appUser)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, appUser.UserName),
                new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString())
            };

            return claims;
        }
    }
}