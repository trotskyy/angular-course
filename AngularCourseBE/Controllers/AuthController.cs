using AngularCourseBE.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace AngularCourseBE.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private static readonly SignInModel _user = new SignInModel
        {
            UserName = "username",
            Password = "password"
        };

        [HttpPost]
        [Route("sign-in")]
        public IHttpActionResult SignIn([FromBody] SignInModel signInModel)
        {
            if (signInModel == null)
            {
                return BadRequest($"{nameof(signInModel)} must be passed");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isValid = _user.Password == signInModel.Password
                && _user.UserName == signInModel.UserName;

            if (!isValid)
            {
                return BadRequest("Wrong username or password");
            }

            var user = new ClaimsIdentity(new[] 
                {
                    new Claim(ClaimTypes.Name, _user.UserName)
                },
                "ApplicationCookie"
            );

            IOwinContext owinContext = Request.GetOwinContext();
            owinContext.Authentication.SignIn(user);

            return Ok();

                // uncomment to use JWT Auth
            //var token = CreateToken(signInModel.UserName);
            //return Ok(token);
        }

        private string CreateToken(string userName)
        {
            DateTime issuedAt = DateTime.UtcNow;
            DateTime expires = issuedAt + JwtHelper.TokenLifetTime;

            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, userName)
            });


            SigningCredentials signingCredentials = JwtHelper.CreateCredentials();

            var token = tokenHandler
                .CreateJwtSecurityToken(
                    issuer: JwtHelper.Issuer,
                    audience: JwtHelper.Audience,
                    subject: claimsIdentity,
                    notBefore: issuedAt,
                    expires: expires,
                    signingCredentials: signingCredentials);

            string tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}

