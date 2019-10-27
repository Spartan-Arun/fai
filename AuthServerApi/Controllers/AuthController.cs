using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using AuthserverAPi.data;
using System.Security.Claims;
namespace AuthserverAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginRepository Login;

        public AuthController(ILoginRepository _Login){
            this.Login = _Login;
        }
        [HttpPost("token")]
        public async Task<IActionResult> TokenGenartor(Login User){
                string Role = string.Empty;
                var flag = Login.UserLogin(User.UserName,User.Password,out Role);
                if(flag){
                //security key
                string key = "this_is_my_secured_token_key_for_JWT_token";

                //symmetric security key
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                //creds sigin
                var signInCredentials = new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256Signature);

                //adding user Role
                var claims = new []{
                    new Claim(Role,"")
                };

                //create token
                var jwtToken =  new JwtSecurityToken(
                    issuer:"abc.com",
                    audience:"readers",
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signInCredentials,
                    claims:claims
                );
                

                //return token
                return Ok(new{ token= new JwtSecurityTokenHandler().WriteToken(jwtToken),role=Role});
                }
                else{
                    return BadRequest("user id / password in-correct");
                }

        }
    }
}
