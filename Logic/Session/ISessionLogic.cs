using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Session
{
    public interface ISessionLogic
    {
        LoginResponse Login(LoginRequest login);
    }
}
