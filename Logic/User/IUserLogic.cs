using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logic.User
{
    public interface IUserLogic
    {
        UserItem Create(UserCreateRequest user);
        UserItem? GetForId(decimal id);
        UserItem? GetForUsername(string username);
        List<UserItem> GetList();
        void Delete(decimal id);
    }
}
