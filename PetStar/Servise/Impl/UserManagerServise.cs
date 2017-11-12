using System.Collections.Generic;
using PetStar.App_Data;
using PetStar.Entity;

namespace PetStar.Servise.Impl
{
    public class UserManagerServise: IUsersServise
    {
        public List<User> GetUsers()
        {
            var response = ApiHelper<User>.GetList("https://jsonplaceholder.typicode.com/users");

            foreach (var item in response)
            {
                var user = item;
                this.Encrypt(ref user);
            }
            return response;
        }

        public User GetUser(int id)
        {
            var response = ApiHelper<User>.Get("https://jsonplaceholder.typicode.com/users?id="+id);

            Encrypt(ref response);
            return response;
        }

        private void Encrypt(ref User user)
        {
            user.Email =  EncryptionHelper.Encrypt(user.Email);
        }
    }
}