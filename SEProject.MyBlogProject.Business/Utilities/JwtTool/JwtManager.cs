﻿using Microsoft.IdentityModel.Tokens;
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
        public JwtToken GenerateJwt(AppUser appUser)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey));

            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: JwtInfo.Issuer,
                audience: JwtInfo.Audience,
                claims: SetClaims(appUser),
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(JwtInfo.Expires),
                signingCredentials: signingCredentials
                );

            JwtToken jwtToken = new JwtToken();
    
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            
            jwtToken.Token = handler.WriteToken(jwtSecurityToken);

            return jwtToken;
        }

        private List<Claim> SetClaims(AppUser appUser)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));

            return claims;
        }
    }
}