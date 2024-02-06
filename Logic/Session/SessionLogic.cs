using Data;
using Entities.Models;
using Logic.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Logic.Session
{
    public class SessionLogic : ISessionLogic
    {
        private readonly ModelContext _dataContext;
        private readonly IUserLogic _userLogic;
        private readonly IConfiguration _configuration;

        public SessionLogic(
            ModelContext dataContext,
            IUserLogic userLogic,
            IConfiguration configuration
        )
        {
            _dataContext = dataContext;
            _userLogic = userLogic;
            _configuration = configuration;
        }

        LoginResponse ISessionLogic.Login(LoginRequest login)
        {
            if (String.IsNullOrWhiteSpace(login.Username))
            {
                throw new ArgumentNullException(nameof(login.Username));
            }

            if (String.IsNullOrWhiteSpace(login.Password))
            {
                throw new ArgumentNullException(nameof(login.Password));
            }

            UserItem? user = _userLogic.GetForUsername(login.Username);
            if (user == null)
            {
                throw new ArgumentException("The user with that username does not exist.");
            }

            if (!PasswordHash.Verify(login.Password, user.PasswordHash))
            {
                throw new ArgumentException("Password incorrect.");
            }

            SessionItem session = new SessionItem();
            session.UserId = user.Id;
            //session.OpenedAt = DateTime.Now;

            _dataContext.Sessions.Add(session);
            _dataContext.SaveChanges();

            // Jwt? jwt = _configuration.GetSection("Jwt").Get<Jwt>();
            Jwt? jwt = (Jwt?)_configuration.GetSection("Jwt");
            


            if (jwt == null
                || string.IsNullOrEmpty(jwt.Key)
                || string.IsNullOrEmpty(jwt.Subject)
            )
            {
                throw new Exception("No JWT configuration.");
            }


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("userId", user.Id.ToString()),
                new Claim("sessionId", session.Id.ToString()),
                new Claim("role", user.Role ?? ""),
            };


            var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.UtcNow.Add(jwt.ValidityTime),
                signingCredentials: singIn
            );



            return new LoginResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
