using System.Collections.Generic;
using PetStar.Entity;

namespace PetStar.Servise
{
    public interface IUsersServise
    {
        List<User> GetUsers();

        User GetUser(int id);
    }
}