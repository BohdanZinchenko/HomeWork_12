using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepsWebApp
{
    /// <summary>
    /// User Service (Save users in memory)
    /// Check Authenticate
    /// </summary>
    public class UserService : IUserService
    {
        private readonly List<User> _listOfUsers;

        /// <summary>
        /// Constructor of UserService
        /// </summary>
        public UserService()
        {
            _listOfUsers = new List<User>();
        }
        /// <summary>
        /// Authenticate user 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<User> Authenticate(string login, string password)
        {
            return _listOfUsers.FirstOrDefault(x => x.Login == login && x.Password == password);
        }

        /// <summary>
        /// Method to add users 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(User user)
        {
            _listOfUsers.Add(user);
            return true;
        }
    }
}